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
            return _data.GetAllCustomers();
        }
        public Customer Add(Customer p_cust)
        {
            if(p_cust.Name == null || p_cust.Address == null || p_cust.Email == null || p_cust.PhoneNumber == null)
                throw new System.Exception("All customer info must be != null");
            _data.AddCustomer(p_cust);
            return p_cust;
        }
        /*
        public List<object> GetAll()
        {
            return _data.GetAll();
        }

        public object Add(object o)
        {
            Customer c = (Customer)o;
            if(c.Name == null || c.Address == null || c.Email == null || c.PhoneNumber == null)
                throw new System.Exception("All customer info must be != null");
            _data.Add(o);
            return o;
        }

        public void Update(object o)
        {
            throw new System.NotImplementedException();
        }*/
    }
}