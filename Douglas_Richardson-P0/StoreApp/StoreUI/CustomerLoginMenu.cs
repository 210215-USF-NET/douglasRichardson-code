using System;
using StoreModels;
using StoreBL;
using Entity = StoreDL.Entities;
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
        private Entity.P0DatabaseContext context;
        public CustomerLoginMenu(ICustomerBL newCustomerBL, IManagerBL newManagerBL, IUserBL newUserBL, Entity.P0DatabaseContext context){
            customerBL = newCustomerBL;
            managerBL = newManagerBL;
            userBL = newUserBL;
            this.context = context;
        }
        public void CreateElement()
        {
            Customer newCustomer = new Customer();
        }

        public void End(Customer customer)
        {
            active = false;
            userBL.LogUserIn = true;
            userBL.IsUserManager = false;
            MenuFactory menuFactory = new MenuFactory(userBL,context);
            menuFactory.Start(customer);   
        }
        public void End(Manager manager)
        {
            active = false;
            userBL.LogUserIn = true;
            userBL.IsUserManager = true;
            MenuFactory menuFactory = new MenuFactory(userBL,context);
            menuFactory.Start(manager);   
        }
        public void End()
        {
            active = false;
            Console.WriteLine("Exiting Customer Menu. ");
            MenuFactory menuFactory = new MenuFactory(userBL,context);
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