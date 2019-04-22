using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SharpDeck
{

    public class SharpDeck : IEnumerable<Card>
    {
        private List<Card> _deck = new List<Card>();
        private bool hasJokers = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="withJokers">Make the deck with two jokers.</param>
        /// <param name="shuffle">Shuffle the deck after making it.</param>
        public SharpDeck(bool shuffle = true, bool withJokers = false)
        {
            this.Create();
            hasJokers = withJokers;
            if (withJokers)
            {
                // edited to included exta jokers
                _deck.Add(new Card(Rank.Joker, Suit.Hearts)); // Suit does not matter for jokers
                _deck.Add(new Card(Rank.Joker, Suit.Clubs));
                _deck.Add(new Card(Rank.Joker, Suit.Spades)); 
                _deck.Add(new Card(Rank.Joker, Suit.Diamonds));
            }

            if (shuffle)
            {
                Shuffle(DateTime.Now.Millisecond);
            }
        }

        public List<Card> Cards
        {
            get
            {
                return this._deck;
            }
        }

        /// <summary>
        /// Shuffles the deck object according to the Fisher–Yates Modern Shuffle.
        /// </summary>
        /// <param name="seed">Seed for RNG</param>
        public void Shuffle(int seed)
        {
            //Shuffle the Deck
            Random rng = new Random(seed);
            var pos = rng.Next(0, _deck.Count);
            var list = _deck.ToList();
            for (int i = 0; i < list.Count() - 1; i++)
            {
                pos = rng.Next(0, _deck.Count);
                var swapout = list[pos];
                if (pos != i)
                {
                    list[pos] = list[i];
                    list[i] = swapout;
                }

            }
            _deck = new List<Card>(list);
        }

        /// <summary>
        /// Removes and returns the top card of the deck.
        /// </summary>
        /// <returns>Top card of the deck</returns>
        public Card Deal()
        {
            //Deal the top card
            var card = _deck.First();
            _deck.RemoveAt(0);
            return card;
        }
        /// <summary>
        /// Returns the top card without removing it
        /// </summary>
        /// <returns>Top card of the deck</returns>
        public Card Peek()
        {
            return _deck.First();
        }

        /// <summary>
        ///Returns a card at a specified zero-based index.
        /// </summary>
        /// <param name="i">Zero based index position of a card in the deck.</param>
        /// <returns></returns>
        public Card this[int i]
        {
            get
            {
                return _deck.ElementAt(i);
            }
        }

        private void Create()
        {
            _deck = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit))) //O(n^2)
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    if (rank == Rank.Joker)
                    {
                        continue;
                    }
                    else
                    {
                        _deck.Add(new Card(rank, suit));
                    }
                }
            }
        }


        #region IEnumerable

        public IEnumerator<Card> GetEnumerator()
        {
            return _deck.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _deck.GetEnumerator();
        }

        #endregion
    }
}
