using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class IdentityUserMapping : IEntityTypeConfiguration<IdentityUser<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUser<string>> builder)
        {
            builder.ToTable("Users", "identity");
        }
    }
}
