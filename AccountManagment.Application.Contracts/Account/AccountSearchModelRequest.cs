namespace AccountManagment.Application.Contracts.Account
{
    public class AccountSearchModelRequest : AccountListRequest
    {
        public string? RoleId { get; set; }

        public string? UserName { get; set; }

        public string? CountryCode { get; set; }

        public string? PhoneNumber { get; set; }
    }
}