using StoreModels;
namespace StoreBL
{
    public interface ICustomer
    {
        //These methods also need to be in the repository DL class
         public void newCustomer(Customer customer);
         List<Customer> GetCustomers();
    }
}