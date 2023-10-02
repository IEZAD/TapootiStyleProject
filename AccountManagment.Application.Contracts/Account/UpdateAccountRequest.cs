using System.ComponentModel.DataAnnotations;

namespace AccountManagment.Application.Contracts.Account
{
    public class UpdateAccountRequest
    {
        [Required(ErrorMessage = "Id is Required")]
        public string Id { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum length for UserName is 50")]
        public string? UserName { get; set; }

        [MaxLength(3, ErrorMessage = "Maximum length for CountryCode is 3")]
        public string? CountryCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string? PhoneNumber { get; set; }
    }
}
