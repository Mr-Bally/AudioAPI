using DAL;
using System;
using System.Collections.Generic;

namespace AudioAPIConsole
{
    public class DummyData
    {
        private readonly IAudioService _audioService;

        private List<string> FileNames = new List<string>();

        private const string FileName = "TestFile";

        public DummyData(IAudioService audioService)
        {
            _audioService = audioService;
        }

        public void PopulateTable(int count)
        {
            var data = GetData(count);

            foreach(var record in data)
            {
                _audioService.AddAudioFile(record);    
            }
        }

        private IEnumerable<AudioFile> GetData(int count)
        {
            var toReturn = new List<AudioFile>();

            GetListOfFileNames(count);

            FileNames.ForEach(x => toReturn.Add(GenerateAudioFile(x)));

            return toReturn;
        }

        private AudioFile GenerateAudioFile(string fileName)
        {
            return new AudioFile
            {
                Id = Guid.NewGuid(),
                AuthorId = Guid.NewGuid(),
                FileName = fileName,
                FilePath = $"/{ fileName }/"
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
