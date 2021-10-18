using System.Collections.Generic;

namespace Models
{
    public class LineItems
    {
        private Product _product;
        private int _quantity;
        public LineItems(Product p_product, int p_quantity)
        {
            _product = p_product;
            _quantity = p_quantity;
        }

        public Product Product { get => _product; set => _product = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
    }
}