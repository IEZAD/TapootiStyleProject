using System.ComponentModel.DataAnnotations;

namespace AccountManagment.Application.Contracts.Account
{
    public class ResetPasswordConfirmCommand
    {
        [Required]
        public string Token { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
