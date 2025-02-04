using SalesApp.Domain.Enums;
using System.Text.Json.Serialization;

namespace SalesApp.Domain.Entities
{
    public class Sale
    {
        public int id { get; set; }

        public DateTime date { get; set; }

        public int userId { get; set; }

        public decimal totalProductAmount { get; set; }
        public decimal totalDiscountAmount { get; set;}
        public decimal totalSaleAmount { get; set; }

        public string branch { get; set; }

        public List<SaleItem> products { get; set; }

        public SaleStatus status { get; set; }



        [JsonIgnore]
        public User user { get; set; }


        public void CalculateSaleDiscount()
        {
            foreach(var item in products)
            {
                item.CalculateItemDiscount();
            }

            totalDiscountAmount = products.Sum(x => x.discount);
            totalProductAmount = products.Sum(x => x.quantity * x.price);
            totalSaleAmount = products.Sum(x => x.total);
        }
    }
}
