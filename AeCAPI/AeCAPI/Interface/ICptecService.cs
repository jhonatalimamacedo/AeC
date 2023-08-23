using Microsoft.AspNetCore.Mvc;

namespace AeCAPI.Interface
{
    public interface ICptecService
    {
        Task<string> aeroporto(string codigo);
        Task<string> cidade(int codigo);
    }
}