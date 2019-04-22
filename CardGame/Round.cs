using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Card = SharpDeck.Card;
using Deck = SharpDeck.SharpDeck;
using Rank = SharpDeck.Rank;

namespace ConsoleCardGame

{
    public class Round
    {
        public Game Game { get; private set; }
        public Player[] Players { get; private set; }
        public Player NextPlayer
        {
            get
            {
                foreach (Move move in Moves)
                {
                    if (move.Card == null)
                    {
                        return move.Player;
                    }
                }

                return null;
            }
            private set { }

        }
        public Deck Deck { get; private set; }
        public Move[] Moves { get; private set; }
        public Move CurrentMove { get; private set; }
        public Move WinningMove { get; private set; }
        public bool IsOver { get; set; }


        /// <summary>
        ///
        /// </summary>
        /// <param name="players">Array of players in the game.</param>
        /// <param name="deck">Deck for this round.</param>
        /// <returns></returns>
        public Round(Game game, Deck deck)
        {
            this.Game = game;
            this.Players = game.Players;
            this.NextPlayer = Players[0];
            this.Deck = deck;
            this.Moves = new Move[Players.Length];
            for (int i = 0; i < Moves.Length; i++)
            {
                Moves[i] = new Move(Players[i], null);
            }
        }


        /// <summary>
        /// Sets NextPlayer to null, set value for WinningMove, sets IsOver, and updates Game with score"
        /// </summary>
        private void EndRound()
        {
            NextPlayer = null;
            WinningMove = FindWinningMove();
            IsOver = true;
            Game.UpdateScores();
        }

        /// <summary>
        /// Creates and returns the next move. 
        /// </summary>
        /// <param name="card">Card that will be played in the next move.</param>
        /// <returns>Card</returns>
        public Move NextMove(Card card)
        {

            foreach (Move move in Moves)
            {
                if (move.Card == null)
                {
                    move.Card = card;
                    CurrentMove = move;

                    return move;
                }
            }

            EndRound();

            return null;
        }

        /// <summary>
        /// Finds the winning move of a round by comparing values for all cards. 
        /// </summary>
        /// <returns>Move</returns>
        private Move FindWinningMove()
        {
            List<Move> unorderMoves = new List<Move>();

            foreach (Move move in Moves)
            {
                if (move.Card.Rank != Rank.Joker)
                {
                    unorderMoves.Add(move);
                }
            }

            if (unorderMoves.Count > 0)
            {
                IEnumerable<Move> orderMoves = unorderMoves.OrderBy(move => move.Card.maxetaValue);
                return orderMoves.Last();
            }
            else
            {
                return null;
            }
        }

        public Move NextMove()
        {

            return NextMove(Deck.Deal());
        }

        public void AutoComplete()
        {
            while (!IsOver)
            {
                NextMove();
            }
        }


        public override string ToString()
        {
            string round = "";

            foreach (Move move in Moves)
            {
                round += move.ToString() + "\n";
            }

            return round += "The winner is " + this.WinningMove.Player.Name + " with " + this.WinningMove.Card;
        }
    }
}
