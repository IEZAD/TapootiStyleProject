using Serilog;
using Serilog.Events;
using Microsoft.AspNetCore.Builder;
using _0_Framework.Apllication.Logger;

namespace _0_Framework.Apllication.Extensions
{
    public static class SerilogEx
    {
        public static void UseSeriLog_Console(this ConfigureHostBuilder configureHostBuilder) => configureHostBuilder.UseSerilog(configureLogger: (builder, logger) => logger = new SerilogConfig(builder.Configuration).ConfigSqlServer(LogEventLevel.Verbose));

        public static void UseSeriLog_SqlServer(this ConfigureHostBuilder configureHostBuilder) => configureHostBuilder.UseSerilog(configureLogger: (builder, logger) => { logger = new SerilogConfig(builder.Configuration).ConfigSqlServer(LogEventLevel.Information); logger.CreateLogger(); });
    }
}