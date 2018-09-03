using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFinder
{
    // klasa w ktorej sa wykonywane operacje na populacji wedlug algorytmow genetycznych
    class DNA
    {

        internal static void MakeAFirstPopulation(int populationSize)
        {
            ToolClass.population.Clear();

            for (int i = 0; i < populationSize; i++)
            {
                ToolClass.population.Add(new Individual(Form1.targetText.TextLength));
            }

            foreach (var item in ToolClass.population)
            {
                for (int i = 0; i < Form1.targetText.TextLength; i++)
                {
                    item.letters[i] = RandomCharacterGenerator.GetRandomChar();
                    //item.letters[i] = Convert.ToChar(random.Next(97, 122));
                }
            }

        }

        internal static void CalculateFitness(ref List<Individual> population)
        {
            foreach (var item in population)
            {
                int score = 0;
                for (int i = 0; i < Form1.targetText.TextLength; i++)
                {

                    if (item.letters[i] == Form1.targetText.Text[i])
                    {
                        score++;
                    }
                    //---------bardzo zle rozwiazanie---------
                    //for (int j = 0; j < targetText.Length; j++)
                    //{
                    //    if (item.letters[i] == targetText[j])
                    //    {
                    //        score++;
                    //        //break;
                    //    }
                    //}
                }
                item.fitness = (float)score / Form1.targetText.TextLength;
            }


            //----------------------------------------------------------
            //szukanie najwiekszej wartosci fitness w list population!
            //---------------------------------------------------------
            var maxFitnessFactor = population.Max(r => r.fitness);
           

            foreach (var item in population)
            {
                item.normalizedFitness = item.fitness / (float)maxFitnessFactor;
                ToolClass.averageFitness += item.normalizedFitness;
            }
            ToolClass.averageFitness = ToolClass.averageFitness / population.Count;
        }

        

        internal static void MakePopulation(ref List<Individual> population, ref List<Individual> populationPool)
        {
            populationPool.Clear();

            // dodawanie elementow o najwyzszym wspolczynniku fitness
            foreach (var item in population)
            {

                if (ToolClass.random.NextDouble() <= item.normalizedFitness)
                {
                    populationPool.Add(item);
                }
            }

            //--------obciazajacy system sposob----------
            /*
            //foreach (var item in population)
            //{
            //    for (int i = 0; i < item.normalizedFitness*100; i++)
            //    {
            //        populationPool.Add(item);
            //    }
            //}
            */

            for (int i = 0; i < ToolClass.populationSize; i++)
            {
                var parentA = populationPool[ToolClass.random.Next(ToolClass.populationPool.Count)];
                var parentB = populationPool[ToolClass.random.Next(ToolClass.populationPool.Count)];
                population[i] = Crossover(parentA, parentB);
            }
            ApplyMutation(ToolClass.mutationRate);
        }

        private static Individual Crossover(Individual parentA, Individual parentB)
        {
            Individual child = new Individual(Form1.targetText.TextLength);
            int randomPick = ToolClass.random.Next(0, Form1.targetText.TextLength);

            for (int i = 0; i < Form1.targetText.TextLength; i++)
            {
                if (child.letters[i] == parentA.letters[i])
                {
                    child.letters[i] = parentA.letters[i];
                }
                else if (child.letters[i] == parentB.letters[i])
                {
                    child.letters[i] = parentB.letters[i];
                }
                else if (i <= randomPick - 1)
                {
                    child.letters[i] = parentA.letters[i];
                }
                else
                {
                    child.letters[i] = parentB.letters[i];
                }

            }
            return child;
        }

        private static void ApplyMutation(float mutationRate)
        {
            foreach (var item in ToolClass.population)
            {
                for (int i = 0; i < Form1.targetText.TextLength; i++)
                {
                    if (ToolClass.random.NextDouble() <= mutationRate)
                    {
                        item.letters[i] = RandomCharacterGenerator.GetRandomChar();
                    }

                }
            }
        }

        

        internal static void CheckForResult()
        {
            bool checker = true;
            string result = "";
            foreach (var item in ToolClass.population)
            {
                for (int i = 0; i < Form1.targetText.TextLength; i++)
                {
                    result += item.letters[i];
                }
                if (result == Form1.targetText.Text)
                {
                    Form1.timer.Stop();
                    Form1.txtBox1.AppendText(result + Environment.NewLine);
                    checker = false;
                    Form1.labeltext4.Text = result;
                    break;
                }
                else
                {
                    result = "";
                }

            }
            string line = "";

            var maxFitnessFactor = ToolClass.population.Max(r => r.fitness);

            //-------------wybieranie najbardziej podobnego slowa do slowa docelowego------------
            var bestParent = ToolClass.population.First(r => r.fitness == maxFitnessFactor);
            for (int i = 0; i < Form1.targetText.TextLength; i++)
            {
                line += bestParent.letters[i].ToString();
            }
            if (checker)
            {
                Form1.txtBox1.AppendText(line + Environment.NewLine);
                Form1.labeltext4.Text = line;
            }

            Form1.lbl2.Text = "Obecna populacja: " + ToolClass.currentPopulation;
            Form1.lbl3.Text = String.Format("Average Fitness: {0:p}", ToolClass.averageFitness);
                

            ToolClass.currentPopulation++;
        }
    }
}
