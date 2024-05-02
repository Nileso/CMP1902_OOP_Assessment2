using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment2
{
    internal class Game
    {
        static public void Main() //allows the user to select which die game they are going to play
        {
            while (true)
            {
                DisplayMenu();
                string userOption = Console.ReadLine();
                switch (userOption) //gives the user the option to choose what part of the program they want to visit
                {
                    case "1":
                        SevensOut sevensOut = new SevensOut();
                        sevensOut.PlayGame(userPlayAgainstComputer()); //starts the SevensOut game
                        break;
                    case "2":
                        ThreeOrMore threeOrMore = new ThreeOrMore();
                        threeOrMore.PlayGame(userPlayAgainstComputer()); //starts the ThreeOrMore game
                        break;
                    case "3":
                        Statistics.ViewData();
                        break;
                    case "4":
                        Testing testing = new Testing();
                        testing.Test();
                        break;
                    case "5":
                        Console.WriteLine("Exitting Program...");
                        return;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }

        static void DisplayMenu() //provides the user with options on a console
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Select an Option. \n" +
                              "1. Play Sevens Out \n" +
                              "2. Play Three or More \n" +
                              "3. View statistics data \n" +
                              "4. Perform testing \n" +
                              "5. Exit Program");
            Console.WriteLine("----------------------------");
        }

        static bool userPlayAgainstComputer() //the user can select to play with the computer or not
        {
            while (true)
            {
                Console.WriteLine("Select play mode: \n " +
                                  "1. Against Computer \n " +
                                  "2. Two Players");
                string userChoice = Console.ReadLine();
                if (userChoice == "1") 
                {
                    return true;
                }
                else if (userChoice == "2")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid Input"); //keeps the user in a loop until they type the correct input
                }
            }
        }
    }
}
