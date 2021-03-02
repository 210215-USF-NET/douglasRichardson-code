using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using System.Collections.Generic;
namespace StoreDL.Mappers
{
    public class ProductMapper
    {
        public Model.Product ParseProduct(Entity.Product Product){
            return new Model.Product{
                Price = (double) Product.Price,
                ProductName = Product.ProductName,
                Category = (Model.Category) Product.Category,
                Id = (int)Product.Id
            };
        }
        public Entity.Product ParseProduct(Model.Product Product){
            return new Entity.Product{
                ProductName = Product.ProductName,
                Price = Product.Price,
                Category = (int) Product.Category,
                Id = (int)Product.Id
            };
        }
    }
}