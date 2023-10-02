using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AccountManagment.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        #region DefaultUserId
        private const string ADMIN_ID = "6aabd0ed-3b59-45d6-b1fa-6803efedcb9d";
        private const string SUPER_ADMIN_ROLE_ID = "1b1a3a22-115c-45e7-bcc9-0786caa01401";
        #endregion

        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.Property(x => x.CountryCode).IsRequired().HasMaxLength(3);
            builder.HasOne(x => x.Role).WithMany(x => x.Accounts).HasForeignKey(x => x.RoleId);

            #region DefaultUser
            var admin = new Account(ADMIN_ID, SUPER_ADMIN_ROLE_ID, "98", "9108031881", "SuperAdmin", true);
            admin.PasswordHash = PassGenerate(admin);
            builder.HasData(admin);
            #endregion
        }

        public string PassGenerate(Account account)
        {
            var passHash = new PasswordHasher<Account>();
            return passHash.HashPassword(account, "Qwerty123456&*");
        }
    }
}
