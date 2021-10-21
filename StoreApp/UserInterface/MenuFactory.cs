using BusinessLogic;
using DataAccessLogic;

namespace UserInterface
{
    public class MenuFactory : IFactory
    {
        public IMenu GetMenu(MenuType p_menu)
        {
            switch (p_menu)
            {
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.AddCustomer:
                    return new AddCustomer(new CustomerBL(new CustomerRepo()));
                case MenuType.Inventory:
                    return new Inventory(new StoreBL(new StoreRepo()));
                case MenuType.OrderHistory:
                    return new OrderHistory();
                case MenuType.PlaceOrder:
                    return new PlaceOrder(new StoreBL(new StoreRepo()));
                case MenuType.Replenish:
                    return new Replenish();
                case MenuType.Search:
                    return new Search(new CustomerBL(new CustomerRepo()));
                default:
                    return null;
            }
        }
    }
}