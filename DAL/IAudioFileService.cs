namespace DAL
{
    public interface IAudioFileService
    {
        bool SaveAudioFile(string path, string fileName, byte[] data);
    }
}
