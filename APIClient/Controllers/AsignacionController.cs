using Microsoft.AspNetCore.Mvc;
using APIClient.Infrastructure.Data.Entities;
using APIClient.Infrastructure.Data.Repositories;
using APIClient.Infrastructure.Specification;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
 

namespace APIClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AsignacionController : ControllerBase
    {
        private readonly IAsignacionRepository<Asignacion> _asignacionRepository;
        private readonly ILogger<AsignacionController> _logger;
        public AsignacionController(IAsignacionRepository<Asignacion> asignacionRepository, ILogger<AsignacionController> logger)
        {
           
            _asignacionRepository = asignacionRepository;
            _logger = logger;
        }

        // GET: api/<AsignacionController>
        [HttpGet]
       
         public async Task<IEnumerable<Asignacion>> GetAsignacionAsync()
        {
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
            return await _asignacionRepository.GetAsignacionAsync();
        }
               

        [HttpGet("{id}", Name = "GetAsignacionAsync")]
       
        public async Task<ActionResult<Asignacion>> GetAsignacionByIdAsync(int id)
        {
            //   var clsasignacion = await _asignacionRepository.GetAsignacionByIdAsync(id);

            // var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
          //  return await _asignacionRepository.GetAsignacionByIdAsync(id);

            var clsasignacion = await _asignacionRepository.GetAsignacionByIdAsync(id);

            if (clsasignacion == null)
            {
                return NotFound();
            }

            return clsasignacion;
        }

        //public async Task<Asignacion> GetSumaParticipacion

        [HttpGet("/asignacion/{matriculaSuma}", Name = "GetSumaParticipacion")]
        public async Task<ActionResult<Asignacion>> GetSumaParticipacion (string matriculaSuma)
        {
            //   var clsasignacion = await _asignacionRepository.GetAsignacionByIdAsync(id);
            //var userName = User.Identity?.Name;
            // _logger.LogInformation($"User [{userName}] is viewing values.");
            return await _asignacionRepository.GetSumaParticipacion(matriculaSuma);

          
        }

        [HttpGet("/chapter/{MatriculaChapter}", Name = "GetAsignacionMatriculaAsync")]
        
        public async Task<IEnumerable<Asignacion>> GetAsignacionMatriculaChapterByIdAsync(string MatriculaChapter)
        {
            // var userName = User.Identity?.Name;
            // _logger.LogInformation($"User [{userName}] is viewing values.");
            return await _asignacionRepository.GetAsignacionMatriculaChapterByIdAsync(MatriculaChapter);
            
        }

        [HttpGet("/usuario/{Usuario}", Name = "GetAsignacionUsuarioAsync")]
        public async Task<IEnumerable<Asignacion>> GetAsignacionMatriculaUsuarioByIdAsync(string Usuario)
        {
             //var userName = User.Identity?.Name;
             //_logger.LogInformation($"User [{userName}] is viewing values.");
            return await _asignacionRepository.GetAsignacionMatriculausuarioByIdAsync(Usuario);

        }

        [HttpGet("specify")]
        public IActionResult Specify()
        {
            //var specification = new DeveloperWithAddressSpecification(3);
           var specification = new DeveloperByIncomeSpecification();
            var developers = _asignacionRepository.FindWithSpecificationPattern(specification);
            return Ok(developers);
        }

        [HttpPost]
        //[Route("api/Asignacion/Create")]
        public async Task<IActionResult> PostAsync([FromBody] Asignacion asignacion)
        {
           // var userName = User.Identity?.Name;
           // _logger.LogInformation($"User [{userName}] is viewing values.");
            var result = await _asignacionRepository.InsertAsync(asignacion);
            return CreatedAtRoute("GetAsignacionAsync", new { id = result.IdPorcentajeAsignacion }, result);
        }

        // PUT api/<AsignacionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Asignacion asignacion)
        {
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
            var result = await _asignacionRepository.UpdateAsync(id, asignacion);
            return Ok(result);
            //return RedirectToAction(nameof(Index));
        }

        // DELETE api/<AsignacionController>/5
        [HttpDelete("{id}")]
        //[Route("api/Asignacion/Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
            var result = await _asignacionRepository.DeleteAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
