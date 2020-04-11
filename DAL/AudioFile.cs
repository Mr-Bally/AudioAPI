using System;
using System.IO;

namespace DAL
{
    public class AudioFile
    {
        public Guid Id { get; set; }

        public Guid AuthorId { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public DateTime LastUpdated { get; set; }

        public byte[] AudioData { get; set; }

        public override string ToString()
        {
            return $"ID { Id }, AuthorID { AuthorId }, Filename: { FileName }, FilePath: { FilePath }, LastUpdated { LastUpdated.ToString() }";
        }
    }
}
