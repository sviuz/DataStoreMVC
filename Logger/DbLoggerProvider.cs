using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;

namespace DataShopMVC.Logger
{
    public class DbLoggerProvider : ILoggerProvider
    {
        private readonly IApplicationBuilder Application;
        public DbLoggerProvider(IApplicationBuilder application)
        {
            Application = application;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new DbLogger(Application, categoryName);
        }

        public void Dispose()
        {
            
        }
    }
}