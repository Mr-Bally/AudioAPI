using System;

namespace DAL
{
    public interface IAudioService
    {
        AudioFile GetAudioFile(Guid id);
        AudioFile DeleteAudioFile(Guid id);
        bool AddAudioFile(AudioFile audioFile);
        bool UpdateAudioFile(AudioFile audioFile);
    }
}
