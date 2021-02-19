using System;
using StoreModels;
namespace StoreUI
{
    public class CustomerRegisterMenu : IMenu
    {
        Boolean active = true; //whether the menu is active in the console
        public void CreateNewCustomer()
        {
            Customer newCustomer = new Customer();
        }

        public void End()
        {
            active = false;
        }

        public void Start()
        {
            Console.WriteLine("New Customer Menu. ");
            Console.WriteLine("Type !stop to exit out of this menu.");
            do{
                string userInput = Console.ReadLine();
                if(userInput.Equals("!stop")){ 
                    End();
                    MenuFactory menuFactory = new MenuFactory();
                    menuFactory.Start();    
                }else{
                    
                }
            }while(active);
            //TODO: Log to a file that a customer was created. 
            Console.WriteLine("");

        }
    }
}