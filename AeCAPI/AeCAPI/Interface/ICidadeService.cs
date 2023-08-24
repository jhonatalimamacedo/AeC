using AeCAPI.Entity;
using AeCAPI.Model;

namespace AeCAPI.Interface
{
    public interface ICidadeService
    {
        void Create(string message);
        Cidades GetById(int id);
    }
}
