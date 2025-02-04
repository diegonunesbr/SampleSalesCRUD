using Microsoft.EntityFrameworkCore;
using SalesApp.Application.Interfaces;
using SalesApp.Domain.Entities;
using SalesApp.Infrastructure.DataContext;

namespace SalesApp.Infrastructure.Repositories
{
    public class SaleRepository(SalesAppDataContext Context): ISaleRepository
    {

        public void Add(Sale entity)
        {
            Context.Sales.Add(entity);
        }

        public void Update(Sale entity)
        {
            Context.SaleItems.Where(x => x.saleId == entity.id).ExecuteDelete();
            Context.Sales.Update(entity);
        }

        public async Task<Sale?> GetById(int id)
        {
            Sale? s = await Context.Sales.Where(x => x.id == id).FirstOrDefaultAsync();
            return s;
        }

        public void LoadItems(Sale entity)
        {
            entity.products = Context.SaleItems.Where(x => x.saleId == entity.id).AsNoTracking().ToList();

            foreach(var item in entity.products)
            {
                item.product = Context.Products.Where(x => x.id == item.productId).AsNoTracking().First();
            }
        }
    }
}
