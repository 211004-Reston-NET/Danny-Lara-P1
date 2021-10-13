using System.Collections.Generic;

namespace Models
{
    public class Order
    {
        private List<LineItems> items;
        private StoreFront store;
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
        public Order(List<LineItems> p_items, StoreFront p_store)
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
        public StoreFront Store { get => store; set => store = value; }
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}