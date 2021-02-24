using StoreModels;
using StoreDL;
using System.Collections.Generic;
namespace StoreBL
{
    public class CustomerBL : ICustomerBL
    {

        private ICustomerRepo iCustomerRepo;
        public CustomerBL(ICustomerRepo newICustomerRepo){
            iCustomerRepo = newICustomerRepo;
        }

        public void AddNewCustomer(Customer customer){
            List<Customer> newList = GetCustomers();
            int newCustomerID = newList.Count + 1;
            customer.CustomerID = newCustomerID;
            //TODO:New Order History, will be empty
            iCustomerRepo.AddNewCustomer(customer);
        }
        public List<Customer> GetCustomers(){
            return iCustomerRepo.GetCustomers();
        }
        public Customer FindCustomerOnEmail(string emailAddress){
            List<Customer> theseCustomers = GetCustomers();
            foreach (Customer c in theseCustomers)
            {
                if(c.EmailAddress.Equals(emailAddress)){
                    return c;
                }
            }
            return null; 
        }
    }
}