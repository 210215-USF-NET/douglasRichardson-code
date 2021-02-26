using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using System.Collections.Generic;
namespace StoreDL.Mappers
{
    public class CartMapper
    {
        public Model.Order ParseOrder(Entity.Cart Order){
            if(Order != null){
                if(Order.Customer != null && Order.Location != null){
                    return new Model.Order{
                        Customer = ParseCustomer(Order.Customer),
                        Total = (double) Order.Total,
                        Quantity = (int) Order.Quantity,
                        Location = ParseLocation(Order.Location),
                        orderItems = new ItemMapper().ParseItem(Order.Item),
                        Id = Order.Id
                    };
                }else{
                    return new Model.Order{
                        Customer = null,
                        Total = (double) Order.Total,
                        Quantity = (int) Order.Quantity,
                        Location = null,
                        orderItems = new ItemMapper().ParseItem(Order.Item),
                        Id = Order.Id
                    };
                }
            }else{
                return null;
            }
            
            
        }
        public Entity.Cart ParseOrder(Model.Order Order){
            if(Order.Id == null){
                return new Entity.Cart{
                    Customer = ParseCustomer(Order.Customer),
                    Total = Order.Total,
                    Quantity = Order.Quantity,
                    Location = ParseLocation(Order.Location),
                    Item = new ItemMapper().ParseItem(Order.orderItems)
                };
            }
            return new Entity.Cart{
                Customer = ParseCustomer(Order.Customer),
                Total = Order.Total,
                Quantity = Order.Quantity,
                Location = ParseLocation(Order.Location),
                Item = new ItemMapper().ParseItem(Order.orderItems),
                Id = (int)Order.Id
            };
        }
        public Model.Customer ParseCustomer(Entity.Customer customer){
            return new Model.Customer{
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                EmailAddress = customer.EmailAddress
            };
        }
        public Entity.Customer ParseCustomer(Model.Customer customer){
            return new Entity.Customer{
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                EmailAddress = customer.EmailAddress
            };
        }
        public Model.Location ParseLocation(Entity.LocationTable Location){
            return new Model.Location{
                Address = Location.LocationAddress,
                LocationName = Location.LocationName
            };
        }
        public Entity.LocationTable ParseLocation(Model.Location Location){
            return new Entity.LocationTable{
                LocationAddress = Location.Address,
                LocationName = Location.LocationName
            };
        }
        
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
    }
}