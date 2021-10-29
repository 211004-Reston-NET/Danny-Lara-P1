using System.Collections.Generic;

namespace Models
{
    public class Order
    {
        private int _orderNumber;
        private int _custID;
        private int _storeID;
        private List<LineItems> _items;
        private Store _store;
        private double _totalPrice;

        public Order()
        {
            _items = new List<LineItems>();
            _store = new Store();
            _totalPrice = 0;
        }
        public Order(List<LineItems> p_items, Store p_store)
        {
            _items = p_items;
            _store = p_store;
            double total = 0;
            foreach (LineItems item in _items)
            {
                total += item.Product.Price * item.Quantity;
            }
            _totalPrice = total;
        }
        public List<LineItems> Items { get => _items; set => _items = value; }
        public Store Store { get => _store; set => _store = value; }
        public double TotalPrice { get => _totalPrice; set => _totalPrice = value; }
        public int OrderNumber { get => _orderNumber; set => _orderNumber = value; }
        public int CustID { get => _custID; set => _custID = value; }
        public int StoreID { get => _storeID; set => _storeID = value; }

        public void UpdatePrice()
        {
            double total = 0;
            foreach (LineItems item in _items)
            {
                total += item.Product.Price * item.Quantity;
            }
            _totalPrice = total;
        }

        public override string ToString()
        {
            string s = "Store: " + _store.Name;
            s += "\nCust ID: " + CustID;
            s += "\nItems:\n";
            foreach (LineItems item in _items)
            {
                s += $"\t{item.Product.Name} ({item.Quantity}) at {item.Product.Price.ToString("C")} each\n";
            }
            s += $"Order total: {_totalPrice.ToString("C")}";
            return s;
        }
    }
}