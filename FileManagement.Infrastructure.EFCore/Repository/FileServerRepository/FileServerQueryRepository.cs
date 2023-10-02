using _0_Framework.Infrastructure.Common;
using FileManagement.Domain.FileServerAgg;

namespace FileManagement.Infrastructure.EFCore.Repository.FileServerRepository
{
    public class FileServerQueryRepository : QueryRepositoryBase<FileServer, Guid>, IFileServerQueryRepository
    {
        private readonly FileContext _context;

        public FileServerQueryRepository(FileContext context) : base(context)
        {
            _context = context;
        }
    }
}