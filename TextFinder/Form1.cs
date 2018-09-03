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
        public static string targetText { get; set; }
        public static string textbox1 { get; set; }
        public static string labeltext4 { get; set; }
        public static Label lbl3 { get; set; }
        public static Timer timer { get; set; }
        public static TextBox txtBox1 { get; set; }

        public Form1()
        {
            
            InitializeComponent();

            txtBox1 = textBox1;
            timer = timer1;
            label4.Text = labeltext4;
            //textBox1.Text = textbox1;
            targetText = textBox2.Text;
            DNA.MakeAFirstPopulation(ToolClass.populationSize);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DNA.CalculateFitness(ref ToolClass.population);
            DNA.MakePopulation(ref ToolClass.population, ref ToolClass.populationPool);
            DNA.CheckForResult();
        }
    }
}
