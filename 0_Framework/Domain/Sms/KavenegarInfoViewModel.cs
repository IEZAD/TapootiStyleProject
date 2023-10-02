namespace _0_Framework.Domain.Sms
{
    public class KavenegarInfoViewModel
    {
        public string Sender { get; set; } = string.Empty;

        public string ApiKey { get; set; } = string.Empty;

        public List<string> Templates { get; set; } = new List<string>();
    }
}
