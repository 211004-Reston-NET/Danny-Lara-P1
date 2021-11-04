using BusinessLogic;
using DataAccessLogic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace UserInterface
{
    public class MenuFactory : IFactory
    {
        public IMenu GetMenu(MenuType p_menu)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();

            DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>().UseSqlServer(config.GetConnectionString("Reference2DB")).Options;
            switch (p_menu)
            {
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.AddCustomer:
                    return new AddCustomer(new CustomerBL(new CloudRepo(new DataContext(options))));
                case MenuType.Inventory:
                    return new Inventory(new StoreBL(new CloudRepo(new DataContext(options))));
                case MenuType.OrderHistory:
                    return new OrderHistory(new StoreBL(new CloudRepo(new DataContext(options))), new CustomerBL(new CloudRepo(new DataContext(options))));
                case MenuType.PlaceOrder:
                    return new PlaceOrder(new StoreBL(new CloudRepo(new DataContext(options))));
                case MenuType.Replenish:
                    return new Replenish(new StoreBL(new CloudRepo(new DataContext(options))));
                case MenuType.Search:
                    return new Search(new CustomerBL(new CloudRepo(new DataContext(options))));
                default:
                    return null;
            }
        }
    }
}