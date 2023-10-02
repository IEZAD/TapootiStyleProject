using System.Linq.Expressions;

namespace _0_Framework.Domain.Common
{
    public interface IRepository<TEntity, TKey> : IQueryRepository<TEntity, TKey>
        where TEntity : EntityBase
        where TKey : IComparable<TKey>, IEquatable<TKey>
    {
        Task SaveChangesAsync();

        Task CreateAsync(TEntity entity);

        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        Task UpdateAsync(TEntity entity);

        Task UpdateRangeAsync(IEnumerable<TEntity> entities);

        Task DeleteAsync(TEntity entity);

        Task<bool> DeleteByIdAsync(TKey id);

        Task DeleteRangeAsync(IEnumerable<TEntity> entity);

        bool Exists(Expression<Func<TEntity, bool>> expression);
    }
}
