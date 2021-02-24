using StoreDL;
using StoreModels;
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
        private double cartTotal;
        public CartBL(CartRepo newCartRepo, OrderRepo newOrderRepo){
            cartRepo = newCartRepo;
            orderRepo = newOrderRepo;
            cartOrder = new Order();
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
        public void AddNewItemToOrder(Item item){
            cartOrder.Total = item.Product.Price * item.Quantity;
            cartRepo.AddNewItemToOrder(item);         
        }
        public void RemoveItemFromOrder(Item item){
            cartRepo.RemoveItemFromOrder(item);
        }
        public double GetPrice(){
            return cartRepo.GetPrice();
        }
        public void SetPrice(){

        }
        public void pushOrder(){
            //Get all the needed items to create an order
            cartOrder.orderItems = cartRepo.GetCartItems();
            orderRepo.PushOrder(cartOrder);
            //Empty cart
            cartRepo.EmptyCart();
        }
    }
}