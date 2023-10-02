using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileManagement.Infrastructure.EFCore.Mapping
{
    public class FileMapping : IEntityTypeConfiguration<Domain.FileAgg.File>
    {
        public void Configure(EntityTypeBuilder<Domain.FileAgg.File> builder)
        {
            builder.ToTable("Files");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Path).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.FileName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.MimeType).IsRequired().HasMaxLength(100);
            builder.Property(x => x.FileServerId).IsRequired().HasMaxLength(450);
            builder.Property(x => x.AccountId).IsRequired(false).HasMaxLength(450);

            builder.HasOne(x => x.FileServer).WithMany(x => x.Files).HasPrincipalKey(x => x.Id).HasForeignKey(x => x.FileServerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}