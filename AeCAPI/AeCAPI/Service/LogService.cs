using AeCAPI.Data;
using AeCAPI.Entity;
using AeCAPI.Interface;
using System;

namespace AeCAPI.Service
{
    public class LogService : ILogService
    {
        private readonly AeCContext _context;
        public LogService(AeCContext aeCContext)
        {
            _context = aeCContext;
        }
        public void SaveLog(int code, string message)
        {
            var logEntry = new log
            {
                data = DateTime.Now,
                codeMessage = code,
                message = message
            };

            _context.logs.Add(logEntry);
            _context.SaveChangesAsync();
        }
    }
}
