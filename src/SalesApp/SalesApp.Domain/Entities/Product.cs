using SalesApp.Domain.Enums;
using SalesApp.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalesApp.Domain.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(1000)]
        public string title { get; set; } = string.Empty;

        [Required]
        public decimal price { get; set; }

        [Required]
        [StringLength(5000)]
        public string description { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string category { get; set; } = string.Empty;

        [StringLength(5000)]
        public string image { get; set; } = string.Empty;

        public Rating rating { get; set; }
    }
}
