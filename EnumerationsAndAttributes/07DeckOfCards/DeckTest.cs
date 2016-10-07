using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08CardGame
{
    class DeckTest
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Deck deck = new Deck();
            foreach (Card card in deck)
            {
                Console.WriteLine(card);
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
        Ace = 14,
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
        King = 13
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

            var suits = Enum.GetValues(typeof(Suit)).Cast<Suit>();
            var ranks = Enum.GetValues(typeof(Rank)).Cast<Rank>();

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    this.cards.Add(new Card(rank, suit));
                }
            }
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
