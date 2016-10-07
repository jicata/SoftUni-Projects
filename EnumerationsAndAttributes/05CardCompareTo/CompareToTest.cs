using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05CardCompareTo
{

    class CompareCardsTest
    {
        static void Main(string[] args)
        {
            Rank firstCardRank = (Rank)Enum.Parse(typeof(Rank), Console.ReadLine());
            Suit firstCardSuit = (Suit)Enum.Parse(typeof(Suit), Console.ReadLine());
            Rank secondCardRank = (Rank)Enum.Parse(typeof(Rank), Console.ReadLine());
            Suit secondCardSuit = (Suit)Enum.Parse(typeof(Suit), Console.ReadLine());

            Card first = new Card(firstCardRank, firstCardSuit);
            Card second = new Card(secondCardRank, secondCardSuit);

            if (first.CompareTo(second) <= 0)
            {
                Console.WriteLine(second);
            }
            else
            {
                Console.WriteLine(first);
            }
        }
    }

    enum Suit
    {
        Clubs = 0,
        Diamonds = 13,
        Hearts = 26,
        Spades = 39
    }

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

    class Card : IComparable<Card>
    {
        public Card(Rank rank, Suit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
            this.Power = (int)this.Rank + (int)this.Suit;
        }

        public Rank Rank { get; private set; }
        public Suit Suit { get; private set; }
        public int Power { get; private set; }

        public int CompareTo(Card other)
        {
            return this.Power.CompareTo(other.Power);
        }

        public override string ToString()
        {
            return string.Format("Card name: {0} of {1}; Card power: {2}",
                this.Rank,
                this.Suit,
                this.Power);
        }
    }
    
    class Deck : IEnumerable<Card>
    {
        private ICollection<Card> cards;

        public Deck()
        {
            this.cards = new List<Card>();
            var suits = Enum.GetValues(typeof(Suit));
            var ranks = Enum.GetValues(typeof(Rank));
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    Rank r = (Rank)Enum.Parse(typeof(Rank), rank.ToString());
                    Suit s = (Suit)Enum.Parse(typeof(Suit), suit.ToString());
                    this.cards.Add(new Card(r, s));
                }
            }
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Card> GetEnumerator()
        {
            foreach (Card card in cards)
            {
                yield return card;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }  
}
