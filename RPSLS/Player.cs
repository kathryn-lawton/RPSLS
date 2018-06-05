using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    abstract class Player
    {
        //member variables
        protected List<string> gestures = new List<string>() { "rock", "paper", "scissors", "lizard", "spock" };
        public int score;
        public string name;

        //constructor
        public Player(string playerName)
        {
            this.name = playerName;
            this.score = 0;
        }

        //member methods
        public abstract string MakeGestureChoice();
   
    }
}
