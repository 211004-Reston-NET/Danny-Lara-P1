using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLogic.Entities
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int ProductQuantity { get; set; }

        public virtual Store Store { get; set; }
    }
}
