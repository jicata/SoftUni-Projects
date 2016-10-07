namespace _04CardsWithPower
{
    using System;
    using System.Linq;

    enum CardSuits
    {
        Clubs = 0,
        Diamonds = 13,
        Hearts = 26,
        Spades = 39
    }
    enum CardRank
    {

        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eigth = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }

    class Card
    {
        private CardSuits suit;
        private CardRank rank;

        public Card(CardSuits suit, CardRank rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        public override string ToString()
        {
            return $"Card name: {this.rank} of {this.suit}; Card power: {this.CalcPower()}";
        }

        private int CalcPower()
        {
            int suitPower = 0;
            switch (this.suit)
            {
                case CardSuits.Clubs:
                    suitPower = (int)CardSuits.Clubs;
                    break;
                case CardSuits.Hearts:
                    suitPower = (int)CardSuits.Hearts;
                    break;
                case CardSuits.Diamonds:
                    suitPower = (int)CardSuits.Diamonds;
                    break;
                case CardSuits.Spades:
                    suitPower = (int)CardSuits.Spades;
                    break;
            }
            int totalPower = (int)this.rank + suitPower;
            return totalPower;
        }
    }

    class Program
    {
        static void Main()
        {
            string rank = Console.ReadLine();
            string suit = Console.ReadLine();

            CardRank trueRank = (CardRank)Enum.Parse(typeof(CardRank), rank, false);
            CardSuits trueSuit = (CardSuits)Enum.Parse(typeof(CardSuits), suit, false);
            Card card = new Card(trueSuit, trueRank);
            Console.WriteLine(card.ToString());
        }
    }
}
