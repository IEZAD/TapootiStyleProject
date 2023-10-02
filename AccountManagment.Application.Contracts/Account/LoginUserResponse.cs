namespace AccountManagment.Application.Contracts.Account
{
    public class LoginUserResponse : AccountViewModelResponse
    {
        public string? Token { get; set; }
    }
}