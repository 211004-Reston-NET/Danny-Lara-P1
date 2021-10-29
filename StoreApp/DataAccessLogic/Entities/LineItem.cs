using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLogic.Entities
{
    public partial class LineItem
    {
        public int LineItemId { get; set; }
        public int OrderNumber { get; set; }
        public int ProductId { get; set; }
        public int LineItemQuantity { get; set; }

        public virtual Order OrderNumberNavigation { get; set; }
        public virtual Product Product { get; set; }
    }
}
