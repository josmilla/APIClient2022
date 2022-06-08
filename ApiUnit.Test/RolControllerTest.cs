using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using APIClient.Controllers;
using APIClient.Infrastructure.Data.Contexts;
using APIClient.Infrastructure.Data.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIClient.Infrastructure.Data.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
 

namespace ApiUnit.Test
{
    [TestFixture]
    public class RolControllerTests
    {


        private DbContextOptions<AsignacionContext> _dbContextOptions = new DbContextOptionsBuilder<AsignacionContext>()
        .UseInMemoryDatabase(databaseName: "MempryDb")
        .EnableSensitiveDataLogging()
        .Options;

        private Mock<ILogger<RolController>> _logger;
         private RolRepository _rolRepository;
        private RolController _controller;


        

        [OneTimeSetUp]
        public void Setup()
        {


             
            SeedDb();
            _rolRepository = new RolRepository(new AsignacionContext(_dbContextOptions));
            _logger = new Mock<ILogger<RolController>>();
            _controller = new RolController(_rolRepository, _logger.Object);
           
          
        }

        [Test]
        public async Task GetRolAsync()
        {
            var actionResult = await _controller.GetRolAsync();
            var valor = actionResult.As<IEnumerable<Rol>>();
            valor.Should().NotBeNullOrEmpty();
            valor.Count().Should().Be(5);
            Assert.AreEqual(5, actionResult.Count());

        }

       

        [Test]

       // public async Task<ActionResult<Aplicativo>> GetAplicativoByIdAsync(int id)
        public async Task GetRolByIdAsync()
        {

            var actionResult = await _controller.GetRolByIdAsync(1);
            var resultado = actionResult.Value;
            Assert.IsTrue(true);
            resultado.Should().NotBeNull();
            resultado.SqRol.Should().Be("QA");
             
        }

        private void SeedDb()
        {
            using var context = new AsignacionContext(_dbContextOptions);

            List<Rol> roles = new List<Rol>
            {
                new Rol{ IdRol =1,SqRol="QA",FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true},
                new Rol{ IdRol =2,SqRol="DEVELOVER",FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true },
                new Rol{ IdRol =3,SqRol="PO",FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO" , FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true},
                new Rol{ IdRol =4,SqRol="CL",FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true },
                new Rol{ IdRol =5,SqRol="TEACH LEADER",FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true }
            };

            context.Rol.AddRange(roles);
            context.SaveChanges();
        }
    }
}