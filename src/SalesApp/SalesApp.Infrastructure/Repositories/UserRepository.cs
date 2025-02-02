using Microsoft.EntityFrameworkCore;
using SalesApp.Domain.Entities;
using SalesApp.Infrastructure.DataContext;

namespace SalesApp.Infrastructure.Repositories
{
    public class UserRepository(SalesAppDataContext Context)
    {
        
        public void Add(User entity)
        {
            Context.Users.Add(entity);
        }

        public void Update(User entity)
        {
            Context.Users.Update(entity);
        }

        public int DeleteById(int id)
        {
            int rows = Context.Users.Where(x => x.id == id).ExecuteDelete();
            return rows;
        }

        public async Task<User?> GetById(int id)
        {
            User u = await Context.Users.Where(x => x.id == id).FirstAsync();
            return u;
        }

        public async Task<List<User>> GetAll()
        {
            List<User> l = await Context.Users.ToListAsync();
            return l;
        }
    }
}
