using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class LineItemVM
    {
        public LineItemVM()
        {
        }
        public LineItemVM(LineItems p_lineItem)
        {
            this.LineItemId = p_lineItem.LineItemId;
            this.OrderNumber = p_lineItem.OrderNumber;
            this.ProductID = p_lineItem.ProductID;
            this.Quantity = p_lineItem.Quantity;
            this.ProductName = p_lineItem.Product.Name;
            this.Price = p_lineItem.Product.Price;
        }
        public int LineItemId { get; set; }
        public int OrderNumber { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }
}