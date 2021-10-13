using System.Collections.Generic;

namespace Models
{
    public class Customer
    {
        private string name;
        private string address;
        private string email;
        private string phoneNumber;
        private List<Order> orders;

        public Customer(){}
        
        public Customer(string custName, string custAddress, string custEmail, string custPhone)
        {
            name = custName;
            address = custAddress;
            email = custEmail;
            phoneNumber = custPhone;
            orders = new List<Order>();
        }

        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public List<Order> Orders { get => orders; set => orders = value; }

        public override string ToString()
        {
            return $"Name:\t\t{Name}\nAddresss:\t{Address}\nEmail:\t\t{Email}\nPhone#:\t\t{PhoneNumber}";
        }
    }
}