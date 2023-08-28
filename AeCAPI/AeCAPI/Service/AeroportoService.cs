using AeCAPI.Entity;
using AeCAPI.Interface;
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
            Aeroportos result = JsonConvert.DeserializeObject<Aeroportos>(message);

            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {

                dbConnection.Open();
                string insertQuery = "INSERT INTO Aeroportos (umidade, visibilidade, codigo_icao, pressao_atmosferica, vento, direcao_vento, condicao, condicao_desc, temp, atualizado_em) " +
                                     "VALUES (@umidade, @visibilidade, @codigo_icao, @pressao_atmosferica, @vento, @direcao_vento, @condicao, @condicao_desc, @temp, @atualizado_em)";
                dbConnection.Execute(insertQuery, new
                {
                    umidade = result.umidade,
                    visibilidade = result.visibilidade,
                    codigo_icao = result.codigo_icao,
                    pressao_atmosferica = result.pressao_atmosferica,
                    vento = result.vento,
                    direcao_vento = result.direcao_vento,
                    condicao = result.condicao,
                    condicao_desc = result.condicao_desc,
                    temp = result.temp,
                    atualizado_em = result.atualizado_em
                });

            }
        }
        public Aeroportos GetById(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                string selectQuery = "SELECT * FROM Aeroportos WHERE id = @Id";
                return dbConnection.QueryFirstOrDefault<Aeroportos>(selectQuery, new { Id = id });
            }
        }
    }
}
