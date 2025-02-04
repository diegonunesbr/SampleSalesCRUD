using System.Text.Json.Serialization;

namespace SalesApp.Domain.Entities
{
    public class SaleItem
    {
        [JsonIgnore]
        public int saleId { get; set; }

        [JsonIgnore]
        public Sale sale { get; set; }

        public int productId { get; set; }

        [JsonIgnore]
        public Product product { get; set; }

        public int quantity { get; set; }

        public decimal price { get; set; }

        public decimal discount { get; set; }

        public decimal total { get; set; }

        public void CalculateItemDiscount()
        {
            decimal percDiscount;
            
            if(quantity >= 10)
            {
                percDiscount = 20;
            } else if(quantity >= 4)
            {
                percDiscount = 10;
            } else
            {
                percDiscount = 0;
            }

            price = product.price;
            decimal subTotal = quantity * price;

            discount = Math.Round(subTotal * percDiscount / (decimal)100.0, 2);
            total = subTotal - discount;
        }
    }
}
