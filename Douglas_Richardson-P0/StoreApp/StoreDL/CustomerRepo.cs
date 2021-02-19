﻿using System.IO;
using System.Text.Json;
using System;
using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public class CustomerRepo : ICustomerRepo
    {
        private string jsonString;
        private string filePath = "./StoreDL/Customers.json";
        public void newCustomer(Customer customer){

        }
        List<Customer> GetCustomers(){
            try{
                jsonString = File.ReadAllText(filePath);
            }catch(Exception e){
                return new List<Customer>();
            }
            return JsonSerializer.Deserialize<List<Customer>>(jsonString);
        }
    }
}
