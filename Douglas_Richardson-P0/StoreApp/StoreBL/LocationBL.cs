using StoreDL;
using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public class LocationBL
    {
        LocationRepo locationRepo;
        public LocationBL(LocationRepo newLocationRepo){
            locationRepo = newLocationRepo;
        }
        public void AddNewLocation(Location Location){
            locationRepo.AddNewLocation(Location);
        }
        public List<Location> GetLocations(){
            return locationRepo.GetLocations();
        }
    }
}