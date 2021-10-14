using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using System.Net.Mail;

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
        
        public Customer(string p_name, string p_address, string p_email, string p_phone)
        {
            if(p_name == null || p_address == null || p_email == null || p_phone == null)
                throw new InvalidDataException("Missing field for a new customer");
            name = p_name;
            address = p_address;
            email = p_email;
            phoneNumber = p_phone;
            orders = new List<Order>();
        }

        public string Name { get => name; set{
            if (!Regex.IsMatch(value, @"^[A-Za-z .]+$"))
            {
                throw new Exception("Names can only hold letters!");
            }
            name = value;
        } }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set{
            try
            {
                 MailAddress m = new MailAddress(value);
            }
            catch (System.Exception)
            {
                throw new Exception("Invalid email format!");
            }
            email = value;
        } }
        public string PhoneNumber { get => phoneNumber; set{
            if(!Regex.IsMatch(value, @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"))
                throw new Exception("Invalid phone number format");
            phoneNumber = value;
            } }
        public List<Order> Orders { get => orders; set => orders = value; }

        public override string ToString()
        {
            return $"Name:\t\t{Name}\nAddresss:\t{Address}\nEmail:\t\t{Email}\nPhone#:\t\t{PhoneNumber}";
        }
    }
}