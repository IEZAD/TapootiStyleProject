using System.Net;

namespace _0_Framework.Apllication.Messaging.ApiWrapper
{
    public class ApiWrapperResponse
    {
        public bool Failed { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }

        public List<string> Messages { get; set; } = new();

        public ApiWrapperResponse()
        {

        }

        public ApiWrapperResponse(Exception ex)
        {
            Failed = true;
            AddMessage(ex.Message);
            HttpStatusCode = HttpStatusCode.BadRequest;
        }

        public ApiWrapperResponse(bool failed, HttpStatusCode httpStatusCode, string message)
        {
            Failed = failed;
            AddMessage(message);
            HttpStatusCode = httpStatusCode;
        }

        public ApiWrapperResponse(bool failed, HttpStatusCode httpStatusCode, List<string> messages)
        {
            Failed = failed;
            Messages.AddRange(messages);
            HttpStatusCode = httpStatusCode;
        }

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }
    }

    public class ApiWrapperResponse<TEntity> : ApiWrapperResponse where TEntity : class
    {
        public TEntity Entity { get; set; }

        public ApiWrapperResponse(TEntity data)
        {
            Failed = false;
            Entity = data;
            HttpStatusCode = HttpStatusCode.OK;
            if (data is null)
            {
                HttpStatusCode = HttpStatusCode.BadRequest;
                AddMessage("Data_Is_Empty");
            }
            else
            {
                AddMessage("Data_Loaded");
            }
        }

        public ApiWrapperResponse(Exception ex)
        {
            Failed = true;
            Entity = default;
            AddMessage(ex.Message);
            HttpStatusCode = HttpStatusCode.BadRequest;
        }

        public ApiWrapperResponse(bool failed, HttpStatusCode httpStatusCode, string messages)
        {
            Failed = failed;
            AddMessage(messages);
            HttpStatusCode = httpStatusCode;
        }

        public ApiWrapperResponse(TEntity data, bool failed, HttpStatusCode httpStatusCode, string message)
        {
            Entity = data;
            Failed = failed;
            AddMessage(message);
            HttpStatusCode = httpStatusCode;
            if (data is null)
            {
                HttpStatusCode = HttpStatusCode.BadRequest;
                AddMessage("Data_Is_Empty");
            }
            else
            {
                AddMessage("Data_Loaded");
            }
        }

        public ApiWrapperResponse(TEntity data, bool failed, HttpStatusCode httpStatusCode, List<string> messages)
        {
            Entity = data;
            Failed = failed;
            Messages.AddRange(messages);
            HttpStatusCode = httpStatusCode;
            if (data is null)
            {
                HttpStatusCode = HttpStatusCode.BadRequest;
                AddMessage("Data_Is_Empty");
            }
            else
            {
                AddMessage("Data_Loaded");
            }
        }
    }
}