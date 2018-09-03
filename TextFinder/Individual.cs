using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFinder
{
    // typ przechowujacy dane kazdego "osobnika" z populacji
    class Individual
    {
        public float fitness { get; set; }
        public float normalizedFitness { get; set; }
        public char[] letters { get; set; }

        public Individual(int textLength)
        {
            letters = new char[textLength];
        }
    }
}
