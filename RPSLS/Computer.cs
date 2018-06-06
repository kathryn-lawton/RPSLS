using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Computer : Player
    {
        private const string computerName = "Computer";
       
        public Computer() :
            base(computerName)
        {

        }

        public override int MakeGestureChoice()
        {
            Random random = new Random();
            int index = random.Next(base.gestures.Count);
            string value = gestures[index];
            Console.WriteLine($"{base.name} chose {value}.");

            return index;            
        }

    }
}
