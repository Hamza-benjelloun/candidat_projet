using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace candidat_projet
{
    public partial class page5 : Form
    {
        decimal res;
        String precedant;
        String suivant;
        public page5(String prec , decimal resultat,String suiv)
        {
            InitializeComponent();
            res = resultat;
            precedant = prec;
            suivant = suiv;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private SqlConnection getConnection()
        {
            return new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\USERS\ADMINISTRATEUR\DESKTOP\CANDIDAT_PROJET\CANDIDAT_PROJET\DATABASE1.MDF; Integrated Security = True");

        }
        public void voir(String question)
        {
            try
            {
                using (SqlConnection con = getConnection())
                {
                    string query = "SELECT Id_activite_A,ressource_data,ressource_name,ressource_type from Activite_enseignement where condidat=@id and num_quesstion=@num";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(suivant);
                    cmd.Parameters.AddWithValue("@num", question);
                    con.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var id_file = reader["Id_activite_A"];
                        var name = reader["ressource_name"].ToString();
                        var data = (byte[])reader["ressource_data"];
                        var extn = reader["ressource_type"].ToString();
                        var newFileName = name.Replace(extn, DateTime.Now.ToString("ddMMyyyyhhmmss")) + extn;
                        File.WriteAllBytes(newFileName, data);
                        System.Diagnostics.Process.Start(newFileName);


                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Fichier non trouve !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void background_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void suivant_Click(object sender, EventArgs e)
        {
             
        }

        private void precedent_Click(object sender, EventArgs e)
        {
            this.Hide();
            Page4 page = new Page4(suivant,precedant);
            page.Show();

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Valider_Click(object sender, EventArgs e) {
            label27.Visible = true;
            label28.Visible = true;
            update();
            label28.Text = Convert.ToString(res) + "/100";
            byte admis=0;
            if (res > 50) {
                admis =1;
            }
            byte traite = 1;
            decimal note = res;
            using (SqlConnection con = getConnection())
            {
                con.Open();

                string query = "UPDATE Candidat Set note=@note ,traite=@traite,admis=@admis WHERE Id_condidat=@suiv;";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@note",note);
                cmd.Parameters.AddWithValue("@traite",traite);
                cmd.Parameters.AddWithValue("@suiv", suivant);
                cmd.Parameters.AddWithValue("@admis", admis);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            this.Hide();
            Page6 page = new Page6();
            page.Show();
        }
        private void B37_Click(object sender, EventArgs e)
        {
            voir("B37");
        }
        public void update()
        {
            res = res + nb11.Value + nb111.Value + nb112.Value + nb121.Value + nb131.Value + nb132.Value + nb211.Value + nb212.Value + nb22.Value + nb31.Value + nb32.Value + nb33.Value + nb34.Value + nb35.Value + nb36.Value+nb37.Value;
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void nb37_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void nb36_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void nb35_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void nb34_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void nb33_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void nb32_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void nb31_ValueChanged(object sender, EventArgs e)
        {
        }

        private void nb22_ValueChanged(object sender, EventArgs e)
        {
        }

        private void nb212_ValueChanged(object sender, EventArgs e)
        {
        }

        private void nb211_ValueChanged(object sender, EventArgs e)
        {
        }

        private void nb132_ValueChanged(object sender, EventArgs e)
        {
        }

        private void nb131_ValueChanged(object sender, EventArgs e)
        {
        }

        private void nb121_ValueChanged(object sender, EventArgs e)
        {
        }

        private void nb112_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void nb111_ValueChanged(object sender, EventArgs e)
        {
        }

        private void nb11_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void B11_Click(object sender, EventArgs e)
        {
            voir("B11");
        }

        private void B111_Click(object sender, EventArgs e)
        {
            voir("B111");
        }

        private void B112_Click(object sender, EventArgs e)
        {
            voir("B112");
        }

        private void B121_Click(object sender, EventArgs e)
        {
            voir("B121");
        }

        private void B131_Click(object sender, EventArgs e)
        {
            voir("B131");
        }

        private void B132_Click(object sender, EventArgs e)
        {
            voir("B132");
        }

        private void B211_Click(object sender, EventArgs e)
        {
            voir("B211");
        }

        private void B212_Click(object sender, EventArgs e)
        {
            voir("B212");
        }

        private void B22_Click(object sender, EventArgs e)
        {
            voir("B22");
        }

        private void B31_Click(object sender, EventArgs e)
        {
            voir("B31");
        }

        private void B32_Click(object sender, EventArgs e)
        {
            voir("B32");
        }

        private void B33_Click(object sender, EventArgs e)
        {
            voir("B33");
        }

        private void B34_Click(object sender, EventArgs e)
        {
            voir("B34");
        }

        private void B35_Click(object sender, EventArgs e)
        {
            voir("B35");
        }

        private void B36_Click(object sender, EventArgs e)
        {
            voir("B36");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
