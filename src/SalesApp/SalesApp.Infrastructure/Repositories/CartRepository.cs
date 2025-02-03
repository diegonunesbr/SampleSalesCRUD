using Microsoft.EntityFrameworkCore;
using SalesApp.Application.Interfaces;
using SalesApp.Domain.Entities;
using SalesApp.Infrastructure.DataContext;

namespace SalesApp.Infrastructure.Repositories
{
    public class CartRepository(SalesAppDataContext Context): ICartRepository
    {

        public void Add(Cart entity)
        {
            Context.Carts.Add(entity);
        }

        public void Update(Cart entity)
        {
            Context.CartItems.Where(x => x.cartId == entity.id).ExecuteDelete();
            Context.Carts.Update(entity);
        }

        public void Delete(Cart entity)
        {
            Context.Carts.Remove(entity);
        }

        public async Task<int> DeleteById(int id)
        {
            int rows = await Context.Carts.Where(x => x.id == id).ExecuteDeleteAsync();
            return rows;
        }

        public async Task<Cart?> GetById(int id)
        {
            Cart? p = await Context.Carts.Where(x => x.id == id).FirstOrDefaultAsync();
            return p;
        }

        public async Task<List<Cart>> GetAll(int page, int size, string order)
        {
            var l = await Context.Carts
                .OrderWithText(order)
                .Skip(size * (page - 1))
                .Take(size)
                .ToListAsync();
            return l;
        }

        public async Task<bool> ExistsByUserAndDate(int id, int userId, DateTime date)
        {
            return await Context.Carts.AnyAsync(x => x.id != id && x.userId == userId && x.date == date);
        }

        public void LoadItems(Cart entity)
        {
            entity.products = Context.CartItems.Where(x => x.cartId == entity.id).AsNoTracking().ToList();
        }
    }
}
