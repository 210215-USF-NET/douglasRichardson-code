using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using System.Collections.Generic;
namespace StoreDL.Mappers
{
    public class ManagerMapper
    {
        public Model.Manager ParseManager(Entity.Manager manager){
            return new Model.Manager{
                FirstName = manager.FirstName,
                LastName = manager.LastName,
                EmailAddress = manager.EmailAddress
            };
        }
        public Entity.Manager ParseManager(Model.Manager manager){
            return new Entity.Manager{
                FirstName = manager.FirstName,
                LastName = manager.LastName,
                EmailAddress = manager.EmailAddress
            };
        }
    }
}