using Microsoft.EntityFrameworkCore;
using SalesApp.Domain.Entities;
using SalesApp.Infrastructure.DataContext;

namespace SalesApp.Infrastructure.Repositories
{
    public class ProductRepository(SalesAppDataContext Context)
    {
        
        public void Add(Product entity)
        {
            Context.Products.Add(entity);
        }

        public void Update(Product entity)
        {
            Context.Products.Update(entity);
        }

        public int DeleteById(int id)
        {
            int rows = Context.Products.Where(x => x.id == id).ExecuteDelete();
            return rows;
        }

        public async Task<Product?> GetById(int id)
        {
            Product u = await Context.Products.Where(x => x.id == id).FirstAsync();
            return u;
        }

        public async Task<List<Product>> GetAll()
        {
            List<Product> l = await Context.Products.ToListAsync();
            return l;
        }

        public async Task<List<string>> GetAllCategories()
        {
            List<string> l = await Context.Products.Select(x => x.category).Distinct().ToListAsync();
            return l;
        }

        public async Task<List<Product>> GetAllWithCategory(string category)
        {
            List<Product> l = await Context.Products.Where(x => x.category == category).ToListAsync();
            return l;
        }
    }
}
