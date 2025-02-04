using SalesApp.Domain.Entities;

namespace SalesApp.Application.Sales.Events
{
    internal class SaleCancelledEvent
    {
        public Sale sale { get; set; }
    }
}
