using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using System.Collections.Generic;
namespace StoreDL
{
    public class CustomerMapper
    {
        public Model.Customer ParseCustomer(Entity.Customer customer){
            return new Model.Customer{
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                EmailAddress = customer.EmailAddress
            };
        }
        public Entity.Customer ParseCustomer(Model.Customer customer){
            return new Entity.Customer{
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                EmailAddress = customer.EmailAddress
            };
        }
    }
}