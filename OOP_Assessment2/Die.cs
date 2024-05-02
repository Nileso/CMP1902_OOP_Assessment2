using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment2
{
    internal class Die
    {
        public int currentValue { get; private set; } //current value is public to get but private to set
        static Random random = new Random(); /*creating the 'random' object is required to generate random numbers*/
        public int Roll() // gets the current value for the die
        {
            currentValue = random.Next(1, 7); //creates a random number for current value
            return currentValue;
        }
    }
}
