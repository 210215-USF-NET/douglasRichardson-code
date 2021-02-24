using System.IO;
using System.Text.Json;
using System;
using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public class OrderRepo
    {
        private string jsonString;
        private string filePath = "../StoreDL/Orders.json";
        public void PushOrder(Order Order){
            List<Order> ItemsFromFile = GetOrders();
            ItemsFromFile.Add(Order);
            jsonString = JsonSerializer.Serialize(ItemsFromFile);
            File.WriteAllText(filePath, jsonString);
        }
        public List<Order> GetOrders(){
            try{
                jsonString = File.ReadAllText(filePath);
            }catch(Exception e){
                return new List<Order>();
            }
            return JsonSerializer.Deserialize<List<Order>>(jsonString);
        }
    }
}