using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class ComputerPlayer : Player
    {
        //member variables
        private const string computerName = "Computer";
       
        //constructor
        public ComputerPlayer() :
            base(computerName)
        {
        }

        //member methods

        public override string MakeGestureChoice()
        {
            Random r = new Random();
            int index = r.Next(base.gestures.Count);
            string value = gestures[index];
            Console.WriteLine(computerName + " chose " + value + ".");
            return value;
            
        }

    }
}
