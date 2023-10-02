using Microsoft.EntityFrameworkCore;
using FileManagement.Domain.FileServerAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileManagement.Infrastructure.EFCore.Mapping
{
    public class FileServerMapping : IEntityTypeConfiguration<FileServer>
    {
        #region DefaultFileServer 
        private const long FILE_SERVER_CAPACITY = 0;
        private const bool FILE_SERVER_IS_ACTIVE = true;
        private const string FILE_SERVER_NAME = "Public";
        private const string FILE_SERVER_FTPDATA = "";
        private const string FILE_SERVER_HTTP_PATH = "/Main";
        private const string FILE_SERVER_HTTP_DESCRIPTION = null;
        private const string FILE_SERVER_HTTP_DOMAIN = "http://127.0.0.127";
        private Guid FILE_SERVER_ID = Guid.Parse("812E3B67-7E01-4664-A72A-2957A146DA80");
        #endregion

        public void Configure(EntityTypeBuilder<FileServer> builder)
        {
            builder.ToTable("FileServers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.FTPData).IsRequired().HasMaxLength(450);
            builder.Property(x => x.HttpPath).IsRequired().HasMaxLength(200);
            builder.Property(x => x.HttpDomain).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(450);

            #region DefaultUser
            var fileServer = new FileServer(FILE_SERVER_ID, FILE_SERVER_NAME, FILE_SERVER_CAPACITY, FILE_SERVER_IS_ACTIVE, FILE_SERVER_FTPDATA, FILE_SERVER_HTTP_DOMAIN, FILE_SERVER_HTTP_PATH, FILE_SERVER_HTTP_DESCRIPTION);
            builder.HasData(fileServer);
            #endregion
        }
    }
}