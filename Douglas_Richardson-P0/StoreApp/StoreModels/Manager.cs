namespace StoreModels
{
    /// <summary>
    /// This class should contain necessary properties and fields for customer info.
    /// </summary>
    public class Manager
    {
        //TODO: Create a menu factory and a person factory
        private string firstName;
        private string lastName;
        private string emailAddress;
        private int managerID = 0;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int ManagerID { get; set; }
        //TODO: Order history here
    }
}