using Microsoft.EntityFrameworkCore;
using AccountManagment.Domain.RoleAgg;
using AccountManagment.Domain.PermissionAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        #region DefaultRoleIdes
        const string ROLE_ID_User = "11EF8012-B314-485E-ABEC-C8D473B03679";
        const string ROLE_ID_Admin = "29DDC46D-9B46-4BD9-A833-26CE67267ED5";
        const string ROLE_ID_Super_Admin = "1b1a3a22-115c-45e7-bcc9-0786caa01401";
        #endregion

        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            #region PermissionConfig
            builder.OwnsMany<Permission>(x => x.Permissions, navigationBuilder =>
            {
                navigationBuilder.ToTable("RolePermissions");
                navigationBuilder.HasKey(x => x.Id);
                navigationBuilder.Ignore(x => x.Name);
                navigationBuilder.WithOwner(x => x.Role);
            });
            #endregion

            #region DefaultRoles
            builder.HasData(new Role(ROLE_ID_User, DefaultRoles.User, new List<Permission>()));
            builder.HasData(new Role(ROLE_ID_Admin, DefaultRoles.Admin, new List<Permission>()));
            builder.HasData(new Role(ROLE_ID_Super_Admin, DefaultRoles.SuperAdmin, new List<Permission>()));
            #endregion
        }
    }
}
