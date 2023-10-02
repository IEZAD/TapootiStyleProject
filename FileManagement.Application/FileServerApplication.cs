using AutoMapper;
using _0_Framework.Apllication.Logger;
using _0_Framework.Apllication.Apllication;
using FileManagement.Application.Contracts.FileServer;

namespace FileManagement.Application
{
    public class FileServerApplication : TapootiApllication, IFileServerApplication
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public FileServerApplication(ILogger logger,
                                     IMapper mapper) : base(logger, mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
    }
}