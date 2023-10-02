namespace _0_Framework.Domain.Common
{
    public interface IQueryRepository<TEntity, TKey>
        where TEntity : EntityBase
        where TKey : IComparable<TKey>, IEquatable<TKey>
    {
        Task<IList<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(TKey id);

        IQueryable<TEntity> GetAllAsNoTracking();
    }
}