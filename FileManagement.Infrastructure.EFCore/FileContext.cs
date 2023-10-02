using Microsoft.EntityFrameworkCore;
using FileManagement.Domain.FileServerAgg;
using FileManagement.Infrastructure.EFCore.Mapping;

namespace FileManagement.Infrastructure.EFCore
{
    public class FileContext : DbContext
    {
        public DbSet<FileServer> FileServers { get; set; }

        public DbSet<Domain.FileAgg.File> Files { get; set; }

        public FileContext(DbContextOptions<FileContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(FileMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}