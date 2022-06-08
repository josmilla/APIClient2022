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
using Microsoft.AspNetCore.Mvc;

namespace ApiUnit.Test
{
    [TestFixture]
    public class AplicativoControllerTests
    {


        private DbContextOptions<AsignacionContext> _dbContextOptions = new DbContextOptionsBuilder<AsignacionContext>()
        .UseInMemoryDatabase(databaseName: "MempryDb")
        .EnableSensitiveDataLogging()
        .Options;

        private Mock<ILogger<AplicativoController>> _logger;
         
        //private ILogger<AplicativoController> _logger;
        private AplicativoRepository _aplicativoRepository;
        private AplicativoController _controller;


        

        [OneTimeSetUp]
        public void Setup()
        {


             
            SeedDb();
            _aplicativoRepository = new AplicativoRepository(new AsignacionContext(_dbContextOptions));
            _logger = new Mock<ILogger<AplicativoController>>();
            _controller = new AplicativoController(_aplicativoRepository,_logger.Object);
           // _controller = new AplicativoController(_aplicativoRepository, _logger);
          
        }

        [Test]
        public async Task GetAplicativoAsync()
        {
            var result = await _controller.GetAplicativoAsync();
            var aplicativo = result.As<IEnumerable<Aplicativo>>();
            aplicativo.Should().NotBeNullOrEmpty();
            aplicativo.Count().Should().Be(5);
            Assert.AreEqual(5, result.Count());

        }

       [Test]

    
        public async Task GetAplicativoByIdAsync()
        {

            var actionResult = await _controller.GetAplicativoByIdAsync(2);
            var aplicativo = actionResult.Value;
            Assert.IsTrue(true);
            aplicativo.Should().NotBeNull();
            aplicativo.CodAplicativo.Should().Be("E150");
             
        }

        private void SeedDb()
        {
            using var context = new AsignacionContext(_dbContextOptions);

            List<Aplicativo> aplicativos = new List<Aplicativo>
            {
                new Aplicativo{ IdAplicativo =1,CodAplicativo="E243",NombreAplicativo="",BiddingblockAplicativo="",EstadoAplicativo="Vigente", FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true},
                new Aplicativo{ IdAplicativo =2,CodAplicativo="E150",NombreAplicativo="",BiddingblockAplicativo="",EstadoAplicativo="Vigente", FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true },
                new Aplicativo{ IdAplicativo =3,CodAplicativo="E556",NombreAplicativo="",BiddingblockAplicativo="",EstadoAplicativo="Vigente", FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO" , FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true},
                new Aplicativo{ IdAplicativo =4,CodAplicativo="PNOK",NombreAplicativo="",BiddingblockAplicativo="",EstadoAplicativo="Vigente", FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true },
                new Aplicativo{ IdAplicativo =5,CodAplicativo="TTRA",NombreAplicativo="",BiddingblockAplicativo="",EstadoAplicativo="Vigente", FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true }
            };

            context.Aplicativo.AddRange(aplicativos);
            context.SaveChanges();
        }
    }
}