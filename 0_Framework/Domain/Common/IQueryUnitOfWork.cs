namespace _0_Framework.Domain.Common
{
    public interface IQueryUnitOfWork : IDisposable
    {
        bool IsDisposed { get; }
    }
}
