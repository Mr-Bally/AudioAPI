using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class AudioRepository : IAudioRepository
    {
        private const string AudioDb = "AudioDb";

        public int AddAudioFile(AudioFile audioFile)
        {
            using (IDbConnection dbConnection = new SqlConnection(ConfigurationAccess.GetConnectionString(AudioDb)))
            {
                return dbConnection.Execute("dbo.AddAudioFile @Id, @FileName, @AuthorId, @FilePath", new
                {
                    audioFile.Id,
                    audioFile.FileName,
                    audioFile.AuthorId,
                    audioFile.FilePath
                });
            }
        }

        public int DeleteAudioFile(Guid id)
        {
            using (IDbConnection dbConnection = new SqlConnection(ConfigurationAccess.GetConnectionString(AudioDb)))
            {
                return dbConnection.Execute("dbo.DeleteAudioFile @Id", new
                {
                    Id = id
                });
            }
        }

        public AudioFile GetAudioFile(Guid id)
        {
            using (IDbConnection dbConnection = new SqlConnection(ConfigurationAccess.GetConnectionString(AudioDb)))
            {
                return dbConnection.QueryFirst<AudioFile>("dbo.GetAudioFile @Id", new
                {
                    Id = id
                });
            }
        }
    }
}
