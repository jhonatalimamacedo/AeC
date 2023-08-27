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
            var result = JsonConvert.DeserializeObject<Cidade>(message);

            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                // Inserir a cidade
                string insertCidadeQuery = "INSERT INTO Cidade (cidade, atualizado_em, estado) VALUES (@Cidade, @Atualizado_em, @Estado)";
                dbConnection.Execute(insertCidadeQuery, new
                {
                    Cidade = result.cidade,
                    Atualizado_em = result.atualizado_em,
                    Estado = result.estado
                });

                // Obter o ID da última cidade inserida
                int cidadeId = dbConnection.QuerySingle<int>("SELECT SCOPE_IDENTITY()");

                foreach (var item in result.clima)
                {
                    string insertClimaQuery = "INSERT INTO climas (condicao, condicao_desc, data, indice_uv, max, min, idCidade) " +
                                              "VALUES (@Condicao, @Condicao_Desc, @Data, @Indice_UV, @Max, @Min, @IdCidade)";
                    dbConnection.Execute(insertClimaQuery, new
                    {
                        Condicao = item.condicao,
                        Condicao_Desc = item.condicao_desc,
                        Data = item.data,
                        Indice_UV = item.indice_uv,
                        Max = item.max,
                        Min = item.min,
                        IdCidade = cidadeId
                    });
                }
            }
        }
    



    public Cidade GetById(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                string selectCidadeQuery = "SELECT * FROM cidades WHERE id = @Id";
                return dbConnection.QueryFirstOrDefault<Cidade>(selectCidadeQuery, new { Id = id });
            }
        }
    }
}
