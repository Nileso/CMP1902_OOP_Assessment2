using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment2
{
    internal class Statistics
    {
        //fields used to store the data about the games are private so they are not accidently changed
        static int numberOfPlays_SevensOut = 0;
        static int highScore_SevensOut = 0;

        static int numberOfPlays_ThreeOrMore = 0;
        static int highScore_ThreeOrMore = 0;
        static int minRolls_ThreeOrMore = 9999;

        static public int SetHighScore(string game, int num) //setter used to change high score for SevensOut or ThreeOrMore
        {
            if (game == "SevensOut")
            {
                return highScore_SevensOut = num;
            }
            if (game == "ThreeOrMore")
            {
                return highScore_ThreeOrMore = num;
            }
            else
            {
                return -1;
            }
        }

        static public int GetHighScore(string game) //getter used to get high score for SevensOut or ThreeOrMore
        {
            if (game == "SevensOut")
            {
                return highScore_SevensOut;
            }
            if (game == "ThreeOrMore")
            {
                return highScore_ThreeOrMore;
            }
            else
            {
                return -1;
            }
        }

        static public int GetMinimumRolls() //getter used to get the minimum rolls for ThreeOrMore
        {
            return minRolls_ThreeOrMore;
        }

        static public int SetMinimumRolls(int num) //setter used to set the minimum rolls for ThreeOrMore
        {
            return minRolls_ThreeOrMore = num;
        }

        static public int IncreaseNumberOfPlays(string game) //increases the number of plays for SevensOut or ThreeOrMore when the game is played
        {
            if (game == "SevensOut")
            {
                return numberOfPlays_SevensOut++;
            }
            if (game == "ThreeOrMore")
            {
                return numberOfPlays_ThreeOrMore++;
            }
            else
            {
                return -1;
            }
        }

        static public void ViewData() //allows the user to view the data from the main menu
        {
            Console.WriteLine($"SevensOut: \n" +
                              $"--High score = {highScore_SevensOut} \n" +
                              $"--Number of plays = {numberOfPlays_SevensOut}");
            Console.WriteLine($"ThreeOrMore: \n" +
                              $"--High score = {highScore_ThreeOrMore} \n" +
                              $"--Number of plays = {numberOfPlays_ThreeOrMore} \n" +
                              $"--Minimum rolls to win = {minRolls_ThreeOrMore}");
        }
    }
}
