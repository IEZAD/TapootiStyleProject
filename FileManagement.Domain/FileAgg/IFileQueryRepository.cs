using _0_Framework.Domain.Common;

namespace FileManagement.Domain.FileAgg
{
    public interface IFileQueryRepository : IQueryRepository<File, Guid>
    {
    }
}