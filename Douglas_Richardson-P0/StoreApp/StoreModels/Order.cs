namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a customer order. 
    /// </summary>
    public class Order
    {
        //customerid in customer
        private Customer customer;
        private Location location;
        private double total;
        private int orderID;
        
        public Customer Customer { get; set; }
        public double Total { get; set; }
        public int OrderID { get; set; }
        //TODO: collection of items
    }
}