using System;
using StoreModels;
namespace StoreUI
{
    public class CartMenu : IMenu
    {
        Customer cartCustomer;
        Order cartOrder;

        public Order GetOrder { get; set; }
        public CartMenu(Customer customer){
            cartCustomer = customer;
        }
        public void End()
        {
            throw new System.NotImplementedException();
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }
    }
}