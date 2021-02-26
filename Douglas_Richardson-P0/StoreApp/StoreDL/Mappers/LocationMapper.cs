using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using System.Collections.Generic;
namespace StoreDL.Mappers
{
    public class LocationMapper
    {
        public Model.Location ParseLocation(Entity.LocationTable Location){
            return new Model.Location{
                Address = Location.LocationAddress,
                LocationID = Location.Id,
                LocationName = Location.LocationName
            };
        }
        public Entity.LocationTable ParseLocation(Model.Location Location){
            return new Entity.LocationTable{
                LocationAddress = Location.Address,
                LocationName = Location.LocationName
            };
        }
    }
}