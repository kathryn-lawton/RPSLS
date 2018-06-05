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
            Console.WriteLine("Please enter your name:");
            playerName = Console.ReadLine();
            return playerName;
            //add validation

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

                    newPlayer = new HumanPlayer(playerName);
                }
                else if (playerChoice == "computer")
                {
                    newPlayer = new ComputerPlayer();
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
            Console.WriteLine(winner + " is the winner of this game!");
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
                DisplayScore();
            }
            else
            {
                switch (player1Gesture)
                {
                    case "rock":
                        if (player2Gesture == "scissors" || player2Gesture == "lizard")
                        {
                            Console.WriteLine(player1.name + " wins this round.");
                            player1.score += 1;
                            DisplayScore();
                        }
                        else
                        {
                            Console.WriteLine(player2.name + " wins this round.");
                            player2.score += 1;
                            DisplayScore();
                        }
                        break;
                    case "paper":
                        if (player2Gesture == "rock" || player2Gesture == "spock")
                        {
                            Console.WriteLine(player1.name + " wins this round.");
                            player1.score += 1;
                            DisplayScore();
                        }
                        else
                        {
                            Console.WriteLine(player2.name + " wins this round.");
                            player2.score += 1;
                            DisplayScore();
                        }
                        break;
                    case "scissors":
                        if(player2Gesture == "paper" || player2Gesture == "lizard")
                        {
                            Console.WriteLine(player1.name + " wins this round.");
                            player1.score += 1;
                            DisplayScore();
                        }
                        else
                        {
                            Console.WriteLine(player2.name + " wins this round.");
                            player2.score += 1;
                            DisplayScore();
                        }
                        break;
                    case "lizard":
                        if(player2Gesture == "paper" || player2Gesture == "spock")
                        {
                            Console.WriteLine(player1.name + " wins this round.");
                            player1.score += 1;
                            DisplayScore();
                        }
                        else
                        {
                            Console.WriteLine(player2.name + " wins this round.");
                            player2.score += 1;
                            DisplayScore();
                        }
                        break;
                    case "spock":
                        if(player2Gesture == "rock" || player2Gesture == "scissors")
                        {
                            Console.WriteLine(player1.name + " wins this round.");
                            player1.score += 1;
                            DisplayScore();
                        }
                        else
                        {
                            Console.WriteLine(player2.name + " wins this round.");
                            player2.score += 1;
                            DisplayScore();
                        }
                        break;
                    default:
                        break;

                }
            } 
        }

        public void DisplayScore()
        {
            Console.WriteLine(player1.name + "'s score is: " + player1.score);
            Console.WriteLine(player2.name + "'s score is: " + player2.score);
        }

        public void RunGame()
        {
            // Create Player 1
            string playerName = GetPlayerName();
            player1 = new HumanPlayer(playerName);

            // Create Player 2
            player2 = DeterminePlayer();


            //start loop
            while (player1.score < 2 && player2.score < 2)
            {
                DoRound();
            }

            string winner = DetermineWinner();
            DisplayWinner(winner);

            



            // if player 1 wins == 2 - declare winner
            // else if player 2 wins == 2 -delare winner
            // else -- error msg (should not happen)


            //call MakeChoice
            //determineRoundWinner
            //display winner
            //store winner in player



        }
    }
}