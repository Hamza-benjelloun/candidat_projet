using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.IO;



namespace candidat_projet
{
    public partial class Page4 : Form
    {
        String prec;
        String suiv;
        decimal resultat;
        public Page4(String suivant,String precedant)
        {
            prec = precedant;
            suiv = suivant;
            InitializeComponent();
            
        }
        private SqlConnection getConnection()
        {
            return new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\USERS\ADMINISTRATEUR\DESKTOP\CANDIDAT_PROJET\CANDIDAT_PROJET\DATABASE1.MDF; Integrated Security = True");

        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_2(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            voir("A12");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            voir("A13");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            voir("A211");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            voir("A343");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            voir("A212");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            voir("A213");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            voir("A22");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            voir("A23");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            voir("A31");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            voir("A32");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            voir("A331");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            voir("A332");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            voir("A341");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            voir("A342");
        }
        private void openFile(int id)
        {
            using (SqlConnection con = getConnection())
            {
                string query = "SELECT Id_activite_A,ressource_data,ressource_name,ressource_type from Activite_enseignement where Id_activite_A=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                con.Open();

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["ressource_name"].ToString();
                    var data = (byte[])reader["ressource_data"];
                    var extn = reader["ressource_type"].ToString();
                    var newFileName = name.Replace(extn, DateTime.Now.ToString("ddMMyyyyhhmmss")) + extn;
                    File.WriteAllBytes(newFileName, data);
                    System.Diagnostics.Process.Start(newFileName);

                }
            }
        }
        public void voir(String question) {
            try
            {
                using (SqlConnection con = getConnection())
                {
                    string query = "SELECT Id_activite_A,ressource_data,ressource_name,ressource_type from Activite_enseignement where condidat=@id and num_quesstion=@num";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(suiv);
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
            catch (Exception e){
                Console.WriteLine(e.Message);
                MessageBox.Show("Fichier non trouve !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            voir("A11");
        }       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            update();
            page5 page5 = new page5(prec,resultat,suiv);
            page5.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Page3 page3 = new Page3(prec);
            page3.Show();
        }

        private void na11_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void na35_ValueChanged(object sender, EventArgs e)
        {
            
        }
        public void update() {
            resultat = na11.Value + na12.Value + na13.Value + na211.Value + na212.Value + na213.Value + na31.Value + na32.Value + na331.Value + na332.Value + na341.Value + na342.Value + na343.Value + na344.Value + na35.Value;
        }

        private void na12_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void na13_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void na211_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void na212_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void na213_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void na22_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void na23_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void na31_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void na32_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void na331_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void na332_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void na341_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void na342_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void na343_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void na344_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void a344_Click(object sender, EventArgs e)
        {
            voir("A344");
        }

        private void a35_Click(object sender, EventArgs e)
        {
            voir("A35");
        }
    }
}
