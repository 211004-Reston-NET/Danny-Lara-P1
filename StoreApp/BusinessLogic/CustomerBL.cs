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

        /// <summary>
        /// Gets a list of all the customers in the database
        /// </summary>
        /// <returns>A list of all the customers in the customer table</returns>
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
        /// <summary>
        /// Gets a specific customer by customer ID
        /// </summary>
        /// <param name="p_custId">The customer ID</param>
        /// <returns>The specific customer from the customer table or null if the ID is not found in the table</returns>
        public Customer GetCustomer(int p_custId)
        {
            List<Customer> allCusts = _data.GetAllCustomers();
            foreach (Customer c in allCusts)
            {
                if (c.CustID == p_custId)
                    return c;
            }
            return null;
        }
        /// <summary>
        /// Add a customer to the database
        /// </summary>
        /// <param name="p_cust">The customer to be added</param>
        /// <returns>The customer that was added</returns>
        public Customer Add(Customer p_cust)
        {
            if(p_cust.Name == null || p_cust.Address == null || p_cust.Email == null || p_cust.PhoneNumber == null)
                throw new System.Exception("All customer info must be != null");
            _data.AddCustomer(p_cust);
            return p_cust;
        }
        /// <summary>
        /// Gets all the orders made by a specific customer
        /// </summary>
        /// <param name="p_custId">The customer ID</param>
        /// <returns>A list of orders or null if the customer ID is not found in the database</returns>
        public List<Order> GetOrdersByCustId(int p_custId)
        {
            return _data.GetOrdersByCustId(p_custId);
        }
        /// <summary>
        /// Checks to see if a customer exists in the database
        /// </summary>
        /// <param name="p_custId">The ID of the customer to search for</param>
        /// <returns>True if the customer is found otherwise false</returns>
        public bool CustExists(int p_custId)
        {
            if (_data.GetCustomerByCustId(p_custId) != null)
                return true;
            else
                return false;
        }
    }
}