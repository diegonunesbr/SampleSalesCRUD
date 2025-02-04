using SalesApp.Domain.Entities;
using System.Text.Json.Serialization;

namespace SalesApp.Application.Carts.Commands
{
    public class UseCartItemCommand
    {
        public int productId { get; set; }

        [JsonIgnore]
        public Product? product { get; set; }

        public int quantity { get; set; }
    }
}
