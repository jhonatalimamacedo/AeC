using AeCAPI.Entity;
using AeCAPI.Interface;
using AeCAPI.Model;
using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AeCAPI.Service
{
    public class LogService : ILogService
    {
        private readonly string _connectionString;

        public LogService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void SaveLog(int code, string message)
        {
            var logEntry = new log
            {
                data = DateTime.Now,
                codeMessage = code,
                messagem = message
            };

            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                string insertQuery = "INSERT INTO log (data, codeMessage, messagem) VALUES (@data, @codeMessage, @messagem)";
                dbConnection.Execute(insertQuery, logEntry);
            }
        }
    }
}
