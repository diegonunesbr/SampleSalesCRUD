using Microsoft.EntityFrameworkCore;
using SalesApp.Application.Interfaces;
using SalesApp.Domain.Entities;
using SalesApp.Infrastructure.DataContext;

namespace SalesApp.Infrastructure.Repositories
{
    public class ProductRepository(SalesAppDataContext Context): IProductRepository
    {

        public void Add(Product entity)
        {
            Context.Products.Add(entity);
        }

        public void Update(Product entity)
        {
            Context.Products.Update(entity);
        }

        public void Delete(Product entity)
        {
            Context.Products.Remove(entity);
        }

        public async Task<int> DeleteById(int id)
        {
            int rows = await Context.Products.Where(x => x.id == id).ExecuteDeleteAsync();
            return rows;
        }

        public async Task<Product?> GetById(int id)
        {
            Product? p = await Context.Products.Where(x => x.id == id).FirstOrDefaultAsync();
            return p;
        }

        public async Task<List<Product>> GetAll(int page, int size, string order)
        {
            var l = await Context.Products
                .OrderWithText(order)
                .Skip(size * (page - 1))
                .Take(size)
                .ToListAsync();
            return l;
        }

        public async Task<List<string>> GetAllCategories()
        {
            List<string> l = await Context.Products.Select(x => x.category).OrderBy(x => x).Distinct().ToListAsync();
            return l;
        }

        public async Task<List<Product>> GetAllWithCategory(string category, int page, int size, string order)
        {
            var l = await Context.Products
                .Where(x => x.category == category)
                .OrderWithText(order)
                .Skip(size * (page - 1))
                .Take(size)
                .ToListAsync();
            return l;
        }

        public async Task<bool> ExistsByTitle(int id, string title)
        {
            return await Context.Products.AnyAsync(x => x.id != id && x.title == title);
        }
    }
}
