using _0_Framework.Apllication.Messaging.ApiWrapper;
using _0_Framework.Domain.Pagination;

namespace AccountManagment.Application.Contracts.Account
{
    public interface IAccountApplication
    {
        Task<ApiWrapperResponse> SignOutAsync();

        Task<ApiWrapperResponse<dynamic>> ResendConfirmEmailAddress(string email);

        Task<ApiWrapperResponse> ResetPasswordAsync(ResetPasswordRequest command);

        Task<ApiWrapperResponse> UpdateAccountAsync(UpdateAccountRequest command);

        Task<ApiWrapperResponse> ForgetPasswordAsync(ForgetPasswordRequest command);

        Task<ApiWrapperResponse<dynamic>> ConfirmEmailAddress(Guid userId, string code);
        
        Task<ApiWrapperResponse<LoginUserResponse>> LoginAsync(LoginUserRequest command);

        Task<ApiWrapperResponse> ResendConfirmPhoneNumberAsync(PhoneNumberRequest command);

        Task<ApiWrapperResponse> ConfirmPhoneNumberAsync(ConfirmPhoneNumberRequest command);

        Task<ApiWrapperResponse<AccountViewModelResponse>> UserInfoByIdAsync(string userId);

        Task<ApiWrapperResponse> UpdateAccountAdminAsync(UpdateAccountAdminRequest command);

        Task<ApiWrapperResponse<AccountViewModelResponse>> UserInfoByUserNameAsync(string userId);

        Task<ApiWrapperResponse<AccountViewModelResponse>> RegisterUserAsync(RegisterUserRequest command);

        Task<ApiWrapperResponse<AccountViewModelResponse>> RegisterAdminAsync(RegisterAdminRequest command);

        Task<ApiWrapperResponse<AccountViewModelResponse>> UserInfoByPhoneNumberAsync(PhoneNumberRequest userId);

        Task<ApiWrapperResponse<PagedResult<AccountViewModelResponse>>> GetAccountsAsync(AccountListRequest command);

        Task<ApiWrapperResponse<PagedResult<AccountViewModelResponse>>> SearchAsync(AccountSearchModelRequest command);
    }
}