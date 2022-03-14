using System.Data.SqlClient;
using System.Data;


namespace DataAccessLayer.Repository
{
    public class BaseRepos
    {
        private readonly string ConnectionString;
        public BaseRepos(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public IDbConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
