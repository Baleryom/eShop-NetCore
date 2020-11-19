using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Domain.Models
{
    public class ContactDetail
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int CustomerId { get; set; }
    }
}
