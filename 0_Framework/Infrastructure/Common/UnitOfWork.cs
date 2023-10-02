using _0_Framework.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace _0_Framework.Infrastructure.Common
{
    public abstract class UnitOfWork<TEntity> : QueryUnitOfWork<TEntity>, IUnitOfWork where TEntity : DbContext
    {
        public UnitOfWork(Options options) : base(options: options)
        {
        }

        public async Task SaveAsync()
        {
            await DatabaseContext.SaveChangesAsync();
        }
    }
}
