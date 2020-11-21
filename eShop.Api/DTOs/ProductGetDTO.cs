using eShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Api.Controllers
{
    public class ProductGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Supplier Supplier { get; set; }
        public string PhotoUrl { get; set; }

    }
}
