using System;
using StoreModels;

namespace StoreUI
{
    public class CustomerLoginMenu : IMenu
    {
        /// <summary>
        /// For creating a new customer
        /// </summary>
        
        Boolean active = true; //whether the menu is active in the console
        public void CreateElement()
        {
            Customer newCustomer = new Customer();
        }

        public void End()
        {
            active = false;
            Console.WriteLine("Exiting Customer Menu. ");
        }

        public void Start()
        {
            
            do{

            }while(active);
        }//start

    }//class
}