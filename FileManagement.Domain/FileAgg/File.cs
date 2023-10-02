using _0_Framework.Domain.Common;
using FileManagement.Domain.FileServerAgg;

namespace FileManagement.Domain.FileAgg
{
    public class File : EntityBase, IComparable<Guid>, IEquatable<Guid>
    {
        public string Path { get; private set; }

        public string Title { get; private set; }

        public bool IsPrivate { get; private set; }

        public string FileName { get; private set; }

        public string MimeType { get; private set; }

        public long SizeOnDisk { get; private set; }

        public Guid? AccountId { get; private set; }

        public Guid FileServerId { get; private set; }

        public virtual FileServer FileServer { get; private set; }

        protected File()
        {
        }

        public File(string path,
                    string title,
                    string fileName,
                    string mimeType,
                    bool isPrivate,
                    long sizeOnDisk,
                    Guid fileServerId,
                    Guid? accountId)
        {
            Path = path;
            Title = title;
            FileName = fileName;
            MimeType = mimeType;
            IsPrivate = isPrivate;
            AccountId = accountId;
            SizeOnDisk = sizeOnDisk;
            FileServerId = fileServerId;
        }

        public void Update(string path,
                           string title,
                           string fileName,
                           string mimeType,
                           bool isPrivate,
                           long sizeOnDisk,
                           Guid fileServerId,
                           Guid? accountId)
        {
            Path = path;
            Title = title;
            FileName = fileName;
            MimeType = mimeType;
            IsPrivate = isPrivate;
            AccountId = accountId;
            SizeOnDisk = sizeOnDisk;
            FileServerId = fileServerId;
        }

        public int CompareTo(Guid other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Guid other)
        {
            throw new NotImplementedException();
        }
    }
}