using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace candidat_projet{
    
    public partial class Page3 : Form
    {
        String pass;
        private SqlConnection getConnection()
        {
            return new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\USERS\ADMINISTRATEUR\DESKTOP\CANDIDAT_PROJET\CANDIDAT_PROJET\DATABASE1.MDF; Integrated Security = True");

        }
        SqlCommand cmd;
        SqlConnection con;
        public Page3(String passage)
        {
            InitializeComponent();
            con = getConnection();
            string pesab = "SELECT Id_condidat FROM Candidat C WHERE (C.traite IS NULL OR C.traite=0) AND C.grade_souhaite='grade A a grade B' AND C.grade_actuel='PES-A'";
            string pesbc = "SELECT Id_condidat FROM Candidat C WHERE (C.traite IS NULL OR C.traite=0) AND C.grade_souhaite='grade B a grade C' AND C.grade_actuel='PES-B'";
            string phab = "SELECT Id_condidat FROM Candidat C WHERE (C.traite IS NULL OR C.traite=0) AND C.grade_souhaite='grade A a grade B' AND C.grade_actuel='PH-A'";
            string phbc = "SELECT Id_condidat FROM Candidat C WHERE (C.traite IS NULL OR C.traite=0) AND C.grade_souhaite='grade B a grade C' AND C.grade_actuel='PH-B'";
            string paab = "SELECT Id_condidat FROM Candidat C WHERE (C.traite IS NULL OR C.traite=0) AND C.grade_souhaite='grade A a grade B' AND C.grade_actuel='PA_A'";
            string pabc = "SELECT Id_condidat FROM Candidat C WHERE (C.traite IS NULL OR C.traite=0)  AND C.grade_souhaite='grade B a grade C' AND C.grade_actuel='PA_B'";
            string pacd = "SELECT Id_condidat FROM Candidat C WHERE (C.traite IS NULL OR C.traite=0) AND C.grade_souhaite='grade C a grade D' AND C.grade_actuel='PA_C'";
            switch (passage) {
                case "pesab":
                    cmd = new SqlCommand(pesab, con);
                    break;
                case "pesbc":
                    cmd = new SqlCommand(pesbc, con);
                    break;
                case "phab":
                    cmd = new SqlCommand(phab, con);
                    break;
                case "phbc":
                    cmd = new SqlCommand(phbc, con);
                    break;
                case "paab":
                    cmd = new SqlCommand(paab, con);
                    break;
                case "pabc":
                    cmd = new SqlCommand(pabc, con);
                    break;
                default :
                    cmd = new SqlCommand(pacd, con);
                    break;
            }
            int[] allRecords = null;            
            using (cmd)
            {
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    var list = new List<int>();
                    while (reader.Read())
                        list.Add( reader.GetInt32(0));
                    allRecords = list.ToArray();
                }
            }
            int n = allRecords.Length;
            for (int i = 0; i < n; i++) {
                switch (i) {
                    case 0:
                        btn1.Text = Convert.ToString(allRecords[0]);
                        btn1.BackColor = Color.MediumPurple;
                        btn1.Enabled = true;
                        break;
                    case 1:
                        btn2.Text = Convert.ToString(allRecords[1]);
                        btn2.BackColor = Color.MediumPurple;
                        btn2.Enabled = true;
                        break;
                    case 2:
                        btn3.Text = Convert.ToString(allRecords[2]);
                        btn3.BackColor = Color.MediumPurple;
                        btn3.Enabled = true;
                        break;
                    case 3:
                        btn4.Text = Convert.ToString(allRecords[3]);
                        btn4.BackColor = Color.MediumPurple;
                        btn4.Enabled = true;
                        break;
                    case 4:
                        btn5.Text = Convert.ToString(allRecords[4]);
                        btn5.BackColor = Color.MediumPurple;
                        btn5.Enabled = true;
                        break;
                    case 5:
                        btn6.Text = Convert.ToString(allRecords[5]);
                        btn6.BackColor = Color.MediumPurple;
                        btn6.Enabled = true;
                        break;
                    case 6:
                        btn7.Text = Convert.ToString(allRecords[6]);
                        btn7.BackColor = Color.MediumPurple;
                        btn7.Enabled = true;
                        break;
                    case 7:
                        btn8.Text = Convert.ToString(allRecords[7]);
                        btn8.BackColor = Color.MediumPurple;
                        btn8.Enabled = true;
                        break;
                    case 8:
                        btn9.Text = Convert.ToString(allRecords[8]);
                        btn9.BackColor = Color.MediumPurple;
                        btn9.Enabled = true;
                        break;                        
                        

                }
            }
            con.Close();
            pass = passage;

        }        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Page2 page = new Page2();
            this.Hide();
            page.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
                    }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
                    }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            suivant(btn8.Text,pass);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            suivant(btn2.Text,pass);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            suivant(btn3.Text,pass);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            suivant(btn1.Text,pass);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            suivant(btn4.Text,pass);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            suivant(btn5.Text,pass);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            suivant(btn6.Text,pass);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            suivant(btn9.Text,pass);
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click_1(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            suivant(btn7.Text,pass);
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }
        private void suivant(string suivant,string precedant)
        {
            this.Hide();
            Page4 page4 = new Page4(suivant,precedant);
            page4.Show();

        }
    }
}
