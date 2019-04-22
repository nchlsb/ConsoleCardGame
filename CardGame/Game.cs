using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deck = SharpDeck.SharpDeck;
using Rank = SharpDeck.Rank;

namespace ConsoleCardGame
{
    public class Game
    {
        public Player[] Players { get; private set; }
        private Round CurrentRound { get; set; }
        public Player Winner { get; private set; }
        public Player[] PlayersInOrderOfScore
        {
            get
            {
                List<Player> players = new List<Player>();

                foreach (Player player in this.Players)
                {
                    players.Add(player);
                }

                IEnumerable<Player> query = players.OrderBy(player => player.Score);

                return query.Cast<Player>().ToArray();
            }
            private set
            {
            }
        }
        public Player InSecondPlace
        {
            get
            {
                return PlayersInOrderOfScore[PlayersInOrderOfScore.Length - 2];
            }
            private set
            {
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="players">Array of players in the game.</param>
        /// <returns></returns>
        public Game(Player[] players)
        {
            this.Players = players;
            this.CurrentRound = null;

        }

        /// <summary>
        /// Updates scores with -1 for players who drew penalty and +2 for winner of current round.
        /// </summary>
        public void UpdateScores()
        {
            if (this.CurrentRound != null)
            {
                foreach (Move move in CurrentRound.Moves)
                {
                    if (move.Card.Rank == Rank.Joker)
                    {
                        if (move.Player.Score - 1 > 0)
                        {
                            move.Player.Score--;
                        }                        
                    }
                }


                if (CurrentRound.IsOver && CurrentRound.WinningMove != null)
                {
                    CurrentRound.WinningMove.Player.Score += 2;

                    if (CurrentRound.WinningMove.Player.Score >= 21 && InSecondPlace.Score <= CurrentRound.WinningMove.Player.Score - 2)
                    {
                        this.Winner = CurrentRound.WinningMove.Player;
                    }
                }                
            }
        }

        /// <summary>
        ///Returns a the next round. 
        /// </summary>
        /// <param name="deck">The deck with which the round will be played.</param>
        /// <returns>Round</returns>
        public Round NextRound(Deck deck)
        {           
            deck.Shuffle(DateTime.Now.Millisecond);

            CurrentRound = new Round(this, new Deck(true, true));

            return CurrentRound;
        }

        public void AuotComplete()
        {
            while (Winner == null)
            {
                NextRound(new Deck(true, true));

                CurrentRound.AutoComplete();

                // for debugging 
                //Console.WriteLine(CurrentRound.ToString());
            }
        }

        public override string ToString()
        {
            string game = "";

            foreach (Player player in this.Players)
            {
                game += player.Name + ": " + player.Score + ",";
            }

            return game;
        }
    }
}
