namespace SharpDeck
{
    public class Card
    {
        private Suit _suit { get; set; }
        private Rank _rank { get; set; }
        private double _maxetaValue { get;set; }

        public Card(Rank rank, Suit Suit)
        {
            this._suit = Suit;
            this._rank = rank;
            this._maxetaValue = (double)rank + (double)Suit * 0.1;
        }

        public bool IsJoker
        {
            get
            {
                return this._rank == 0;
            }
        }

        public Rank Rank
        {
            get
            {
                return this._rank;
            }
        }

        public Suit Suit
        {
            get
            {
                return this._suit;
            }
        }

        public double maxetaValue
        {
            get
            {
                return this._maxetaValue;
            }
        }

        public override string ToString()
        {
            return CardTranslator.Translate(this);
        }

        public string ToMaxetaString()
        {
            return CardTranslator.MaxetaTranslate(this);
        }

    }

    public enum Rank
    {
        Joker = -1,
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

    public enum Suit
    {
        Clubs = 1,
        Diamonds = 2,
        Hearts = 3,
        Spades = 4
    }
}