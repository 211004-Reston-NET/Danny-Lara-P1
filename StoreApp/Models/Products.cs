using System.Collections.Generic;

namespace Models
{
    public class Products
    {
        private string name;
        private double price;
        private string description;
        private string category;

        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public string Category { get => category; set => category = value; }

        public override string ToString()
        {
            return $"Product name:\t{Name}\nPrice:\t\t${Price}\nDescription:\t{Description}\nCategory:\t\t{Category}";
        }
    }
}