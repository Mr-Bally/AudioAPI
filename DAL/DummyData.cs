using DAL;
using System;
using System.Collections.Generic;
using System.IO;

namespace AudioAPIConsole
{
    public class DummyData
    {
        private readonly IAudioService _audioService;

        private List<string> FileNames = new List<string>();

        private const string FileName = "TestFile";

        private const string FilePath = @"C:\Users\samba\source\repos\TestData\AudioFile\testAudioFile.mp3";

        public DummyData(IAudioService audioService)
        {
            _audioService = audioService;
        }

        public void PopulateTable(int count, bool includeAudioFile = false)
        {
            var data = GetData(count, includeAudioFile);

            foreach(var record in data)
            {
                _audioService.AddAudioFile(record);    
            }
        }

        private IEnumerable<AudioFile> GetData(int count, bool includeAudioFile)
        {
            var toReturn = new List<AudioFile>();
            var audioFile = GetTestAudioFile(includeAudioFile);

            GetListOfFileNames(count);

            FileNames.ForEach(x => toReturn.Add(GenerateAudioFile(x, audioFile)));

            return toReturn;
        }

        private byte[] GetTestAudioFile(bool includeAudioFile)
        {
            if (!includeAudioFile)
            {
                return new byte[0];    
            }

            try
            {
                using (FileStream stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                {
                    var bytes = new byte[stream.Length];
                    var numBytesToRead = (int)stream.Length;
                    var numBytesRead = 0;
                    
                    while (numBytesToRead > 0)
                    {
                        var x = stream.Read(bytes, numBytesRead, numBytesToRead);

                        if (x == 0)
                        { 
                            break;
                        }

                        numBytesRead += x;
                        numBytesToRead -= x;
                    }

                    numBytesToRead = bytes.Length;

                    return bytes;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new byte[0];
        }

        private AudioFile GenerateAudioFile(string fileName, byte[] audioStream)
        {
            return new AudioFile
            {
                Id = Guid.NewGuid(),
                AuthorId = Guid.NewGuid(),
                FileName = fileName,
                FilePath = $"/{ fileName }/",
                AudioData = audioStream
            };
        }

        private void GetListOfFileNames(int count)
        {
            for (var x = 0; x < count; x++)
            {
                FileNames.Add(FileName + x);
            }
        }
    }
}
