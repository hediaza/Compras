using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SqlServerDB
{
    public interface IDbConnector: IDisposable
    {
        IDbConnection GetConnection();
    }

    public class DapperConnector: IDbConnector
    {
        private IDbConnection connection;

        public DapperConnector() : this("SqlServerConnection") {
        }

        public DapperConnector(string connectionStringName) {
            // Obtiene parametros de conexion
            var connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ToString();
            connection = new SqlConnection(connectionString);
            connection.Open();            

            // Para consultas mapea snake_case a PascalCase
            //DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public IDbConnection GetConnection() {
            return connection;
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}
