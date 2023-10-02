using System.ComponentModel.DataAnnotations;

namespace AccountManagment.Application.Contracts.Account
{
    public class ResetPasswordRequest : PhoneNumberRequest
    {
        [Required(ErrorMessage = "Code is Required")]
        [MaxLength(300, ErrorMessage = "Maximum length for Code is 300")]
        public string Code { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        [MaxLength(50, ErrorMessage = "Maximum length for Password is 50")]
        public string Password { get; set; }
    }
}
