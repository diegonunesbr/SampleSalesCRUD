using SalesApp.Domain.Entities;

namespace SalesApp.Application.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product entity);
        void Update(Product entity);
        Task<int> DeleteById(int id);
        Task<Product?> GetById(int id);
        Task<List<Product>> GetAll(int page, int size, string order);
        Task<List<string>> GetAllCategories();
        Task<List<Product>> GetAllWithCategory(string category, int page, int size, string order);
        Task<bool> ExistsByTitle(int id, string title);
    }
}
