using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace candidat_projet
{
    public partial class Page6 : Form
    {
        public Page6()
        {
            InitializeComponent();
        }
        private SqlConnection getConnection()
        {
            return new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\USERS\ADMINISTRATEUR\DESKTOP\CANDIDAT_PROJET\CANDIDAT_PROJET\DATABASE1.MDF; Integrated Security = True");

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void PESAB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        protected void BindDataGridViewPESAB()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT nom,prenom,note,grade_actuel FROM Candidat WHERE grade_souhaite='grade A a grade B' AND grade_actuel IN ('PES-A','PES-B') AND traite IS NOT NULL ORDER BY note DESC", con))
                {                    
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);                       
                        this.PESAB.DataSource = dt;                        
                        
                    }
                }
            }

        }

        protected void BindDataGridViewPESBC()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT nom,prenom,note,grade_actuel FROM Candidat WHERE grade_souhaite='grade B a grade C' AND grade_actuel IN ('PES-A','PES-B') AND traite IS NOT NULL ORDER BY note DESC", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.PESBC.DataSource = dt;

                    }
                }
            }

        }

        protected void BindDataGridViewPHAB()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT nom,prenom,note,grade_actuel FROM Candidat WHERE grade_souhaite='grade A a grade B' AND grade_actuel IN ('PH-A','PH-B') AND traite IS NOT NULL ORDER BY note DESC", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.PHAB.DataSource = dt;

                    }
                }
            }

        }

        protected void BindDataGridViewPHBC()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT nom,prenom,note,grade_actuel FROM Candidat WHERE grade_souhaite='grade B a grade C' AND grade_actuel IN ('PH-A','PH-B') AND traite IS NOT NULL ORDER BY note DESC", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.PHBC.DataSource = dt;

                    }
                }
            }

        }

        protected void BindDataGridViewPAAB()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT nom,prenom,note,grade_actuel FROM Candidat WHERE grade_souhaite='grade A a grade B' AND grade_actuel IN ('PA-A','PA-B','PA-C') AND traite IS NOT NULL ORDER BY note DESC", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.PAAB.DataSource = dt;

                    }
                }
            }

        }

        protected void BindDataGridViewPABC()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT nom,prenom,note,grade_actuel FROM Candidat WHERE grade_souhaite='grade B a grade C' AND grade_actuel IN ('PA-A','PA-B','PA-C') AND traite IS NOT NULL ORDER BY note DESC", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.PABC.DataSource = dt;

                    }
                }
            }

        }

        protected void BindDataGridViewPACD()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT nom,prenom,note,grade_actuel FROM Candidat WHERE grade_souhaite='grade C a grade D' AND grade_actuel IN ('PA-A','PA-B','PA-C') AND traite IS NOT NULL ORDER BY note DESC", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.PACD.DataSource = dt;

                    }
                }
            }

        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            BindDataGridViewPESAB();
            BindDataGridViewPESBC();
            BindDataGridViewPHAB();
            BindDataGridViewPHBC();
            BindDataGridViewPAAB();
            BindDataGridViewPABC();
            BindDataGridViewPACD();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }

}
