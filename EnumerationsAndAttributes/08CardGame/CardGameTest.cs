using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08CardGame
{
    class CardGameTest
    {
        static void Main()
        {
            string firstPlayerName = Console.ReadLine();
            string secondPlayerName = Console.ReadLine();
            Player playerOne = new Player(firstPlayerName);
            Player playerTwo = new Player(secondPlayerName);
            Deck deck = new Deck();
            string cardInput = Console.ReadLine();
            while(playerOne.HandSize < 5)
            {
                string[] cardInfo = cardInput.Split();
                try
                {
                    Rank rank = (Rank)Enum.Parse(typeof(Rank), cardInfo[0]);
                    Suit suit = (Suit)Enum.Parse(typeof(Suit), cardInfo[2]);

                    Card card = new Card(rank, suit);

                    if(deck.Contains(card))
                    {
                        deck.DrawCard(card);
                        playerOne.AddCard(card);
                    }
                    else
                    {
                        Console.WriteLine("Card is not in the deck.");
                    }
                }
                catch(ArgumentException)
                {
                    Console.WriteLine("No such card exists.");
                }

                
                cardInput = Console.ReadLine();
            }

            while (playerTwo.HandSize < 5)
            {
                string[] cardInfo = cardInput.Split();
                try
                {
                    Rank rank = (Rank)Enum.Parse(typeof(Rank), cardInfo[0]);
                    Suit suit = (Suit)Enum.Parse(typeof(Suit), cardInfo[2]);

                    Card card = new Card(rank, suit);

                    if (deck.Contains(card))
                    {
                        deck.DrawCard(card);
                        playerTwo.AddCard(card);
                    }
                    else
                    {
                        Console.WriteLine("Card is not in the deck.");
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("No such card exists.");
                }

                cardInput = Console.ReadLine();
            }

            if(playerOne.HighestCard.CompareTo(playerTwo.HighestCard) > 0)
            {
                Console.WriteLine("{0} wins with {1}", playerOne.Name, playerOne.HighestCard);
            }
            else
            {
                Console.WriteLine("{0} wins with {1}", playerTwo.Name, playerTwo.HighestCard);
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

        public override int GetHashCode()
        {
            return (int)this.Rank + (int)this.Suit;
        }

        public override bool Equals(object obj)
        {
            Card other = obj as Card;
            if(this.Suit != other.Suit)
            {
                return false;
            }

            if(this.Rank != other.Rank)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return string.Format("{0} of {1}.", this.Rank, this.Suit);
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

        public int Count { get { return this.cards.Count; } }

        public void Shuffle()
        {
            Random randGen = new Random();

            var shuffledCards = new List<Card>(this.cards);

            for (int i = 0; i < this.cards.Count; i++)
            {
                int r = i + (int)(randGen.NextDouble() * (this.cards.Count - i));
                Card temp = shuffledCards[r];
                shuffledCards[r] = shuffledCards[i];
                shuffledCards[i] = temp;
            }

            this.cards = shuffledCards;
        }

        public bool Contains(Card card)
        {
            return this.cards.Contains(card);
        }

        public void DrawCard(Card card)
        {
            this.cards.Remove(card);
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

    class Player
    {
        private ICollection<Card> hand;

        public Player(string name)
        {
            this.Name = name;
            this.hand = new List<Card>(5);
        }

        public string Name { get; private set; }

        public IEnumerable<Card> Hand
        {
            get
            {
                return this.hand;
            }
        }

        public int HandSize
        {
            get
            {
                return this.hand.Count;
            }
        }

        public Card HighestCard
        {
            get
            {
                return this.Hand.OrderBy(x => x.Power).LastOrDefault();
            }
        }

        public void AddCard(Card card)
        {
            this.hand.Add(card);
        }
    }
}
