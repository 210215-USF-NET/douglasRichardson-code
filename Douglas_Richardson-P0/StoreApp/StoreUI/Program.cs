using System;
using StoreBL;
using StoreDL;
using StoreDL.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
namespace StoreUI
{
    class Program
    {
        /// <summary>
        /// This is the main method, its the starting point of your application
        /// </summary>
        /// <param name="args"></param>
        
        
        static void Main(string[] args)
        {

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            //db connection
            string connectionString = configuration.GetConnectionString("P0-Database");
            DbContextOptions<P0DatabaseContext> options = new DbContextOptionsBuilder<P0DatabaseContext>()
            .UseSqlServer(connectionString).Options;

            //new context
            using var context = new P0DatabaseContext(options);

            Console.WriteLine("Welcome to INSERT NAME HERE! ");
            Console.WriteLine("How may we help you? ");
            //call method that starts main user interface
            MenuFactory menuFactory = new MenuFactory(new UserBL(),context);
            menuFactory.Start();
        }
    }
}
