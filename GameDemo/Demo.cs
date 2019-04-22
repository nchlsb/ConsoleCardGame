using System;
using Deck = SharpDeck.SharpDeck;
using Card = SharpDeck.Card;
using Rank = SharpDeck.Rank;
using Suit = SharpDeck.Suit;
using System.Threading;
using ConsoleCardGame;

namespace NickBradyCardProject
{
    class Demo
    {
        static void Main(string[] args)
        {
            Game game = new Game(DemoSetUp());
            Scoreboard scoreboard = new Scoreboard(game);

            /* There are three types of demos.
             * The first one is fully manual.
             * The second two are partially and fully automated. */


            //DemoGame(game, scoreboard);

            //DemoAutoCompleteRounds(game, scoreboard);

            DemoAutoCompleteGame(game, scoreboard);

        }

        public static void DemoGame(Game game, Scoreboard scoreboard)
        {
            while (game.Winner == null)
            {
                scoreboard.Display();
                Console.WriteLine("\n\n");

                Round round = game.NextRound(new Deck(true, true));

                while (!round.IsOver)
                {
                    if (round.NextPlayer != null)
                    {
                        Console.Write(round.NextPlayer.Name + ", press any key to draw a card.");
                        Console.ReadKey();
                    }

                    if (round.NextMove() != null)
                    //if (round.NextMove(new Card(Rank.Joker,Suit.Clubs)) != null)
                    {
                        Console.CursorLeft = 0;
                        ConsoleHelper.ClearConsoleLine();
                        Console.WriteLine(round.CurrentMove.ToString());

                        System.Threading.Thread.Sleep(2);
                    }


                    if (round.IsOver)
                    {
                        string endOfRoundMessage = "\n";

                        if (round.WinningMove != null)
                        {
                            endOfRoundMessage += round.WinningMove.Player.Name + " wins with a " + round.WinningMove.Card.ToString();
                        }
                        else
                        {
                            endOfRoundMessage += "Nobody wins";
                        }

                        Console.WriteLine(endOfRoundMessage);
                        Console.Write("Press any key continue");
                        Console.ReadKey();
                    }

                }

                Console.Clear();
            }

            scoreboard.Display();
            Player winner = game.Winner;
            Console.WriteLine("\n\n" + winner.Name + " wins with a score of " + winner.Score);
            Console.WriteLine("Press any key to end the game");
            Console.ReadKey();
        }

        public static void DemoAutoCompleteRounds(Game game, Scoreboard scoreboard)
        {
            while (game.Winner == null)
            {

                Round round = game.NextRound(new Deck(true, true));

                while (!round.IsOver)
                {
                    round.NextMove();
                }

                scoreboard.Display();
                Console.WriteLine();

                foreach (Move move in round.Moves)
                {
                    Console.WriteLine(move.ToString());
                }

                string endOfRoundMessage = "\n";

                if (round.WinningMove != null)
                {
                    endOfRoundMessage += round.WinningMove.Player.Name + " wins with a " + round.WinningMove.Card.ToString();
                }
                else
                {
                    endOfRoundMessage += "Nobody wins";
                }

                Console.WriteLine(endOfRoundMessage);
                Console.Write("Press any key continue");
                Console.ReadKey();

                Console.Clear();
            }

            scoreboard.Display();
            Player winner = game.Winner;
            Console.WriteLine("\n\n" + winner.Name + " wins with a score of " + winner.Score);
            Console.WriteLine("Press any key to end the game");
            Console.ReadKey();
        }

        public static void DemoAutoCompleteGame(Game game, Scoreboard scoreboard)
        {
            game.AuotComplete();

            scoreboard.Display();
            Player winner = game.Winner;
            Console.WriteLine("\n\n" + winner.Name + " wins with a score of " + winner.Score);
            Console.WriteLine("Press any key to end the game");
            Console.ReadKey();
        }

        public static Player[] DemoSetUp()
        {
            Console.WriteLine("\nUse the arrows to choose # of players.");

            int numberOfPlayers = ConsoleHelper.MultipleChoice(false, "Two", "Three", "Four") + 2; // off set start at 0k
            Player[] players = new Player[numberOfPlayers];

            Console.Clear();

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.Write("Player " + (i + 1) + " choose your name: ");
                string name = Console.ReadLine();
                if (name.Length > 15)
                {
                    name = name.Substring(0, 15);
                }
                else if (name.Length == 0)
                {
                    name = "Player " + (i + 1);
                }
                players[i] = new Player(name);
            }

            Console.Clear();
            Console.Write("Welcome ");
            for (int i = 0; i < players.Length; i++)
            {
                if (i < players.Length - 1)
                {
                    Console.Write(players[i].Name + ", ");
                }
                else
                {
                    Console.Write("and " + players[i].Name + ".");
                }
            }

            Console.WriteLine("\nPress any key to start the game");
            Console.ReadKey();
            Console.Clear();

            return players;
        }
        
        
    }
}
