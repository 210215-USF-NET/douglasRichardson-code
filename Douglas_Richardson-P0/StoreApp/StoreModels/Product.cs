namespace StoreModels
{
    //This class should contain all necessary fields to define a product.
    public class Product
    {
        private int productID;
        private string productName;
        private double price;
        private Category category;
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
    }
}