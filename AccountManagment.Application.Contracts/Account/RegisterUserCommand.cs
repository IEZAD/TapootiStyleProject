namespace AccountManagment.Application.Contracts.Account
{
    public class RegisterUserCommand
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string RePassword { get; set; }

        public string CountryCode { get; set; }

        public string PhoneNumber { get; set; }

    }
}
