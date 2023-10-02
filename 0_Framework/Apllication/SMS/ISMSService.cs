using Kavenegar.Core.Models;
using _0_Framework.Domain.Sms;

namespace _0_Framework.Apllication.SMS
{
    public interface ISMSService
    {
        Task<SendResult> SendPublicSMS(InputSmsViewModel inputSms);

        Task<SendResult> SendLookUpVerifySMS(InputSmsViewModel inputSms);

        Task<SendResult> SendLookUpForgetPasswordSMS(InputSmsViewModel inputSms);
    }
}
