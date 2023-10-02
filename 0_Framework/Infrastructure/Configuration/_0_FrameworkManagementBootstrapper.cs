using _0_Framework.Apllication.SMS;
using _0_Framework.Apllication.Logger;
using Microsoft.Extensions.DependencyInjection;

namespace _0_Framework.Infrastructure.Configuration
{
    public class _0_FrameworkManagementBootstrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
            service.AddSingleton<ILogger, Serilogger>();
            service.AddTransient<ISMSService, SMSService>();
        }
    }
}