using System.Collections.Generic;

namespace Models
{
    public class Order
    {
        private List<LineItems> items;
        private Store store;
        private double totalPrice;

        public Order()
        {
            double total = 0;
            foreach (LineItems item in items)
            {
                total += item.Product.Price;
            }
            totalPrice = total;
        }
        public Order(List<LineItems> p_items, Store p_store)
        {
            items = p_items;
            store = p_store;
            double total = 0;
            foreach (LineItems item in items)
            {
                total += item.Product.Price;
            }
            totalPrice = total;
        }
        public List<LineItems> Items { get => items; set => items = value; }
        public Store Store { get => store; set => store = value; }
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }

        public override string ToString()
        {
            string s = "Store: " + store.Name;
            s += "Items:\n";
            foreach (LineItems item in items)
            {
                s += $"{item.Product.Name} ({item.Quantity}) at ${item.Product.Price} each\n";
            }
            s += $"Order total: ${totalPrice}";
            return s;
        }
    }
}