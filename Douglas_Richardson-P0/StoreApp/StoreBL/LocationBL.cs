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
            Location.LocationID = locationRepo.GetLocations().Count+1;
            locationRepo.AddNewLocation(Location);
        }
        public List<Location> GetLocations(){
            return locationRepo.GetLocations();
        }
    }
}