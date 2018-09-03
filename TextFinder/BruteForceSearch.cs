using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFinder
{
    class BruteForceSearch
    {
        public static Individual bruteForceSearch { get; set; } = new Individual(Form1.targetText.TextLength);

        public static void CreateRandomLetters()
        {
          
            for (int i = 0; i < Form1.targetText.TextLength; i++)
            {
                bruteForceSearch.letters[i] = RandomCharacterGenerator.GetRandomChar();
            }
        }
        public static void CheckForResult()
        {
            string result = "";
            for (int i = 0; i < Form1.targetText.TextLength; i++)
            {
                result += bruteForceSearch.letters[i];
            }

            if (result == Form1.targetText.Text)
            {
                Form1.timer_2.Stop();
            }
            Form1.txtBox3.AppendText(result + Environment.NewLine);
        }

    }
}
