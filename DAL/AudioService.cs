using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DAL
{
    public class AudioService : IAudioService
    {
        private readonly ILogger _logger;

        private readonly IAudioRepository _audioRepository;

        private readonly IAudioFileService _audioFileService;

        private readonly string _audioFilePath = ConfigurationAccess.GetAudioFilePath();

        public AudioService(ILogger<AudioService> logger, IAudioRepository audioRepository, IAudioFileService audioFileService)
        {
            _audioRepository = audioRepository;
            _audioFileService = audioFileService;
            _logger = logger;
        }

        public async Task<bool> AddAudioFile(AudioFile audioFile)
        {
            audioFile.FilePath = _audioFilePath + $"/{ audioFile.AuthorId.ToString() }/";
            
            var result = await _audioRepository.AddAudioFile(audioFile);
            
            if (result == 1 && audioFile?.AudioData.Length > 0 && 
                await _audioFileService.SaveAudioFile(audioFile.FilePath, audioFile.Id.ToString(), audioFile.AudioData))
            {
                return true;
            }

            await _audioRepository.DeleteAudioFile(audioFile.Id);
            
            _logger.LogError($"Could not save audio file, ID: { audioFile.Id }, File length: { audioFile.AudioData.Length }");

            return false;
        }

        public async Task<int> DeleteAudioFile(Guid id)
        {
            return await _audioRepository.DeleteAudioFile(id);
        }

        public async Task<AudioFile> GetAudioFile(Guid id)
        {
            return await _audioRepository.GetAudioFile(id);
        }
    }
}
