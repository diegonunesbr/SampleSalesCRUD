using Microsoft.EntityFrameworkCore;
using SalesApp.Application.Interfaces;
using SalesApp.Domain.Entities;
using SalesApp.Infrastructure.DataContext;

namespace SalesApp.Infrastructure.Repositories
{
    public class UserRepository(SalesAppDataContext Context): IUserRepository
    {
        
        public void Add(User entity)
        {
            Context.Users.Add(entity);
        }

        public void Update(User entity)
        {
            Context.Users.Update(entity);
        }

        public async Task<int> DeleteById(int id)
        {
            int rows = await Context.Users.Where(x => x.id == id).ExecuteDeleteAsync();
            return rows;
        }

        public async Task<User?> GetById(int id)
        {
            User? u = await Context.Users.Where(x => x.id == id).FirstOrDefaultAsync();
            return u;
        }

        public async Task<List<User>> GetAll()
        {
            List<User> l = await Context.Users.ToListAsync();
            return l;
        }

        public async Task<bool> ExistsByUserName(int id, string username)
        {
            return await Context.Users.AnyAsync(x => x.id != id && x.username == username);
        }

        public async Task<bool> ExistsByEmail(int id, string email)
        {
            return await Context.Users.AnyAsync(x => x.id != id && x.email == email);
        }
    }
}
