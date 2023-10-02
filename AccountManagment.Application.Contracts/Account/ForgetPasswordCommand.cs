namespace AccountManagment.Application.Contracts.Account
{
    public class ForgetPasswordCommand
    {
        public string CountryCode { get; set; }

        public string PhoneNumber { get; set; }
    }
}
