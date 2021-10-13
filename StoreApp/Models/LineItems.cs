using System.Collections.Generic;

namespace Models
{
    public class LineItems
    {
        private Products product;
        private int quantity;

        public Products Product { get => product; set => product = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}