using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class OrderVM
    {
        public OrderVM()
        {}
        public OrderVM(Order p_order)
        {
            this.OrderNumber = p_order.OrderNumber;
            this.CustId = p_order.CustID;
            this.StoreId = p_order.StoreID;
            this.TotalPrice = p_order.TotalPrice;
        }
        public int OrderNumber { get; set; }
        public int CustId { get; set; }
        public int StoreId { get; set; }
        public double TotalPrice { get; set; }
    }
}
