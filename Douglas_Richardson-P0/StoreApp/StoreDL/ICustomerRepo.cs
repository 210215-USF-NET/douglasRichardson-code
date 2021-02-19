namespace StoreDL
{
    public interface ICustomerRepo
    {
         public void newCustomer(Customer customer);
         List<Customer> GetCustomers();
    }
}