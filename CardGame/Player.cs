using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCardGame
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Player(string Name)
        {
            this.Name = Name;
            this.Score = 0;
        }

        
    }
}
