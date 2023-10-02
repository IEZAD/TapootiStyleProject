using Microsoft.EntityFrameworkCore;
using AccountManagment.Domain.RoleAgg;
using AccountManagment.Domain.AccountAgg;
using AccountManagement.Infrastructure.EFCore.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EFCore
{
    public class AccountContext : IdentityDbContext<Account, Role, string>
    {
        public DbSet<Role> Roles { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("Tapooti");
            var assembly = typeof(AccountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            //base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
