using SalesApp.Domain.Entities;

namespace SalesApp.Application.Sales.Events
{
    public class SaleCreatedEvent
    {
        public Sale sale {  get; set; }
    }
}
