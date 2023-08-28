using AeCAPI.Interface;

namespace AeCAPI.Service
{
    public class CptecService : ICptecService
    {
        private readonly HttpClient _httpClient;
        private readonly string cidadeUrl = "https://brasilapi.com.br/api/cptec/v1/clima/previsao/";
        private readonly string aeroportoUrl = "https://brasilapi.com.br/api/cptec/v1/clima/aeroporto/";

        public CptecService( HttpClient httpClient)
        {
            _httpClient = httpClient;

        }public async Task<string> cidade(int codigo)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(cidadeUrl + codigo);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return jsonResponse;
            }
            else
            {
                throw new Exception("Erro na requisição para a API de clima para Cidade");
            }
        }
        public async Task<string> aeroporto(string codigo)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(aeroportoUrl + codigo);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return jsonResponse;
            }
            else
            {
                throw new Exception("Erro na requisição para a API de clima para Aeroporto");
            }

        }

        
    }
}
