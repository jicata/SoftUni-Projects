namespace _02CardRank
{
    using System;
    enum CardRank
    {
            Ace,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
    }
    class Program
    {
        static void Main()
        {
            CardRank[] cardRanks = (CardRank[]) Enum.GetValues(typeof(CardRank));
        
            Console.WriteLine("Card Ranks:");
            foreach (var cardRank in cardRanks)
            {
                Console.WriteLine("Ordinal value: {0}; Name value: {1}", (int)cardRank, cardRank);
            }
        }
    }
}
