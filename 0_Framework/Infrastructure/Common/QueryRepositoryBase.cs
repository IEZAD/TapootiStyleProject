using _0_Framework.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace _0_Framework.Infrastructure.Common
{
    public abstract class QueryRepositoryBase<TEntity, TKey> : IQueryRepository<TEntity, TKey>
            where TEntity : EntityBase
            where TKey : IComparable<TKey>, IEquatable<TKey>
    {

        // **********
        protected DbSet<TEntity> DbSet { get; }

        // **********
        protected DbContext DatabaseContext { get; }
        // **********

        // **********
        protected IQueryable<TEntity> DbSetAsNoTracking { get; }
        // **********

        protected QueryRepositoryBase(DbContext databaseContext) : base()
        {
            DatabaseContext = databaseContext ?? throw new ArgumentNullException(paramName: nameof(databaseContext));
            DbSet = databaseContext.Set<TEntity>();
            DbSetAsNoTracking = DbSet.AsNoTracking();
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await DbSet.FindAsync(keyValues: id);
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            // ToListAsync -> Extension Method -> using Microsoft.EntityFrameworkCore;
            var result = await DbSet.ToListAsync();
            return result;
        }

        public virtual IQueryable<TEntity> GetAllAsNoTracking()
        {
            // ToListAsync -> Extension Method -> using Microsoft.EntityFrameworkCore;
            var result = DbSet.AsNoTracking().AsQueryable();
            return result;
        }
    }
}