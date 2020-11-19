using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Domain.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public double TotalPrice { get; set; }
        public List<Product> Products { get; set; }
    }
}
