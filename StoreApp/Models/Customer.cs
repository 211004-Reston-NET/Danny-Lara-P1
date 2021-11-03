using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using System.Net.Mail;

namespace Models
{
    public class Customer
    {
        private int _custID;
        private string _name;
        private string _address;
        private string _email;
        private string _phoneNumber;
        private List<Order> _orders;

        public Customer()
        {
            _name = null;
            _address = null;
            _email = null;
            _phoneNumber = null;
            _orders = new List<Order>();
        }
        
        public Customer(string p_name, string p_address, string p_email, string p_phone)
        {
            if(p_name == null || p_address == null || p_email == null || p_phone == null)
                throw new InvalidDataException("Missing field for a new customer");
            _name = p_name;
            _address = p_address;
            _email = p_email;
            _phoneNumber = p_phone;
            _orders = new List<Order>();
        }

        public string Name { get => _name; set{
            if (!Regex.IsMatch(value, @"^[A-Za-z .]+$"))
            {
                throw new Exception("Names can only hold letters!");
            }
            _name = value;
        } }
        public string Address { get => _address; set => _address = value; }
        public string Email { get => _email; set{
            try
            {
                 MailAddress m = new MailAddress(value);
            }
            catch (System.Exception)
            {
                throw new Exception("Invalid email format!");
            }
            _email = value;
        } }
        public string PhoneNumber { get => _phoneNumber; set{
            if(!Regex.IsMatch(value, @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"))
                throw new Exception("Invalid phone number format");
            _phoneNumber = value;
            } }
        public List<Order> Orders { get => _orders; set => _orders = value; }
        public int CustID { get => _custID; set => _custID = value; }

        public override string ToString()
        {
            String s = $"ID:\t\t{CustID}\nName:\t\t{Name}\nAddresss:\t{Address}\nEmail:\t\t{Email}\nPhone#:\t\t{PhoneNumber}";
            return s;
        }
    }
}