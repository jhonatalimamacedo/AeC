using AeCAPI.Entity;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace AeCAPI.Data
{
    public class AeCContext
    {
        private readonly string _connectionString;

        public AeCContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Aeroportos> ObterAeroportos()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<Aeroportos>("SELECT * FROM aeroporto");
            }
        }

        public IEnumerable<Cidades> ObterCidades()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<Cidades>("SELECT * FROM cidades");
            }
        }

        public IEnumerable<Clima> ObterClimas()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<Clima>("SELECT * FROM climas");
            }
        }

        public IEnumerable<log> ObterLogs()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<log>("SELECT * FROM logs");
            }
        }

        public IEnumerable<T> ExecutarConsulta<T>(string query, object parametros = null)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<T>(query, parametros);
            }
        }

        public int ExecutarComando(string comando, object parametros = null)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.Execute(comando, parametros);
            }
        }

    }
}
