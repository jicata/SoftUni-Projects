using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06CustomTypeAttribute
{
    class CustomTypeAttributeTest
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Type type = null;
            if(input == "Rank")
            {
                type = typeof(Rank);
            }
            else if(input == "Suit")
            {
                type = typeof(Suit);
            }

            var customAttributes = type.GetCustomAttributes(false);
            foreach (TypeAttribute attribute in customAttributes)
            {
                Console.WriteLine("Type = {0}, Description = {1}", attribute.Type, attribute.Description);
            }
        }
    }
    
    [Type("Enumeration", "Suit", "Provides suit constants for a Card class.")]
    enum Suit
    {
        Clubs = 0,
        Diamonds = 13,
        Hearts = 26,
        Spades = 39
    }

    [Type("Enumeration", "Rank", "Provides rank constants for a Card class.")]
    enum Rank
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }

    [AttributeUsage(AttributeTargets.Enum, AllowMultiple = true)]
    class TypeAttribute : Attribute
    {
        public TypeAttribute(string type, string category, string description)
        {
            this.Type = type;
            this.Category = category;
            this.Description = description;
        }

        public string Type { get; private set; }
        public string Category { get; private set; }
        public string Description { get; private set; }
    }

    
}
