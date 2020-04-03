using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AudioWebAPI.Controllers
{
    [ApiController]
    [Route("[audio]")]
    public class AudioController : ControllerBase
    {
        private readonly ILogger<AudioController> _logger;

        public AudioController(ILogger<AudioController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet("/{id}")]
        public async Task<ActionResult<AudioFile>> GetTodoItem(string id)
        {
            //var audioFile = await _context.TodoItems.FindAsync(id);

            //if (audioFile is null)
            //{
            //    _logger.LogInformation($"Error: Could not find audio file for ID: {id}");
            //    return NotFound();
            //}

            //return audioFile;
            return null;
        }

        [HttpPost("/store")]
        public async Task<ActionResult<AudioFile>> StoreAudioFile(AudioFile audioFile)
        {
            return null;
            // Store file and return whether it was saved successfully
        }
    }
}
