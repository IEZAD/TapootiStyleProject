namespace _0_Framework.Domain.Sms
{
    public class InputSmsViewModel
    {
        private string _number;

        public string? Token1 { get; private set; }

        public string? Token2 { get; private set; }

        public string? Token3 { get; private set; }

        public string Message { get; private set; } = string.Empty;

        public string Number { get => _number; private set => _number = "+" + value; }

        public InputSmsViewModel(string number, string message)
        {
            Number = number;
            Message = message;
        }

        public InputSmsViewModel(string number, string token1, string? token2, string? token3)
        {
            Number = number;
            Token1 = token1;
            Token2 = token2 ?? string.Empty;
            Token3 = token3 ?? string.Empty;
        }
    }
}
