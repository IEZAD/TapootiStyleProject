namespace _0_Framework.Infrastructure.Permission
{
    public class NeedsPermissionAttribute : Attribute
    {
        public int Permission { get; set; }

        public NeedsPermissionAttribute(int permission)
        {
            Permission = permission;
        }

        public bool IsVolatile(bool disposing)
        {
            return true;
        }
    }
}
