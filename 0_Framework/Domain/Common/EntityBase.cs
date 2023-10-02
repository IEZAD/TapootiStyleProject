using _0_Framework.Apllication.Extensions;

namespace _0_Framework.Domain.Common
{
    public class EntityBase
    {
        // **********
        public Guid Id { get; set; }
        // **********

        // **********
        public DateTime CreationDate { get; set; }
        // **********

        public EntityBase()
        {
            CreationDate = DateTime.Now;
            Id = new Guid().SequentialGuid();
        }
    }

    public class EntityBase<TKey>
    {
        // **********
        public TKey Id { get; set; }
        // **********

        // **********
        public DateTime CreationDate { get; set; }
        // **********

        public EntityBase()
        {
            CreationDate = DateTime.Now;
        }
    }
}
