using FileManagement.Domain.FileAgg;
using _0_Framework.Infrastructure.Common;

namespace FileManagement.Infrastructure.EFCore.Repository.FileRepository
{
    public class FileQueryRepository : QueryRepositoryBase<Domain.FileAgg.File, Guid>, IFileQueryRepository
    {
        private readonly FileContext _context;

        public FileQueryRepository(FileContext context) : base(context)
        {
            _context = context;
        }
    }
}