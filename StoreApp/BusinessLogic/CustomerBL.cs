using System.Collections.Generic;
using DataAccessLogic;
using Models;

namespace BusinessLogic
{
    public class CustomerBL //: IBL
    {
        private CloudRepo _data;
        public CustomerBL(CloudRepo p_data)
        {
            _data = p_data;
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = _data.GetAllCustomers();
            foreach (Customer c in customers)
            {
                c.Orders = _data.GetOrdersByCustId(c.CustID);
                foreach (Order o in c.Orders)
                {
                    o.Items = _data.GetLineItemsByOrderNum(o.OrderNumber);
                    foreach (LineItems item in o.Items)
                    {
                        item.Product = _data.GetProductByProductId(item.ProductID);
                    }
                }
            }
            return customers;
        }
        public Customer Add(Customer p_cust)
        {
            if(p_cust.Name == null || p_cust.Address == null || p_cust.Email == null || p_cust.PhoneNumber == null)
                throw new System.Exception("All customer info must be != null");
            _data.AddCustomer(p_cust);
            return p_cust;
        }
        public List<Order> GetOrdersByCustId(int p_custId)
        {
            return _data.GetOrdersByCustId(p_custId);
        }
        public bool CustExists(int p_custId)
        {
            if (_data.GetCustomerByCustId(p_custId) != null)
                return true;
            else
                return false;
        }
    }
}