using Xunit;
using BusinessLogic;
using DataAccessLogic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DataAccessLogic.Entities;
using System.Collections.Generic;
using Model = Models;

namespace AppTest
{
    public class DatabaseTests
    {
        /// <summary>
        /// Tests to see if stores can be retrieved from the database
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
            List<Model.Store> stores = bl.GetAll();

            Assert.NotEmpty(stores);
        }
    }
}