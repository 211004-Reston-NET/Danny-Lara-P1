using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]    
        public int ProductID { get => _id; set => _id = value; }
        [ForeignKey("StoreID")]
        public int StoreID { get => _storeID; set => _storeID = value; }

        public override string ToString()
        {
            return $"Product ID:\t{ProductID}\nProduct name:\t{Name}\nPrice:\t\t${Price}\nDescription:\t{Description}\nQuantity:\t{Quantity}";
        }
    }
}