using APIClient.Infrastructure.Data.Contexts;
using APIClient.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
 
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using Serilog;
 
using System.Text;
 
using APIClient.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using APIClient.Infrastructure;
using APIClient.Infrastructure.Data.Entities;
 
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Net5.Deployment.API.Infrastructure.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace APIClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddControllers().AddJsonOptions(x =>
            //    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            //services.AddControllers().AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            //});

            //services.AddControllers().AddJsonOptions(j =>
            //{
            //    var stockConverterOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            //    stockConverterOptions.Converters.Add(new JsonStringEnumConverter());
            //    var stockConverter = new StocksConverter(stockConverterOptions);

            //    j.JsonSerializerOptions.Converters.Add(stockConverter);
            //});
           
            services.AddControllers();
            //services.AddControllers()
            // .AddJsonOptions(o => o.JsonSerializerOptions
            //     .ReferenceHandler = ReferenceHandler.Preserve);

            var jwtTokenConfig = Configuration.GetSection("jwtTokenConfig").Get<JwtTokenConfig>();
            services.AddSingleton(jwtTokenConfig);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });
          
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIClient", Version = "v1" });
                c.SchemaFilter<FieldsSchemaFilter>();

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });
            });

            string connectionString = Configuration.GetConnectionString("AsigConnectionString");
            services.AddDbContext<AsignacionContext>(o => o.UseSqlServer(connectionString));
            services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
            services.AddHostedService<JwtRefreshTokenCache>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IAsignacionRepository<Asignacion>, AsignacionRepository>();
            services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<ICargaSigaRepository, CargaSigaRepository>();
            services.AddScoped<IAplicativoRepository, AplicativoRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ISquadRepository, SquadRepository>();
            services.AddScoped<ITribucoeRepository, TribucoeRepository>();
            services.AddHealthChecks()
            .AddDbContextCheck<AsignacionContext>()
            .AddUrlGroup(new Uri("http://localhost:4200"), name: "Google Inc.")
            .AddCheck<CustomHealthCheck>(name: "New Custom Check")
            .AddCheck("CatalogDB-Check", new SqlConnectionHealthCheck(connectionString), HealthStatus.Unhealthy, new string[] { "catalogdb" });

            services.AddHealthChecksUI()
                .AddInMemoryStorage();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
            });

            // REGISTRAMOS SWAGGER COMO SERVICIO
             

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AsignacionContext context)
        {
            app.UseCors(options => {

                
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
            }
                );
            //app.UseCors(options =>
            //{
            //    options.WithOrigins("h ttp://localhost:4200/");
            //    options.AllowAnyMethod();
            //    options.AllowAnyHeader();
            //    options.AllowAnyOrigin()
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIClient v1"));
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            context.EnsureSeeDataForContext();

            app.UseSerilogRequestLogging();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHealthChecks("/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(config => config.UIPath = "/health-ui");


        }



        public class FieldsSchemaFilter : ISchemaFilter
        {
            public void Apply(OpenApiSchema schema, SchemaFilterContext context)
            {
                var fields = context.Type.GetFields();

                if (fields == null) return;
                if (fields.Length == 0) return;

                foreach (var field in fields)
                {
                    schema.Properties[field.Name] = new OpenApiSchema
                    {
                        // this should be mapped to an OpenApiSchema type
                        Type = field.FieldType.Name
                    };
                }
            }
        }

    }
}
