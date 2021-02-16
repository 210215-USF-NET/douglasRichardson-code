using System; 

namespace HelloWorld
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // string name = Console.ReadLine();
            // Console.WriteLine($"Hello {name}!");
            Generic<string> g = new Generic<string>();
            g.Field = "A string";
            Console.WriteLine("Generic.Field = \"{0}\"", g.Field);
            Console.WriteLine("Generic.Field.GetType() = {0}", g.Field.GetType().FullName);
        }
        
    }
    
    public class Generic<T>{
        public T Field;

    }
}
