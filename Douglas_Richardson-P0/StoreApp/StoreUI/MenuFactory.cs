using System;
namespace StoreUI
{
    public class MenuFactory : IMenu
    {
        Boolean active = true;
        public MenuFactory(){

        }

        public void End(){
            active = false;
        }

        public void Start(){
            do{
                Console.WriteLine("Choose from one of the following by entering a number. ");
                Console.WriteLine("[1] Login in");
                Console.WriteLine("[2] Register");
                Console.WriteLine("[3] View Cart");
                Console.WriteLine("[4] View Products");
                if(Program.userLoggedIn){
                    Console.WriteLine("[1] View Products ");
                    Console.WriteLine("[2] View Cart");
                    Console.WriteLine("[3] View Order History");
                    Console.WriteLine("[4] Logout");
                }
                
                //get userinput
                string userInput = Console.ReadLine();
                switch (userInput){
                    case "1":
                        End();
                        CustomerLoginMenu customerLoginMenu = new CustomerLoginMenu();
                        customerLoginMenu.Start();
                        break;
                    case "2":
                        End();
                        CustomerRegisterMenu customerRegisterMenu = new CustomerRegisterMenu();
                        customerRegisterMenu.Start();
                        break;
                    case "3":
                        End();
                        OrderHistoryMenu orderHistoryMenu = new OrderHistoryMenu();
                        orderHistoryMenu.Start();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye. ");
                        End();
                        break;    
                    default:
                        Console.WriteLine("Invalid Input, please choose and type a number. ");
                        break;

                }
            }while(active);
        }//End of start()
    }//End of class
}