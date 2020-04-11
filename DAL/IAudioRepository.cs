using System;

namespace DAL
{
    public interface IAudioRepository
    {
        AudioFile GetAudioFile(Guid id);
        int DeleteAudioFile(Guid id);
        int AddAudioFile(AudioFile audioFile);
    }
}
