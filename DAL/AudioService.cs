using System;

namespace DAL
{
    public class AudioService : IAudioService
    {
        private readonly IAudioRepository _audioRepository;

        public AudioService(IAudioRepository audioRepository)
        {
            _audioRepository = audioRepository;
        }

        public bool AddAudioFile(AudioFile audioFile)
        {
            return _audioRepository.AddAudioFile(audioFile);
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
