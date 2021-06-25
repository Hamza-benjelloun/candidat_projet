using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace candidat_projet
{
    public partial class Form2 : Form
    {
        List<Panel> listPanel = new List<Panel>();
        Boolean insererA31 = false;
        Boolean insererA32 = false;
        Boolean insererA331 = false;
        Boolean insererA332 = false;
        Boolean insererA341 = false;
        Boolean insererA342 = false;
        Boolean insererA343 = false;
        Boolean insererA344 = false;
        Boolean insererA35 = false;

        private SqlConnection getConnection()
        {
            return new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\USERS\ADMINISTRATEUR\DESKTOP\CANDIDAT_PROJET\CANDIDAT_PROJET\DATABASE1.MDF; Integrated Security = True");

        }



        int index;
        String id_session;
        public Form2(String id_session)
        {
            InitializeComponent();
            this.id_session = id_session;
            Console.WriteLine(id_session);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listPanel.Add(panel1);
            listPanel.Add(panel3);
            listPanel.Add(panel2);
            listPanel.Add(panel4);
            listPanel.Add(panel5);

            listPanel[index].BringToFront();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void activite_enseignementBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.activite_enseignementBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet1);

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void A12Btn_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        protected void BindDataGridView()
        {
            using (SqlConnection con = getConnection()
)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", "A11");
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.activite_enseignementDataGridView.DataSource = dt;
                    }
                }
            }

        }
        private void A11Btn_Click(object sender, EventArgs e)
        {
            SqlConnection con = getConnection();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "A11");

                        con.Open();
                        
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                ////MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                              
                            }
                        

                    }
                }
            }
            this.BindDataGridView();
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
        private void openFileB(int id)
        {
            using (SqlConnection con = getConnection())
            {
                string query = "SELECT Id_activite_B,ressource_data,ressource_name,ressource_type from Activite_recherche where Id_activite_B=@id";
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
        private void openBtn_Click(object sender, EventArgs e)
        {
            var selectedRow = activite_enseignementDataGridView.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFile(id);
            }
        }

        private void activite_enseignementDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void quitterBtn_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = getConnection();
            string query = "delete from Candidat where Id_condidat=@id_session";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id_session", id_session);
            con.Open();
            cmd.ExecuteNonQuery();

            string query2 = "delete from Activite_enseignement where condidat=@id_session";
            SqlCommand cmd2 = new SqlCommand(query2, con);

            cmd2.Parameters.AddWithValue("@id_session", id_session);
            cmd2.ExecuteNonQuery();

            string query3 = "delete from Activite_recherche where condidat=@id_session";
            SqlCommand cmd3 = new SqlCommand(query3, con);

            cmd3.Parameters.AddWithValue("@id_session", id_session);
            cmd3.ExecuteNonQuery();
            con.Close();

            this.Close();
            

        }

        private void precedentBtn_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                listPanel[--index].BringToFront();
            }
        }

        private void suivantBtn_Click(object sender, EventArgs e)
        {
            if (index < listPanel.Count - 1)
            {
                listPanel[++index].BringToFront();
                if (index == 3)
                {
                    suivantBtn.Text = "   Terminer";
                }
                if (index == 4)
                {
                    SqlConnection con = getConnection();
                    string query4 = "select * from Candidat where Id_condidat=@id";

                    SqlCommand cmd4 = new SqlCommand(query4, con);
                    //cmd3.Parameters.AddWithValue("@mail", emailText2.Text);
                    cmd4.Parameters.AddWithValue("@id", id_session);
                    con.Open();

                    var reader4 = cmd4.ExecuteReader();

                    if (reader4.Read())
                    {
                        
                        var v_nom = reader4["nom"].ToString();
                        var v_prenom = reader4["prenom"].ToString();
                        var v_departement = reader4["departement"].ToString();
                        var v_date_recrutement = reader4["date_recrutement"].ToString();
                        var v_grade_actuel = reader4["grade_actuel"].ToString();
                        var v_tel = reader4["tel"].ToString();
                        var v_fax = reader4["fax"].ToString();
                        var v_email = reader4["email"].ToString();
                        var v_date_depot_dossier = reader4["date_depot_dossier"].ToString();
                        var v_admis = reader4["admis"].ToString();
                        var v_note = reader4["note"].ToString();
                        var v_traite = reader4["traite"].ToString();
                        var v_type_passage = reader4["type_passage"].ToString();
                        var v_grade_souhaite = reader4["grade_souhaite"].ToString();

                        //MessageBox.Show(v_nom,"", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        nom.Text = v_nom;
                        prenom.Text = v_prenom;
                        departement.Text = v_departement;
                        date_rec.Text = v_date_recrutement;
                        grade_actuel.Text = v_grade_actuel;
                        tel.Text = v_tel;
                        fax.Text = v_fax;
                        adr.Text = v_email;
                        depot.Text = v_date_depot_dossier;
                        if (v_admis == "False")
                        {
                            res.Text = "Non admis";
                        }
                        else
                        {
                            res.Text = "Admis";
                        }

                        if (v_traite == "")
                        {
                            traite.Text = "En cours de traitement";
                            noteLbl.Text = "Note indisponible";

                        }
                        else
                        {
                            traite.Text = "Dossier traité";
                            noteLbl.Text = v_note;
                        }


                        passage.Text = v_type_passage;
                        souhaite.Text = v_grade_souhaite;

                    }
                    this.BindDataGridViewA();
                    this.BindDataGridViewB();
                    num_dossier.Text = id_session.ToString();

                }
               
            }
                
            }
        

        
        private void supprimerBtn_Click(object sender, EventArgs e)
        {
            
                using (SqlConnection con = getConnection())
                {
                    var selectedRow = activite_enseignementDataGridView.SelectedRows;
                    foreach (var row in selectedRow)
                    {
                        var id = (int)((DataGridViewRow)row).Cells[0].Value;
                        var query = "delete from Activite_enseignement where Id_activite_A = @id_activite";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@id_activite", id);

                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            
                            MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.BindDataGridView();
                        }
                    }
                }
            

        }

        private void metroButton11_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = getConnection();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "A11");

                        con.Open();
                        
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                ////MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                              
                            }
                       

                    }
                }
            }
            this.BindDataGridView();
        }

        private void afficherBtnA31_Click(object sender, EventArgs e)
        {
            var selectedRow = activite_enseignementDataGridView.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFile(id);
            }
        }

        private void supprimerBtnA31_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = activite_enseignementDataGridView.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_enseignement where Id_activite_A = @id_activite";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nop");
                    }
                    else
                    {
                        Console.WriteLine("done");
                        
                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BindDataGridView();
                    }
                }
            }

        }

        private void ajouterBtnA12_Click(object sender, EventArgs e)
        {
            SqlConnection con = getConnection();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "A12");

                        con.Open();

                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            //MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }


                    }
                }
            }
            using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
            {
                cmd.Parameters.AddWithValue("@id_session", id_session);
                cmd.Parameters.AddWithValue("@num", "A12");
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    this.dataGridView1.DataSource = dt;
                }
            }
        }

        private void supprimerBtnA12_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = dataGridView1.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_enseignement where Id_activite_A = @id_activite";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nop");
                    }
                    else
                    {
                        Console.WriteLine("done");
                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
                        {
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num", "A12");
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                this.dataGridView1.DataSource = dt;
                            }
                        }
                    }
                }
            }
        }

        private void afficherBtnA12_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFile(id);
            }
        }

        private void ajouterBtnA13_Click(object sender, EventArgs e)
        {
            SqlConnection con = getConnection();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "A13");
                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            //MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
            }
            using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
            {
                cmd.Parameters.AddWithValue("@id_session", id_session);
                cmd.Parameters.AddWithValue("@num", "A13");
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    this.dataGridView2.DataSource = dt;
                }
            }
        }

        private void supprimerBtnA13_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = dataGridView2.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_enseignement where Id_activite_A = @id_activite";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");
                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
                        {
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num", "A13");
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                this.dataGridView2.DataSource = dt;
                            }
                        }
                    }
                }
            }
        }

        private void afficherBtnA13_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView2.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFile(id);
            }
        }

        private void ajouterBtnA211_Click(object sender, EventArgs e)
        {
            SqlConnection con = getConnection();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "A211");
                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            //MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
            }
            using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
            {
                cmd.Parameters.AddWithValue("@id_session", id_session);
                cmd.Parameters.AddWithValue("@num", "A211");
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    this.dataGridView4.DataSource = dt;
                }
            }
        }

        private void supprimerBtnA211_Click(object sender, EventArgs e)
        {
                using (SqlConnection con = getConnection())
                {
                    var selectedRow = dataGridView4.SelectedRows;
                    foreach (var row in selectedRow)
                    {
                        var id = (int)((DataGridViewRow)row).Cells[0].Value;
                        var query = "delete from Activite_enseignement where Id_activite_A = @id_activite";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@id_activite", id);
                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nope");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            using (cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
                            {
                                cmd.Parameters.AddWithValue("@id_session", id_session);
                                cmd.Parameters.AddWithValue("@num", "A211");
                                cmd.CommandType = CommandType.Text;
                                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                                {
                                    DataTable dt = new DataTable();
                                    sda.Fill(dt);
                                    this.dataGridView4.DataSource = dt;
                                }
                            }
                        }
                    }
                }
            
        }

        private void afficherBtnA211_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView4.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFile(id);
            }
        }

        private void ajouterBtnA212_Click(object sender, EventArgs e)
        {
            SqlConnection con = getConnection();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "A212");
                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            //MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
            }
            using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
            {
                cmd.Parameters.AddWithValue("@id_session", id_session);
                cmd.Parameters.AddWithValue("@num", "A212");
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    this.dataGridView3.DataSource = dt;
                }
            }
        }

        private void supprimerBtnA212_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = dataGridView3.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_enseignement where Id_activite_A = @id_activite";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");
                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
                        {
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num", "A212");
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                this.dataGridView3.DataSource = dt;
                            }
                        }
                    }
                }
            }
        }

        private void afficherBtnA212_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView3.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFile(id);
            }
        }

        private void afficherBtnA213_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView5.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFile(id);
            }
        }

        private void supprimerBtnA213_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = dataGridView5.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_enseignement where Id_activite_A = @id_activite";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");
                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
                        {
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num", "A213");
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                this.dataGridView5.DataSource = dt;
                            }
                        }
                    }
                }
            }
        }

        private void ajouterBtnA213_Click(object sender, EventArgs e)
        {
            SqlConnection con = getConnection();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = "a.docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "A213");
                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            //MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
            }
            using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
            {
                cmd.Parameters.AddWithValue("@id_session", id_session);
                cmd.Parameters.AddWithValue("@num", "A213");
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    this.dataGridView5.DataSource = dt;
                }
            }
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = dataGridView6.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_enseignement where Id_activite_A = @id_activite";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");
                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
                        {
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num", "A23");
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                this.dataGridView6.DataSource = dt;
                            }
                        }
                    }
                }
            }
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            SqlConnection con = getConnection();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "A23");
                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            //MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
            }
            using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
            {
                cmd.Parameters.AddWithValue("@id_session", id_session);
                cmd.Parameters.AddWithValue("@num", "A23");
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    this.dataGridView6.DataSource = dt;
                }
            }
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView6.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFile(id);
            }
        }

        private void afficherBtnA22_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView7.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFile(id);
            }
        }

        private void supprimerBtnA22_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = dataGridView7.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_enseignement where Id_activite_A = @id_activite";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");
                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
                        {
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num", "A22");
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                this.dataGridView7.DataSource = dt;
                            }
                        }
                    }
                }
            }
        }

        private void ajouterBtnA22_Click(object sender, EventArgs e)
        {
            SqlConnection con = getConnection();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "A22");
                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            //MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
            }
            using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
            {
                cmd.Parameters.AddWithValue("@id_session", id_session);
                cmd.Parameters.AddWithValue("@num", "A22");
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    this.dataGridView7.DataSource = dt;
                }
            }
        }












        /// /////////////////////////////////////////////////////////////////////   A3 ////////////////////////////////////////////////////////



        private void importA31_Click(object sender, EventArgs e)
        {
            if (insererA31 == false)
            {
                SqlConnection con = getConnection();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileNames in openFileDialog.FileNames)
                        {
                            string contentType = "";
                            switch (Path.GetExtension(fileNames).ToLower())
                            {
                                case ".jpg":
                                    contentType = ".jpg";
                                    break;
                                case ".png":
                                    contentType = ".png";
                                    break;
                                case ".gif":
                                    contentType = ".gif";
                                    break;
                                case ".bmp":
                                    contentType = ".bmp";
                                    break;
                                case ".doc":
                                    contentType = ".msword";
                                    break;
                                case ".docx":
                                    contentType = ".docx";
                                    break;
                                case ".xls":
                                    contentType = ".xls";
                                    break;
                                case ".xlsx":
                                    contentType = ".xlsx";
                                    break;
                                case ".pdf":
                                    contentType = ".pdf";
                                    break;
                                case ".ppt":
                                    contentType = ".ppt";
                                    break;
                                case ".pptx":
                                    contentType = ".pptx";
                                    break;
                            }
                            byte[] bytes = File.ReadAllBytes(fileNames);

                            var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                            cmd.Parameters.AddWithValue("@ressource_type", contentType);
                            cmd.Parameters.AddWithValue("@ressource_data", bytes);
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num_quesstion", "A31");

                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                //MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                A31.Text = Path.GetFileName(fileNames);
                                insererA31 = true;

                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("attention !! t'as le droit d'importer qu'un seule fichier", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        private void importA32_Click(object sender, EventArgs e)
        {
            if (insererA32 == false)
            {
                SqlConnection con = getConnection();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileNames in openFileDialog.FileNames)
                        {
                            string contentType = "";
                            switch (Path.GetExtension(fileNames).ToLower())
                            {
                                case ".jpg":
                                    contentType = ".jpg";
                                    break;
                                case ".png":
                                    contentType = ".png";
                                    break;
                                case ".gif":
                                    contentType = ".gif";
                                    break;
                                case ".bmp":
                                    contentType = ".bmp";
                                    break;
                                case ".doc":
                                    contentType = ".msword";
                                    break;
                                case ".docx":
                                    contentType = ".docx";
                                    break;
                                case ".xls":
                                    contentType = ".xls";
                                    break;
                                case ".xlsx":
                                    contentType = ".xlsx";
                                    break;
                                case ".pdf":
                                    contentType = ".pdf";
                                    break;
                                case ".ppt":
                                    contentType = ".ppt";
                                    break;
                                case ".pptx":
                                    contentType = ".pptx";
                                    break;
                            }
                            byte[] bytes = File.ReadAllBytes(fileNames);

                            var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                            cmd.Parameters.AddWithValue("@ressource_type", contentType);
                            cmd.Parameters.AddWithValue("@ressource_data", bytes);
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num_quesstion", "A32");

                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                //MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                A32.Text = Path.GetFileName(fileNames);
                                insererA32 = true;

                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("attention !! t'as le droit d'importer qu'un seule fichier", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void importA331_Click(object sender, EventArgs e)
        {
            if (insererA331 == false)
            {
                SqlConnection con = getConnection();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileNames in openFileDialog.FileNames)
                        {
                            string contentType = "";
                            switch (Path.GetExtension(fileNames).ToLower())
                            {
                                case ".jpg":
                                    contentType = ".jpg";
                                    break;
                                case ".png":
                                    contentType = ".png";
                                    break;
                                case ".gif":
                                    contentType = ".gif";
                                    break;
                                case ".bmp":
                                    contentType = ".bmp";
                                    break;
                                case ".doc":
                                    contentType = ".msword";
                                    break;
                                case ".docx":
                                    contentType = ".docx";
                                    break;
                                case ".xls":
                                    contentType = ".xls";
                                    break;
                                case ".xlsx":
                                    contentType = ".xlsx";
                                    break;
                                case ".pdf":
                                    contentType = ".pdf";
                                    break;
                                case ".ppt":
                                    contentType = ".ppt";
                                    break;
                                case ".pptx":
                                    contentType = ".pptx";
                                    break;
                            }
                            byte[] bytes = File.ReadAllBytes(fileNames);

                            var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                            cmd.Parameters.AddWithValue("@ressource_type", contentType);
                            cmd.Parameters.AddWithValue("@ressource_data", bytes);
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num_quesstion", "A331");

                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                //MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                A331.Text = Path.GetFileName(fileNames);
                                insererA331 = true;

                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("attention !! t'as le droit d'importer qu'un seule fichier", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void importA332_Click(object sender, EventArgs e)
        {
            if (insererA332 == false)
            {
                SqlConnection con = getConnection();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileNames in openFileDialog.FileNames)
                        {
                            string contentType = "";
                            switch (Path.GetExtension(fileNames).ToLower())
                            {
                                case ".jpg":
                                    contentType = ".jpg";
                                    break;
                                case ".png":
                                    contentType = ".png";
                                    break;
                                case ".gif":
                                    contentType = ".gif";
                                    break;
                                case ".bmp":
                                    contentType = ".bmp";
                                    break;
                                case ".doc":
                                    contentType = ".msword";
                                    break;
                                case ".docx":
                                    contentType = ".docx";
                                    break;
                                case ".xls":
                                    contentType = ".xls";
                                    break;
                                case ".xlsx":
                                    contentType = ".xlsx";
                                    break;
                                case ".pdf":
                                    contentType = ".pdf";
                                    break;
                                case ".ppt":
                                    contentType = ".ppt";
                                    break;
                                case ".pptx":
                                    contentType = ".pptx";
                                    break;
                            }
                            byte[] bytes = File.ReadAllBytes(fileNames);

                            var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                            cmd.Parameters.AddWithValue("@ressource_type", contentType);
                            cmd.Parameters.AddWithValue("@ressource_data", bytes);
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num_quesstion", "A332");

                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                //MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                A332.Text = Path.GetFileName(fileNames);
                                insererA332 = true;
                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("attention !! t'as le droit d'importer qu'un seule fichier", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void importA341_Click(object sender, EventArgs e)
        {
            if (insererA341 == false)
            {
                SqlConnection con = getConnection();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileNames in openFileDialog.FileNames)
                        {
                            string contentType = "";
                            switch (Path.GetExtension(fileNames).ToLower())
                            {
                                case ".jpg":
                                    contentType = ".jpg";
                                    break;
                                case ".png":
                                    contentType = ".png";
                                    break;
                                case ".gif":
                                    contentType = ".gif";
                                    break;
                                case ".bmp":
                                    contentType = ".bmp";
                                    break;
                                case ".doc":
                                    contentType = ".msword";
                                    break;
                                case ".docx":
                                    contentType = ".docx";
                                    break;
                                case ".xls":
                                    contentType = ".xls";
                                    break;
                                case ".xlsx":
                                    contentType = ".xlsx";
                                    break;
                                case ".pdf":
                                    contentType = ".pdf";
                                    break;
                                case ".ppt":
                                    contentType = ".ppt";
                                    break;
                                case ".pptx":
                                    contentType = ".pptx";
                                    break;
                            }
                            byte[] bytes = File.ReadAllBytes(fileNames);

                            var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                            cmd.Parameters.AddWithValue("@ressource_type", contentType);
                            cmd.Parameters.AddWithValue("@ressource_data", bytes);
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num_quesstion", "A341");

                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                //MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                A341.Text = Path.GetFileName(fileNames);
                                insererA341 = true;

                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("attention !! t'as le droit d'importer qu'un sele fichier", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void importA342_Click(object sender, EventArgs e)
        {
            if (insererA342 == false)
            {
                SqlConnection con = getConnection();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileNames in openFileDialog.FileNames)
                        {
                            string contentType = "";
                            switch (Path.GetExtension(fileNames).ToLower())
                            {
                                case ".jpg":
                                    contentType = ".jpg";
                                    break;
                                case ".png":
                                    contentType = ".png";
                                    break;
                                case ".gif":
                                    contentType = ".gif";
                                    break;
                                case ".bmp":
                                    contentType = ".bmp";
                                    break;
                                case ".doc":
                                    contentType = ".msword";
                                    break;
                                case ".docx":
                                    contentType = ".docx";
                                    break;
                                case ".xls":
                                    contentType = ".xls";
                                    break;
                                case ".xlsx":
                                    contentType = ".xlsx";
                                    break;
                                case ".pdf":
                                    contentType = ".pdf";
                                    break;
                                case ".ppt":
                                    contentType = ".ppt";
                                    break;
                                case ".pptx":
                                    contentType = ".pptx";
                                    break;
                            }
                            byte[] bytes = File.ReadAllBytes(fileNames);

                            var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                            cmd.Parameters.AddWithValue("@ressource_type", contentType);
                            cmd.Parameters.AddWithValue("@ressource_data", bytes);
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num_quesstion", "A342");

                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                //MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                A342.Text = Path.GetFileName(fileNames);
                                insererA342 = true;
                            }

                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("attention !! t'as le droit d'importer qu'un sele fichier", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void importA343_Click(object sender, EventArgs e)
        {
            if (insererA343 == false)
            {
                SqlConnection con = getConnection();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileNames in openFileDialog.FileNames)
                        {
                            string contentType = "";
                            switch (Path.GetExtension(fileNames).ToLower())
                            {
                                case ".jpg":
                                    contentType = ".jpg";
                                    break;
                                case ".png":
                                    contentType = ".png";
                                    break;
                                case ".gif":
                                    contentType = ".gif";
                                    break;
                                case ".bmp":
                                    contentType = ".bmp";
                                    break;
                                case ".doc":
                                    contentType = ".msword";
                                    break;
                                case ".docx":
                                    contentType = ".docx";
                                    break;
                                case ".xls":
                                    contentType = ".xls";
                                    break;
                                case ".xlsx":
                                    contentType = ".xlsx";
                                    break;
                                case ".pdf":
                                    contentType = ".pdf";
                                    break;
                                case ".ppt":
                                    contentType = ".ppt";
                                    break;
                                case ".pptx":
                                    contentType = ".pptx";
                                    break;
                            }
                            byte[] bytes = File.ReadAllBytes(fileNames);

                            var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                            cmd.Parameters.AddWithValue("@ressource_type", contentType);
                            cmd.Parameters.AddWithValue("@ressource_data", bytes);
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num_quesstion", "A343");

                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                //MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                A343.Text = Path.GetFileName(fileNames);
                                insererA343 = true;
                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("attention !! t'as le droit d'importer qu'un sele fichier", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void importA344_Click(object sender, EventArgs e)
        {
            if (insererA344 == false)
            {
                SqlConnection con = getConnection();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileNames in openFileDialog.FileNames)
                        {
                            string contentType = "";
                            switch (Path.GetExtension(fileNames).ToLower())
                            {
                                case ".jpg":
                                    contentType = ".jpg";
                                    break;
                                case ".png":
                                    contentType = ".png";
                                    break;
                                case ".gif":
                                    contentType = ".gif";
                                    break;
                                case ".bmp":
                                    contentType = ".bmp";
                                    break;
                                case ".doc":
                                    contentType = ".msword";
                                    break;
                                case ".docx":
                                    contentType = ".docx";
                                    break;
                                case ".xls":
                                    contentType = ".xls";
                                    break;
                                case ".xlsx":
                                    contentType = ".xlsx";
                                    break;
                                case ".pdf":
                                    contentType = ".pdf";
                                    break;
                                case ".ppt":
                                    contentType = ".ppt";
                                    break;
                                case ".pptx":
                                    contentType = ".pptx";
                                    break;
                            }
                            byte[] bytes = File.ReadAllBytes(fileNames);

                            var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                            cmd.Parameters.AddWithValue("@ressource_type", contentType);
                            cmd.Parameters.AddWithValue("@ressource_data", bytes);
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num_quesstion", "A344");

                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                //MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                A344.Text = Path.GetFileName(fileNames);
                                insererA344 = true;
                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("attention !! t'as le droit d'importer qu'un sele fichier", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void importA35_Click(object sender, EventArgs e)
        {
            if (insererA35 == false)
            {
                SqlConnection con = getConnection();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileNames in openFileDialog.FileNames)
                        {
                            string contentType = "";
                            switch (Path.GetExtension(fileNames).ToLower())
                            {
                                case ".jpg":
                                    contentType = ".jpg";
                                    break;
                                case ".png":
                                    contentType = ".png";
                                    break;
                                case ".gif":
                                    contentType = ".gif";
                                    break;
                                case ".bmp":
                                    contentType = ".bmp";
                                    break;
                                case ".doc":
                                    contentType = ".msword";
                                    break;
                                case ".docx":
                                    contentType = ".docx";
                                    break;
                                case ".xls":
                                    contentType = ".xls";
                                    break;
                                case ".xlsx":
                                    contentType = ".xlsx";
                                    break;
                                case ".pdf":
                                    contentType = ".pdf";
                                    break;
                                case ".ppt":
                                    contentType = ".ppt";
                                    break;
                                case ".pptx":
                                    contentType = ".pptx";
                                    break;
                            }
                            byte[] bytes = File.ReadAllBytes(fileNames);

                            var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                            cmd.Parameters.AddWithValue("@ressource_type", contentType);
                            cmd.Parameters.AddWithValue("@ressource_data", bytes);
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num_quesstion", "A35");

                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                //MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                A35.Text = Path.GetFileName(fileNames);
                                insererA35 = true;
                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("attention !! t'as le droit d'importer qu'un sele fichier", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void A344_Click(object sender, EventArgs e)
        {

        }

        private void A332_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BindDataGridView1()
        {
            SqlConnection cn = getConnection();
            using (SqlConnection con = cn)

            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", "A211");
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.dataGridView4.DataSource = dt;
                    }
                }
            }

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

            SqlConnection con = getConnection();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "A211");




                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            //MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }



                    }
                }
            }
            this.BindDataGridView1();
        }

        private void supprimer(String num)
        {
            SqlConnection cn = getConnection();
            using (SqlConnection con = cn)

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("delete from Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", num);
                    cmd.CommandType = CommandType.Text;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Fichier supprime");

                    }
                    catch (Exception exp)
                    {
                        //MetroMessageBox.Show(this, "Le numero de client deja existe ", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MessageBox.Show(exp.Message);
                    }
                }
            }

        }

     
        private void sA31_Click_1(object sender, EventArgs e)
        {
            supprimer("A31");
            A31.Text = "";
            insererA31 = false;
        }

        private void sA32_Click_1(object sender, EventArgs e)
        {
            supprimer("A32");
            A32.Text = "";
            insererA32 = false;
        }

        private void sA331_Click(object sender, EventArgs e)
        {
            supprimer("A331");
            A331.Text = "";
            insererA331 = false;
        }

        private void sA332_Click(object sender, EventArgs e)
        {
            supprimer("A332");
            A332.Text = "";
            insererA332 = false;
        }

        private void sA341_Click(object sender, EventArgs e)
        {
            supprimer("A341");
            A341.Text = "";
            insererA341 = false;
        }

        private void sA342_Click(object sender, EventArgs e)
        {
            supprimer("A342");
            A342.Text = "";
            insererA342 = false;
        }

        private void sA343_Click(object sender, EventArgs e)
        {
            supprimer("A343");
            A343.Text = "";
            insererA343 = false;
        }

        private void sA344_Click(object sender, EventArgs e)
        {
            supprimer("A344");
            A344.Text = "";
            insererA344 = false;
        }

        private void sA35_Click(object sender, EventArgs e)
        {
            supprimer("A35");
            A35.Text = "";
            insererA35 = false;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////B1////////////////////
        protected void BindDataGridViewB111()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_B,ressource_name FROM Activite_recherche where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", "B111");
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.activite_rechercheDataGridView.DataSource = dt;
                    }
                }
            }

        }
        private void B111BtnImport_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_recherche (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "B111");




                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            ////MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }



                    }
                }
            }
            this.BindDataGridViewB111();

        }
        protected void BindDataGridViewB112()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_B,ressource_name FROM Activite_recherche where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", "B112");
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.dataGridView8.DataSource = dt;
                    }
                }
            }

        }
        private void B112BtnImport_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = getConnection())
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_recherche (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "B112");




                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            ////MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }



                    }
                }
            }
            this.BindDataGridViewB112();

        }


        protected void BindDataGridViewB121()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_B,ressource_name FROM Activite_recherche where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", "B121");
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.dataGridView9.DataSource = dt;
                    }
                }
            }

        }

        private void B121BtnImport_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_recherche (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "B121");




                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            ////MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }



                    }
                }
            }
            this.BindDataGridViewB121();
        }
        protected void BindDataGridViewB131()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_B,ressource_name FROM Activite_recherche where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", "B131");
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.dataGridView10.DataSource = dt;
                    }
                }
            }

        }
        private void B131BtnImport_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_recherche (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "B131");




                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            ////MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }



                    }
                }
            }
            this.BindDataGridViewB131();
        }
        protected void BindDataGridViewB132()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_B,ressource_name FROM Activite_recherche where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", "B132");
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.dataGridView11.DataSource = dt;
                    }
                }
            }

        }
        private void B132BtnImport_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_recherche (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "B132");




                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            ////MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }



                    }
                }
            }
            this.BindDataGridViewB132();
        }
        protected void BindDataGridViewB211()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_B,ressource_name FROM Activite_recherche where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", "B211");
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.dataGridView14.DataSource = dt;
                    }
                }
            }

        }
        private void B211BtnImport_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_recherche (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "B211");




                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            ////MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }



                    }
                }
            }
            this.BindDataGridViewB211();
        }
        protected void BindDataGridViewB212()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_B,ressource_name FROM Activite_recherche where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", "B212");
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.dataGridView13.DataSource = dt;
                    }
                }
            }

        }
        private void B212BtnImport_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_recherche (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "B212");




                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            ////MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }



                    }
                }
            }
            this.BindDataGridViewB212();
        }
        protected void BindDataGridViewB22()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_B,ressource_name FROM Activite_recherche where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", "B22");
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.dataGridView12.DataSource = dt;
                    }
                }
            }

        }
        private void B22BtnImport_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_recherche (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "B22");




                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            ////MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }



                    }
                }
            }
            this.BindDataGridViewB22();
        }

        private void activite_rechercheDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = activite_rechercheDataGridView.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_recherche where Id_activite_B = @id_activite";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");

                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BindDataGridViewB111();
                    }
                }
            }
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            var selectedRow = activite_rechercheDataGridView.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFileB(id);
            }
        }

        private void bunifuImageButton4_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = dataGridView8.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_recherche where Id_activite_B = @id_activite";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");

                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BindDataGridViewB112();
                    }
                }
            }
        }

        private void bunifuImageButton6_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = dataGridView9.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_recherche where Id_activite_B = @id_activite";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");

                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BindDataGridViewB121();
                    }
                }
            }
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = dataGridView10.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_recherche where Id_activite_B = @id_activite";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");

                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BindDataGridViewB131();
                    }
                }
            }
        }

        private void bunifuImageButton10_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = dataGridView11.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_recherche where Id_activite_B = @id_activite";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");

                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BindDataGridViewB132();
                    }
                }
            }
        }

        private void bunifuImageButton12_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = dataGridView14.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_recherche where Id_activite_B = @id_activite";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");

                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BindDataGridViewB211();
                    }
                }
            }
        }

        private void bunifuImageButton14_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = dataGridView13.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_recherche where Id_activite_B = @id_activite";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");

                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BindDataGridViewB212();
                    }
                }
            }
        }

        private void bunifuImageButton17_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = dataGridView12.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_recherche where Id_activite_B = @id_activite";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");

                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BindDataGridViewB22();
                    }
                }
            }
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView8.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFileB(id);
            }
        }

        private void bunifuImageButton5_Click_1(object sender, EventArgs e)
        {
            var selectedRow = dataGridView9.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFileB(id);
            }
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView10.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFileB(id);
            }
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView11.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFileB(id);
            }
        }

        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView14.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFileB(id);
            }
        }

        private void bunifuImageButton13_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView13.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFileB(id);
            }
        }

        private void bunifuImageButton16_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView12.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFileB(id);
            }
        }
        protected void BindDataGridViewB31()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_B,ressource_name FROM Activite_recherche where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", "B31");
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.dataGridView15.DataSource = dt;
                    }
                }
            }

        }
        private void B31BtnImport_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_recherche (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "B31");




                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            ////MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }



                    }
                }
            }
            this.BindDataGridViewB31();
        }
        protected void BindDataGridViewB32()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_B,ressource_name FROM Activite_recherche where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", "B32");
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.dataGridView16.DataSource = dt;
                    }
                }
            }

        }
        private void B32BtnImport_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_recherche (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "B32");




                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            ////MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }



                    }
                }
            }
            this.BindDataGridViewB32();
        }
        protected void BindDataGridViewB33()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_B,ressource_name FROM Activite_recherche where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", "B33");
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.dataGridView18.DataSource = dt;
                    }
                }
            }

        }
        private void B33BtnImport_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_recherche (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "B33");




                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            ////MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }



                    }
                }
            }
            this.BindDataGridViewB33();
        }
        protected void BindDataGridViewB34()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_B,ressource_name FROM Activite_recherche where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", "B34");
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.dataGridView17.DataSource = dt;
                    }
                }
            }

        }
        private void B34BtnImport_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_recherche (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "B34");




                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            ////MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }



                    }
                }
            }
            this.BindDataGridViewB34();
        }
        protected void BindDataGridViewB35()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_B,ressource_name FROM Activite_recherche where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", "B35");
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.dataGridView20.DataSource = dt;
                    }
                }
            }

        }
        private void B35BtnImport_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_recherche (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "B35");




                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            ////MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }



                    }
                }
            }
            this.BindDataGridViewB35();
        }
        protected void BindDataGridViewB36()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_B,ressource_name FROM Activite_recherche where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", "B36");
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.dataGridView19.DataSource = dt;
                    }
                }
            }

        }
        private void B36BtnImport_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_recherche (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "B36");




                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            ////MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }



                    }
                }
            }
            this.BindDataGridViewB36();
        }
        protected void BindDataGridViewB37()
        {
            using (SqlConnection con = getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_B,ressource_name FROM Activite_recherche where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", "B37");
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.dataGridView21.DataSource = dt;
                    }
                }
            }

        }
        private void B37BtnImport_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = ".docx";
                                break;
                            case ".xls":
                                contentType = ".xls";
                                break;
                            case ".xlsx":
                                contentType = ".xlsx";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = ".ppt";
                                break;
                            case ".pptx":
                                contentType = ".pptx";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_recherche (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "B37");




                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            ////MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }



                    }
                }
            }
            this.BindDataGridViewB37();
        }

        private void bunifuImageButton18_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = dataGridView15.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_recherche where Id_activite_B = @id_activite";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");

                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BindDataGridViewB31();
                    }
                }
            }
        }

        private void bunifuImageButton21_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = dataGridView16.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_recherche where Id_activite_B = @id_activite";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");

                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BindDataGridViewB32();
                    }
                }
            }
        }

        private void bunifuImageButton27_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = dataGridView18.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_recherche where Id_activite_B = @id_activite";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");

                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BindDataGridViewB33();
                    }
                }
            }
        }

        private void bunifuImageButton24_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = dataGridView17.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_recherche where Id_activite_B = @id_activite";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");

                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BindDataGridViewB34();
                    }
                }
            }
        }

        private void bunifuImageButton30_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = dataGridView20.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_recherche where Id_activite_B = @id_activite";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");

                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BindDataGridViewB35();
                    }
                }
            }
        }

        private void bunifuImageButton36_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = dataGridView21.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_recherche where Id_activite_B = @id_activite";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");

                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BindDataGridViewB37();
                    }
                }
            }
        }

        private void bunifuImageButton33_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = getConnection())
            {
                var selectedRow = dataGridView19.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_recherche where Id_activite_B = @id_activite";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");

                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BindDataGridViewB36();
                    }
                }
            }
        }

        private void bunifuImageButton15_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView15.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFileB(id);
            }
        }

        private void bunifuImageButton20_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView16.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFileB(id);
            }
        }

        private void bunifuImageButton26_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView18.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFileB(id);
            }
        }

        private void bunifuImageButton23_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView17.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFileB(id);
            }
        }

        private void bunifuImageButton29_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView20.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFileB(id);
            }
        }

        private void bunifuImageButton32_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView19.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFileB(id);
            }
        }

        private void bunifuImageButton35_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView21.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFileB(id);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label72_Click(object sender, EventArgs e)
        {

        }

        private void terminerBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }



        protected void BindDataGridViewA()
        {
            using (SqlConnection con = getConnection()
)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_A,num_quesstion,ressource_name FROM Activite_enseignement where condidat = @id_session", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);

                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.dataGridViewA.DataSource = dt;
                    }
                }
            }

        }
        protected void BindDataGridViewB()
        {
            using (SqlConnection con = getConnection()
)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_B,num_quesstion,ressource_name FROM Activite_recherche where condidat = @id_session", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);

                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.dataGridViewB.DataSource = dt;
                    }
                }
            }

        }

        private void bunifuImageButton22_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridViewA.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFile(id);
            }
        }

        private void bunifuImageButton19_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridViewB.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFileB(id);
            }
        }

        private void label87_Click(object sender, EventArgs e)
        {

        }
    }


}

  