using Microsoft.AspNetCore.Identity;
using AccountManagment.Domain.AccountAgg;
using AccountManagment.Domain.PermissionAgg;

namespace AccountManagment.Domain.RoleAgg
{
    public class Role : IdentityRole
    {
        public List<Account> Accounts { get; private set; }
        //public ICollection<Account> Accounts { get; private set; }

        public List<Permission> Permissions { get; private set; }
        //public ICollection<Permission> Permissions { get; private set; }

        public DateTime CreationDate { get; private set; } = DateTime.Now;

        protected Role()
        {
        }

        public Role(string name, List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions;
            Accounts = new List<Account>();
            NormalizedName = name.ToUpper();
        }

        public Role(string id, string name, List<Permission> permissions)
        {
            Id = id;
            Name = name;
            Permissions = permissions;
            Accounts = new List<Account>();
            NormalizedName = name.ToUpper();
        }

        public void Update(string name, List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions;
            NormalizedName = name.ToUpper();
        }
    }
}
