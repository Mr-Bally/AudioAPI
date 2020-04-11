using System;

namespace DAL
{
    public class AudioService : IAudioService
    {
        private readonly IAudioRepository _audioRepository;

        private readonly string _audioFilePath = ConfigurationAccess.GetAudioFilePath();

        public AudioService(IAudioRepository audioRepository)
        {
            _audioRepository = audioRepository;
        }

        public bool AddAudioFile(AudioFile audioFile)
        {
            audioFile.FilePath = _audioFilePath + $"{ audioFile.AuthorId.ToString() }/{ audioFile.Id }/";
            
            var result = _audioRepository.AddAudioFile(audioFile);

            if (result == 1)
            {
                // If save successful then save the audio file to the given path    
            }

            return true;
        }

        public AudioFile DeleteAudioFile(Guid id)
        {
            return _audioRepository.DeleteAudioFile(id);
        }

        public AudioFile GetAudioFile(Guid id)
        {
            return _audioRepository.GetAudioFile(id);
        }

        public bool UpdateAudioFile(AudioFile audioFile)
        {
            return _audioRepository.UpdateAudioFile(audioFile);
        }
    }
}
