using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace candidat_projet
{
    public partial class Page2 : Form
    {
        private string passage = "";

        public Page2()
        {
            InitializeComponent();
        }

        private void Page2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        //Passages
        private void button2_Click(object sender, EventArgs e)
        {
            passage = "pesab";
            suivant(passage);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            passage = "paab";
            suivant(passage);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            passage = "pabc";
            suivant(passage);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            passage = "pacd";
            suivant(passage);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            passage = "phbc";
            suivant(passage);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            passage = "phab";
            suivant(passage);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            passage = "pesbc";
            suivant(passage);
        }
        //end Passage
        private void label5_Click(object sender, EventArgs e)
        {

        }

        
        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void suivant(string suivant)
        {
            this.Hide();
            Page3 page3 = new Page3(suivant);
            page3.Show();

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            first first = new first();
            first.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
