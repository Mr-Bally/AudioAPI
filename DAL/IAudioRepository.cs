using System;
using System.Threading.Tasks;

namespace DAL
{
    public interface IAudioRepository
    {
        Task<AudioFile> GetAudioFile(Guid id);
        Task<int> DeleteAudioFile(Guid id);
        Task<int> AddAudioFile(AudioFile audioFile);
    }
}
