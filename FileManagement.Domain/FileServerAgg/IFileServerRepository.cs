using _0_Framework.Domain.Common;

namespace FileManagement.Domain.FileServerAgg
{
    public interface IFileServerRepository : IRepository<FileServer, Guid>
    {
    }
}