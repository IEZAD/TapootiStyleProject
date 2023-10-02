using FileManagement.Domain.FileAgg;
using _0_Framework.Infrastructure.Common;

namespace FileManagement.Infrastructure.EFCore.Repository.FileRepository
{
    public class FileRepository : RepositoryBase<Domain.FileAgg.File, Guid>, IFileRepository
    {
        private readonly FileContext _context;

        public FileRepository(FileContext context) : base(context)
        {
            _context = context;
        }
    }
}