using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment2
{
    internal class SevensOut : DieGame //inherits from the die game class
    {
        public Die die1 = new Die();
        public Die die2 = new Die();

        public void PlayGame(bool playAgainstComputer) //changes the game depending on if the user plays against the computer or not
        {
            Statistics.IncreaseNumberOfPlays("SevensOut");//increases the number of plays from SevensOut in the statistics class
            if (playAgainstComputer)
            {
                PlayAgainstComputer();
            }
            else
            {
                PlayAgainstPlayer();
            }
        }
        public void PlayAgainstComputer()
        {
            while (true)
            {
                Player1Turn();
                ComputerTurn();
                if (HasGameEnded("Computer"))
                {
                    break;
                }
            }
        }

        public void PlayAgainstPlayer()
        {
            while (true)
            {
                Player1Turn();
                Player2Turn();
                if (HasGameEnded("Player2"))
                {
                    break;
                }
            }
        }

        public void Player1Turn() //allows the player to roll the die and calculates their score
        {
            if (playerOneOut == false) //stops the player from rolling if they are out
            {
                Console.Write("Player1:");
                WaitUntilUserRolls(); //waits until user rolls
                die1.Roll();
                die2.Roll();
                Console.WriteLine($"Player1 rolls a {die1.currentValue} and a {die2.currentValue}");
                if (die1.currentValue + die2.currentValue == 7) //the user is out if their sum adds p to 7
                {
                    playerOneOut = true;
                    Console.WriteLine("Player1 is out");
                }
                else if (die1.currentValue == die2.currentValue) //the user gets double points to their sum if they have the same number
                {
                    playerOneScore += die1.currentValue * 4;
                }
                else //adds to player score
                {
                    playerOneScore += (die1.currentValue + die2.currentValue);
                }
                Console.WriteLine($"Player1's score is {playerOneScore}.");
            }
        }

        public void ComputerTurn() //automatically rolls and calculates the computers score without the need for input
        {
            if (playerTwoOut == false)
            {
                die1.Roll();
                die2.Roll();
                Console.WriteLine($"Computer rolls a {die1.currentValue} and a {die2.currentValue}");
                if (die1.currentValue + die2.currentValue == 7)
                {
                    playerTwoOut = true;
                    Console.WriteLine("Computer is out");
                }
                else if (die1.currentValue == die2.currentValue)
                {
                    playerTwoScore += die1.currentValue * 4;
                }
                else
                {
                    playerTwoScore += (die1.currentValue + die2.currentValue);
                }
                Console.WriteLine($"Computer's score is {playerTwoScore}.");
            }
        }
        public void Player2Turn() //Mostly the same a Player1Turn apart from string and variable changes
        {
            if (playerTwoOut == false)
            {
                Console.Write("Player2:");
                WaitUntilUserRolls();
                die1.Roll();
                die2.Roll();
                Console.WriteLine($"Player2 rolls a {die1.currentValue} and a {die2.currentValue}");
                if (die1.currentValue + die2.currentValue == 7)
                {
                    playerTwoOut = true;
                    Console.WriteLine("Player2 is out");
                }
                else if (die1.currentValue == die2.currentValue)
                {
                    playerTwoScore += die1.currentValue * 4;
                }
                else
                {
                    playerTwoScore += (die1.currentValue + die2.currentValue);
                }
                Console.WriteLine($"Player2's score is {playerTwoScore}.");
            }
        }
        public bool HasGameEnded(string playerType) //checks if both players are out, then ends the game
        {
            if (playerOneOut && playerTwoOut)
            {
                Console.WriteLine("Final scores: \n " +
                                   $"Player1: {playerOneScore} " +
                                   $"{playerType}: {playerTwoScore}");

                CheckHighScore(playerType);           
                return true;
            }
            return false;
        }

        public void CheckHighScore(string playerType)
        {
            //checks if there is a new high score for the user, computers CANNOT have a new high score
            if (playerOneScore > Statistics.GetHighScore("SevensOut") && playerOneScore > playerTwoScore)
            {
                Console.WriteLine($"Player1 has set a new high score! {playerOneScore} (was {Statistics.GetHighScore("SevensOut")})");
                Statistics.SetHighScore("SevensOut",playerOneScore);
            }
            if (playerTwoScore > Statistics.GetHighScore("SevensOut") && playerType == "Player2" && playerTwoScore > playerOneScore)
            {
                Console.WriteLine($"Player2 has set a new high score! {playerTwoScore} (was {Statistics.GetHighScore("SevensOut")})");
                Statistics.SetHighScore("SevensOut", playerTwoScore);
            }
            if (playerOneScore > Statistics.GetHighScore("SevensOut") && playerType == "Computer")
            {
                Console.WriteLine($"Player1 has set a new high score! {playerOneScore} (was {Statistics.GetHighScore("SevensOut")})");
                Statistics.SetHighScore("SevensOut", playerOneScore);
            }
        }

    }
}
