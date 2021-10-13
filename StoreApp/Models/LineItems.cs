using System.Collections.Generic;

namespace Models
{
    public class LineItems
    {
        private Product product;
        private int quantity;

        public Product Product { get => product; set => product = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}