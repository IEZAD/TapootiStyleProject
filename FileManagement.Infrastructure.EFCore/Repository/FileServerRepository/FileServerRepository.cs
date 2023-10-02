using _0_Framework.Infrastructure.Common;
using FileManagement.Domain.FileServerAgg;

namespace FileManagement.Infrastructure.EFCore.Repository.FileServerRepository
{
    public class FileServerRepository : RepositoryBase<FileServer, Guid>, IFileServerRepository
    {
        private readonly FileContext _context;

        public FileServerRepository(FileContext context) : base(context)
        {
            _context = context;
        }
    }
}