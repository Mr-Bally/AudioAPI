using DAL;
using System;
using System.Collections.Generic;

namespace AudioAPIConsole
{
    public static class DummyData
    {
        private static List<string> FileNames = new List<string>();

        private const string FileName = "TestFile";

        public static IEnumerable<AudioFile> GetData(int count)
        {
            var toReturn = new List<AudioFile>();

            GetListOfFileNames(count);

            FileNames.ForEach(x => toReturn.Add(GenerateAudioFile(x)));

            return toReturn;
        }

        private static AudioFile GenerateAudioFile(string fileName)
        {
            return new AudioFile
            {
                Id = Guid.NewGuid(),
                AuthorId = Guid.NewGuid(),
                FileName = fileName,
                FilePath = $"/{ fileName }/"
            };
        }

        private static void GetListOfFileNames(int count)
        {
            for (var x = 0; x < count; x++)
            {
                FileNames.Add(FileName + x);
            }
        }
    }
}
