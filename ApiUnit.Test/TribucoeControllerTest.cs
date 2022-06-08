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
    public class TribucoeControllerTests
    {


        private DbContextOptions<AsignacionContext> _dbContextOptions = new DbContextOptionsBuilder<AsignacionContext>()
        .UseInMemoryDatabase(databaseName: "MempryDb")
        .EnableSensitiveDataLogging()
        .Options;

        private Mock<ILogger<TribuCoeController>> _logger;
         private TribucoeRepository _tribucoeRepository;
        private TribuCoeController _controller;


        

        [OneTimeSetUp]
        public void Setup()
        {


             
            SeedDb();
            _tribucoeRepository = new TribucoeRepository(new AsignacionContext(_dbContextOptions));
            _logger = new Mock<ILogger<TribuCoeController>>();
            _controller = new TribuCoeController(_tribucoeRepository, _logger.Object);
           // _controller = new AplicativoController(_aplicativoRepository, _logger);
          
        }

        [Test]
        public async Task GetTribucoeAsync()
        {
            var result = await _controller.GetTribucoeAsync();
            var valor = result.As<IEnumerable<Tribucoe>>();
            valor.Should().NotBeNullOrEmpty();
            valor.Count().Should().Be(5);
            Assert.AreEqual(5, result.Count());

            //  _logger.Verify(logger => logger.LogError(It.IsAny<string>()), Times.Once);
        }

       

        [Test]

       // public async Task<ActionResult<Aplicativo>> GetAplicativoByIdAsync(int id)
        public async Task GetTribucoeByIdAsync()
        {

            var actionResult = await _controller.GetTribucoeByIdAsync(2);
            var valor = actionResult.Value;
            Assert.IsTrue(true);
            valor.Should().NotBeNull();
            valor.CodTribucoe.Should().Be("2050101");
             
        }

        private void SeedDb()
        {
            using var context = new AsignacionContext(_dbContextOptions);

            List<Tribucoe> tribucoes = new List<Tribucoe>
            {
                new Tribucoe{ IdTribucoe =1,CodTribucoe="2050100",NombreTribucoe="TRIBU CANALES",CategoriaTribucoe="", FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true},
                new Tribucoe{ IdTribucoe =2,CodTribucoe="2050101",NombreTribucoe="TRIBU DEMO",CategoriaTribucoe="", FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true },
                new Tribucoe{ IdTribucoe =3,CodTribucoe="2050102",NombreTribucoe="TRIBU STAFF",CategoriaTribucoe="", FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO" , FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true},
                new Tribucoe{ IdTribucoe =4,CodTribucoe="2050103",NombreTribucoe="TRIBU HOSTING",CategoriaTribucoe="",FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true },
                new Tribucoe{ IdTribucoe =5,CodTribucoe="2050104",NombreTribucoe="TRIBU DATA",CategoriaTribucoe="", FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true }
            };

            context.Tribucoe.AddRange(tribucoes);
            context.SaveChanges();
        }
    }
}