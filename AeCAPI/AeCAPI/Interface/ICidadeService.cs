using AeCAPI.Entity;

namespace AeCAPI.Interface
{
    public interface ICidadeService
    {
        void create(string message);
        Cidades getId(int id);
    }
}
