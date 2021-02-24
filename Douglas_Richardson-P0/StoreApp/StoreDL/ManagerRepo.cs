using System.IO;
using System.Text.Json;
using System;
using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public class ManagerRepo : IManagerRepo
    {
        private string jsonString;
        private string filePath = "../StoreDL/Managers.json";
        public void AddNewManager(Manager Manager){
            List<Manager> ManagersFromFile = GetManagers();
            ManagersFromFile.Add(Manager);
            jsonString = JsonSerializer.Serialize(ManagersFromFile);
            File.WriteAllText(filePath, jsonString);
        }
        public List<Manager> GetManagers(){
            try{
                jsonString = File.ReadAllText(filePath);
            }catch(Exception e){
                return new List<Manager>();
            }
            return JsonSerializer.Deserialize<List<Manager>>(jsonString);
        }

    }//class
}
