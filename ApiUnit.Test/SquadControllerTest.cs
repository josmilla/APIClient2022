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
    public class SquadControllerTests
    {


        private DbContextOptions<AsignacionContext> _dbContextOptions = new DbContextOptionsBuilder<AsignacionContext>()
        .UseInMemoryDatabase(databaseName: "MempryDb")
        .EnableSensitiveDataLogging()
        .Options;

        private Mock<ILogger<SquadController>> _logger;
         private SquadRepository _squadRepository;
        private SquadController _controller;


        

        [OneTimeSetUp]
        public void Setup()
        {


             
            SeedDb();
            _squadRepository = new SquadRepository(new AsignacionContext(_dbContextOptions));
            _logger = new Mock<ILogger<SquadController>>();
            _controller = new SquadController(_squadRepository, _logger.Object);
           
          
        }

        [Test]
        public async Task GetSquadAsync()
        {
            var result = await _controller.GetSquadAsync();
            var aplicativo = result.As<IEnumerable<Squad>>();
            aplicativo.Should().NotBeNullOrEmpty();
            aplicativo.Count().Should().Be(5);
            Assert.AreEqual(5, result.Count());

        }

       

        [Test]

       // public async Task<ActionResult<Aplicativo>> GetAplicativoByIdAsync(int id)
        public async Task GetSquadByIdAsync()
        {

            var actionResult = await _controller.GetSquadByIdAsync(2);
            var resultado = actionResult.Value;
            Assert.IsTrue(true);
            resultado.Should().NotBeNull();
            resultado.CodSquad.Should().Be("4051");
             
        }

        private void SeedDb()
        {
            using var context = new AsignacionContext(_dbContextOptions);

            List<Squad> squads = new List<Squad>
            {
                new Squad{ IdSquad =1,CodSquad="4050",NombreSquad="SQUAD FINANZAS",IdTribucoe=1, FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true},
                new Squad{ IdSquad =2,CodSquad="4051",NombreSquad="SQUAD PRUEBAS",IdTribucoe=2, FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true },
                new Squad{ IdSquad =3,CodSquad="4052",NombreSquad="SQUAD DEMO",IdTribucoe=3, FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO" , FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true},
                new Squad{ IdSquad =4,CodSquad="4053",NombreSquad="SQUAD PERSONAS",IdTribucoe=4,FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true },
                new Squad{ IdSquad =5,CodSquad="4054",NombreSquad="SQUAD FERPER",IdTribucoe=5, FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true }
            };

            context.Squad.AddRange(squads);
            context.SaveChanges();
        }
    }
}