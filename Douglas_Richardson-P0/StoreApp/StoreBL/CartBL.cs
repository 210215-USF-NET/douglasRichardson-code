using StoreDL;
using StoreModels;
using System;
using System.Collections.Generic;
namespace StoreBL
{   
    public class CartBL
    {
        /// <summary>
        /// The cart holds items for the customer when they are shopping, This holds the precusor to an order.
        /// </summary>
        private CartRepo cartRepo;
        private OrderRepo orderRepo;
        private Order cartOrder;
        private int? cartID;
        private double cartTotal;
        public CartBL(CartRepo newCartRepo, OrderRepo newOrderRepo){
            cartRepo = newCartRepo;
            orderRepo = newOrderRepo;
            // cartOrder = cartRepo.GetCartOrder(cartID);
            // if(cartOrder == null){
            //     cartOrder = new Order();
            //     cartOrder.orderItems = new Item();
                //cartOrder.orderItems = new List<Item>();
            
        }
        //creates a new order to keep track of what the customer puts in
        // public void CreateNewOrder(Order order){
        //     cartOrder = order;
        //     cartOrder.OrderID = cartRepo.GetOrders();
        // }
        public void AddCustomer(Customer customer){
            cartOrder.Customer = customer;
        }
        public void AddLocation(Location location){
            cartOrder.Location = location;
        }
        public void AddNewItemToOrder(Item item,int choice,Customer customer,IUserBL userBL,Location location){
            if(item != null){
                cartOrder = new Order();
                
                cartOrder.Quantity = choice;
                cartOrder.Total = item.Product.Price * choice;
                cartOrder.orderItems = item;
                if(customer == null){
                    cartOrder.Customer.EmailAddress = null;
                    cartOrder.Customer.FirstName = null;
                    cartOrder.Customer.LastName = null;
                }else{
                    cartOrder.Customer = customer;
                }
                if(location == null){
                    cartOrder.Location = new Location();
                }else{
                    cartOrder.Location = location;
                }
                cartRepo.UpdateCart(userBL.CartID,cartOrder);
            }else{
                cartOrder = new Order();
                cartOrder.Location = new Location();
                cartOrder.Customer = new Customer();
                cartOrder.orderItems = new Item();
                cartOrder.orderItems.ItemLocation = cartOrder.Location;
                cartOrder.orderItems.Product = new Product();
                userBL.CartID = cartRepo.AddNewCart(cartOrder);
            }     
            
        }
        public void RemoveItemFromOrder(Item item){
            
        }
        public Order GetOrder(int? cartID){
            return cartRepo.GetCartOrder(cartID);
        }
        public int GetAmountOfItem(Item item){
            if(cartOrder.orderItems != null){
                return cartOrder.orderItems.Quantity;
                // foreach (Item findItem in cartOrder.orderItems)
                // {
                //     if(findItem.ItemID == item.ItemID){
                //         return findItem.Quantity;
                //     }
                // }
            }
            return 0;
        }
        public double GetPrice(int? cartID){
            Order cartOrder = cartRepo.GetCartOrder(cartID);
            if(cartOrder != null){
                return cartRepo.GetCartOrder(cartID).Total;
            }else{
                return 0.0;
            }  
        }
        public Location GetLocation(int? cartID){
            Order cartOrder = cartRepo.GetCartOrder(cartID);
            if(cartOrder != null){
                return cartRepo.GetCartOrder(cartID).Location;
            }else{
                return null;
            }  
        }
        public void SetPrice(){

        }
        public void EmptyCart(int? cartID){
            if(cartRepo.GetCartOrder(cartOrder.Id) != null){
                cartRepo.EmptyCart(cartOrder);
                Console.WriteLine("asdf");
            }
        }
        public void pushOrder(int? cartID){
            //Get all the needed items to create an order
          //  orderRepo.PushOrder(cartRepo.GetCartOrder());
            //Empty cart
            //cartRepo.EmptyCart();
        }
    }
}