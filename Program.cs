using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //ILoggerFactory loggerFactory = new LoggerFactory().AddConsole((_, __) => true);
            //ILogger logger = loggerFactory.CreateLogger<Program>();

            //logger.LogInformation("Logging information.");
            //logger.LogCritical("Logging critical information.");
            //logger.LogDebug("Logging debug information.");
            //logger.LogError("Logging error information.");
            //logger.LogTrace("Logging trace");
            //logger.LogWarning("Logging warning.");

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
