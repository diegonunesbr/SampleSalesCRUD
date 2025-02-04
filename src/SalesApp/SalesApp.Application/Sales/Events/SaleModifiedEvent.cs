using SalesApp.Domain.Entities;

namespace SalesApp.Application.Sales.Events
{
    public class SaleModifiedEvent
    {
        public Sale sale { get; set; }
    }
}
