using System.ComponentModel.DataAnnotations;

namespace AccountManagment.Application.Contracts.Account
{
    public class PhoneNumberRequest
    {
        [Required(ErrorMessage = "CountryCode is Required")]
        [MaxLength(3, ErrorMessage = "Maximum lenght for CountryCode is 3")]
        public string CountryCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "PhoneNumber is Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
    }
}
