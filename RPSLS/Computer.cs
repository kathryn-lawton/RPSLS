using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Computer : Player
    {
        //member variables
        private const string computerName = "Computer";
       
        //constructor
        public Computer() :
            base(computerName)
        {
        }

        //member methods

        public override string MakeGestureChoice()
        {
            Random r = new Random();
            int index = r.Next(base.gestures.Count);
            string value = gestures[index];
            Console.WriteLine(base.name + " chose " + value + ".");
            return value;
            
        }

    }
}
