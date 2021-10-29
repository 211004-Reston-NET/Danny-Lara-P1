using System.Collections.Generic;

namespace Models
{
    public class Store
    {
        private int _storeID;
        private string _name;
        private string _address;
        private List<Product> _products;
        private List<Order> _orders;
        public Store()
        {
            _name = "";
            _address = "";
            _products = new List<Product>();
            _orders = new List<Order>();
        }

        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public List<Product> Products { get => _products; set => _products = value; }
        public List<Order> Orders { get => _orders; set => _orders = value; }
        public int StoreID { get => _storeID; set => _storeID = value; }

        public override string ToString()
        {
            string output = $"Store name: {Name} ID: {_storeID}\nAddress: {Address}\nItems: ";
            foreach (Product item in Products)
            {
                output += item.Name;
                output += ", ";
            }
            output = output.Remove(output.Length-2);
            return output;
        }
    }
}