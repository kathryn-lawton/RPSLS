using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class HumanPlayer: Player
    {
        //member variables

        //constructor
        public HumanPlayer(string playerName) :
            base(playerName)
        {
        }

        //member methods

        public override string MakeGestureChoice()
        {
            string input = string.Empty;
            do
            {
                Console.WriteLine("Please enter a gesture choice from the printed list:");
                foreach (string gesture in base.gestures)
                {
                    Console.WriteLine(gesture);
                }

                input = Console.ReadLine().ToLower();


            } while (IsValidGesture(input) == false);

            return input;
        }

        private bool IsValidGesture(string input)
        {
            foreach(string gesture in base.gestures)
            {
                if (gesture.CompareTo(input) == 0)
                {
                    return true;
                }
            }

            Console.WriteLine("{0} is an invalid gesture.", input);
            return false;
        }
    }
}
