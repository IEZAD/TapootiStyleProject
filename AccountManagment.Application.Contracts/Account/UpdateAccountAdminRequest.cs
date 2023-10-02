namespace AccountManagment.Application.Contracts.Account
{
    public class UpdateAccountAdminRequest : UpdateAccountRequest
    {
        public string? RoleId { get; set; }
    }
}
