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
    public class RolController : ControllerBase
    {
        private readonly IRolRepository _rolRepository;
        private readonly ILogger<RolController> _logger;
        public RolController(IRolRepository rolRepository, ILogger<RolController> logger)
        {
            _rolRepository = rolRepository;
            _logger = logger;
        }

        
        [HttpGet]
        public async Task<IEnumerable<Rol>> GetRolAsync()
        {
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
            return await _rolRepository.GetRolAsync();
        }

        // GET api/<AsignacionController>/5

        [HttpGet("{id}", Name = "GetRolAsync")]
        public async Task<ActionResult<Rol>> GetRolByIdAsync(int id)
        {
            var clsasignacion = await _rolRepository.GetRolByIdAsync(id);
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
         //   return await _rolRepository.GetRolByIdAsync(id);

           if (clsasignacion == null)
             {
                return NotFound();
            }

            return clsasignacion;
        }

      
        // POST api/<AsignacionController>
        [HttpPost]
        //[Route("api/Asignacion/Create")]
        public async Task<IActionResult> PostAsync([FromBody] Rol rol)
        {
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
            var result = await _rolRepository.InsertAsync(rol);
            return CreatedAtRoute("GetRolAsync", new { id = result.IdRol }, result);
        }

        // PUT api/<AsignacionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Rol rol)
        {
            var result = await _rolRepository.UpdateAsync(id, rol);
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
            var result = await _rolRepository.DeleteAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
