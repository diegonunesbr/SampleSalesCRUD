using SalesApp.Domain.Entities;
using System.Text.Json.Serialization;

namespace SalesApp.Application.Sales.Commands
{
    public class SaleItemCommand
    {
        public int productId { get; set; }

        [JsonIgnore]
        public Product? product { get; set; }

        public int quantity { get; set; }
    }
}
