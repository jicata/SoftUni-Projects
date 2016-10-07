namespace CardCompareTo
{
    using System;
    using System.Linq;
    using System.Reflection;

    [Type("Enumeration", "Suit", "Provides suit constants for a Card class.")]
    public enum Suit
    {
        Clubs,
        Diamonds = 13,
        Hearts = 26,
        Spades = 39,
    }

    [Type("Enumeration", "Rank", "Provides rank constants for a Card class.")]
    public enum Rank
    {
        Two = 2,
        Three,
        Four,
        FivE,
        Six,
        Seven,
        Eigth,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

  
    public class Card : IComparable<Card>
    {
        Suit suit;
        Rank rank;
        private int power;

        public Card(Suit suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        public int Power
        {
            get { return (int) this.suit + (int) this.rank; }

        }

        public int CompareTo(Card other)
        {
            return this.Power.CompareTo(other.Power);
        }

        public override string ToString()
        {
            return string.Format("Card name: {0} of {1}; Card power: {2}", 
                this.rank, this.suit, Power);
        }
    }

    class Program
    {
        static void Main()
        {
            string target = Console.ReadLine();
            Type type = null;
            if (target == "Rank")
            {
                type = typeof(Rank);
            }
            else
            {
                type = typeof(Suit);
            }
            var attributes = type.GetCustomAttributes().Cast<TypeAttribute>();

            foreach (var attribute in attributes)
            {
                Console.WriteLine(attribute);
            }


        }
    }

    [AttributeUsage(AttributeTargets.Enum)]
    public class TypeAttribute : Attribute
    {
        //Type type?
        string type;
        string category;
        string description;

        public TypeAttribute(string type, string category, string description)
        {
            this.Type = type;
            this.Category = category;
            this.Description = description;
        }
    
        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public override string ToString()
        {
          //  Type = Enumeration, Description = Provides rank constants for a Card class.
            return string.Format("Type = {0}, Description = {1}", this.type, this.description);
        }
    }   
}
