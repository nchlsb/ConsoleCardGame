using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCardGame
{
    public class Scoreboard
    {
        private Game Game { get; set; }

        public Scoreboard(Game game)
        {
            this.Game = game;
        }

        public void Display(int cursorPostion)
        {
            Console.CursorLeft = cursorPostion;
            Console.Write(ToString());
        }

        public void Display()
        {
            Display(0);
        }

        public override string ToString()
        {
            return Game.ToString().Replace(","," | ");
        }
    }
}
