using StoreModels;
using StoreDL;
using System.Collections.Generic;
using Serilog;

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
            Log.Logger = new LoggerConfiguration()
            .WriteTo.File(@"ourLog.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }
        public void AddItemToRepo(Item Item){
            itemRepo.AddNewItem(Item);
        }
        public void ChangeItemQuantity(Item Item){
            if(Item.Quantity < 0){
                throw new NumberCannotBeNegative();
            }
            itemRepo.ChangeItemQuantity(Item);
            Log.Information("Item "+Item.Product.ProductName+" was changed to "+Item.Quantity);
        }
        public void ChangeItemLocation(Item Item){
            itemRepo.ChangeItemLocation(Item);
            Log.Information("Item "+Item.Product.ProductName+" was changed to "+Item.ItemLocation);
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