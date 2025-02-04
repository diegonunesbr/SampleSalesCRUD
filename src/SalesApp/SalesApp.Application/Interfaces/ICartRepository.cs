using SalesApp.Domain.Entities;

namespace SalesApp.Application.Interfaces
{
    public interface ICartRepository
    {
        void Add(Cart entity);
        void Update(Cart entity);
        void Delete(Cart entity);
        Task<int> DeleteById(int id);
        Task<Cart?> GetById(int id);
        Task<List<Cart>> GetAll(int page, int size, string order);
        Task<bool> ExistsByUserAndDate(int id, int userId, DateTime date);
        void LoadItems(Cart entity);
    }
}
