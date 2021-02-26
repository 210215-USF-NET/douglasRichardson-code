using System;
using StoreBL;
using StoreDL;
using Entity = StoreDL.Entities;
using Mapper = StoreDL.Mappers;
using StoreModels;
namespace StoreUI
{
    public class MenuFactory : IMenu
    {
        Boolean active = true;
        
        //main userBL
        private IUserBL ourUserBL;
        private Entity.P0DatabaseContext context;
        public MenuFactory(IUserBL newUserBL, Entity.P0DatabaseContext context){
            ourUserBL = newUserBL;
            this.context = context;
        }

        public void End(){
            active = false;
        }

        //TODO: user input validation/cleaning

        public void Start(){
            do{
                Console.WriteLine("Choose from one of the following by entering a number. ");
                Console.WriteLine("[1] Login in");
                Console.WriteLine("[2] Register");
                Console.WriteLine("[3] View Cart");
                Console.WriteLine("[4] View Products");
                Console.WriteLine("[5] Exit Store");
                CustomerNotLoggedIn();
            }while(active);
        }//End of start()
        
        public void Start(Manager manager){
            do{
                if(ourUserBL.LogUserIn){
                    Console.WriteLine("Hello "+manager.LastName);
                    Console.WriteLine("Choose from one of the following by entering a number. ");
                    Console.WriteLine("[1] View Products ");
                    Console.WriteLine("[2] View Order Histories from Locations");
                    Console.WriteLine("[3] Logout");
                    ManagerIsLoggedIn(manager);
                }
            }while(active);
        }

        public void Start(Customer customer){
            do{
                if(ourUserBL.LogUserIn){
                    Console.WriteLine("Hello "+customer.FirstName);
                    Console.WriteLine("Choose from one of the following by entering a number. ");
                    Console.WriteLine("[1] View Products ");
                    Console.WriteLine("[2] View Cart");
                    Console.WriteLine("[3] View Order History");
                    Console.WriteLine("[4] Logout");
                    CustomerIsLoggedIn(customer);
                }
            }while(active);

        }

        //This handles when the customer is not logged/registered in to the store
        private void CustomerNotLoggedIn(){
            string userInput = Console.ReadLine();
            switch (userInput){
                //Login
                case "1":
                    End();
                    CustomerLoginMenu customerLoginMenu = new CustomerLoginMenu(
                        new CustomerBL(new CustomerRepo(context, new CustomerMapper())), 
                        new ManagerBL(new ManagerRepo(context, new Mapper.ManagerMapper())), 
                        ourUserBL,
                        context);
                    customerLoginMenu.Start();
                    break;
                //Register
                case "2":
                    End();
                    CustomerRegisterMenu customerRegisterMenu = new CustomerRegisterMenu(
                        new CustomerBL(new CustomerRepo(context, new CustomerMapper())), 
                        new ManagerBL(new ManagerRepo(context, new Mapper.ManagerMapper())), 
                        ourUserBL,
                        context);
                    customerRegisterMenu.Start();
                    break;
                //View Cart
                case "3":
                    End();
                    CartMenu cartMenu = new CartMenu(null,
                    new CartBL(new CartRepo(context, new Mapper.CartMapper()), new OrderRepo()),
                    ourUserBL,
                    context);
                    cartMenu.Start();
                    break;
                //View Products
                case "4": 
                    ProductMenu productMenu = new ProductMenu(
                        new ProductBL(new ProductRepo(context, new Mapper.ProductMapper()),context),
                        new ItemBL(new ItemRepo(context, new Mapper.ItemMapper())),
                        ourUserBL,
                        new LocationBL(new LocationRepo(context, new Mapper.LocationMapper())),
                        new CartBL(new CartRepo(context, new Mapper.CartMapper()), new OrderRepo()),
                        context);
                    productMenu.Start(null);
                    End();
                    break;
                //Exit store
                case "5":
                    Console.WriteLine("Thank you for visiting our store! Please come back later. ");
                    End();
                    break;      
                default:
                    Console.WriteLine("Invalid Input, please choose and type a number. ");
                    break;

            }
        }

        //When the customer is logged in to the store
        private void CustomerIsLoggedIn(Customer customer){
            string userInput = Console.ReadLine();
            switch (userInput){
                //View Products
                case "1":
                    End();
                    ProductMenu productMenu = new ProductMenu(
                        new ProductBL(new ProductRepo(context, new Mapper.ProductMapper()),context),
                        new ItemBL(new ItemRepo(context, new Mapper.ItemMapper())),
                        ourUserBL,
                        new LocationBL(new LocationRepo(context, new Mapper.LocationMapper())),
                        new CartBL(new CartRepo(context, new Mapper.CartMapper()), new OrderRepo()),
                        context);
                    productMenu.Start(customer);
                    break;
                //View Cart
                case "2":
                    End();
                    CartMenu cartMenu = new CartMenu(customer,
                    new CartBL(new CartRepo(context, new Mapper.CartMapper()), new OrderRepo()),
                    ourUserBL,
                    context);
                    cartMenu.Start();
                    break;
                //View Order History
                case "3":
                    End();
                    OrderHistoryMenu orderHistoryMenu = new OrderHistoryMenu();
                    orderHistoryMenu.Start();
                    break;
                //Logout
                case "4": 
                    Console.WriteLine("Have a good day! "+customer.FirstName);
                    ourUserBL.IsUserManager = false;
                    ourUserBL.LogUserIn = false;
                    Start();
                    break; 
                default:
                    Console.WriteLine("Invalid Input, please choose and type a number. ");
                    break;

            }
        }

        //When the manager is logged in to the store
        private void ManagerIsLoggedIn(Manager manager){
            string userInput = Console.ReadLine();
            switch (userInput){
                //View Products
                case "1":
                    End();
                    ProductMenuManager productMenu = new ProductMenuManager(
                        new ProductBL(new ProductRepo(context, new Mapper.ProductMapper()),context),
                        new ItemBL(new ItemRepo(context, new Mapper.ItemMapper())),
                        ourUserBL,
                        new LocationBL(new LocationRepo(context, new Mapper.LocationMapper())),
                        new CartBL(new CartRepo(context, new Mapper.CartMapper()), new OrderRepo()),
                        context);
                    productMenu.Start(manager);
                    break;
                //View Order Histories from location
                case "2":
                    End();
                    OrderHistoryMenu orderHistoryMenu = new OrderHistoryMenu();
                    orderHistoryMenu.Start();
                    break;
                //Log Out
                case "3":
                    Console.WriteLine("Good work! Come back tomorrow. ");
                    ourUserBL.IsUserManager = false;
                    ourUserBL.LogUserIn = false;
                    Start();
                    break;      
                default:
                    Console.WriteLine("Invalid Input, please choose and type a number. ");
                    break;

            }
        }
    }//End of class
}