namespace _03DeckOfCards
{
    using System;

    enum CardSuits
    {
        Clubs = 0,
        Diamonds = 1,
        Hearts = 2,
        Spades = 3
    }
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
            CardRank[] cardRanks = (CardRank[])Enum.GetValues(typeof(CardRank));
            CardSuits[] cardSuits = (CardSuits[])Enum.GetValues(typeof(CardSuits));
            foreach (var cardSuit in cardSuits)
            {
                foreach (var cardRank in cardRanks)
                {
                    Console.WriteLine($"{cardRank} of {cardSuit}");
                }
            }
        }
    }
}
