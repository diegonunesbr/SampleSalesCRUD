using SalesApp.Domain.Entities;

namespace SalesApp.Application.Interfaces
{
    public interface ISaleRepository
    {
        void Add(Sale entity);
        void Update(Sale entity);
        Task<Sale?> GetById(int id);
        void LoadItems(Sale entity);
    }
}
