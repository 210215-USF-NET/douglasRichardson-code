using System;
using HeroDemoModels;

//this adds the folder as a reference to the project file
//dotnet add reference ../HeroDemoModels

namespace HeroDemo
{
    /// <summary>
    /// The UI for the heroes
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Add hero method
            Hero newHero = new Hero();
            Console.WriteLine("Enter a hero name: ");
            newHero.HeroName = Console.ReadLine();
            Console.WriteLine("Enter HP value: ");
            newHero.Hp = Convert.ToInt16(Console.ReadLine());


            SuperPower newSuperPower = new SuperPower();
            Console.WriteLine("Enter super power details: ");
            Console.WriteLine("Enter superhero power name: ");
            newSuperPower.Name = Console.ReadLine();
            Console.WriteLine("Enter superhero power description: ");
            newSuperPower.Description = Console.ReadLine();
            Console.WriteLine("Enter SuperPower damage: ");
            newSuperPower.Damage = Convert.ToInt16(Console.ReadLine());
            newHero.SuperPower = newSuperPower;
            
            //Element newElement = new Element();
            Console.WriteLine("Enter the hero element type: ");
            newHero.ElementType = Enum.Parse<Element >(Console.ReadLine());

            Console.WriteLine($"A new Hero created with: \n\t name: {newHero.HeroName} \n\t superPower: {newHero.SuperPower.Name} \n\t type: {newHero.ElementType}");

            
        }//main method
    }//class
}
