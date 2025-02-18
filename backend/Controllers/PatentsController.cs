// Controllers/PatentsController.cs
using Backend.Services;
using Backend.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using backend.Models;
using backend.Services;
using backend.Logging;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatentsController : ControllerBase
    {
        private readonly IPatentService _patentService;
        private readonly ILoggerManager _loggerManager;

        public PatentsController(IPatentService patentService, ILoggerManager loggerManager)
        {
            _patentService = patentService;
            _loggerManager = loggerManager;
        }

        // GET api/patents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patent>>> GetPatents()
        {
            _loggerManager.Logger.LogInformation("GetPatents endpoint called.");
            var patents = await _patentService.GetPatentsAsync();
            return Ok(patents);
        }

        // GET api/patents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patent>> GetPatent(int id)
        {
            _loggerManager.Logger.LogInformation($"GetPatent endpoint called with id {id}.");
            return await _patentService.GetPatentAsync(id);
        }

        // POST api/patents
        [HttpPost]
        public async Task<ActionResult<Patent>> CreatePatent(Patent patent)
        {
            _loggerManager.Logger.LogInformation("CreatePatent endpoint called.");
            await _patentService.CreatePatentAsync(patent);
            return CreatedAtAction(nameof(GetPatent), new { id = patent.Id }, patent);
        }

        // PUT api/patents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatent(int id, Patent patent)
        {
            _loggerManager.Logger.LogInformation($"UpdatePatent endpoint called with id {id}.");
            if (id != patent.Id)
            {
                _loggerManager.Logger.LogError($"Invalid patent id {id}.");
                return BadRequest();
            }
            await _patentService.UpdatePatentAsync(patent);
            return NoContent();
        }

        // DELETE api/patents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatent(int id)
        {
            _loggerManager.Logger.LogInformation($"DeletePatent endpoint called with id {id}.");
            await _patentService.DeletePatentAsync(id);
            return NoContent();
        }
    }
}