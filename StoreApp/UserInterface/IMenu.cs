using DataAccessLogic;
namespace UserInterface
{
    public enum MenuType
    {
        MainMenu,
        AddCustomer,
        Search,
        Inventory,
        PlaceOrder,
        OrderHistory,
        Replenish,
        StoreOrderMenu,
        Exit
    }
    public interface IMenu
    {
        /// <summary>
        /// 
        /// </summary>
        void Menu();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        MenuType Choice();
    }
}