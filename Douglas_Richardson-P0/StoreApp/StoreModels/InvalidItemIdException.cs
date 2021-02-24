namespace StoreModels
{
    public class InvalidItemIdException : System.Exception
    {
        public InvalidItemIdException() { }
        public InvalidItemIdException(string message) : base(message) { }
        public InvalidItemIdException(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidItemIdException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}