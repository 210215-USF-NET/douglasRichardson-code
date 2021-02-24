using System.IO;
using System.Text.Json;
using System;
using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{
    public class ItemRepo : IItemRepo
    {
        private string jsonString;
        private string filePath = "../StoreDL/Items.json";
        public void AddNewItem(Item Item){
            List<Item> ItemsFromFile = GetItems();
            ItemsFromFile.Add(Item);
            jsonString = JsonSerializer.Serialize(ItemsFromFile);
            File.WriteAllText(filePath, jsonString);
        }
        public List<Item> GetItems(){
            try{
                jsonString = File.ReadAllText(filePath);
            }catch(Exception e){
                return new List<Item>();
            }
            return JsonSerializer.Deserialize<List<Item>>(jsonString);
        }

        public void ChangeItemLocation(Item item){
            List<Item> ItemsFromFile = GetItems();
            foreach (Item listItem in ItemsFromFile){
                if(item.ItemID == listItem.ItemID){
                    listItem.ItemLocation = item.ItemLocation;
                }
            }
            jsonString = JsonSerializer.Serialize(ItemsFromFile);
            File.WriteAllText(filePath, jsonString);
        }

        public void ChangeItemQuantity(Item item){
            List<Item> ItemsFromFile = GetItems();
            foreach (Item listItem in ItemsFromFile){
                if(item.ItemID == listItem.ItemID){
                    listItem.Quantity = item.Quantity;
                }
            }
            jsonString = JsonSerializer.Serialize(ItemsFromFile);
            File.WriteAllText(filePath, jsonString);
        }
    }//class
}
