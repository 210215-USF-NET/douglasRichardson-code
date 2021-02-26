using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Collections.Generic;
namespace StoreDL
{
    public interface ICustomerRepo
    {
         public void AddNewCustomer(Model.Customer customer);
         //getCustomers is for putting all the customers into a list and resaving them into the json file
        List<Model.Customer> GetCustomers();

        Model.Customer GetCustomerByName(string lastname);

    }
}