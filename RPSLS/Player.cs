using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    abstract class Player
    {
        protected List<string> gestures = new List<string>() { "rock", "paper", "scissors", "lizard", "spock" };
        public int score;
        public string name;

        public Player(string playerName)
        {
            this.name = playerName;
            this.score = 0;
        }

        public abstract string MakeGestureChoice();
   
    }
}
