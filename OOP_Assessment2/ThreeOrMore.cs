using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment2
{
    internal class ThreeOrMore : DieGame //inherits from die game class
    {
        //die array is used instead of 5 individual die object as it allows for easier rolls and value checking
        Die[] die_array = new Die[5] {new Die(), new Die(), new Die(), new Die(), new Die()};
        int player1MinimumRolls = 0;
        int player2MinimumRolls = 0;

        public void PlayGame(bool playAgainstComputer) //changes the game depending on if the user plays with a computer
        {
            Statistics.IncreaseNumberOfPlays("ThreeOrMore");//increases the number of plays to ThreeOrMore in the statistics class
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
                if (HasPlayerWon("Computer"))
                {
                    break;
                }
                ComputerTurn();
                if (HasPlayerWon("Computer"))
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
                if (HasPlayerWon("Player2"))
                {
                    break;
                }
                Player2Turn();
                if (HasPlayerWon("Player2"))
                {
                    break;
                }
            }
        }

        public void Player1Turn() //allows the player to roll the die and calculates their score
        {
            int[] die_tally = new int[6] { 0, 0, 0, 0, 0, 0 }; //die tally is used to count the number of occurances for each die value
            bool reroll = false;
            int pointsToAdd = 0;
            Console.Write("Player1:");
            WaitUntilUserRolls();
            player1MinimumRolls += 1;
            RollAllDice();
            Console.Write("Player1:");
            DisplayAllDice();
            string kinds = DetectKinds(die_tally);
            switch (kinds) //calculates the points to add from the kinds and if there is a reroll
            {
                case "2-of-a-kind":
                    Console.WriteLine("2-of-a-kind");
                    pointsToAdd = 0;
                    reroll = true;
                    break;
                case "2-of-a-kind 3-of-a-kind":
                    Console.WriteLine("2-of-a-kind 3-of-a-kind");
                    reroll = true;
                    pointsToAdd = 3;
                    break;
                case "3-of-a-kind":
                    Console.WriteLine($"{kinds} +3 to score");
                    pointsToAdd = 3;
                    break;
                case "4-of-a-kind":
                    Console.WriteLine($"{kinds} +6 to score");
                    pointsToAdd = 6;
                    break;
                case "5-of-a-kind":
                    Console.WriteLine($"{kinds} +12 to score");
                    pointsToAdd = 12;
                    break;
                default:
                    Console.WriteLine("");
                    pointsToAdd = 0;
                    break;
            }
            if (reroll) //the user can select two different reroll options
            {
                Console.WriteLine("Type 'ra' to reroll all dice or type 'rr' to reroll the remaining dice");
                string rerollChoice = GetUserRerollChoice();
                player1MinimumRolls += 1;
                if (rerollChoice == "ra")
                {
                    die_tally = new int[6] { 0, 0, 0, 0, 0, 0 };
                    RollAllDice();
                    Console.Write("Player1:");
                    DisplayAllDice();
                    kinds = DetectKinds(die_tally);
                    pointsToAdd = FindRerollPoints(kinds);
                }
                else
                {
                    for (int i = 0; i<6; i++) //iterates through the die tally and rerolls all of the dice apart from the 2-of-a-kind
                    {
                        if (die_tally[i] == 2)
                        {
                            RollAllDiceBut(i+1);
                            break;
                        }
                    }
                    die_tally = new int[6] { 0, 0, 0, 0, 0, 0 }; //resets the die tally for the next turn
                    Console.Write("Player1:");
                    DisplayAllDice();
                    kinds = DetectKinds(die_tally);
                    pointsToAdd = FindRerollPoints(kinds);
                }
            }
            playerOneScore += pointsToAdd; //adds the points of this turn to the players score
            Console.WriteLine($"Player1's score is {playerOneScore}.");
        }

        public void Player2Turn() //the same as Player1Turn apart from string and variable changes
        {
            int[] die_tally = new int[6] { 0, 0, 0, 0, 0, 0 };
            bool reroll = false;
            int pointsToAdd = 0;
            Console.Write("Player2:");
            WaitUntilUserRolls();
            player2MinimumRolls += 1;
            RollAllDice();
            Console.Write("Player2:");
            DisplayAllDice();
            string kinds = DetectKinds(die_tally);
            switch (kinds)
            {
                case "2-of-a-kind":
                    Console.WriteLine("2-of-a-kind");
                    pointsToAdd = 0;
                    reroll = true;
                    break;
                case "2-of-a-kind 3-of-a-kind":
                    Console.WriteLine("2-of-a-kind 3-of-a-kind");
                    reroll = true;
                    pointsToAdd = 3;
                    break;
                case "3-of-a-kind":
                    Console.WriteLine($"{kinds} +3 to score");
                    pointsToAdd = 3;
                    break;
                case "4-of-a-kind":
                    Console.WriteLine($"{kinds} +6 to score");
                    pointsToAdd = 6;
                    break;
                case "5-of-a-kind":
                    Console.WriteLine($"{kinds} +12 to score");
                    pointsToAdd = 12;
                    break;
                default:
                    Console.WriteLine("");
                    pointsToAdd = 0;
                    break;
            }
            if (reroll)
            {
                Console.WriteLine("Type 'ra' to reroll all dice or type 'rr' to reroll the remaining dice");
                string rerollChoice = GetUserRerollChoice();
                player2MinimumRolls += 1;
                if (rerollChoice == "ra")
                {
                    die_tally = new int[6] { 0, 0, 0, 0, 0, 0 };
                    RollAllDice();
                    Console.Write("Player2:");
                    DisplayAllDice();
                    kinds = DetectKinds(die_tally);
                    pointsToAdd = FindRerollPoints(kinds);
                }
                else
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (die_tally[i] == 2)
                        {
                            RollAllDiceBut(i + 1);
                            break;
                        }
                    }
                    die_tally = new int[6] { 0, 0, 0, 0, 0, 0 };
                    Console.Write("Player2:");
                    DisplayAllDice();
                    kinds = DetectKinds(die_tally);
                    pointsToAdd = FindRerollPoints(kinds);
                }
            }
            playerTwoScore += pointsToAdd;
            Console.WriteLine($"Player2's score is {playerTwoScore}.");
        }

        public void ComputerTurn() //the computer plays automatically without needing an input to roll the dice
        {
            int[] die_tally = new int[6] { 0, 0, 0, 0, 0, 0 };
            bool reroll = false;
            int pointsToAdd = 0;
            Console.WriteLine("Computer: Rolls the dice");
            RollAllDice();
            Console.Write("Computer:");
            DisplayAllDice();
            string kinds = DetectKinds(die_tally);
            switch (kinds)
            {
                case "2-of-a-kind":
                    Console.WriteLine("2-of-a-kind");
                    pointsToAdd = 0;
                    reroll = true;
                    break;
                case "2-of-a-kind 3-of-a-kind":
                    Console.WriteLine("2-of-a-kind 3-of-a-kind");
                    reroll = true;
                    pointsToAdd = 3;
                    break;
                case "3-of-a-kind":
                    Console.WriteLine($"{kinds} +3 to score");
                    pointsToAdd = 3;
                    break;
                case "4-of-a-kind":
                    Console.WriteLine($"{kinds} +6 to score");
                    pointsToAdd = 6;
                    break;
                case "5-of-a-kind":
                    Console.WriteLine($"{kinds} +12 to score");
                    pointsToAdd = 12;
                    break;
                default:
                    Console.WriteLine("");
                    pointsToAdd = 0;
                    break;
            }
            if (reroll) //the computer rerolls all of the dice automatically
            {
                Console.WriteLine("Computer is rerolling");
                die_tally = new int[6] { 0, 0, 0, 0, 0, 0 };
                RollAllDice();
                Console.Write("Computer:");
                DisplayAllDice();
                kinds = DetectKinds(die_tally);
                pointsToAdd = FindRerollPoints(kinds);
            }
            playerTwoScore += pointsToAdd;
            Console.WriteLine($"Computer's score is {playerTwoScore}.");
        }

        public string GetUserRerollChoice() //returns the type of reroll the user would like to do
        {
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == "ra" || userInput == "rr")
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine($"{userInput} is an invalid input, type 'ra' to reroll all dice or type 'rr' to reroll the remaining dice");
                }
            }
        }

        public string DetectKinds(int[] die_tally) //finds the kinds using the die tally (example: a 3 in the die tally means a 3-of-a-kind)
        {
            bool twoOfAKind = false;
            bool threeOfAKind = false;
            foreach (Die die in die_array)
            {
                die_tally[die.currentValue-1] += 1;
            }
            foreach (int num in die_tally)
            {
                switch (num)
                {
                    case 2:
                        twoOfAKind = true;
                        break;
                    case 3:
                        threeOfAKind = true;
                        break;
                    case 4:
                        return "4-of-a-kind";
                    case 5:
                        return "5-of-a-kind";

                }
            }
            if (twoOfAKind == true && threeOfAKind == false)
            {
                return "2-of-a-kind";
            }
            if (twoOfAKind == true && threeOfAKind == true)
            {
                return "2-of-a-kind 3-of-a-kind";
            }
            if (twoOfAKind == false && threeOfAKind == true)
            {
                return "3-of-a-kind";
            }
            else
            {
                return "";
            }
        }
        public void RollAllDice() //iterates through the die array and rolls all of the dice
        {
            foreach (Die die in die_array)
            {
                die.Roll();
            }
        }

        public void RollAllDiceBut(int num) //iterates through the die array and rolls all of the dice apart from the number argument
        {
            foreach (Die die in die_array)
            {
                if (die.currentValue != num)
                {
                    die.Roll();
                }
            }
        }

        public void DisplayAllDice() //iterates through the die array and displays the dice to the user
        {
            Console.Write("[ ");
            foreach (Die die in die_array)
            {
                Console.Write($"{die.currentValue} ");
            }
            Console.Write("] ");
        }

        public int FindRerollPoints(string kinds) //this is needed as the user cannot reroll more than once
        {
            int pointsToAdd = 0;
            switch (kinds)
            {
                case "2-of-a-kind 3-of-a-kind":
                    Console.WriteLine($"{kinds} +3 to score");
                    pointsToAdd = 3;
                    break;
                case "3-of-a-kind":
                    Console.WriteLine($"{kinds} +3 to score");
                    pointsToAdd = 3;
                    break;
                case "4-of-a-kind":
                    Console.WriteLine($"{kinds} +6 to score");
                    pointsToAdd = 6;
                    break;
                case "5-of-a-kind":
                    Console.WriteLine($"{kinds} +12 to score");
                    pointsToAdd = 12;
                    break;
                default:
                    Console.WriteLine("");
                    pointsToAdd = 0;
                    break;
            }
            return pointsToAdd;
        }

        public bool HasPlayerWon(string playerType) //checks if the player has won if their score is above 20
        { 
            //the player can set a new minimum roll and new high score, however the computer cannot set any new scores
            if (playerOneScore >= 20)
            {
                Console.WriteLine("Player1 has won!");
                if (player1MinimumRolls < Statistics.GetMinimumRolls())
                {
                    Console.WriteLine($"Player1 has set a new minimum rolls! {player1MinimumRolls} (was {Statistics.GetMinimumRolls()})");
                    Statistics.SetMinimumRolls(player1MinimumRolls);
                }
                if (playerOneScore > Statistics.GetHighScore("ThreeOrMore"))
                {
                    Console.WriteLine($"Player1 has set a new high score! {playerOneScore} (was {Statistics.GetHighScore("ThreeOrMore")})");
                    Statistics.SetHighScore("ThreeOrMore", playerOneScore);
                }
                return true;
            }
            if (playerTwoScore >= 20 && playerType == "Player2")
            {
                Console.WriteLine("Player2 has won!");
                if (player2MinimumRolls < Statistics.GetMinimumRolls())
                {
                    Console.WriteLine($"Player2 has set a new minimum rolls! {player2MinimumRolls} (was {Statistics.GetMinimumRolls()})");
                    Statistics.SetMinimumRolls(player2MinimumRolls);
                }
                if (playerTwoScore > Statistics.GetHighScore("ThreeOrMore"))
                {
                    Console.WriteLine($"Player2 has set a new high score! {playerTwoScore} (was {Statistics.GetHighScore("ThreeOrMore")})");
                    Statistics.SetHighScore("ThreeOrMore", playerTwoScore);
                }
                return true;
            }
            if (playerTwoScore >= 20 && playerType == "Computer")
            {
                Console.WriteLine("Computer has won!");
                return true;
            }
            return false;

        }
    }
}
