using SalesApp.Domain.Entities;

namespace SalesApp.Application.Interfaces
{
    public interface IUserRepository
    {
        void Add(User entity);
        void Update(User entity);
        Task<int> DeleteById(int id);
        Task<User?> GetById(int id);
        Task<List<User>> GetAll();
        Task<bool> ExistsByUserName(int id, string username);
        Task<bool> ExistsByEmail(int id, string email);
    }
}
