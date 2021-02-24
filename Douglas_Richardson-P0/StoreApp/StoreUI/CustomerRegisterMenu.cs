using System;
using StoreModels;
using StoreBL;
namespace StoreUI
{
    public class CustomerRegisterMenu : IMenu
    {
        bool active = true; //whether the menu is active in the console

      
        private ICustomerBL customerBL;
        private IManagerBL managerBL;
        private IUserBL userBL;
        public CustomerRegisterMenu(ICustomerBL newCustomerBL, IManagerBL newManagerBL, IUserBL newUserBL){
            customerBL = newCustomerBL;
            managerBL = newManagerBL;
            userBL = newUserBL;
        }

        public void End(){
            active = false;
            MenuFactory menuFactory = new MenuFactory(userBL);
            menuFactory.Start();   
        }
        public void End(Manager manager){
            active = false;
            managerBL.AddNewManager(manager);
            userBL.LogUserIn = true;
            userBL.IsUserManager = true;
            MenuFactory menuFactory = new MenuFactory(userBL);
            menuFactory.Start(manager);   
        }
        public void End(Customer customer){
            active = false;
            customerBL.AddNewCustomer(customer);
            userBL.LogUserIn = true;
            userBL.IsUserManager = false;
            MenuFactory menuFactory = new MenuFactory(userBL);
            menuFactory.Start(customer);   
        }
        public void Start(){
            //For customer or manager, like the fields on a webpage, before its sent to the server
            string firstName = null;
            string lastName = null; 
            string emailAddress = null;
            Console.WriteLine("New Customer Menu. ");
            Console.WriteLine("Type !stop to exit out of this menu.");

            do{
                //let the user know
                if(firstName == null){
                    Console.WriteLine("Please type your first name. ");
                }else if(lastName == null){
                    Console.WriteLine("Please type your last name. ");
                }else if(emailAddress == null){
                    Console.WriteLine("Please type a valid email address. ");
                }else{
                    Console.WriteLine("Do you want to be a manager? ");
                }

                //Get userinput
                try{
                    string userInput = Console.ReadLine();
                    if(userInput.Equals("!stop")){ 
                        End();     
                    }
                    if(firstName == null){
                        firstName = userInput;
                    }else if(lastName == null){
                        lastName = userInput;
                    }else if(emailAddress == null){
                        emailAddress = userInput;
                    }else{
                        //Finish making customer
                        //TODO: Let user review what they input?'
                        //TODO: Log to a file that a customer was created.
                        if(userInput.Equals("no") || userInput.Equals("n")){
                            Customer newCustomer = new Customer();
                            newCustomer.FirstName = firstName;
                            newCustomer.LastName = lastName;
                            newCustomer.EmailAddress = emailAddress;
                            Console.WriteLine("Welcome "+newCustomer.FirstName+"!");
                            End(newCustomer);
                        }else if(userInput.Equals("yes") || userInput.Equals("y")){
                            Manager newManager = new Manager();
                            newManager.FirstName = firstName;
                            newManager.LastName = lastName;
                            newManager.EmailAddress = emailAddress;
                            Console.WriteLine("Welcome aboard "+newManager.FirstName+" as a new manager!");
                            End(newManager);
                        }
                        
                    }//End of if !stop
                }catch(Exception e){
                    //TODO: Log exception?, use NLOG? serilog?
                    Console.WriteLine("Invalid input. ");
                }
           }while(active);
        }//End of start


    }
}