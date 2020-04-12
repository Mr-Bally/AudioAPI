using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DAL
{
    public class AudioFileService : IAudioFileService
    {
        private readonly ILogger _logger;

        private const string DefaultFileExtension = ".mp3";

        public AudioFileService(ILogger<AudioFileService> logger)
        {
            _logger = logger;
        }

        public async Task<bool> SaveAudioFile(string path, string fileName, byte[] data)
        {
            if (!CheckFilePath(path))
            {
                return false;
            }

            return await SaveAudioFileToPath(path, fileName, data);
        }

        private bool CheckFilePath(string filePath)
        {
            try
            {
                if (Directory.Exists(filePath))
                {
                    return true;
                }

                Directory.CreateDirectory(filePath);

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error when saving file: ", ex);
            }

            return false;
        }

        private async Task<bool> SaveAudioFileToPath(string path, string fileName, byte[] audioFile)
        {
            var fullPath = path + fileName + DefaultFileExtension;

            try
            {
                using (FileStream fsNew = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    await fsNew.WriteAsync(audioFile, 0, audioFile.Length);
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error when saving to path: ", ex);
            }

            return false;
        }
    }
}
