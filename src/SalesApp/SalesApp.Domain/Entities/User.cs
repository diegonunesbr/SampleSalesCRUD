using SalesApp.Domain.Enums;
using SalesApp.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalesApp.Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(300)]
        public string email { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string username { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string password { get; set; } = string.Empty;
        public Name name { get; set; }

        public Address address { get; set; }

        [Required]
        [StringLength(30)]
        public string phone { get; set; } = string.Empty;

        public UserStatus status { get; set; }

        public UserRole role { get; set; }
    }
}
