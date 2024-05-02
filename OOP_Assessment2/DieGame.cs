using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment2
{
    internal class DieGame //used as a base class for SevensOut and ThreeOrMore to inherit from
    {
        //both die game classes use these properties 
        public int playerOneScore = 0;
        public bool playerOneOut = false;

        public int playerTwoScore = 0;
        public bool playerTwoOut = false;

        public void WaitUntilUserRolls() //waits until the user rolls the die and keeps them in a loop if they type an invalid input
        {
            while (true)
            {
                Console.WriteLine("Type 'r' to roll the dice");
                string userInput = Console.ReadLine();
                if (userInput == "r")
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"{userInput} is an invalid input");
                }
            }
        }
    }
}
