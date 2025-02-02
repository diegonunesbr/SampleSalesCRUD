namespace SalesApp.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken ct = default);
    }
}
