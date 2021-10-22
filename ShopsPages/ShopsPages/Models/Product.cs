using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopsPages.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ShopId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Shop Shop { get; set; }
    }
}
