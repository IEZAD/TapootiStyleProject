using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Microsoft.Extensions.Configuration;

namespace _0_Framework.Apllication.Logger
{
    public class SerilogConfig
    {
        private readonly IConfiguration _configuration;

        public SerilogConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LoggerConfiguration ConfigSqlServer(LogEventLevel logEventLevel)
        {
            var ColumnOptions = new ColumnOptions();
            ColumnOptions.LogEvent.DataLength = -1;
            ColumnOptions.TimeStamp.NonClusteredIndex = true;
            ColumnOptions.Store.Add(StandardColumn.LogEvent);
            ColumnOptions.PrimaryKey = ColumnOptions.TimeStamp;
            ColumnOptions.Store.Remove(StandardColumn.Properties);

            return new LoggerConfiguration().Enrich
                                            .FromLogContext()
                                            .MinimumLevel.Is(logEventLevel)
                                            .WriteTo.MSSqlServer(
                                              connectionString: _configuration["ConnectionStrings:Tapooti"],
                                              sinkOptions: new MSSqlServerSinkOptions
                                                { 
                                                    AutoCreateSqlTable = true,
                                                    TableName = "Loggings",
                                                    BatchPeriod = new TimeSpan(0, 0, 1),
                                                },
                                              columnOptions: ColumnOptions);
        }
    }
}