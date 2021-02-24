using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface ICustomerRepo
    {
         public void AddNewCustomer(Customer customer);
         //getCustomers is for putting all the customers into a list and resaving them into the json file
        List<Customer> GetCustomers();

    }
}