using AeCAPI.Entity;

namespace AeCAPI.Interface
{
    public interface ILogService
    {
        void SaveLog(int code, string message);
        IEnumerable<log> Get ();
    }
}
