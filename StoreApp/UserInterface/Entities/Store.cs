using System;
using System.Collections.Generic;

#nullable disable

namespace UserInterface.Entities
{
    public partial class Store
    {
        public Store()
        {
            Orders = new HashSet<Order>();
            Products = new HashSet<Product>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
