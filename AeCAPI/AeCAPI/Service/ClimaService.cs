using AeCAPI.Entity;
using AeCAPI.Interface;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace AeCAPI.Service
{
    public class ClimaService : IClimaService
    {
        private readonly string _connectionString;

        public ClimaService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Clima GetClima(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                string selectQuery = "SELECT * FROM climas WHERE id = @Id";
                return dbConnection.QueryFirstOrDefault<Clima>(selectQuery, new { Id = id });
            }
        }
    }
}
