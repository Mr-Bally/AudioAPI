using System;
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

        private readonly IAudioService _audioService;

        public AudioController(ILogger<AudioController> logger, IAudioService audioService)
        {
            _logger = logger;
            _audioService = audioService;
        }
        
        [HttpGet("/{id}")]
        public AudioFile GetAudioFile(Guid id)
        {
            var audioFile = _audioService.GetAudioFile(id);

            if (audioFile is null)
            {
                _logger.LogError($"Error: Could not find audio file with ID: { id.ToString() }");
            }

            return audioFile;
        }

        [HttpPost("/store")]
        public async Task<ActionResult<AudioFile>> StoreAudioFile(AudioFile audioFile)
        {
            return null;
            // Store file and return whether it was saved successfully
        }
    }
}
