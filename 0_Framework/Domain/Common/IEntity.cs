namespace _0_Framework.Domain.Common
{
    public interface IEntity
    {
    }

    public interface IEntity<TKey> : IEntity
        where TKey : IComparable<TKey>, IEquatable<TKey>
    {
        // **********
        public TKey Id { get; set; }
        // **********

        // **********
        public DateTime CreationDate { get; set; }
        // **********
    }
}
