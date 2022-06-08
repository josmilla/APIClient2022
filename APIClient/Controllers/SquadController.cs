using Microsoft.AspNetCore.Mvc;
using APIClient.Infrastructure.Data.Entities;
using APIClient.Infrastructure.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
using System.Net.Http;

namespace APIClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  [Authorize]
    public class SquadController : ControllerBase
    {
        private readonly ISquadRepository _squadRepository;
        private readonly ILogger<SquadController> _logger;
        public SquadController(ISquadRepository squadRepository, ILogger<SquadController> logger)
        {
            _squadRepository = squadRepository;
            _logger = logger;
        }

        // GET: api/<AsignacionController>
        [HttpGet]
        public async Task<IEnumerable<Squad>> GetSquadAsync()
        {
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
            //var resultado = _squadRepository.GetSquadAsync();
            //return await HttpClient.GetFromJsonAsync(resultado);

           return await _squadRepository.GetSquadAsync();
        }

        // GET api/<AsignacionController>/5

        [HttpGet("{id}", Name = "GetSquadAsync")]
        public async Task<ActionResult<Squad>> GetSquadByIdAsync(int id)
        {
            //var clsasignacion = await _rolRepository.GetRolByIdAsync(id);
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
            return await _squadRepository.GetSquadByIdAsync(id);

        }

      
        // POST api/<AsignacionController>
        [HttpPost]
        //[Route("api/Asignacion/Create")]
        public async Task<IActionResult> PostAsync([FromBody] Squad squad)
        {
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
            var result = await _squadRepository.InsertAsync(squad);
            return CreatedAtRoute("GetSquadAsync", new { id = result.IdSquad }, result);
        }

        // PUT api/<AsignacionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Squad squad)
        {
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
            var result = await _squadRepository.UpdateAsync(id, squad);
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
            var result = await _squadRepository.DeleteAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
