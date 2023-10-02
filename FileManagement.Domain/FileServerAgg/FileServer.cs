using _0_Framework.Domain.Common;

namespace FileManagement.Domain.FileServerAgg
{
    public class FileServer : EntityBase, IComparable<Guid>, IEquatable<Guid>
    {
        public string Name { get; private set; }

        public bool IsActive { get; private set; }

        public long Capacity { get; private set; }

        public string FTPData { get; private set; }

        public string HttpPath { get; private set; }

        public string HttpDomain { get; private set; }

        public string? Description { get; private set; }

        public ICollection<FileAgg.File> Files { get; private set; }

        protected FileServer()
        {
        }

        public FileServer(string name,
                          long capacity,
                          bool isActive,
                          string ftpData,
                          string httpDomain,
                          string httpPath,
                          string? description)
        {
            Name = name;
            IsActive = isActive;
            Capacity = capacity;
            FTPData = ftpData;
            HttpDomain = httpDomain;
            HttpPath = httpPath;
            Description = description;
            Files = new List<FileAgg.File>();
        }

        public FileServer(Guid id,
                          string name,
                          long capacity,
                          bool isActive,
                          string ftpData,
                          string httpDomain,
                          string httpPath,
                          string description)
        {
            Id = id;
            Name = name;
            IsActive = isActive;
            Capacity = capacity;
            FTPData = ftpData;
            HttpDomain = httpDomain;
            HttpPath = httpPath;
            Description = description;
            Files = new List<FileAgg.File>();
        }


        public void Update(string name,
                           long capacity,
                           bool isActive,
                           string ftpData,
                           string httpDomain,
                           string httpPath,
                           string? description)
        {
            Name = name;
            IsActive = isActive;
            Capacity = capacity;
            FTPData = ftpData;
            HttpDomain = httpDomain;
            HttpPath = httpPath;
            Description = description;
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