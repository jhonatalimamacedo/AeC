using AeCAPI.Entity;

namespace AeCAPI.Interface
{
    public interface ICidadeService
    {
        void Create(string message);
        Cidade GetById(int id);
    }
}
