using System.Threading.Tasks;

namespace DAL
{
    public interface IAudioFileService
    {
        Task<bool> SaveAudioFile(string path, string fileName, byte[] data);
    }
}
