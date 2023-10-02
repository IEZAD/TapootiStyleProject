using _0_Framework.Apllication.Messaging.ApiWrapper;

namespace AccountManagment.Application.Contracts.Role
{
    public interface IRoleApplication
    {
        Task<ApiWrapperResponse> UpdateAsync(EditRole command);

        Task<ApiWrapperResponse> CreateAsync(CreateRole command);

        Task<ApiWrapperResponse<List<RoleViewModel>>> ListAsync();

        Task<ApiWrapperResponse<EditRole>> GetDetailsAsync(string id);
    }
}
