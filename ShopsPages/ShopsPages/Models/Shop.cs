using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopsPages.Models
{
    public class Shop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Address { get; set; } = "";
        public string WorkingHours { get; set; } = "";
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
