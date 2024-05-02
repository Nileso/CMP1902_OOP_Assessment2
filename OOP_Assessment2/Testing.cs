using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment2
{
    internal class Testing
    {
        public void Test() //starts the testing process
        {
            Console.WriteLine("Testing SevensOut:");
            SevensOut testSevensOut = new SevensOut(); //instantiating a new test object
            int sevensOutTotalScore = 0; //used to compare with the SevensOut score
            while (true) //uses the ComputerTurn() method for testing as it is automatic
            {
                testSevensOut.ComputerTurn();
                if (testSevensOut.die1.currentValue + testSevensOut.die2.currentValue == 7)
                {
                    //halts the game if the computer has not stopped rolling the dice at the correct point
                    Debug.Assert(testSevensOut.playerTwoOut, "Error Occured: The computer wasn't stopped by the game");
                    Console.WriteLine("TEST: Game has stopped correctly");//the test has passed
                    break;
                }
                else if (testSevensOut.die1.currentValue == testSevensOut.die2.currentValue)
                {
                    sevensOutTotalScore += testSevensOut.die1.currentValue * 4;
                }
                else
                {
                    sevensOutTotalScore += (testSevensOut.die1.currentValue + testSevensOut.die2.currentValue);
                }
                //halts the game if the test score is different from the game score
                Debug.Assert(sevensOutTotalScore == testSevensOut.playerTwoScore, "The computer's and test's scores do not match");
                Console.WriteLine("TEST: The scores match");//the test has passed
            }
            Console.WriteLine("-----------");
            Console.WriteLine("Testing ThreeOrMore:");
            ThreeOrMore testThreeOrMore = new ThreeOrMore();

            while (true) //loops using the computer turn for automation
            {
                testThreeOrMore.ComputerTurn();
                if (testThreeOrMore.HasPlayerWon("Computer"))
                {
                    break;
                }
            }
            //halts if the game has ended before the score is 20 or above
            Debug.Assert(testThreeOrMore.playerTwoScore >= 20, "Game has ended before the score was 20 or above.");
            Console.WriteLine("TEST: Game has ended correctly");//the test has passed     
        }
    }
}
