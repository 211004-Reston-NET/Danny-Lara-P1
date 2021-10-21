using System.Collections.Generic;
using DataAccessLogic;
using Models;

namespace BusinessLogic
{
    public class CustomerBL
    {
        private CustomerRepo _data;
        public CustomerBL(CustomerRepo p_data)
        {
            _data = p_data;
        }

        public List<Customer> GetAll()
        {
            List<object> list = _data.GetAll();
            List<Customer> custList = new List<Customer>();
            foreach (object item in list)
            {
                custList.Add((Customer)item);
            }
            return custList;
        }
        public Customer Add(Customer p_cust)
        {
            if(p_cust.Name == null || p_cust.Address == null || p_cust.Email == null || p_cust.PhoneNumber == null)
                throw new System.Exception("All customer info must be != null");
            _data.Add(p_cust);
            return p_cust;
        }
    }
}