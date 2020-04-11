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
                return dbConnection.Execute(@$"INSERT INTO AudioFiles(Id, FileName, Author, FilePath)
                    VALUES (${ audioFile.Id.ToString() }, ${ audioFile.FileName }, ${ audioFile.AuthorId.ToString() }, 
                    ${ audioFile.FilePath } );");
            }
        }

        public AudioFile DeleteAudioFile(Guid id)
        {
            throw new NotImplementedException();
        }

        public AudioFile GetAudioFile(Guid id)
        {
            using (IDbConnection dbConnection = new SqlConnection(ConfigurationAccess.GetConnectionString(AudioDb)))
            {
                return dbConnection.QueryFirst<AudioFile>($"SELECT * FROM AudioFiles WHERE Id = {id}");
            }
        }

        public bool UpdateAudioFile(AudioFile audioFile)
        {
            throw new NotImplementedException();
        }
    }
}
