using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using System.Collections.Generic;
namespace StoreDL.Mappers
{
    public class ItemMapper
    {
        public Model.Item ParseItem(Entity.Item Item){
            if(Item.Location != null){
                return new Model.Item{
                    Product = ParseProduct(Item.Product),
                    ItemID = Item.Id,
                    ItemLocation = ParseLocation(Item.Location),
                    Quantity = (int) Item.Quantity
                };
            }else{
                return new Model.Item{
                    Product = ParseProduct(Item.Product),
                    ItemID = Item.Id,
                    Quantity = (int) Item.Quantity
                };
            }
            
        }
        public Entity.Item ParseItem(Model.Item Item){
            
            if(Item.ItemLocation != null){
                return new Entity.Item{
                    Product = ParseProduct(Item.Product),
                    Location = ParseLocation(Item.ItemLocation),
                    Quantity = Item.Quantity
                };
            }else{
                return new Entity.Item{
                    Product = ParseProduct(Item.Product),
                    Quantity = Item.Quantity
                };
            }
        }

        public Model.Product ParseProduct(Entity.Product Product){
            return new Model.Product{
                Price = (double) Product.Price,
                ProductName = Product.ProductName,
                Category = (Model.Category) Product.Category
            };
        }
        public Entity.Product ParseProduct(Model.Product Product){
            return new Entity.Product{
                ProductName = Product.ProductName,
                Price = Product.Price,
                Category = (int) Product.Category
            };
        }
        public Model.Location ParseLocation(Entity.LocationTable Location){
            return new Model.Location{
                Address = Location.LocationAddress,
                LocationID = Location.Id,
                LocationName = Location.LocationName
            };
        }
        public Entity.LocationTable ParseLocation(Model.Location Location){
            return new Entity.LocationTable{
                LocationAddress = Location.Address,
                LocationName = Location.LocationName
            };
        }
    }
}