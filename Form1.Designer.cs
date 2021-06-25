
namespace candidat_projet
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nomLabel;
            System.Windows.Forms.Label prenomLabel;
            System.Windows.Forms.Label departementLabel;
            System.Windows.Forms.Label date_recrutementLabel;
            System.Windows.Forms.Label telLabel;
            System.Windows.Forms.Label faxLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label grade_actuelLabel1;
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grade_actuelText = new System.Windows.Forms.ComboBox();
            this.candidatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database1DataSet = new candidat_projet.Database1DataSet();
            this.quitterBtn = new MetroFramework.Controls.MetroButton();
            this.suivantBtn = new MetroFramework.Controls.MetroButton();
            this.textNom = new System.Windows.Forms.TextBox();
            this.textPrenom = new System.Windows.Forms.TextBox();
            this.departementText = new System.Windows.Forms.TextBox();
            this.date_recrutement_text = new System.Windows.Forms.DateTimePicker();
            this.textTel = new System.Windows.Forms.TextBox();
            this.faxText = new System.Windows.Forms.TextBox();
            this.emailText = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PACD = new MetroFramework.Controls.MetroRadioButton();
            this.PAAB = new MetroFramework.Controls.MetroRadioButton();
            this.labelPa = new System.Windows.Forms.Label();
            this.PABC = new MetroFramework.Controls.MetroRadioButton();
            this.PHBC = new MetroFramework.Controls.MetroRadioButton();
            this.PHAB = new MetroFramework.Controls.MetroRadioButton();
            this.labelPh = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pExceptionel = new MetroFramework.Controls.MetroRadioButton();
            this.pNormal = new MetroFramework.Controls.MetroRadioButton();
            this.pRapid = new MetroFramework.Controls.MetroRadioButton();
            this.candidatTableAdapter = new candidat_projet.Database1DataSetTableAdapters.CandidatTableAdapter();
            this.tableAdapterManager = new candidat_projet.Database1DataSetTableAdapters.TableAdapterManager();
            this.PESAB = new MetroFramework.Controls.MetroRadioButton();
            this.PESBC = new MetroFramework.Controls.MetroRadioButton();
            this.labelPes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            nomLabel = new System.Windows.Forms.Label();
            prenomLabel = new System.Windows.Forms.Label();
            departementLabel = new System.Windows.Forms.Label();
            date_recrutementLabel = new System.Windows.Forms.Label();
            telLabel = new System.Windows.Forms.Label();
            faxLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            grade_actuelLabel1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.candidatBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nomLabel
            // 
            nomLabel.AutoSize = true;
            nomLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nomLabel.ForeColor = System.Drawing.Color.Indigo;
            nomLabel.Location = new System.Drawing.Point(97, 188);
            nomLabel.Name = "nomLabel";
            nomLabel.Size = new System.Drawing.Size(56, 22);
            nomLabel.TabIndex = 7;
            nomLabel.Text = "Nom:";
            // 
            // prenomLabel
            // 
            prenomLabel.AutoSize = true;
            prenomLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            prenomLabel.ForeColor = System.Drawing.Color.Indigo;
            prenomLabel.Location = new System.Drawing.Point(97, 225);
            prenomLabel.Name = "prenomLabel";
            prenomLabel.Size = new System.Drawing.Size(79, 22);
            prenomLabel.TabIndex = 9;
            prenomLabel.Text = "Prénom:";
            // 
            // departementLabel
            // 
            departementLabel.AutoSize = true;
            departementLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            departementLabel.ForeColor = System.Drawing.Color.Indigo;
            departementLabel.Location = new System.Drawing.Point(97, 264);
            departementLabel.Name = "departementLabel";
            departementLabel.Size = new System.Drawing.Size(122, 22);
            departementLabel.TabIndex = 11;
            departementLabel.Text = "Département:";
            // 
            // date_recrutementLabel
            // 
            date_recrutementLabel.AutoSize = true;
            date_recrutementLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            date_recrutementLabel.ForeColor = System.Drawing.Color.Indigo;
            date_recrutementLabel.Location = new System.Drawing.Point(97, 307);
            date_recrutementLabel.Name = "date_recrutementLabel";
            date_recrutementLabel.Size = new System.Drawing.Size(182, 22);
            date_recrutementLabel.TabIndex = 13;
            date_recrutementLabel.Text = "Date de recrutement:";
            // 
            // telLabel
            // 
            telLabel.AutoSize = true;
            telLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            telLabel.ForeColor = System.Drawing.Color.Indigo;
            telLabel.Location = new System.Drawing.Point(97, 380);
            telLabel.Name = "telLabel";
            telLabel.Size = new System.Drawing.Size(193, 22);
            telLabel.TabIndex = 17;
            telLabel.Text = "Numero de téléphone:";
            // 
            // faxLabel
            // 
            faxLabel.AutoSize = true;
            faxLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            faxLabel.ForeColor = System.Drawing.Color.Indigo;
            faxLabel.Location = new System.Drawing.Point(97, 420);
            faxLabel.Name = "faxLabel";
            faxLabel.Size = new System.Drawing.Size(42, 22);
            faxLabel.TabIndex = 19;
            faxLabel.Text = "Fax:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            emailLabel.ForeColor = System.Drawing.Color.Indigo;
            emailLabel.Location = new System.Drawing.Point(97, 457);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(135, 22);
            emailLabel.TabIndex = 21;
            emailLabel.Text = "Adresse e-mail:";
            // 
            // grade_actuelLabel1
            // 
            grade_actuelLabel1.AutoSize = true;
            grade_actuelLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            grade_actuelLabel1.ForeColor = System.Drawing.Color.Indigo;
            grade_actuelLabel1.Location = new System.Drawing.Point(97, 341);
            grade_actuelLabel1.Name = "grade_actuelLabel1";
            grade_actuelLabel1.Size = new System.Drawing.Size(116, 22);
            grade_actuelLabel1.TabIndex = 24;
            grade_actuelLabel1.Text = "Grade actuel:";
            grade_actuelLabel1.Click += new System.EventHandler(this.grade_actuelLabel1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(grade_actuelLabel1);
            this.panel1.Controls.Add(this.grade_actuelText);
            this.panel1.Controls.Add(this.quitterBtn);
            this.panel1.Controls.Add(this.suivantBtn);
            this.panel1.Controls.Add(nomLabel);
            this.panel1.Controls.Add(this.textNom);
            this.panel1.Controls.Add(prenomLabel);
            this.panel1.Controls.Add(this.textPrenom);
            this.panel1.Controls.Add(departementLabel);
            this.panel1.Controls.Add(this.departementText);
            this.panel1.Controls.Add(date_recrutementLabel);
            this.panel1.Controls.Add(this.date_recrutement_text);
            this.panel1.Controls.Add(telLabel);
            this.panel1.Controls.Add(this.textTel);
            this.panel1.Controls.Add(faxLabel);
            this.panel1.Controls.Add(this.faxText);
            this.panel1.Controls.Add(emailLabel);
            this.panel1.Controls.Add(this.emailText);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(-8, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1169, 637);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.pictureBox2.BackgroundImage = global::candidat_projet.Properties.Resources.next;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(925, 580);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 18);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 92;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.pictureBox3.BackgroundImage = global::candidat_projet.Properties.Resources.logout;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(1074, 577);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 23);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::candidat_projet.Properties.Resources._9d065d38f72942e19bed052a6a3862fb__3_3;
            this.pictureBox1.Location = new System.Drawing.Point(8, -17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(226, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(285, 46);
            this.label4.TabIndex = 26;
            this.label4.Text = "Etape (1/5)\r\nInformations Personnelles\r\n";
            // 
            // grade_actuelText
            // 
            this.grade_actuelText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.candidatBindingSource, "grade_actuel", true));
            this.grade_actuelText.FormattingEnabled = true;
            this.grade_actuelText.Items.AddRange(new object[] {
            "PES-A",
            "PES-B",
            "PES-C",
            "PH-A",
            "PH-B",
            "PH-C",
            "PA-A",
            "PA-B",
            "PA-C",
            "PA-D"});
            this.grade_actuelText.Location = new System.Drawing.Point(302, 345);
            this.grade_actuelText.Name = "grade_actuelText";
            this.grade_actuelText.Size = new System.Drawing.Size(200, 21);
            this.grade_actuelText.TabIndex = 25;
            // 
            // candidatBindingSource
            // 
            this.candidatBindingSource.DataMember = "Candidat";
            this.candidatBindingSource.DataSource = this.database1DataSet;
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // quitterBtn
            // 
            this.quitterBtn.Location = new System.Drawing.Point(996, 573);
            this.quitterBtn.Name = "quitterBtn";
            this.quitterBtn.Size = new System.Drawing.Size(111, 31);
            this.quitterBtn.TabIndex = 24;
            this.quitterBtn.Text = "      Quitter";
            this.quitterBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.quitterBtn.Click += new System.EventHandler(this.quitterBtn_Click);
            // 
            // suivantBtn
            // 
            this.suivantBtn.Location = new System.Drawing.Point(855, 573);
            this.suivantBtn.Name = "suivantBtn";
            this.suivantBtn.Size = new System.Drawing.Size(105, 31);
            this.suivantBtn.Style = MetroFramework.MetroColorStyle.Purple;
            this.suivantBtn.TabIndex = 23;
            this.suivantBtn.Text = "      Suivant";
            this.suivantBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.suivantBtn.Click += new System.EventHandler(this.suivantBtn_Click);
            // 
            // textNom
            // 
            this.textNom.BackColor = System.Drawing.Color.White;
            this.textNom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textNom.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.candidatBindingSource, "nom", true));
            this.textNom.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textNom.Location = new System.Drawing.Point(302, 189);
            this.textNom.Name = "textNom";
            this.textNom.Size = new System.Drawing.Size(200, 20);
            this.textNom.TabIndex = 8;
            // 
            // textPrenom
            // 
            this.textPrenom.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.candidatBindingSource, "prenom", true));
            this.textPrenom.Location = new System.Drawing.Point(302, 227);
            this.textPrenom.Name = "textPrenom";
            this.textPrenom.Size = new System.Drawing.Size(200, 20);
            this.textPrenom.TabIndex = 10;
            // 
            // departementText
            // 
            this.departementText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.candidatBindingSource, "departement", true));
            this.departementText.Location = new System.Drawing.Point(302, 265);
            this.departementText.Name = "departementText";
            this.departementText.Size = new System.Drawing.Size(200, 20);
            this.departementText.TabIndex = 12;
            // 
            // date_recrutement_text
            // 
            this.date_recrutement_text.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.candidatBindingSource, "date_recrutement", true));
            this.date_recrutement_text.Location = new System.Drawing.Point(302, 308);
            this.date_recrutement_text.Name = "date_recrutement_text";
            this.date_recrutement_text.Size = new System.Drawing.Size(200, 20);
            this.date_recrutement_text.TabIndex = 14;
            // 
            // textTel
            // 
            this.textTel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.candidatBindingSource, "tel", true));
            this.textTel.Location = new System.Drawing.Point(302, 384);
            this.textTel.Name = "textTel";
            this.textTel.Size = new System.Drawing.Size(200, 20);
            this.textTel.TabIndex = 18;
            // 
            // faxText
            // 
            this.faxText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.candidatBindingSource, "fax", true));
            this.faxText.Location = new System.Drawing.Point(302, 428);
            this.faxText.Name = "faxText";
            this.faxText.Size = new System.Drawing.Size(200, 20);
            this.faxText.TabIndex = 20;
            // 
            // emailText
            // 
            this.emailText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.candidatBindingSource, "email", true));
            this.emailText.Location = new System.Drawing.Point(302, 460);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(200, 20);
            this.emailText.TabIndex = 22;
            this.emailText.TextChanged += new System.EventHandler(this.emailText_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PESAB);
            this.groupBox2.Controls.Add(this.labelPes);
            this.groupBox2.Controls.Add(this.PESBC);
            this.groupBox2.Controls.Add(this.labelPh);
            this.groupBox2.Controls.Add(this.PHBC);
            this.groupBox2.Controls.Add(this.PHAB);
            this.groupBox2.Controls.Add(this.PAAB);
            this.groupBox2.Controls.Add(this.PACD);
            this.groupBox2.Controls.Add(this.labelPa);
            this.groupBox2.Controls.Add(this.PABC);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Indigo;
            this.groupBox2.Location = new System.Drawing.Point(702, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 323);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cadre et grade";
            // 
            // PACD
            // 
            this.PACD.AutoSize = true;
            this.PACD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PACD.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.PACD.Location = new System.Drawing.Point(138, 274);
            this.PACD.Name = "PACD";
            this.PACD.Size = new System.Drawing.Size(173, 25);
            this.PACD.TabIndex = 3;
            this.PACD.Text = "grade C a grade D";
            this.PACD.UseVisualStyleBackColor = true;
            this.PACD.CheckedChanged += new System.EventHandler(this.PACD_CheckedChanged);
            // 
            // PAAB
            // 
            this.PAAB.AutoSize = true;
            this.PAAB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PAAB.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.PAAB.Location = new System.Drawing.Point(138, 212);
            this.PAAB.Name = "PAAB";
            this.PAAB.Size = new System.Drawing.Size(171, 25);
            this.PAAB.TabIndex = 7;
            this.PAAB.Text = "grade A a grade B";
            this.PAAB.UseVisualStyleBackColor = true;
            // 
            // labelPa
            // 
            this.labelPa.AutoSize = true;
            this.labelPa.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPa.ForeColor = System.Drawing.Color.Indigo;
            this.labelPa.Location = new System.Drawing.Point(82, 211);
            this.labelPa.Name = "labelPa";
            this.labelPa.Size = new System.Drawing.Size(38, 26);
            this.labelPa.TabIndex = 10;
            this.labelPa.Text = "PA";
            // 
            // PABC
            // 
            this.PABC.AutoSize = true;
            this.PABC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PABC.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.PABC.Location = new System.Drawing.Point(138, 243);
            this.PABC.Name = "PABC";
            this.PABC.Size = new System.Drawing.Size(170, 25);
            this.PABC.TabIndex = 6;
            this.PABC.Text = "grade B a grade C";
            this.PABC.UseVisualStyleBackColor = true;
            // 
            // PHBC
            // 
            this.PHBC.AutoSize = true;
            this.PHBC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PHBC.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.PHBC.Location = new System.Drawing.Point(139, 149);
            this.PHBC.Name = "PHBC";
            this.PHBC.Size = new System.Drawing.Size(170, 25);
            this.PHBC.TabIndex = 5;
            this.PHBC.Text = "grade B a grade C";
            this.PHBC.UseVisualStyleBackColor = true;
            // 
            // PHAB
            // 
            this.PHAB.AutoSize = true;
            this.PHAB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PHAB.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.PHAB.Location = new System.Drawing.Point(139, 119);
            this.PHAB.Name = "PHAB";
            this.PHAB.Size = new System.Drawing.Size(171, 25);
            this.PHAB.TabIndex = 4;
            this.PHAB.Text = "grade A a grade B";
            this.PHAB.UseVisualStyleBackColor = true;
            // 
            // labelPh
            // 
            this.labelPh.AutoSize = true;
            this.labelPh.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPh.ForeColor = System.Drawing.Color.Indigo;
            this.labelPh.Location = new System.Drawing.Point(80, 119);
            this.labelPh.Name = "labelPh";
            this.labelPh.Size = new System.Drawing.Size(40, 26);
            this.labelPh.TabIndex = 9;
            this.labelPh.Text = "PH";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pExceptionel);
            this.groupBox1.Controls.Add(this.pNormal);
            this.groupBox1.Controls.Add(this.pRapid);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Indigo;
            this.groupBox1.Location = new System.Drawing.Point(702, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 143);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type de passage";
            // 
            // pExceptionel
            // 
            this.pExceptionel.AutoSize = true;
            this.pExceptionel.Checked = true;
            this.pExceptionel.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.pExceptionel.Location = new System.Drawing.Point(63, 37);
            this.pExceptionel.Name = "pExceptionel";
            this.pExceptionel.Size = new System.Drawing.Size(195, 25);
            this.pExceptionel.TabIndex = 1;
            this.pExceptionel.TabStop = true;
            this.pExceptionel.Text = "Passage Exceptionnel";
            this.pExceptionel.UseVisualStyleBackColor = true;
            // 
            // pNormal
            // 
            this.pNormal.AutoSize = true;
            this.pNormal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pNormal.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.pNormal.Location = new System.Drawing.Point(64, 99);
            this.pNormal.Name = "pNormal";
            this.pNormal.Size = new System.Drawing.Size(152, 25);
            this.pNormal.TabIndex = 3;
            this.pNormal.TabStop = true;
            this.pNormal.Text = "Passage normal";
            this.pNormal.UseVisualStyleBackColor = true;
            this.pNormal.CheckedChanged += new System.EventHandler(this.metroRadioButton3_CheckedChanged);
            // 
            // pRapid
            // 
            this.pRapid.AutoSize = true;
            this.pRapid.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.pRapid.Location = new System.Drawing.Point(63, 70);
            this.pRapid.Name = "pRapid";
            this.pRapid.Size = new System.Drawing.Size(151, 25);
            this.pRapid.TabIndex = 2;
            this.pRapid.TabStop = true;
            this.pRapid.Text = "Passage Rapide";
            this.pRapid.UseVisualStyleBackColor = true;
            // 
            // candidatTableAdapter
            // 
            this.candidatTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.Activite_enseignementTableAdapter = null;
            this.tableAdapterManager.Activite_rechercheTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CandidatTableAdapter = this.candidatTableAdapter;
            this.tableAdapterManager.CorrecteurTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = candidat_projet.Database1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // PESAB
            // 
            this.PESAB.AutoSize = true;
            this.PESAB.Checked = true;
            this.PESAB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PESAB.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.PESAB.Location = new System.Drawing.Point(139, 38);
            this.PESAB.Name = "PESAB";
            this.PESAB.Size = new System.Drawing.Size(171, 25);
            this.PESAB.TabIndex = 1;
            this.PESAB.Text = "grade A a grade B";
            this.PESAB.UseVisualStyleBackColor = true;
            // 
            // PESBC
            // 
            this.PESBC.AutoSize = true;
            this.PESBC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PESBC.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.PESBC.Location = new System.Drawing.Point(140, 60);
            this.PESBC.Name = "PESBC";
            this.PESBC.Size = new System.Drawing.Size(170, 25);
            this.PESBC.TabIndex = 2;
            this.PESBC.Text = "grade B a grade C";
            this.PESBC.UseVisualStyleBackColor = true;
            // 
            // labelPes
            // 
            this.labelPes.AutoSize = true;
            this.labelPes.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPes.ForeColor = System.Drawing.Color.Indigo;
            this.labelPes.Location = new System.Drawing.Point(74, 38);
            this.labelPes.Name = "labelPes";
            this.labelPes.Size = new System.Drawing.Size(46, 26);
            this.labelPes.TabIndex = 8;
            this.labelPes.Text = "PES";
            this.labelPes.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(503, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 18);
            this.label1.TabIndex = 93;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(503, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 18);
            this.label2.TabIndex = 94;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(503, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 18);
            this.label3.TabIndex = 95;
            this.label3.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(503, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 18);
            this.label5.TabIndex = 96;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(503, 344);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 18);
            this.label6.TabIndex = 97;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(503, 384);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 18);
            this.label7.TabIndex = 98;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(304, 481);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 12);
            this.label8.TabIndex = 99;
            this.label8.Text = "aaa.aaa@example.aaa";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(503, 461);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 18);
            this.label9.TabIndex = 100;
            this.label9.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(303, 405);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 12);
            this.label10.TabIndex = 101;
            this.label10.Text = "10 chiffres";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::candidat_projet.Properties.Resources.Purple1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.candidatBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroRadioButton pExceptionel;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroRadioButton pRapid;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroRadioButton pNormal;
        private MetroFramework.Controls.MetroRadioButton PAAB;
        private MetroFramework.Controls.MetroRadioButton PHAB;
        private MetroFramework.Controls.MetroRadioButton PABC;
        private MetroFramework.Controls.MetroRadioButton PHBC;
        private System.Windows.Forms.Label labelPa;
        private System.Windows.Forms.Label labelPh;
        private Database1DataSet database1DataSet;
        private System.Windows.Forms.BindingSource candidatBindingSource;
        private Database1DataSetTableAdapters.CandidatTableAdapter candidatTableAdapter;
        private Database1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox textNom;
        private System.Windows.Forms.TextBox textPrenom;
        private System.Windows.Forms.TextBox departementText;
        private System.Windows.Forms.DateTimePicker date_recrutement_text;
        private System.Windows.Forms.TextBox textTel;
        private System.Windows.Forms.TextBox faxText;
        private System.Windows.Forms.TextBox emailText;
        private MetroFramework.Controls.MetroButton quitterBtn;
        private MetroFramework.Controls.MetroButton suivantBtn;
        private MetroFramework.Controls.MetroRadioButton PACD;
        private System.Windows.Forms.ComboBox grade_actuelText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MetroFramework.Controls.MetroRadioButton PESAB;
        private System.Windows.Forms.Label labelPes;
        private MetroFramework.Controls.MetroRadioButton PESBC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

