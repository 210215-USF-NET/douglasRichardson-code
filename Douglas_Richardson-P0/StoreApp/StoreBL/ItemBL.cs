using StoreModels;
using StoreDL;
using System.Collections.Generic;
using System;

namespace StoreBL
{
    /// <summary>
    /// Allows the manager to create and change the location and quantity of items
    /// </summary>
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
            //cannot remove items from a list while iterating using foreach
            for (int i = gotItems.Count - 1; i >= 0; i--)
            {
                if(gotItems[i].Product.ProductName == null){
                    gotItems.RemoveAt(i);
                }        
            }
            return gotItems;
        }
    }
}