using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextFinder
{
    public partial class Form1 : Form
    {
        public static TextBox targetText { get; set; }
        public static string textbox1 { get; set; }
        public static Label labeltext4 { get; set; }
        public static Label lbl2 { get; set; }
        public static Label lbl3 { get; set; }
        public static Timer timer { get; set; }
        public static Timer timer_2 { get; set; }
        public static TextBox txtBox1 { get; set; }
        public static TextBox txtBox3 { get; set; }

        public Form1()
        {
            
            InitializeComponent();

            lbl2 = label2;
            lbl3 = label3;
            labeltext4 = label4;

            txtBox1 = textBox1;
            targetText = textBox2;

            txtBox3 = textBox3;
            timer_2 = timer2;
            timer = timer1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            targetText = textBox2;
            DNA.MakeAFirstPopulation(ToolClass.populationSize);
            timer1.Start();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //metody algorytmu genetycznego
            DNA.CalculateFitness(ref ToolClass.population);
            DNA.MakePopulation(ref ToolClass.population, ref ToolClass.populationPool);
            DNA.CheckForResult();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //metody dla sposobu BruteForce
            BruteForceSearch.CreateRandomLetters();
            BruteForceSearch.CheckForResult();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            BruteForceSearch.bruteForceSearch = new Individual(targetText.TextLength);
        }
    }
}
