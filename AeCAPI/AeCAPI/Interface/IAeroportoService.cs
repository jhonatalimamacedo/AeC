using AeCAPI.Entity;

namespace AeCAPI.Interface
{
    public interface IAeroportoService
    {
        void Create(string message);
       Aeroportos GetById(int id);
    }
}
