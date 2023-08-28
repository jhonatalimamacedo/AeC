using AeCAPI.Entity;
using AeCAPI.Interface;
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

        public IEnumerable<log> Get()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                string selectQuery = "SELECT * FROM log";
                var logEntries = dbConnection.Query<log>(selectQuery);

                return logEntries;
            }
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
