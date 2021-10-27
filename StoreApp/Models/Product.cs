namespace Models
{
    public class Product
    {
        private int _id;
        private int _storeID;
        private string _name;
        private double _price;
        private string _description;
        private int _quantity;

        public string Name { get => _name; set => _name = value; }
        public double Price { get => _price; set => _price = value; }
        public string Description { get => _description; set => _description = value; }
        public int Quantity { get => _quantity; set{
            if (value < 0)
                throw new System.Exception("Cannot add a negative quantity!");
            _quantity = value;
        } }

        public int Id { get => _id; set => _id = value; }

        public override string ToString()
        {
            return $"Product name:\t{Name}\nPrice:\t\t${Price}\nDescription:\t{Description}\nQuantity:\t{Quantity}";
        }
    }
}