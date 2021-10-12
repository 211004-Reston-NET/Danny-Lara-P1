using System.Collections.Generic;
using DataAccessLogic;
using Models;

namespace BusinessLogic
{
    public class CustomerBL
    {
        private DataCollection _data;
        public CustomerBL(DataCollection p_data)
        {
            _data = p_data;
        }

        public List<Customer> GetAll()
        {
            return _data.GetAllCustomers();
        }
        public Customer Add(Customer p_cust)
        {
            _data.AddCustomer(p_cust);
            return p_cust;
        }
    }
}