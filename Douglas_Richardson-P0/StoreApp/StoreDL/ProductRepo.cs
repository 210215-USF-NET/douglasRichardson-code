using System.IO;
using System.Text.Json;
using System;
using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public class ProductRepo
    {
        private string jsonString;
        private string filePath = "../StoreDL/Products.json";
        public void AddNewProduct(Product Product){
            List<Product> ProductsFromFile = GetProducts();
            Console.WriteLine(Product.ProductName);
            ProductsFromFile.Add(Product);
            jsonString = JsonSerializer.Serialize(ProductsFromFile);
            File.WriteAllText(filePath, jsonString);
        }
        public List<Product> GetProducts(){
            try{
                jsonString = File.ReadAllText(filePath);
            }catch(Exception e){
                return new List<Product>();
            }
            return JsonSerializer.Deserialize<List<Product>>(jsonString);
        }

    }//class
}
