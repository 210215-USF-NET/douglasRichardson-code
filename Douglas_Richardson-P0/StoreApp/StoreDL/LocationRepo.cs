using System.IO;
using System.Text.Json;
using System;
using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public class LocationRepo
    {
        private string jsonString;
        private string filePath = "../StoreDL/Locations.json";
        public void AddNewLocation(Location Location){
            List<Location> LocationsFromFile = GetLocations();
            LocationsFromFile.Add(Location);
            jsonString = JsonSerializer.Serialize(LocationsFromFile);
            File.WriteAllText(filePath, jsonString);
        }
        public List<Location> GetLocations(){
            try{
                jsonString = File.ReadAllText(filePath);
            }catch(Exception e){
                return new List<Location>();
            }
            return JsonSerializer.Deserialize<List<Location>>(jsonString);
        }

    }//class
}
