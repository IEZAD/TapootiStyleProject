using System.ComponentModel.DataAnnotations;

namespace AccountManagment.Application.Contracts.Account
{
    public class LoginUserRequest
    {
        [Required(ErrorMessage = "UserName is Required")]
        [MaxLength(50, ErrorMessage = "Maximum length for UserName is 50")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        [MaxLength(50, ErrorMessage = "Maximum length for Password is 50")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        [Required(ErrorMessage = "Remember is Required")]
        public bool IsPersistent { get; set; }
    }
}
