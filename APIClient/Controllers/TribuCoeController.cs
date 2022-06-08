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
    public class TribuCoeController : ControllerBase
    {
        private readonly ITribucoeRepository _tribucoeRepository;
        private readonly ILogger<TribuCoeController> _logger;
        public TribuCoeController(ITribucoeRepository tribucoeRepository, ILogger<TribuCoeController> logger)
        {
            _tribucoeRepository = tribucoeRepository;
            _logger = logger;
        }

        // GET: api/<AsignacionController>
        [HttpGet]
        public async Task<IEnumerable<Tribucoe>> GetTribucoeAsync()
        {
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
            return await _tribucoeRepository.GetTribucoeAsync();
        }

        // GET api/<AsignacionController>/5

        [HttpGet("{id}", Name = "GetTribucoeAsync")]
        public async Task<ActionResult<Tribucoe>> GetTribucoeByIdAsync(int id)
        {
            //var clsasignacion = await _rolRepository.GetRolByIdAsync(id);
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
            return await _tribucoeRepository.GetTribucoeByIdAsync(id);

           
        }

      
        // POST api/<AsignacionController>
        [HttpPost]
        //[Route("api/Asignacion/Create")]
        public async Task<IActionResult> PostAsync([FromBody] Tribucoe tribucoe)
        {
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
            var result = await _tribucoeRepository.InsertAsync(tribucoe);
            return CreatedAtRoute("GetTribucoeAsync", new { id = result.IdTribucoe }, result);
        }

        // PUT api/<AsignacionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Tribucoe tribucoe)
        {
            var result = await _tribucoeRepository.UpdateAsync(id, tribucoe);
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
            var result = await _tribucoeRepository.DeleteAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
