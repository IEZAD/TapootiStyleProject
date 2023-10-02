using System.Linq.Expressions;
using _0_Framework.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace _0_Framework.Infrastructure.Common
{
    public class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
            where TEntity : EntityBase
            where TKey : IComparable<TKey>, IEquatable<TKey>
    {
        public RepositoryBase(DbContext databaseContext)
        {
            DatabaseContext = databaseContext ?? throw new ArgumentNullException(paramName: nameof(databaseContext));
            DbSet = DatabaseContext.Set<TEntity>();
        }

        // **********
        protected DbSet<TEntity> DbSet { get; }
        // **********

        // **********
        protected DbContext DatabaseContext { get; }
        // **********

        public virtual async Task SaveChangesAsync()
        {
            await DatabaseContext.SaveChangesAsync();
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            await DbSet.AddAsync(entity);
        }

        public virtual async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities is null)
            {
                throw new ArgumentNullException(paramName: nameof(entities));
            }

            await DbSet.AddRangeAsync(entities);
        }

        protected virtual void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            DbSet.Update(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            await Task.Run(() =>
            {
                DbSet.Update(entity);
            });
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities is null)
            {
                throw new ArgumentNullException(paramName: nameof(entities));
            }

            await Task.Run(() =>
            {
                DbSet.UpdateRange(entities);
            });
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            await Task.Run(() =>
            {
                DbSet.Remove(entity);
            });
        }

        public virtual async Task<bool> DeleteByIdAsync(TKey id)
        {
            TEntity entity = await GetByIdAsync(id);

            if (entity == null)
            {
                return false;
            }

            await DeleteAsync(entity);

            return true;
        }

        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(paramName: nameof(entities));
            }

            await Task.Run(() =>
            {
                DbSet.RemoveRange(entities);
            });
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await DbSet.FindAsync(keyValues: id);
        }

        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.Any(expression);
        }

        public IQueryable<TEntity> GetAllAsNoTracking()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            // ToListAsync -> Extension Method -> using Microsoft.EntityFrameworkCore;
            var result = await DbSet.ToListAsync();

            return result;
        }
    }
}