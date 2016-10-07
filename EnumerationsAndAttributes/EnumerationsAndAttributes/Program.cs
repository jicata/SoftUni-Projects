namespace EnumerationsAndAttributes
{
    using System;

    enum CardSuits
    {
        Clubs = 0,
        Diamonds = 1,
        Hearts = 2,
        Spades = 3
    }
    class Program
    {
        static void Main()
        {
            var values = (CardSuits[])Enum.GetValues(typeof(CardSuits));
            Console.WriteLine("Card Suits:");
            foreach (var cardSuitse in values)
            {
                Console.WriteLine("Ordinal value: {0}; Name value: {1}", (int)cardSuitse, cardSuitse);
            }
            
        }
    }
}
