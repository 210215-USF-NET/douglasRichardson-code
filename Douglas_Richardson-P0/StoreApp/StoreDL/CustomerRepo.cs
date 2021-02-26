
using System;
using Model = StoreModels;
using Entity = StoreDL.Entities;
//using Mapper = StoreDL.Mappers;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace StoreDL
{
    public class CustomerRepo : ICustomerRepo
    {
        private Entity.P0DatabaseContext context;
        private CustomerMapper mapper; 
        public CustomerRepo(Entity.P0DatabaseContext context, CustomerMapper mapper){
            this.mapper = mapper;
            this.context = context;
        }
        public void AddNewCustomer(Model.Customer customer)
        {
            context.Customers.Add(mapper.ParseCustomer(customer));
            context.SaveChanges();
        }

        public Model.Customer GetCustomerByName(string lastname)
        {
            return context.Customers.Select(x => mapper.ParseCustomer(x)).ToList().FirstOrDefault(x => x.LastName == lastname);
        }

        public List<Model.Customer> GetCustomers()
        {
           return context.Customers.Select(x => mapper.ParseCustomer(x)).ToList();
        }
        // private string jsonString;
        // private string filePath = "../StoreDL/Customers.json";
        // public void AddNewCustomer(Customer customer){
        //     List<Customer> customersFromFile = GetCustomers();
        //     customersFromFile.Add(customer);
        //     jsonString = JsonSerializer.Serialize(customersFromFile);
        //     File.WriteAllText(filePath, jsonString);
        // }
        // public List<Customer> GetCustomers(){
        //     try{
        //         jsonString = File.ReadAllText(filePath);
        //     }catch(Exception e){
        //         return new List<Customer>();
        //     }
        //     return JsonSerializer.Deserialize<List<Customer>>(jsonString);
        // }
    }//class
}
