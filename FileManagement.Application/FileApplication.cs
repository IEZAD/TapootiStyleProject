using AutoMapper;
using _0_Framework.Apllication.Logger;
using _0_Framework.Apllication.Apllication;
using FileManagement.Application.Contracts.File;

namespace FileManagement.Application
{
    public class FileApplication : TapootiApllication, IFileApplication
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public FileApplication(ILogger logger,
                               IMapper mapper): base(logger, mapper) 
        { 
            _logger = logger;
            _mapper = mapper;
        }
    }
}