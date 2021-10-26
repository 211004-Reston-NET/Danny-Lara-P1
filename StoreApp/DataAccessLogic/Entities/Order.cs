using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLogic.Entities
{
    public partial class Order
    {
        public int OrderNumber { get; set; }
        public int? CustId { get; set; }
        public int? StoreId { get; set; }
        public decimal? OrderTotalPrice { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual Store Store { get; set; }
    }
}
