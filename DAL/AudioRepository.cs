using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DAL
{
    public class AudioRepository : IAudioRepository
    {
        private const string AudioDb = "AudioDb";

        public async Task<int> AddAudioFile(AudioFile audioFile)
        {
            using (IDbConnection dbConnection = new SqlConnection(ConfigurationAccess.GetConnectionString(AudioDb)))
            {
                return await dbConnection.ExecuteAsync("dbo.AddAudioFile @Id, @FileName, @AuthorId, @FilePath", new
                {
                    audioFile.Id,
                    audioFile.FileName,
                    audioFile.AuthorId,
                    audioFile.FilePath
                });
            }
        }

        public async Task<int> DeleteAudioFile(Guid id)
        {
            using (IDbConnection dbConnection = new SqlConnection(ConfigurationAccess.GetConnectionString(AudioDb)))
            {
                return await dbConnection.ExecuteAsync("dbo.DeleteAudioFile @Id", new
                {
                    Id = id
                });
            }
        }

        public async Task<AudioFile> GetAudioFile(Guid id)
        {
            using (IDbConnection dbConnection = new SqlConnection(ConfigurationAccess.GetConnectionString(AudioDb)))
            {
                return await dbConnection.QueryFirstAsync<AudioFile>("dbo.GetAudioFile @Id", new
                {
                    Id = id
                });
            }
        }
    }
}
