using _0_Framework.Domain.Common;

namespace FileManagement.Domain.FileAgg
{
    public interface IFileRepository : IRepository<File, Guid>
    {
    }
}