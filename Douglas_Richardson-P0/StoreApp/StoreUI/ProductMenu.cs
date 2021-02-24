using System;
using System.Collections.Generic;
using StoreModels;
using StoreBL;
namespace StoreUI
{
    public class ProductMenu : IMenu
    {
        //active is for the product menu
        bool active = true;
        private ProductBL productBL;
        private ItemBL itemBL;
        private IUserBL ourUserBL;
        private LocationBL locationBL;
        private CartBL cartBL;
        public ProductMenu(ProductBL newProductBL, ItemBL newItemBL, IUserBL userBL, LocationBL newLocationBL, CartBL newCartBL){
            productBL = newProductBL;
            itemBL = newItemBL;
            ourUserBL = userBL;
            locationBL = newLocationBL;
            cartBL = newCartBL;
        }

        public void End()
        {
            active = false;
            MenuFactory menuFactory = new MenuFactory(ourUserBL);
            menuFactory.Start();   
        }
        public void End(Manager manager)
        {
            active = false;
            MenuFactory menuFactory = new MenuFactory(ourUserBL);
            menuFactory.Start(manager);   
        }
        public void End(Customer customer)
        {
            active = false;
            MenuFactory menuFactory = new MenuFactory(ourUserBL);
            menuFactory.Start(customer);   
        }
        public void Start(){}

        //Customer product menu start
        public void Start(Customer customer)
        {
            active = true;
            do{
                //TODO: Let customer choose a product, then view the product, then add to cart.
                //Get the store locations first, let hte customer choose
                List<Location> thisLocationList = locationBL.GetLocations();
                if(thisLocationList.Count != 0){
                    foreach (Location location in thisLocationList){
                        Console.WriteLine("["+location.LocationID+"] "+location.LocationName);
                    }
                }else{
                    Console.WriteLine("There are no store locations.");
                    active = false;
                }
                try{
                    string userInput = Console.ReadLine();
                    if(userInput.Equals("!stop")){ 
                        Start(customer); 
                        break;   
                    }
                    //change string input to an int, then find it in the list
                    int choice = Int32.Parse(userInput);
                    foreach (Location location in thisLocationList){
                        if(choice == location.LocationID){
                            cartBL.AddCustomer(customer);
                            cartBL.AddLocation(location);
                            ListItemsMenuCustomer(customer,location);
                        }else{
                            throw new InvalidItemIdException("Not a valid location id.");
                        }
                    }
                }catch(FormatException){
                    Console.WriteLine("Please type in a number. ");
                }catch(InvalidItemIdException){}
                catch(Exception){}
                
            }while(active);
        }//start
        public void Start(Manager manager)
        {
            active = true;
            do{
                Console.WriteLine("Product Manager Menu");
                Console.WriteLine("[1] Add New Product");
                Console.WriteLine("[2] Add New Location");
                Console.WriteLine("[3] Change Item Quantity");
                Console.WriteLine("[4] Change Item Location");
                Console.WriteLine("[5] Back to Previous Menu");
                ManagerView(manager);
            }while(active);
        }//start

        private void ManagerView(Manager manager){
            string userInput = Console.ReadLine();
            switch(userInput){
                //New product
                case "1":
                    NewProductMenu(manager);
                    Start(manager);
                    break;
                //Add New Location
                case "2":
                    AddNewLocation(manager);
                    break;
                //Change Item Quantity  
                case "3":
                    ListItemsMenuManager(manager,true,false);
                    Start(manager);
                    break;
                //Change Item Location
                case "4":
                    ListItemsMenuManager(manager,false,true);
                    Start(manager);
                    break;
                case "5":
                    End(manager);
                    break;
                default:
                    break;
            }
        }

        private void CustomerView(Customer customer, Location location){

        }

        //Opens the store, gets the items and displays them
        private void ListItemsMenuCustomer(Customer customer, Location location){
            Console.WriteLine(location.LocationName+"'s Menu");
            Console.WriteLine("Type !stop to exit out of this menu.");
            List<Item> thisItemList = itemBL.GetItems();
            if(thisItemList.Count != 0){
                foreach (Item item in thisItemList){
                    if(item.ItemLocation == location){
                        Console.WriteLine("["+item.ItemID+"] "+item.Product.ProductName+" Price: "+item.Product.Price+" Quantity: "+item.Quantity);
                    }
                }
            }else{
                Console.WriteLine("There are no items.");
                Start(customer);
                active = false;
            }
            while(active){
                try{
                    //give the user input, check if they want to stop
                    string userInput = Console.ReadLine();
                    if(userInput.Equals("!stop")){ 
                        Start(customer); 
                        break;   
                    }
                    //change string input to an int, then find it in the list
                    int choice = Int32.Parse(userInput);
                    foreach (Item item in thisItemList){
                        if(choice == item.ItemID){
                            //TODO: How many items, add item to cart
                            Console.WriteLine("There is "+item.Quantity);
                            Console.WriteLine("How many of "+item.Product.ProductName+" do you want?");
                            AddQuantityToCartMenu(item);
                        }else{
                            throw new InvalidItemIdException("Not a valid item id.");
                        }
                    }
                }catch(FormatException){
                    Console.WriteLine("Please type in a number. ");
                }catch(InvalidItemIdException){}
                catch(Exception){}
            }
        }//ListItemsMenu

        private void AddQuantityToCartMenu(Item item){
            try{
                string userInput = Console.ReadLine();
                int choice = Int32.Parse(userInput);
                item.Quantity = choice;
                cartBL.AddNewItemToOrder(item);
            }catch(FormatException){
                Console.WriteLine("Please type in a number from 1 to "+item.Quantity);
            }catch(Exception){}
        }

