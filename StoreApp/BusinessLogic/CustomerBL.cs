using System.Collections.Generic;
using DataAccessLogic;
using Models;

namespace BusinessLogic
{
    public class CustomerBL
    {
        private Repository _data;
        public CustomerBL(Repository p_data)
        {
            _data = p_data;
        }

        public List<Customer> GetAll()
        {
            return _data.GetAllCustomers();
        }
        public Customer Add(Customer p_cust)
        {
            if(p_cust.Name == null || p_cust.Address == null || p_cust.Email == null || p_cust.PhoneNumber == null)
                throw new System.Exception("All customer info must be != null");
            _data.AddCustomer(p_cust);
            return p_cust;
        }
    }
}