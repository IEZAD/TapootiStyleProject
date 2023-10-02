namespace _0_Framework.Infrastructure.Permission
{
    public interface IPermissionExposer
    {
        Dictionary<string, List<PermissionDto>> Expose();
    }
}
