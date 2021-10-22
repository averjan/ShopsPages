﻿namespace ShopsPages.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Address { get; set; } = "";
        public string WorkingHours { get; set; } = "";
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
