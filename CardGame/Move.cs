using SharpDeck;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCardGame
{
    public class Move
    {
        public Player Player { get; set; }
        public Card Card { get; set; }

        public Move(Player player, Card card)
        {
            this.Player = player;
            this.Card = card;
        }

        public override string ToString()
        {
            return Player.Name + " plays " + Card.ToMaxetaString() + ".";
        }
    }
}

