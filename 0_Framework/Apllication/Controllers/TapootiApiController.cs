using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace _0_Framework.Apllication.Controllers
{
    [ApiController]
    public class TapootiApiController : ControllerBase
    {
        protected ObjectResult TapootiObjectResult(dynamic baseResponse)
        {
            return new ObjectResult(baseResponse);
        }

        protected ObjectResult TapootiObjectResult(BaseObjectResultView baseObjectResultView)
        {
            return new ObjectResult(baseObjectResultView);
        }

        protected Guid UserId
        {
            get
            {
                return new Guid(HttpContext.User.Claims.Where(x => x.Type == "UserId").SingleOrDefault().Value);
            }
        }
    }
    public class BaseObjectResultView
    {
        public bool Failed { get; set; }

        public object Result { get; set; }

        public object Message { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