        private void NewProductMenu(Manager manager){
            Product newProduct = new Product();
            Console.WriteLine("New Product Menu. ");
            Console.WriteLine("Type !stop to exit out of this menu.");
            do{
                if(newProduct.ProductName == null){
                    Console.WriteLine("Please type in a product name.");
                }else if(newProduct.Price == 0.0d){
                    Console.WriteLine("Please type in a price. ");
                }else if(newProduct.Category == Category.Nothing){
                    Console.WriteLine("Please pick in a valid category. ");
                    Console.WriteLine("[1] Food");
                    Console.WriteLine("[2] Collars");
                    Console.WriteLine("[3] Leashes");
                    Console.WriteLine("[4] Clothes");
                    Console.WriteLine("[5] Beds");
                    Console.WriteLine("[6] Accessories");
                }
                try{
                    //give the user input, check if they want to stop
                    string userInput = Console.ReadLine();
                    if(userInput.Equals("!stop")){ 
                        End(manager);     
                    }
                    if(newProduct.ProductName == null){
                        newProduct.ProductName = userInput;
                    }else if(newProduct.Price == 0.0d){
                        double result;
                        Double.TryParse(userInput, out result);
                        newProduct.Price = result;
                    }else if(newProduct.Category == Category.Nothing){
                         switch(userInput){
                             case "1":
                                newProduct.Category = Category.Food;
                                active = false;
                                break;
                             case "2":
                                newProduct.Category = Category.Collars;
                                active = false;
                                break;
                             case "3":
                                newProduct.Category = Category.Leashes;
                                active = false;
                                break;
                             case "4":
                                newProduct.Category = Category.Clothes;
                                active = false;
                                break;
                             case "5":
                                newProduct.Category = Category.Beds;
                                active = false;
                                break;
                             case "6":
                                newProduct.Category = Category.Accessories;
                                active = false;
                                break;
                         }
                         productBL.AddProduct(newProduct);
                    }
                }catch(Exception){
                    
                }
            }while(active);
        }//End of NewProductMenu

        //This method lists all of the items for the manager, and allows them to choose an item to change the item's location or quantity
        private void ListItemsMenuManager(Manager manager, bool isChangingItemQuantity, bool isChangingItemLocation){
            if(isChangingItemQuantity){
                Console.WriteLine("Change Item Quantity Menu");
            }else{
                Console.WriteLine("Change Item Location Menu");
            }
            Console.WriteLine("Type !stop to exit out of this menu.");
            //Print all the items, this lets the user know which ones to choose
            List<Item> thisItemList = itemBL.GetItems();
            if(thisItemList.Count != 0){
                foreach (Item item in thisItemList){
                    Console.WriteLine("["+item.ItemID+"] "+item.Product.ProductName+" amount: "+item.Quantity);
                }
            }else{
                Console.WriteLine("There are no items.");
                active = false;
            }
            while(active){
                try{
                    //give the user input, check if they want to stop
                    string userInput = Console.ReadLine();
                    if(userInput.Equals("!stop")){ 
                        Start(manager); 
                        break;   
                    }
                    //change string input to an int, then find it in the list
                    int choice = Int32.Parse(userInput);
                    foreach (Item item in thisItemList){
                        if(choice == item.ItemID){
                            if(isChangingItemQuantity){
                                GiveItemQuantityMenu(item);   
                            }else{
                                GiveItemLocationMenu(item);           
                            }    
                        }else{
                            throw new InvalidItemIdException("Not a valid item id.");
                        }
                    }
                }catch(FormatException){
                    Console.WriteLine("Please type in a number. ");
                }catch(InvalidItemIdException){}
                catch(Exception){}
            }
        }//ListItemsMenuManager

        private void GiveItemQuantityMenu(Item item){
            Console.WriteLine("Please enter the quantity for "+item.Product.ProductName);
            do{
                try{
                    string userInput = Console.ReadLine();
                    int choice = Int32.Parse(userInput);
                    item.Quantity = choice;
                    itemBL.ChangeItemQuantity(item);
                    active = false;
                }catch(FormatException){
                    Console.WriteLine("Please type in a number. ");
                }catch(Exception){}
            }while(active);
        }

        private void GiveItemLocationMenu(Item item){
            Console.WriteLine("Choose a new location for an item");
            List<Location> thisLocationList = locationBL.GetLocations();
            if(thisLocationList.Count != 0){
                foreach (Location location in thisLocationList)
                {
                    Console.WriteLine("["+location.LocationID+"] "+location.LocationName);
                }
            }else{
                Console.WriteLine("There are no locations.");
                active = false;
            }
            do{
                try{
                    string userInput = Console.ReadLine();
                    int choice = Int32.Parse(userInput);
                    foreach (Location location in thisLocationList){
                        if(choice == location.LocationID){
                            item.ItemLocation = location;
                        }else{
                            throw new InvalidItemIdException("Not a valid location id.");
                        }
                    }
                    active = false;
                }catch(FormatException){
                    Console.WriteLine("Please type in a number. ");
                }catch(InvalidItemIdException){}
                catch(Exception){}
            }while(active);
        }

        private void AddNewLocation(Manager manager){
            Console.WriteLine("Please enter a new location");
            Location location = new Location();
            do{
                if(location.LocationName == null){
                    Console.WriteLine("Type in the name for the location.");
                }else if(location.Address == null){
                    Console.WriteLine("Type in the address for the location. ");
                }
                try{
                    string userInput = Console.ReadLine();
                    if(location.LocationName == null){
                        location.LocationName = userInput;
                    }else if(location.Address == null){
                        location.Address = userInput;
                    }
                    locationBL.AddNewLocation(location);
                    active = false;
                    Start(manager);
                }catch(FormatException){
                    Console.WriteLine("Please type in a number. ");
                }catch(Exception){}
            }while(active);
        }
    }//class
}