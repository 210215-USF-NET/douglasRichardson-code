using System.IO;
using System.Text.Json;
using System;
using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{
    public class CartRepo
    {
        private string jsonString;
        private string filePath = "../StoreDL/Cart.json";
        // public void CreateNewCart(){
        //     List<Item> ItemsFromFile = GetCartItems();
        //     ItemsFromFile.Add(order);
        //     jsonString = JsonSerializer.Serialize(ItemsFromFile);
        //     File.WriteAllText(filePath, jsonString);
        // }
        public List<Item> GetCartItems(){
            try{
                jsonString = File.ReadAllText(filePath);
            }catch(Exception e){
                return new List<Item>();
            }
            return JsonSerializer.Deserialize<List<Item>>(jsonString);
        }
        public void AddNewItemToOrder(Item item){
            List<Item> ItemsFromFile = GetCartItems();
            ItemsFromFile.Add(item);
            jsonString = JsonSerializer.Serialize(ItemsFromFile);
            File.WriteAllText(filePath, jsonString);
        }
        public void RemoveItemFromOrder(Item item){
            List<Item> ItemsFromFile = GetCartItems();
            foreach (Item listItem in ItemsFromFile){
                if(item.ItemID == listItem.ItemID){
                    //TODO: REMOVE item from list
                    //ItemsFromFile
                }
            }
            jsonString = JsonSerializer.Serialize(ItemsFromFile);
            File.WriteAllText(filePath, jsonString);
        }

        public void SetPrice(){

        }

        public double GetPrice(){

        }
        public void EmptyCart(){
            
        }
    }
}