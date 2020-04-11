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
            audioFile.FilePath = _audioFilePath + $"/{ audioFile.AuthorId.ToString() }/{ audioFile.Id }/";
            
            var result = _audioRepository.AddAudioFile(audioFile);

            if (result == 1)
            {
                // Add in logic for saving the audio file stream to file location

                return true;
            }

            return false;
        }

        public int DeleteAudioFile(Guid id)
        {
            return _audioRepository.DeleteAudioFile(id);
        }

        public AudioFile GetAudioFile(Guid id)
        {
            return _audioRepository.GetAudioFile(id);
        }
    }
}
