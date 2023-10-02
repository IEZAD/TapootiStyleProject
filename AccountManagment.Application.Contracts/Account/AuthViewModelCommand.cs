using System.ComponentModel.DataAnnotations;

namespace AccountManagment.Application.Contracts.Account
{
    public class AuthViewModelCommand : PhoneNumberRequest
    {
        public string Id { get; set; }

        public string Role { get; set; }

        public string RoleId { get; set; }

        [Required]
        public string UserName { get; set; }

        public List<int> Permissions { get; set; }

        public AuthViewModelCommand() { }

        public AuthViewModelCommand(string id, string roleId, string userName, string countryCode, string phoneNumber, List<int> permissions)
        {
            Id = id;
            RoleId = roleId;
            UserName = userName;
            CountryCode = countryCode;
            PhoneNumber = phoneNumber;
            Permissions = permissions;
        }
    }
}
