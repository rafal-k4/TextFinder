using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFinder
{
    class RandomCharacterGenerator
    {

        public static char GetRandomChar()
        {
            int signNumber = ToolClass.random.Next(62, 123);
            if (signNumber == 63)
            {
                signNumber = 32;
            }
            else if (signNumber == 64)
            {
                signNumber = 46;
            }
            else if (signNumber == 62)
            {
                signNumber = 44;
            }
            char sign = Convert.ToChar(signNumber);
            return sign;
        }

    }
}
