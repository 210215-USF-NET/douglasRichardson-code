using System;
using StoreModels;
using StoreBL;
namespace StoreUI
{
    public class CustomerLoginMenu : IMenu
    {
        /// <summary>
        /// For creating a new customer
        /// </summary>
        
        Boolean active = true; //whether the menu is active in the console
        private ICustomerBL customerBL;
        private IManagerBL managerBL;
        private IUserBL userBL;
        public CustomerLoginMenu(ICustomerBL newCustomerBL, IManagerBL newManagerBL, IUserBL newUserBL){
            customerBL = newCustomerBL;
            managerBL = newManagerBL;
            userBL = newUserBL;
        }
        public void CreateElement()
        {
            Customer newCustomer = new Customer();
        }

        public void End(Customer customer)
        {
            active = false;
            Console.WriteLine("Welcome "+customer.FirstName+"!");
            userBL.LogUserIn = true;
            userBL.IsUserManager = false;
            MenuFactory menuFactory = new MenuFactory(userBL);
            menuFactory.Start(customer);   
        }
        public void End(Manager manager)
        {
            active = false;
            Console.WriteLine("Welcome "+manager.LastName+"!");
            userBL.LogUserIn = true;
            userBL.IsUserManager = true;
            MenuFactory menuFactory = new MenuFactory(userBL);
            menuFactory.Start(manager);   
        }
        public void End()
        {
            active = false;
            Console.WriteLine("Exiting Customer Menu. ");
            MenuFactory menuFactory = new MenuFactory(userBL);
            menuFactory.Start(); 
        }
        public void Start()
        {
            Console.WriteLine("Type in your email to login. ");
            Console.WriteLine("Type !stop to exit out of this menu.");
            //Check managers then customers
            do{
                try{
                    string userInput = Console.ReadLine();
                    if(userInput.Equals("!stop")){ 
                        End();     
                    }
                    Manager thisManager = managerBL.FindManagerOnEmail(userInput);
                    if(thisManager != null){
                        End(thisManager);
                    }
                    Customer thisCustomer = customerBL.FindCustomerOnEmail(userInput);
                    if(thisCustomer != null){
                        End(thisCustomer);
                    }
                }catch(Exception){}
            }while(active);
        }//start

    }//class
}