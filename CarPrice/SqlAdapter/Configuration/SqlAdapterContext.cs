using System.Data;
using System.Data.SqlClient;

namespace CarPrice.SqlAdapter
{
    public class SqlAdapterContext
    {
        private readonly string connectionString;
        public SqlAdapterContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private IDbConnection dbConnection;

        public IDbConnection Connection
        {
            get
            {
                if (dbConnection == null)
                    dbConnection = new SqlConnection(connectionString);

                return dbConnection;
            }
        }
    }
}
