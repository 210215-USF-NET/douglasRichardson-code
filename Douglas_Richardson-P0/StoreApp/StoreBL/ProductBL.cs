using StoreModels;
using StoreDL;
using System.Collections.Generic;
namespace StoreBL
{
    public class ProductBL
    {
        private ProductRepo productRepo;
        public ProductBL(ProductRepo newProductRepo){
            productRepo = newProductRepo;
        }
        public void AddProduct(Product Product){
            
            Product.ProductID = productRepo.GetProducts().Count+1;
            productRepo.AddNewProduct(Product);
            //Turn product into an item, default zero quantity and no location, manager has to set these
            ItemBL newItemBL = new ItemBL(new ItemRepo());
            Item newItem = new Item();
            newItem.Product = Product;
            newItem.Quantity = 0;
            newItem.ItemLocation = null;
            newItem.ItemID = newItemBL.GetItems().Count+1;
            newItemBL.AddItemToRepo(newItem);
        }
        //Give the Products to the user
        public List<Product> GetProducts(){
            return productRepo.GetProducts();
        }
    }
}