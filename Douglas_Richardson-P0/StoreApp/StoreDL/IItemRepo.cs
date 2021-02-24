using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface IItemRepo
    {
         public void AddNewItem(Item Item);
         //getItems is for putting all the Items into a list and resaving them into the json file
        List<Item> GetItems();
        void ChangeItemQuantity(Item Item);
        void ChangeItemLocation(Item Item);
    }
}