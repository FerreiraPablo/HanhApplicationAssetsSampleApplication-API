using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace Hahn.ApplicationProcess.February2021.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var logger = new LoggerConfiguration().WriteTo.RollingFile(new JsonFormatter(), configuration["LoggingFile"]).CreateLogger();

            builder.ConfigureLogging(builderContext => {

                builderContext.AddSerilog(logger, false);
                builderContext
                .AddFilter("Microsoft", LogLevel.Information)
                .AddFilter("System", LogLevel.Error)
                .AddSerilog(logger);
            });

            builder.ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());

            return builder;
        }
    }
            
}
