using AeCAPI.Interface;
using AeCAPI.Model;
using Dapper;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AeCAPI.Service
{
    public class AeroportoService : IAeroportoService
    {
        private readonly string _connectionString;

        public AeroportoService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(string message)
        {
            AeroportosModel result = JsonConvert.DeserializeObject<AeroportosModel>(message);

            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                string insertQuery = "INSERT INTO aeroporto (Nome, Localizacao) VALUES (@Nome, @Localizacao)";
                dbConnection.Execute(insertQuery, result);
            }
        }

        public AeroportosModel GetById(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                string selectQuery = "SELECT * FROM aeroporto WHERE Id = @Id";
                return dbConnection.QueryFirstOrDefault<AeroportosModel>(selectQuery, new { Id = id });
            }
        }
    }
}
