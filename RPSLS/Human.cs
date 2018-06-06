using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Human: Player
    {

        public Human(string playerName) :
            base(playerName)
        {

        }

        public override int MakeGestureChoice()
        {
            int index = 0;
            do
            {
                Console.WriteLine($"{base.name}, please enter a gesture choice from the printed list:");
                foreach (string gesture in base.gestures)
                {
                    Console.WriteLine(gesture);
                }
                string input = Console.ReadLine().ToLower();
                index = IsValidGesture(input);
                
            } while (index < 0);

            return index;
        }
         
        private int IsValidGesture(string input)
        {
            foreach(string gesture in base.gestures)
            {
                if (gesture.CompareTo(input) == 0)
                {
                    return base.gestures.IndexOf(gesture);
                }
            }

            Console.WriteLine($"{input} is an invalid gesture.");
            return -1;
        }
    }
}
