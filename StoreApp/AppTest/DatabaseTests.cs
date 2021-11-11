using Xunit;
using DataAccessLogic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Models;

namespace AppTest
{
    public class DatabaseTests
    {
        private readonly DbContextOptions<DataContext> _options;
        public DatabaseTests()
        {
            _options = new DbContextOptionsBuilder<DataContext>().UseSqlite("Filename = Test.db").Options;
            Seed();
        }
        /// <summary>
        /// Tests to see if all stores can be retrieved from the database
        /// </summary>
        [Fact]
        public void GetAllStoresTest()
        {
            using (var context = new DataContext(_options))
            {
                CloudRepo repo = new CloudRepo(context);
                List<Store> stores = repo.GetAllStores();
                Assert.Equal(3, stores.Count);
                Assert.Equal("Dan's Daffodiles", stores[0].Name);
            }
        }

        /// <summary>
        /// Tests to see if products can be retrieved from the database
        /// </summary>
        [Fact]
        public void GetProductsFromStoreTest()
        {
            using (var context = new DataContext(_options))
            {
                CloudRepo repo = new CloudRepo(context);
                List<Product> products = repo.GetProductsByStoreId(1);
                Assert.Equal("Daffodiles", products[0].Name);
                Assert.Single(products);
            }
        }

        /// <summary>
        /// Tests to see if all customers can be retrieved from the database
        /// </summary>
        [Fact]
        public void GetAllCustomersTest()
        {
            using (var context = new DataContext(_options))
            {
                CloudRepo repo = new CloudRepo(context);
                List<Customer> customers = repo.GetAllCustomers();
                Assert.Equal(2, customers.Count);
                Assert.Equal("Mickey Mouse", customers[0].Name);
            }
        }

        [Fact]
        public void PlaceAnOrderTest()
        {
            using (var context = new DataContext(_options))
            {
                CloudRepo repo = new CloudRepo(context);

            }
        }
        private void Seed()
        {
            using (var context = new DataContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Stores.AddRange
                (
                    new Store
                    {
                        Name = "Dan's Daffodiles",
                        Address = "123 Dan St",
                        Products = new List<Product>
                        {
                            new Product
                            {
                                Name = "Daffodiles",
                                Price = 12.99,
                                Description = "Daffodiles, duh!",
                                StoreID = 1,
                                Quantity = 15
                            }
                        }
                    },
                    new Store
                    {
                        Name = "Sandra's Sunflowers",
                        Address = "543 Dogbed Ln",
                        Products = new List<Product>
                        {
                            new Product
                            {
                                Name = "Sunflower",
                                Price = 5.99,
                                Description = "A single sunflower",
                                StoreID = 2,
                                Quantity = 12
                            },
                            new Product
                            {
                                Name = "Sunflower Seeds",
                                Price = 3.99,
                                Description = "Roasted Sunflower Seeds",
                                StoreID = 2,
                                Quantity = 18
                            }
                        }
                    },
                    new Store
                    {
                        Name = "Fred's Flowers",
                        Address = "1734 Bedrock Ln",
                        Products = new List<Product>
                        {
                            new Product
                            {
                                Name = "Tulip",
                                Price = 7.99,
                                Description = "A bundle of tulips",
                                StoreID = 3,
                                Quantity = 15
                            },
                            new Product
                            {
                                Name = "Wilma's Wreaths",
                                Price = 19.99,
                                Description = "Wreaths made by Fred's wife Wilma",
                                StoreID = 3,
                                Quantity = 25
                            }
                        }
                    });
                context.Customers.AddRange
                (
                    new Customer
                    {
                        Name = "Mickey Mouse",
                        Address = "1928 Disney Way",
                        PhoneNumber = "4071971123",
                        Email = "bigcheese@disney.com"
                    },
                    new Customer
                    {
                        Name = "Donald Duck",
                        Address = "Bay Lake",
                        PhoneNumber = "4075551234",
                        Email = "angryduck@disney.com"
                    });
                context.SaveChanges();
            }
            
        }
    }
}