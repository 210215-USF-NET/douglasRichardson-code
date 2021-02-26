
using System;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using Mapper = StoreDL.Mappers;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace StoreDL
{
    public class CartRepo
    {
        private Entity.P0DatabaseContext context;
        private Mapper.CartMapper mapper; 
        public CartRepo(Entity.P0DatabaseContext context, Mapper.CartMapper mapper){
            this.mapper = mapper;
            this.context = context;
        }
        public int? AddNewCart(Model.Order order)
        {
            Entity.Cart newCart = mapper.ParseOrder(order);
            context.Carts.Add(newCart);
            context.SaveChanges();
            return newCart.Id;
        }

        public void UpdateCart(int? cartID, Model.Order order){
            Entity.Cart thisOrder = context.Carts.Find(cartID);
            thisOrder.Location = mapper.ParseLocation(order.Location);
            thisOrder.Customer = mapper.ParseCustomer(order.Customer);
            thisOrder.Item = mapper.ParseItem(order.orderItems);
            thisOrder.Quantity = order.Quantity;
            thisOrder.Total = order.Total;
            context.SaveChanges();
            context.ChangeTracker.Clear();
        }

        public Model.Order GetCartOrder(int? cartID)
        {
            Entity.Cart thisOrder = context.Carts.Find(cartID);
            return mapper.ParseOrder(thisOrder);
            
        }
        // public void SetPrice(){

        // }

        // public double GetPrice(){
        //     Model.Order cartOrder = GetCartOrder();
        //     return cartOrder.Total;
        // }
        public void EmptyCart(Model.Order order){
            context.Carts.Remove(mapper.ParseOrder(order));
            context.SaveChanges();
        }
    }//class
}
