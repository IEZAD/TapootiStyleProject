namespace _0_Framework.Domain.Common
{
    public interface IUnitOfWork : IQueryUnitOfWork
    {
        Task SaveAsync();
    }
}
