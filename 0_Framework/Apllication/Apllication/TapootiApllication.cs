using AutoMapper;
using System.Net;
using _0_Framework.Apllication.Logger;
using _0_Framework.Apllication.Resources;
using _0_Framework.Apllication.Messaging.ApiWrapper;

namespace _0_Framework.Apllication.Apllication
{
    public class TapootiApllication
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public TapootiApllication(ILogger logger,
                                  IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        protected ApiWrapperResponse ExceptionHandler(Exception exception)
        {
            _logger.Error(exception);
            return new ApiWrapperResponse(true, HttpStatusCode.InternalServerError, ApplicationMessages.Error500);
        }

        protected ApiWrapperResponse<T> ExceptionHandler<T>(Exception exception, T entity) where T : class
        {
            _logger.Error(exception);
            return new ApiWrapperResponse<T>(true, HttpStatusCode.InternalServerError, ApplicationMessages.Error500);
        }
    }
}