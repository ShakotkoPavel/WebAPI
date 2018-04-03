using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class Cart
    {
        public int CartId { get; set; }

        public DateTime DataCreated { get; set; }

        public int MyProperty { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Cart()
        {
            Products = new List<Product>();
        }
    }
}