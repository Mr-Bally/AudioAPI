using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IAudioRepository
    {
        AudioFile GetAudioFile(Guid id);
        AudioFile DeleteAudioFile(Guid id);
        bool AddAudioFile(AudioFile audioFile);
        bool UpdateAudioFile(AudioFile audioFile);
    }
}
