using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFinder
{
    // klasa narzedziowa, sluzy do konfiguracji skladowych algorytmu genetycznego
    static class ToolClass
    {
        public static Random random = new Random();
        public static int populationSize { get; set; } = 600;
        public static float mutationRate { get; set; } = 0.005f;
        public static string targetText { get; set; }
        public static int currentPopulation { get; set; } = 0;
        public static float averageFitness { get; set; }

        public static List<Individual> population = new List<Individual>(); //lista kolekcji zawierajaca populacje osobnikow
        public static List<Individual> populationPool = new List<Individual>(); //lista kolekcji zawierajaca populacje osobnikow do dalszego klonowania
    }
}
