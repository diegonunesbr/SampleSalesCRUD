using System.Text.Json.Serialization;

namespace SalesApp.Domain.Entities
{
    public class Cart
    {
        public int id { get; set; }

        public int userId { get; set; }

        [JsonIgnore]
        public User user { get; set; }

        public DateTime date { get; set; }

        public IList<CartItem> products { get; set; }
    }
}
