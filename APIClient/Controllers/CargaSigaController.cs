using Microsoft.AspNetCore.Mvc;
using APIClient.Infrastructure.Data.Entities;
using APIClient.Infrastructure.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace APIClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CargaSigaController : ControllerBase
    {
        private readonly ICargaSigaRepository _cargasigaRepository;
        private readonly ILogger<CargaSigaController> _logger;
        public CargaSigaController(ICargaSigaRepository cargasigaRepository, ILogger<CargaSigaController> logger)
        {
            _cargasigaRepository = cargasigaRepository;
            _logger = logger;
        }

        // GET: api/<AsignacionController>
        [HttpGet]
        public async Task<IEnumerable<CargaSiga>> GetCargaSigaAsync()
        {
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
            return await _cargasigaRepository.GetCargaSigaAsync();
        }

        // GET api/<AsignacionController>/5

        [HttpGet("{id}", Name = "GetCargaSigaAsync")]
        public async Task<ActionResult<CargaSiga>> GetCargaSigaByIdAsync(int id)
        {
            //var clsasignacion = await _rolRepository.GetRolByIdAsync(id);
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
            return await _cargasigaRepository.GetCargaSigaByIdAsync(id);  
        }

        // GET api/<GetCargaMatriculaUsuario>/5
        [HttpGet("/matriculasiga/{matriculasiga}", Name = "GetCargaMatriculaUsuario")]
       
        public async Task<ActionResult<CargaSiga>> GetCargaMatriculaUsuario(string matriculasiga)
        {
            //var clsasignacion = await _rolRepository.GetRolByIdAsync(id);
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
            return await _cargasigaRepository.GetCargaMatriculaUsuario(matriculasiga);
        }
        

        // POST api/<AsignacionController>
        [HttpPost]
        //[Route("api/Asignacion/Create")]
        public async Task<IActionResult> PostAsync([FromBody] CargaSiga cargasiga)
        {
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
            var result = await _cargasigaRepository.InsertAsync(cargasiga);
            return CreatedAtRoute("GetCargaSigaAsync", new { id = result.IdCarga }, result);
        }

        // PUT api/<AsignacionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CargaSiga cargasiga)
        {
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
            var result = await _cargasigaRepository.UpdateAsync(id, cargasiga);
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
            var result = await _cargasigaRepository.DeleteAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
