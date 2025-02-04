using SalesApp.Domain.Entities;

namespace SalesApp.Application.Sales.Events
{
    internal class ItemCancelledEvent
    {
        public Sale sale { get; set; }
        public SaleItem cancelledItem { get; set; }
    }
}
