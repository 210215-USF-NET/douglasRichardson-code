using System;
using StoreModels;
using StoreBL;
using Entity = StoreDL.Entities;
namespace StoreUI
{
    public class CartMenu : IMenu
    {
        Customer customer;
        private CartBL cartBL;
        private IUserBL ourUserBL;
        private Entity.P0DatabaseContext context;
        private bool active = true;
        public CartMenu(Customer customer, CartBL cart, IUserBL userBL, Entity.P0DatabaseContext context){
            if(customer != null){
                this.customer = customer;
            }
            cartBL = cart;
            ourUserBL = userBL;
            this.context = context;
        }
        public void End()
        {
            active = false;
            MenuFactory menuFactory = new MenuFactory(ourUserBL,context);
            menuFactory.Start(); 
            
        }

        public void Start()
        {   
            Order thisCartOrder = new Order();
            
            try{
                thisCartOrder = cartBL.GetOrder(ourUserBL.CartID);
            }catch(Exception e){
                Console.WriteLine(e.ToString());
            }
            
            if(thisCartOrder == null){
                cartBL.AddNewItemToOrder(null,0,customer,ourUserBL,null);
                thisCartOrder = new Order();
                thisCartOrder.Location = null;
            }
            if(thisCartOrder.Location != null){
                Console.WriteLine("Your store location is: "+thisCartOrder.Location.LocationName);
            }else{
                Console.WriteLine("You do not have a store selected.");
            }
            
            Console.WriteLine("This is what is in your cart");

            if(thisCartOrder.Quantity > 0){
                Console.WriteLine("You have "+thisCartOrder.Quantity+" of "+thisCartOrder.orderItems.Product.ProductName);
            }else{
                Console.WriteLine("Your cart is empty. ");
            }
            // foreach (Item item in thisCartOrder.orderItems)
            // {
            //     Console.WriteLine("You have "+item.Quantity+" of "+item.Product.ProductName);
            // }
            Console.WriteLine("Here is your total. "+cartBL.GetPrice(ourUserBL.CartID));
            while(active){
                Console.WriteLine("[1] Submit your order");
                Console.WriteLine("[2] Clear your cart");
                Console.WriteLine("[3] Go back to the main menu. ");
                try{
                    string userInput = Console.ReadLine();
                    switch(userInput){
                        case "1":
                            if(this.customer != null){
                                if(thisCartOrder.Quantity > 0){
                                    Console.WriteLine("Order is submitted.");
                                    cartBL.pushOrder(ourUserBL.CartID);
                                }else{
                                    Console.WriteLine("Your cart is empty, cannot submit order. ");
                                }     
                            }else{
                                Console.WriteLine("Please login or register to submit your order. ");
                            }
                            End();
                            break;
                        case "2":
                            Console.WriteLine("Cart has been emptied");
                            cartBL.EmptyCart(ourUserBL.CartID);
                            End();
                            break;
                        case "3":
                            End();
                            break;
                    }
                }catch(Exception){

                }
            }//while
        }//start
    }
}