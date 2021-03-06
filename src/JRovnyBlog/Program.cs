using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace JRovnyBlog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((context, logger) =>
                {
                    var isDevelopment = context.HostingEnvironment.IsDevelopment();
                    logger.MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning);
                    logger.Enrich.FromLogContext();
                    if (isDevelopment)
                        logger.WriteTo.Console();
                    logger.WriteTo.File(new JsonFormatter(),
                        isDevelopment ? @".\log\log-.txt" : @"./log/log-.txt",
                        rollingInterval: RollingInterval.Day,
                        retainedFileCountLimit: null,
                        rollOnFileSizeLimit: true);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
