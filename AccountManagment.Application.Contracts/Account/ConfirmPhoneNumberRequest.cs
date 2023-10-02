using System.ComponentModel.DataAnnotations;

namespace AccountManagment.Application.Contracts.Account
{
    public class ConfirmPhoneNumberRequest : PhoneNumberRequest
    {
        [Required(ErrorMessage = "ConfirmCode is Required")]
        [MaxLength(6, ErrorMessage = "Maximum length for ConfirmCode is 6")]
        public string ConfirmCode { get; set; }
    }
}
