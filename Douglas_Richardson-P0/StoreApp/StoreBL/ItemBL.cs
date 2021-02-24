using StoreModels;
using StoreDL;
using System.Collections.Generic;
namespace StoreBL
{
    public class ItemBL
    {
        private IItemRepo iItemRepo;
        public ItemBL(IItemRepo newIItemRepo){
            iItemRepo = newIItemRepo;
        }
        public void AddItemToRepo(Item Item){
            iItemRepo.AddNewItem(Item);
        }
        public void ChangeItemQuantity(Item Item){
            iItemRepo.ChangeItemQuantity(Item);
        }
        public void ChangeItemLocation(Item Item){
            iItemRepo.ChangeItemLocation(Item);
        }
        //Give the items to the user
        public List<Item> GetItems(){
            return iItemRepo.GetItems();
        }
    }
}