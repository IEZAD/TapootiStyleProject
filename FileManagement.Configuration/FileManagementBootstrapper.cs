using FileManagement.Application;
using Microsoft.EntityFrameworkCore;
using FileManagement.Domain.FileAgg;
using FileManagement.Domain.FileServerAgg;
using FileManagement.Infrastructure.EFCore;
using Microsoft.Extensions.DependencyInjection;
using FileManagement.Application.Contracts.File;
using FileManagement.Application.Contracts.FileServer;
using FileManagement.Infrastructure.EFCore.Repository.FileRepository;
using FileManagement.Infrastructure.EFCore.Repository.FileServerRepository;

namespace FileManagement.Configuration
{
    public class FileManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IFileRepository, FileRepository>();
            services.AddTransient<IFileApplication, FileApplication>();
            services.AddTransient<IFileQueryRepository, FileQueryRepository>();

            services.AddTransient<IFileServerRepository, FileServerRepository>();
            services.AddTransient<IFileServerApplication, FileServerApplication>();
            services.AddTransient<IFileServerQueryRepository, FileServerQueryRepository>();

            services.AddDbContext<FileContext>(x => x.UseSqlServer(connectionString));
        }
    }
}