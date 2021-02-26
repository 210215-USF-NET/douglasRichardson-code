using System;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using Mapper = StoreDL.Mappers;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace StoreDL
{
    public class ItemRepo
    {
        private Entity.P0DatabaseContext context;
        private Mapper.ItemMapper mapper; 
        public ItemRepo(Entity.P0DatabaseContext context, Mapper.ItemMapper mapper){
            this.mapper = mapper;
            this.context = context;
        }
        public void AddNewItem(Model.Item Item)
        {
            context.Items.Add(mapper.ParseItem(Item));
            context.SaveChanges();
        }

        public List<Model.Item> GetItems()
        {
           return context.Items.Include("Product").AsNoTracking().Include("Location").AsNoTracking().Select(x => mapper.ParseItem(x)).ToList();
        }

        public void ChangeItemLocation(Model.Item item){
            Entity.Item findItem = context.Items.Find(item.ItemID);
            
            //Entity.LocationTable findLocation = context.LocationTables.Find(item.ItemLocation.LocationID);
            findItem.Location = mapper.ParseLocation(item.ItemLocation);
            context.SaveChanges();
            context.ChangeTracker.Clear();
        }

        public void ChangeItemQuantity(Model.Item item){
            Entity.Item findItem = context.Items.Find(item.ItemID);
            //context.Entry(findItem).CurrentValues.SetValues(mapper.ParseItem(item));
            findItem.Quantity = item.Quantity;
            //Entity.Product findProduct = context.Products.Find(item.Product.Id);
            //findItem.Quantity = item.Quantity;
            context.SaveChanges();
            context.ChangeTracker.Clear();
            
        }
    }//class
}
