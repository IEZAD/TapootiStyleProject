using AccountManagment.Application;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AccountManagment.Domain.RoleAgg;
using AccountManagment.Domain.AccountAgg;
using AccountManagement.Infrastructure.EFCore;
using Microsoft.Extensions.DependencyInjection;
using AccountManagment.Application.Contracts.Role;
using AccountManagment.Application.Contracts.Account;

namespace AccountManagement.Configuration
{
    public class AccountManagementBootstrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
            service.AddTransient<IRoleApplication, RoleApplication>();
            service.AddTransient<IAccountApplication, AccountApplication>();

            //Identity Config
            service.AddIdentity<Account, Role>()
                   .AddEntityFrameworkStores<AccountContext>()
                   .AddDefaultTokenProviders();

            service.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.SignIn.RequireConfirmedPhoneNumber = true;

                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0, 15, 0);

                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
            });

            service.AddDbContext<AccountContext>(x => x.UseSqlServer(connectionString));
        }
    }
}