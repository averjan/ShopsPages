using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopsPages.Models
{
    public class Shop
    {
        public int ShopId { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string WorkingHours { get; set; } = "";
        public ICollection<Product> Products { get; set; }
    }
}
