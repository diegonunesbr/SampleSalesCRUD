using System.Text.Json.Serialization;

namespace SalesApp.Domain.Entities
{
    public class CartItem
    {
        public int cartId { get; set; }

        [JsonIgnore]
        public Cart cart { get; set; }

        public int productId { get; set; }

        [JsonIgnore]
        public Product product { get; set; }

        public int quantity { get; set; }
    }
}
