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
        /// <returns></returns>
        MenuType Choice();
    }
}