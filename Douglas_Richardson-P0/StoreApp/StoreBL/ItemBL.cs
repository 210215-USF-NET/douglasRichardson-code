using StoreModels;
using StoreDL;
using System.Collections.Generic;
using System;

namespace StoreBL
{
    public class ItemBL
    {
        private ItemRepo itemRepo;
        public ItemBL(ItemRepo newItemRepo){
            itemRepo = newItemRepo;
        }
        public void AddItemToRepo(Item Item){
            itemRepo.AddNewItem(Item);
        }
        public void ChangeItemQuantity(Item Item){
            itemRepo.ChangeItemQuantity(Item);
        }
        public void ChangeItemLocation(Item Item){
            itemRepo.ChangeItemLocation(Item);
        }
        //Give the items to the user
        public List<Item> GetItems(){
            List<Item> gotItems = itemRepo.GetItems();
            // foreach (Item item in gotItems)
            // {
            //     Console.WriteLine(item.Product.ProductName);
            //     Console.WriteLine(item.ItemLocation.LocationID);
            //     Console.WriteLine(item.ItemLocation.LocationName);
            // }
            return gotItems;
        }
    }
}