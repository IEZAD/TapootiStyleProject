using _0_Framework.Domain.Common;
using AccountManagment.Domain.RoleAgg;

namespace AccountManagment.Domain.PermissionAgg
{
    public class Permission : EntityBase
    {
        public Guid Id { get; private set; }
        public int Code { get; private set; }
        public string Name { get; private set; }

        public Role Role { get; private set; }
        public string RoleId { get; private set; }

        public Permission(int code)
        {
            Code = code;
        }

        public Permission(int code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
