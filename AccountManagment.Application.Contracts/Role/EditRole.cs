using _0_Framework.Infrastructure.Permission;

namespace AccountManagment.Application.Contracts.Role
{
    public class EditRole : CreateRole
    {
        public string Id { get; set; }

        public List<PermissionDto> MappedPermissions { get; set; }
    }
}
