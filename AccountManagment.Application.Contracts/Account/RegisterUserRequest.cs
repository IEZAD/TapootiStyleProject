using System.ComponentModel.DataAnnotations;

namespace AccountManagment.Application.Contracts.Account
{
    public class RegisterUserRequest
    {
        [Required(ErrorMessage = "UserName is Required")]
        [MaxLength(50, ErrorMessage = "Maximum length for UserName is 50")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [MaxLength(50, ErrorMessage = "Maximum length for Password is 50")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "RePassword is Required")]
        [MaxLength(50, ErrorMessage = "Maximum length for RePassword is 50")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "CountryCode is Required")]
        [MaxLength(3, ErrorMessage = "Maximum length for CountryCode is 3")]
        public string CountryCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "PhoneNumber is Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
    }
}
