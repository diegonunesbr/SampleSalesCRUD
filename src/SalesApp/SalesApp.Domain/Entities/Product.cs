using SalesApp.Domain.ValueObjects;
using System.Text.Json.Serialization;

namespace SalesApp.Domain.Entities
{
    public class Product
    {
        public int id { get; set; }

        public string title { get; set; } = string.Empty;

        public decimal price { get; set; }

        public string? description { get; set; } = string.Empty;

        public string category { get; set; } = string.Empty;

        public string? image { get; set; } = string.Empty;

        public Rating rating { get; set; }

        [JsonIgnore]
        public ICollection<CartItem> carts { get; set; }

        [JsonIgnore]
        public ICollection<SaleItem> sales { get; set; }
    }
}
