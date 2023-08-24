using AeCAPI.Entity;
using AeCAPI.Interface;
using AeCAPI.Model;
using Dapper;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AeCAPI.Service
{
    public class CidadeService : ICidadeService
    {
        private readonly string _connectionString;

        public CidadeService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(string message)
        {
            var result = JsonConvert.DeserializeObject<Cidades>(message);

            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                // Inserir a cidade
                string insertCidadeQuery = "INSERT INTO cidades (cidade, atualizado_em, estado) VALUES (@cidade, @atualizado_em, @estado)";
                dbConnection.Execute(insertCidadeQuery, new
                {
                    cidade = result.cidade,
                    atualizado_em = result.atualizado_em,
                    estado = result.estado
                });

                // Obter o ID da última cidade inserida
                int cidadeId = dbConnection.QuerySingle<int>("SELECT SCOPE_IDENTITY()");

                // Inserir os climas associados à cidade
                foreach (var item in result.clima)
                {
                    string insertClimaQuery = "INSERT INTO climas (condicao, condicao_desc, data, indice_uv, max, min, idCidade) " +
                        "VALUES (@condicao, @condicao_desc, @data, @indice_uv, @max, @min, @idCidade)";
                    dbConnection.Execute(insertClimaQuery, new
                    {
                        condicao = item.condicao,
                        condicao_desc = item.condicao_desc,
                        data = item.data,
                        indice_uv = item.indice_uv,
                        max = item.max,
                        min = item.min,
                        idCidade = cidadeId
                    });
                }
            }
        }

        public Cidades GetById(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                string selectCidadeQuery = "SELECT * FROM cidades WHERE id = @Id";
                return dbConnection.QueryFirstOrDefault<Cidades>(selectCidadeQuery, new { Id = id });
            }
        }
    }
}
