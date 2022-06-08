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
    public class AsignacionControllerTests
    {


        private DbContextOptions<AsignacionContext> _dbContextOptions = new DbContextOptionsBuilder<AsignacionContext>()
        .UseInMemoryDatabase(databaseName: "MempryDb")
        .EnableSensitiveDataLogging()
        .Options;

        private Mock<ILogger<AsignacionController>> _logger;
         private AsignacionRepository _asignacionRepository;
        private AsignacionController _controller;


        

        [OneTimeSetUp]
        public void Setup()
        {


             
            SeedDb();
            _asignacionRepository = new AsignacionRepository(new AsignacionContext(_dbContextOptions));
            _logger = new Mock<ILogger<AsignacionController>>();
            _controller = new AsignacionController(_asignacionRepository, _logger.Object);
           
          
        }

        [Test]
        public async Task GetAsignacionAsync()
        {
            var actionResult = await _controller.GetAsignacionAsync();
            var valor = actionResult.As<IEnumerable<Asignacion>>();
            valor.Should().NotBeNullOrEmpty();
            valor.Count().Should().Be(5);
            Assert.AreEqual(5, actionResult.Count());

        }

       

        [Test]

       // public async Task<ActionResult<Aplicativo>> GetAplicativoByIdAsync(int id)
        public async Task GetAsignacionByIdAsync()
        {

            var actionResult = await _controller.GetAsignacionByIdAsync(1);
            var resultado = actionResult.Value;
            Assert.IsTrue(true);
            resultado.Should().NotBeNull();
            resultado.MatriculaUsuario.Should().Be("0S000123");
             
        }

        private void SeedDb()
        {
            using var context = new AsignacionContext(_dbContextOptions);

            List<Asignacion> asignars = new List<Asignacion>
            {
                new Asignacion{ IdPorcentajeAsignacion=1, MatriculaUsuario="0S000123",ApellidopaternoUsuario="PEREZ",ApellidomaternoUsuario="FLORES",NombreUsuario="JUAN",NombreChapter="",MatriculaChapter="U100200",IdRol =1,Especialidad="TESTER",IdSquad=1,IdAplicativo=1,Porcentaje=100,Comentarios="",FechaPeriodoAprobado="042022",FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true,EstadoRegistro=true},
                new Asignacion{ IdPorcentajeAsignacion=2,MatriculaUsuario="0S000124",ApellidopaternoUsuario="TERRA",ApellidomaternoUsuario="PERU",NombreUsuario="MARIA",NombreChapter="",MatriculaChapter="U100201",IdRol =2,Especialidad="DEVELOPER",IdSquad=2,IdAplicativo=2,Porcentaje=100,Comentarios="",FechaPeriodoAprobado="042022",FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true,EstadoRegistro=true },
                new Asignacion{ IdPorcentajeAsignacion=3,MatriculaUsuario="0S000125",ApellidopaternoUsuario="DEFD",ApellidomaternoUsuario="ROSALES",NombreUsuario="MEY",NombreChapter="",MatriculaChapter="U100202",IdRol =3,Especialidad="TESTER",IdSquad=3,IdAplicativo=3,Porcentaje=100,Comentarios="",FechaPeriodoAprobado="042022",FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true,EstadoRegistro=true},
                new Asignacion{IdPorcentajeAsignacion=4, MatriculaUsuario="0S000126",ApellidopaternoUsuario="ERTES",ApellidomaternoUsuario="JUNA",NombreUsuario="TERESA",NombreChapter="",MatriculaChapter="U100203",IdRol =4,Especialidad="DEVELOPER",IdSquad=4,IdAplicativo=4,Porcentaje=100,Comentarios="",FechaPeriodoAprobado="042022",FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true,EstadoRegistro=true },
                new Asignacion{ IdPorcentajeAsignacion=5,MatriculaUsuario="0S000127",ApellidopaternoUsuario="RTTYA",ApellidomaternoUsuario="ERTA",NombreUsuario="WALTER",NombreChapter="",MatriculaChapter="U100204",IdRol =5,Especialidad="TESTER",IdSquad=5,IdAplicativo=5,Porcentaje=100,Comentarios="",FechaPeriodoAprobado="042022",FechaRegistro=DateTime.Now,UsuarioRegistro="APXPRO", FechaModificacion=DateTime.Now,UsuarioModificacion="APXPRO",Estado=true,EstadoRegistro=true }
            };

            context.Asignacion.AddRange(asignars);
            context.SaveChanges();
        }
    }
}