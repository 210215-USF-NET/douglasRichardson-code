namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a store location.
    /// </summary>
    public class Location
    {
        //Maybe change address into a compositve value thing? street name, state, city
        private string address;
        private string locationName;
        public string Address { get; set; }
        public int LocationID {get; set;}
        public string LocationName { get; set; }
        
        //TODO: add item array list? item interface?
        //public ItemGroup { get; set;}
    }
}