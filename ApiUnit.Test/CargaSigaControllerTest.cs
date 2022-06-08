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
    public class CargaSigaControllerTests
    {


        private DbContextOptions<AsignacionContext> _dbContextOptions = new DbContextOptionsBuilder<AsignacionContext>()
        .UseInMemoryDatabase(databaseName: "MempryDb")
        .EnableSensitiveDataLogging()
        .Options;

        private Mock<ILogger<CargaSigaController>> _logger;
         private CargaSigaRepository _cargasigaRepository;
        private CargaSigaController _controller;


        

        [OneTimeSetUp]
        public void Setup()
        {


             
            SeedDb();
            _cargasigaRepository = new CargaSigaRepository(new AsignacionContext(_dbContextOptions));
            _logger = new Mock<ILogger<CargaSigaController>>();
            _controller = new CargaSigaController(_cargasigaRepository, _logger.Object);
           
          
        }

        [Test]
        public async Task GetCargaSigaAsync()
        {
            var actionResult = await _controller.GetCargaSigaAsync();
            var valor = actionResult.As<IEnumerable<CargaSiga>>();
            valor.Should().NotBeNullOrEmpty();
            valor.Count().Should().Be(5);
            Assert.AreEqual(5, actionResult.Count());

        }

       

        [Test]

       // public async Task<ActionResult<Aplicativo>> GetAplicativoByIdAsync(int id)
        public async Task GetCargaSigaByIdAsync()
        {

            var actionResult = await _controller.GetCargaSigaByIdAsync(1);
            var resultado = actionResult.Value;
            Assert.IsTrue(true);
            resultado.Should().NotBeNull();
            resultado.MatriculaUsuario.Should().Be("0S000123");
             
        }

        private void SeedDb()
        {
            using var context = new AsignacionContext(_dbContextOptions);

            List<CargaSiga> cargasiga = new List<CargaSiga>
            {
                new CargaSiga{ IdCarga=1, NombreCal ="PATRICIO JUNA",MatriculaCal="U300100",NombreChapter="PEDRO DWAS",MatriculaChapter="0S001200",TipoPreper="",Empresa="TCS",MatriculaUsuario="0S000123",ApellidopaternoUsuario="PEREZ",ApellidomaternoUsuario="FLORES",NombreUsuario="JUAN",RolInsourcing="",Especialidad="",ChapterUo ="",Asignacion=100,FechaPeriodo="042022",FechaCarga=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true },
                new CargaSiga{ IdCarga=2,NombreCal ="PATRICIO JUNA",MatriculaCal="U300100",NombreChapter="PEDRO DWAS",MatriculaChapter="0S001200",TipoPreper="",Empresa="TCS",MatriculaUsuario="0S000124",ApellidopaternoUsuario="TERRA",ApellidomaternoUsuario="PERU",NombreUsuario="MARIA",RolInsourcing="",Especialidad="",ChapterUo ="",Asignacion=100,FechaPeriodo="042022",FechaCarga=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true  },
                new CargaSiga{ IdCarga=3,NombreCal ="PATRICIO JUNA",MatriculaCal="U300100",NombreChapter="RICARGO GOMEZ",MatriculaChapter="0S001201",TipoPreper="",Empresa="TCS",MatriculaUsuario="0S000125",ApellidopaternoUsuario="DEFD",ApellidomaternoUsuario="ROSALES",NombreUsuario="MEY",RolInsourcing="",Especialidad="",ChapterUo ="",Asignacion=100,FechaPeriodo="042022",FechaCarga=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true },
                new CargaSiga{ IdCarga=4,NombreCal ="PATRICIO JUNA", MatriculaCal="U300100",NombreChapter="RICARDO GOMEZ",MatriculaChapter="0S001201",TipoPreper="",Empresa="TCS",MatriculaUsuario="0S000126",ApellidopaternoUsuario="ERTES",ApellidomaternoUsuario="JUNA",NombreUsuario="TERESA",RolInsourcing="",Especialidad="",ChapterUo ="",Asignacion=100,FechaPeriodo="042022",FechaCarga=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true  },
                new CargaSiga{ IdCarga=5,NombreCal ="PATRICIO JUNA",MatriculaCal="U300100",NombreChapter="RICARDO GOMERZ",MatriculaChapter="0S001201",TipoPreper="",Empresa="TCS",MatriculaUsuario="0S000127",ApellidopaternoUsuario="RTTYA",ApellidomaternoUsuario="ERTA",NombreUsuario="WALTER",RolInsourcing="",Especialidad="",ChapterUo ="",Asignacion=100,FechaPeriodo="042022",FechaCarga=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true  }
            };

            context.CargaSiga.AddRange(cargasiga);
            context.SaveChanges();
        }
    }
}