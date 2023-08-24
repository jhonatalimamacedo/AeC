using AeCAPI.Entity;
using AeCAPI.Model;

namespace AeCAPI.Interface
{
    public interface IAeroportoService
    {
        void Create(string message);
       AeroportosModel GetById(int id);
    }
}
