using System.ComponentModel.DataAnnotations;

namespace AccountManagment.Application.Contracts.Account
{
    public class AccountViewModelResponse
    {
        public string? Id { get; set; }

        public string? UserName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? CountryCode { get; set; }
    }
}
