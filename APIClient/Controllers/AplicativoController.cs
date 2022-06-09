using Microsoft.AspNetCore.Mvc;
using APIClient.Infrastructure.Data.Entities;
using APIClient.Infrastructure.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace APIClient.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AplicativoController : ControllerBase
    {

        private readonly IAplicativoRepository _aplicativoRepository;
        private readonly ILogger<AplicativoController> _logger;
 
        public AplicativoController(IAplicativoRepository aplicativoRepository, ILogger<AplicativoController> logger)
        {
            _aplicativoRepository = aplicativoRepository;
            _logger = logger;
        }

        [HttpGet]
        
        public async Task<IEnumerable<Aplicativo>> GetAplicativoAsync()
        {
         //var userName = User.Identity?.Name;
         // _logger.LogInformation($"User [{userName}] is viewing values.");
            return await _aplicativoRepository.GetAplicativoAsync();
        }

        [HttpGet("{id}", Name = "GetAplicativoAsync")]
        public async Task<ActionResult<Aplicativo>> GetAplicativoByIdAsync(int id)
        {
          //var userName = User.Identity?.Name;
          // _logger.LogInformation($"User [{userName}] is viewing values.");
            return await _aplicativoRepository.GetAplicativoByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> PostAplicativoAsync([FromBody] Aplicativo aplicativo)
        {
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
            var result = await _aplicativoRepository.InsertAsync(aplicativo);
            return CreatedAtRoute("GetAplicativoAsync", new { id = result.IdAplicativo }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAplicativoAsync(int id, [FromBody] Aplicativo aplicativo)
        {
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
            var result = await _aplicativoRepository.UpdateAsync(id, aplicativo);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAplicativoAsync(int id)
        {
            //var userName = User.Identity?.Name;
            //_logger.LogInformation($"User [{userName}] is viewing values.");
            var result = await _aplicativoRepository.DeleteAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
