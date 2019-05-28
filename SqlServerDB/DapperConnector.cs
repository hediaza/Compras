using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace SqlServerDB
{
    public class DapperConnector: IDisposable
    {
        public IDbConnection connection;

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

        public void Dispose()
        {
            connection.Close();
        }
    }
}
