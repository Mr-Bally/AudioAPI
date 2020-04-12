using System;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AudioWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudioController : ControllerBase
    {
        private readonly ILogger<AudioController> _logger;

        private readonly IAudioService _audioService;

        public AudioController(ILogger<AudioController> logger, IAudioService audioService)
        {
            _logger = logger;
            _audioService = audioService;
        }
        
        [HttpGet("{id}")]
        public async Task<AudioFile> GetAudioFile(Guid id)
        {
            var audioFile = await _audioService.GetAudioFile(id);

            if (audioFile is null)
            {
                _logger.LogError($"Error: Could not find audio file with ID: { id.ToString() }");
            }

            return audioFile;
        }

        [HttpPost("/{audioFile}")]
        public async Task<bool> StoreAudioFile(AudioFile audioFile)
        {
            var result = await _audioService.AddAudioFile(audioFile);

            if (!result)
            { 
                _logger.LogError($"Error: Could not store audio file with ID: { audioFile.ToString() }");
            }

            return result;
        }

        [HttpDelete("/Delete/{id}")]
        public async Task DeleteAudioFile(Guid id)
        {
            var result = await _audioService.DeleteAudioFile(id);
        }
    }
}
