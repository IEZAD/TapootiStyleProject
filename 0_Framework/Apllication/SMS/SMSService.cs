using Kavenegar;
using Kavenegar.Core.Models;
using _0_Framework.Domain.Sms;
using Microsoft.Extensions.Options;

namespace _0_Framework.Apllication.SMS
{
    public class SMSService : ISMSService
    {
        protected KavenegarApi KavenegarApi { get; private set; }

        private readonly KavenegarInfoViewModel _kavenegarInfo;

        public SMSService(IOptions<KavenegarInfoViewModel> kavenegarInfo)
        {
            _kavenegarInfo = kavenegarInfo.Value;
            KavenegarApi = new KavenegarApi(_kavenegarInfo.ApiKey);
        }

        public async Task<SendResult> SendPublicSMS(InputSmsViewModel inputSms)
        {
            try
            {
                return await KavenegarApi.Send(_kavenegarInfo.Sender, inputSms.Number, inputSms.Message);
            }
            catch (Kavenegar.Core.Exceptions.ApiException ex)
            {
                // در صورتی که خروجی وب سرویس 200 نباشد این خطارخ می دهد.
                Console.WriteLine(ex);
                throw;
            }
            catch (Kavenegar.Core.Exceptions.HttpException ex)
            {
                // در زمانی که مشکلی در برقرای ارتباط با وب سرویس وجود داشته باشد این خطا رخ می دهد
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<SendResult> SendLookUpVerifySMS(InputSmsViewModel inputSms)
        {
            try
            {
                var template = _kavenegarInfo.Templates?.FirstOrDefault(x => x.Contains("VerifyTapootiStyleAccount"));
                return await KavenegarApi.VerifyLookup(inputSms.Number, inputSms.Token1, inputSms.Token2, inputSms.Token3, template);
            }
            catch (Kavenegar.Core.Exceptions.ApiException ex)
            {
                // در صورتی که خروجی وب سرویس 200 نباشد این خطارخ می دهد.
                Console.WriteLine(ex);
                throw;
            }
            catch (Kavenegar.Core.Exceptions.HttpException ex)
            {
                // در زمانی که مشکلی در برقرای ارتباط با وب سرویس وجود داشته باشد این خطا رخ می دهد
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<SendResult> SendLookUpForgetPasswordSMS(InputSmsViewModel inputSms)
        {
            try
            {
                var template = _kavenegarInfo.Templates?.FirstOrDefault(x => x.Contains("ForgetPasswordTapootiStyleAccount"));
                return await KavenegarApi.VerifyLookup(inputSms.Number, inputSms.Token1, inputSms.Token2, inputSms.Token3, template);
            }
            catch (Kavenegar.Core.Exceptions.ApiException ex)
            {
                // در صورتی که خروجی وب سرویس 200 نباشد این خطارخ می دهد.
                Console.WriteLine(ex);
                throw;
            }
            catch (Kavenegar.Core.Exceptions.HttpException ex)
            {
                // در زمانی که مشکلی در برقرای ارتباط با وب سرویس وجود داشته باشد این خطا رخ می دهد
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
