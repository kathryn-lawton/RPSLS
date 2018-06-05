using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Game
    {
        public Player player1;
        public Player player2;

        public Game()
        {

        }

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
                    Console.WriteLine($"'{player1.name}' is already a player name. Please choose a different name.");
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



        public void DisplayWinner(string winner)
        {
            Console.WriteLine($"{winner} is the winner of this game!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public void DoRound()
        {
            string player1Gesture = player1.MakeGestureChoice();
            string player2Gesture = player2.MakeGestureChoice();

            if(player1Gesture.CompareTo(player2Gesture) == 0)
            {
                Console.WriteLine("This round is a tie, both players chose the same gesture.");  
            }
            else
            {
                switch (player1Gesture)
                {
                    case "rock":
                        if (player2Gesture == "scissors" || player2Gesture == "lizard")
                        {
                            Console.WriteLine($"{player1.name} wins this round.");
                            player1.score += 1;
                        }
                        else
                        {
                            Console.WriteLine($"{player2.name} wins this round.");
                            player2.score += 1;
                        }
                        break;
                    case "paper":
                        if (player2Gesture == "rock" || player2Gesture == "spock")
                        {
                            Console.WriteLine($"{player1.name} wins this round.");
                            player1.score += 1;
                        }
                        else
                        {
                            Console.WriteLine($"{player2.name} wins this round.");
                            player2.score += 1;
                        }
                        break;
                    case "scissors":
                        if(player2Gesture == "paper" || player2Gesture == "lizard")
                        {
                            Console.WriteLine($"{player1.name} wins this round.");
                            player1.score += 1;
                        }
                        else
                        {
                            Console.WriteLine($"{player2.name} wins this round.");
                            player2.score += 1;
                        }
                        break;
                    case "lizard":
                        if(player2Gesture == "paper" || player2Gesture == "spock")
                        {
                            Console.WriteLine($"{player1.name} wins this round.");
                            player1.score += 1;
                        }
                        else
                        {
                            Console.WriteLine($"{player2.name} wins this round.");
                            player2.score += 1;
                        }
                        break;
                    case "spock":
                        if(player2Gesture == "rock" || player2Gesture == "scissors")
                        {
                            Console.WriteLine($"{player1.name} wins this round.");
                            player1.score += 1;
                        }
                        else
                        {
                            Console.WriteLine($"{player2.name} wins this round.");
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
            Console.WriteLine($"{player1.name}'s score is: {player1.score}");
            Console.WriteLine($"{player2.name}'s score is: {player2.score}");
        }

        public string SetWinner()
        {
            string winningPlayer = string.Empty;
            if (player1.score >= 2)
            {
                winningPlayer = player1.name;
            }
            else if (player2.score >= 2)
            {
                winningPlayer = player2.name;
            }
            else
            {
                Console.WriteLine("There is an error. Please restart game.");
            }
                return winningPlayer;
        }

        public void DetermineWinningPlayer()
        {
            while (player1.score < 2 && player2.score < 2)
            {
                DoRound();
                DisplayScore();
            }         
        }


        public void RunGame()
        {
            string playerName = GetPlayerName();
            player1 = new Human(playerName);

            player2 = DeterminePlayer();

            DetermineWinningPlayer();

            string winner = SetWinner();
            DisplayWinner(winner);
        }
    }
}