using System.Net;

namespace _0_Framework.Apllication.Messaging.ApiWrapper
{
    public class ApiWrapperMessages
    {
        public ApiWrapperMessages()
        {
        }

        public ApiWrapperMessages(Exception ex)
        {
            Message = ex.Message;
            MessageType = ApiWrapperMessageType.Error;
        }

        public ApiWrapperMessages(string message,
                                  ApiWrapperMessageType messageType)
        {
            Message = message;
            MessageType = messageType;
        }

        public ApiWrapperMessages(string message,
                                  HttpStatusCode httpStatusCode,
                                  ApiWrapperMessageType messageType)
        {
            Message = message;
            MessageType = messageType;
            HttpStatusCode = httpStatusCode;
        }

        public string Message { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }

        public ApiWrapperMessageType MessageType { get; set; }
    }
}
