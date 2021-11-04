using Xunit;
using BusinessLogic;
using DataAccessLogic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Models;

namespace AppTest
{
    public class DatabaseTests
    {
        /// <summary>
        /// Tests to see if all stores can be retrieved from the database
        /// </summary>
        [Fact]
        public void GetStoresTest()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();
            DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>().UseSqlServer(config.GetConnectionString("Reference2DB")).Options;
            StoreBL bl = new StoreBL(new CloudRepo(new DataContext(options)));
            List<Store> stores = bl.GetAll();

            Assert.NotEmpty(stores);
            Assert.NotNull(stores);
        }

        /// <summary>
        /// Tests to see if products can be retrieved from the database
        /// </summary>
        [Fact]
        public void GetProductsFromStoreTest()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();
            DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>().UseSqlServer(config.GetConnectionString("Reference2DB")).Options;
            StoreBL bl = new StoreBL(new CloudRepo(new DataContext(options)));
            List<Product> products = bl.GetStoreProducts(1);

            Assert.NotEmpty(products);
            Assert.NotNull(products);
        }

        /// <summary>
        /// Tests to see if all customers can be retrieved from the database
        /// </summary>
        [Fact]
        public void GetAllCustomersTest()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();
            DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>().UseSqlServer(config.GetConnectionString("Reference2DB")).Options;
            CustomerBL bl = new CustomerBL(new CloudRepo(new DataContext(options)));
            List<Customer> customers = bl.GetAll();

            Assert.NotEmpty(customers);
            Assert.NotNull(customers);
        }
    }
}