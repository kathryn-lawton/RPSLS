using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Game
    {
        //member variables
        public Player player1;
        public Player player2;


        //constructor
        public Game()
        {
        }

        //member methods
        public string GetPlayerName()
        {
            string playerName = string.Empty;
            do
            {
                Console.WriteLine("Please enter your name:");
                string input = Console.ReadLine();

                if(input.ToLower().CompareTo("computer") == 0)
                {
                    Console.WriteLine("'Computer' is not a valid name.");
                }
                else if(player1 != null && player1.name.ToLower().CompareTo(input.ToLower()) == 0)
                {
                    Console.WriteLine("'{0}' is already a player name. Please choose a different name.", player1.name);
                }
                else
                {
                    playerName = input;
                }
            } while (playerName.CompareTo(string.Empty) == 0);
            
            return playerName;
        }  

        public Player DeterminePlayer()
        {
            Console.WriteLine("Will you be playing against another person or the computer? Please enter 'human' or 'computer':");

            Player newPlayer = null;
            do
            {
                string playerChoice = Console.ReadLine();
                if (playerChoice == "human")
                {
                    string playerName = GetPlayerName();

                    newPlayer = new Human(playerName);
                }
                else if (playerChoice == "computer")
                {
                    newPlayer = new Computer();
                }
                else
                {
                    Console.WriteLine("Please enter a valid player type.");
                }
            } while (newPlayer == null);

            return newPlayer;
        }

        public string DetermineWinner()
        {
            string winningPlayer = string.Empty;
            if(player1.score >= 2)
            {
                winningPlayer = player1.name;
            }
            else if(player2.score >= 2)
            {
                winningPlayer = player2.name;
            }
            else
            {
                Console.WriteLine("There is an error. Please restart game.");
            }
            return winningPlayer;
        }

        public void DisplayWinner(string winner)
        {
            Console.WriteLine("{0} is the winner of this game!", winner);
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            
            
        }

        public void DoRound()
        {
            string player1Gesture = player1.MakeGestureChoice();
            string player2Gesture = player2.MakeGestureChoice();

            if(player1Gesture.CompareTo(player2Gesture) == 0)
            {
                Console.WriteLine("There is no winner this round, both players tied.");
               
            }
            else
            {
                switch (player1Gesture)
                {
                    case "rock":
                        if (player2Gesture == "scissors" || player2Gesture == "lizard")
                        {
                            Console.WriteLine("{0} wins this round.", player1.name);
                            player1.score += 1;
                        }
                        else
                        {
                            Console.WriteLine("{0} wins this round.", player2.name);
                            player2.score += 1;
                        }
                        break;
                    case "paper":
                        if (player2Gesture == "rock" || player2Gesture == "spock")
                        {
                            Console.WriteLine("{0} wins this round.", player1.name);
                            player1.score += 1;
                        }
                        else
                        {
                            Console.WriteLine("{0} wins this round.", player2.name);
                            player2.score += 1;
                        }
                        break;
                    case "scissors":
                        if(player2Gesture == "paper" || player2Gesture == "lizard")
                        {
                            Console.WriteLine("{0} wins this round.", player1.name);
                            player1.score += 1;
                        }
                        else
                        {
                            Console.WriteLine("{0} wins this round.", player2.name);
                            player2.score += 1;
                        }
                        break;
                    case "lizard":
                        if(player2Gesture == "paper" || player2Gesture == "spock")
                        {
                            Console.WriteLine("{0} wins this round.", player1.name);
                            player1.score += 1;
                        }
                        else
                        {
                            Console.WriteLine("{0} wins this round.", player2.name);
                            player2.score += 1;
                        }
                        break;
                    case "spock":
                        if(player2Gesture == "rock" || player2Gesture == "scissors")
                        {
                            Console.WriteLine("{0} wins this round.", player1.name);
                            player1.score += 1;
                        }
                        else
                        {
                            Console.WriteLine("{0} wins this round.", player2.name);
                            player2.score += 1;
                        }
                        break;
                    default:
                        break;

                }
            } 
        }

        public void DisplayScore()
        {
            Console.WriteLine("{0}'s score is: {1}", player1.name, player1.score);
            Console.WriteLine("{0}'s score is: {1}", player2.name, player2.score);
        }

        public void RunGame()
        {
            // Create Player 1
            string playerName = GetPlayerName();
            player1 = new Human(playerName);

            // Create Player 2
            player2 = DeterminePlayer();


            //start loop
            while (player1.score < 2 && player2.score < 2)
            {
                DoRound();
                DisplayScore();
            }

            string winner = DetermineWinner();
            DisplayWinner(winner);

        }
    }
}