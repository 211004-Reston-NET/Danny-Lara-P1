using System.Collections.Generic;

namespace Models
{
    public class Store
    {
        private string _name;
        private string _address;
        private List<Products> _products;
        private List<Order> _orders;

        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public List<Products> Products { get => _products; set => _products = value; }
        public List<Order> Orders { get => _orders; set => _orders = value; }

        public override string ToString()
        {
            string output = $"Store name: {Name}\nAddress: {Address}\nItems: ";
            foreach (Products item in Products)
            {
                output += item.Name;
                output += ", ";
            }
            output = output.Remove(output.Length-2);
            /*output += "\nOrders: ";
            foreach (Order order in Orders)
            {
                output += order;
                output += '\n';
            }*/
            return output;
        }
    }
}