using System;
using System.Threading.Tasks;

namespace DAL
{
    public interface IAudioService
    {
        Task<AudioFile> GetAudioFile(Guid id);
        Task<int> DeleteAudioFile(Guid id);
        Task<bool> AddAudioFile(AudioFile audioFile);
    }
}
