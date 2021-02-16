using System;
/*
fields are characteristics of the object
properties are smart fields

POCO: plain c# object, 
    - class that holds data
*/


namespace HeroDemoModels
{

    /// <summary>
    /// Data structure for modeling the hero
    /// </summary>
    public class Hero
    {
        private string heroName;
        private int hp;
        private Element elementType;
        private SuperPower superPower;
        //keyword prop as a shortcut to create this
        public string HeroName { 
            get{ return heroName;}
            set{
                if (value.Equals(null)){
                    //TODO: exception
                   
                }
                heroName = value;
            }
        }//HeroName property

        public int Hp{get; set;}
        public Element ElementType {get;set;}

        public SuperPower SuperPower {get;set;}
    }//hero class
}
