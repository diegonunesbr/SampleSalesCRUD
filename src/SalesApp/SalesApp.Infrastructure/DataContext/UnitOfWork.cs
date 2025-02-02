using SalesApp.Application.Interfaces;

namespace SalesApp.Infrastructure.DataContext
{
    public class UnitOfWork(SalesAppDataContext Context): IUnitOfWork
    {
        public async Task<int> CommitAsync(CancellationToken ct = default)
        {
            return await Context.SaveChangesAsync(ct);
        }
    }
}
