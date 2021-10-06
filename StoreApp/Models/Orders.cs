using System.Collections.Generic;

namespace Models
{
    public class Orders
    {
        private List<LineItems> items;
        private string location;
        private double totalPrice;
    }
}