using System;

namespace StoreUI
{
    class Program
    {
        /// <summary>
        /// This is the main method, its the starting point of your application
        /// </summary>
        /// <param name="args"></param>
        
        static public Boolean userLoggedIn = false;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to INSERT NAME HERE! ");
            Console.WriteLine("How may we help you? ");
            //call method that starts main user interface
            MenuFactory menuFactory = new MenuFactory();
            menuFactory.Start();
        }
    }
}
