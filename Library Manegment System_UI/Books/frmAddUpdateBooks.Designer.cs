namespace Library_Manegment_System
{
    partial class frmAddUpdateBooks
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAddCategory = new Guna.UI2.WinForms.Guna2Button();
            this.lblAddGenre = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddPublisher = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddAuther = new Guna.UI2.WinForms.Guna2Button();
            this.label4 = new System.Windows.Forms.Label();
            this.NupDNumofCopies = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.cbPublisherName = new System.Windows.Forms.ComboBox();
            this.CMstripPublisher = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBookPrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbGenre = new System.Windows.Forms.ComboBox();
            this.CMstripGenre = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbAutherName = new System.Windows.Forms.ComboBox();
            this.CMstripAuther = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.CMstripCategory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblBookID = new System.Windows.Forms.Label();
            this.txtAdditionalDetails = new System.Windows.Forms.TextBox();
            this.dtpPublicationDate = new System.Windows.Forms.DateTimePicker();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitel = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NupDNumofCopies)).BeginInit();
            this.CMstripPublisher.SuspendLayout();
            this.CMstripGenre.SuspendLayout();
            this.CMstripAuther.SuspendLayout();
            this.CMstripCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.lblAddCategory);
            this.groupBox1.Controls.Add(this.lblAddGenre);
            this.groupBox1.Controls.Add(this.btnAddPublisher);
            this.groupBox1.Controls.Add(this.btnAddAuther);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.NupDNumofCopies);
            this.groupBox1.Controls.Add(this.cbPublisherName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtBookPrice);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbGenre);
            this.groupBox1.Controls.Add(this.cbAutherName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbCategory);
            this.groupBox1.Controls.Add(this.lblBookID);
            this.groupBox1.Controls.Add(this.txtAdditionalDetails);
            this.groupBox1.Controls.Add(this.dtpPublicationDate);
            this.groupBox1.Controls.Add(this.txtISBN);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(904, 420);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BookInfo";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblAddCategory
            // 
            this.lblAddCategory.CheckedState.Parent = this.lblAddCategory;
            this.lblAddCategory.CustomImages.Parent = this.lblAddCategory;
            this.lblAddCategory.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAddCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddCategory.ForeColor = System.Drawing.Color.White;
            this.lblAddCategory.HoverState.Parent = this.lblAddCategory;
            this.lblAddCategory.Location = new System.Drawing.Point(804, 189);
            this.lblAddCategory.Name = "lblAddCategory";
            this.lblAddCategory.ShadowDecoration.Parent = this.lblAddCategory;
            this.lblAddCategory.Size = new System.Drawing.Size(60, 29);
            this.lblAddCategory.TabIndex = 29;
            this.lblAddCategory.Text = "Add";
            this.lblAddCategory.Click += new System.EventHandler(this.lblAddCategory_Click);
            // 
            // lblAddGenre
            // 
            this.lblAddGenre.CheckedState.Parent = this.lblAddGenre;
            this.lblAddGenre.CustomImages.Parent = this.lblAddGenre;
            this.lblAddGenre.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAddGenre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddGenre.ForeColor = System.Drawing.Color.White;
            this.lblAddGenre.HoverState.Parent = this.lblAddGenre;
            this.lblAddGenre.Location = new System.Drawing.Point(804, 126);
            this.lblAddGenre.Name = "lblAddGenre";
            this.lblAddGenre.ShadowDecoration.Parent = this.lblAddGenre;
            this.lblAddGenre.Size = new System.Drawing.Size(60, 29);
            this.lblAddGenre.TabIndex = 28;
            this.lblAddGenre.Text = "Add";
            this.lblAddGenre.Click += new System.EventHandler(this.lblAddGenre_Click);
            // 
            // btnAddPublisher
            // 
            this.btnAddPublisher.CheckedState.Parent = this.btnAddPublisher;
            this.btnAddPublisher.CustomImages.Parent = this.btnAddPublisher;
            this.btnAddPublisher.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddPublisher.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddPublisher.ForeColor = System.Drawing.Color.White;
            this.btnAddPublisher.HoverState.Parent = this.btnAddPublisher;
            this.btnAddPublisher.Location = new System.Drawing.Point(334, 328);
            this.btnAddPublisher.Name = "btnAddPublisher";
            this.btnAddPublisher.ShadowDecoration.Parent = this.btnAddPublisher;
            this.btnAddPublisher.Size = new System.Drawing.Size(66, 33);
            this.btnAddPublisher.TabIndex = 27;
            this.btnAddPublisher.Text = "Add";
            this.btnAddPublisher.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // btnAddAuther
            // 
            this.btnAddAuther.CheckedState.Parent = this.btnAddAuther;
            this.btnAddAuther.CustomImages.Parent = this.btnAddAuther;
            this.btnAddAuther.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddAuther.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddAuther.ForeColor = System.Drawing.Color.White;
            this.btnAddAuther.HoverState.Parent = this.btnAddAuther;
            this.btnAddAuther.Location = new System.Drawing.Point(334, 264);
            this.btnAddAuther.Name = "btnAddAuther";
            this.btnAddAuther.ShadowDecoration.Parent = this.btnAddAuther;
            this.btnAddAuther.Size = new System.Drawing.Size(66, 33);
            this.btnAddAuther.TabIndex = 26;
            this.btnAddAuther.Text = "Add";
            this.btnAddAuther.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(418, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 22);
            this.label4.TabIndex = 25;
            this.label4.Text = "Year Published:";
            // 
            // NupDNumofCopies
            // 
            this.NupDNumofCopies.BackColor = System.Drawing.Color.Transparent;
            this.NupDNumofCopies.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NupDNumofCopies.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.NupDNumofCopies.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.NupDNumofCopies.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NupDNumofCopies.DisabledState.Parent = this.NupDNumofCopies;
            this.NupDNumofCopies.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.NupDNumofCopies.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.NupDNumofCopies.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NupDNumofCopies.FocusedState.Parent = this.NupDNumofCopies;
            this.NupDNumofCopies.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NupDNumofCopies.ForeColor = System.Drawing.Color.Black;
            this.NupDNumofCopies.Location = new System.Drawing.Point(486, 373);
            this.NupDNumofCopies.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NupDNumofCopies.Name = "NupDNumofCopies";
            this.NupDNumofCopies.ShadowDecoration.Parent = this.NupDNumofCopies;
            this.NupDNumofCopies.Size = new System.Drawing.Size(94, 41);
            this.NupDNumofCopies.TabIndex = 24;
            this.NupDNumofCopies.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            // 
            // cbPublisherName
            // 
            this.cbPublisherName.ContextMenuStrip = this.CMstripPublisher;
            this.cbPublisherName.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPublisherName.FormattingEnabled = true;
            this.cbPublisherName.Items.AddRange(new object[] {
            "None"});
            this.cbPublisherName.Location = new System.Drawing.Point(161, 328);
            this.cbPublisherName.Name = "cbPublisherName";
            this.cbPublisherName.Size = new System.Drawing.Size(167, 29);
            this.cbPublisherName.TabIndex = 23;
            // 
            // CMstripPublisher
            // 
            this.CMstripPublisher.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMstripPublisher.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editeToolStripMenuItem1});
            this.CMstripPublisher.Name = "CMstripPublisher";
            this.CMstripPublisher.Size = new System.Drawing.Size(110, 32);
            // 
            // editeToolStripMenuItem1
            // 
            this.editeToolStripMenuItem1.Name = "editeToolStripMenuItem1";
            this.editeToolStripMenuItem1.Size = new System.Drawing.Size(109, 28);
            this.editeToolStripMenuItem1.Text = "Edit";
            this.editeToolStripMenuItem1.Click += new System.EventHandler(this.editeToolStripMenuItem1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 335);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(160, 22);
            this.label11.TabIndex = 22;
            this.label11.Text = "Publisher Name:";
            // 
            // txtBookPrice
            // 
            this.txtBookPrice.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookPrice.Location = new System.Drawing.Point(598, 329);
            this.txtBookPrice.Name = "txtBookPrice";
            this.txtBookPrice.Size = new System.Drawing.Size(227, 28);
            this.txtBookPrice.TabIndex = 21;
            this.txtBookPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBookPrice_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(418, 331);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 22);
            this.label10.TabIndex = 20;
            this.label10.Text = "Book Price :";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // cbGenre
            // 
            this.cbGenre.ContextMenuStrip = this.CMstripGenre;
            this.cbGenre.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGenre.FormattingEnabled = true;
            this.cbGenre.Items.AddRange(new object[] {
            "None"});
            this.cbGenre.Location = new System.Drawing.Point(598, 126);
            this.cbGenre.Name = "cbGenre";
            this.cbGenre.Size = new System.Drawing.Size(200, 29);
            this.cbGenre.TabIndex = 19;
            // 
            // CMstripGenre
            // 
            this.CMstripGenre.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMstripGenre.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editeToolStripMenuItem});
            this.CMstripGenre.Name = "CMstripGenre";
            this.CMstripGenre.Size = new System.Drawing.Size(110, 32);
            // 
            // editeToolStripMenuItem
            // 
            this.editeToolStripMenuItem.Name = "editeToolStripMenuItem";
            this.editeToolStripMenuItem.Size = new System.Drawing.Size(109, 28);
            this.editeToolStripMenuItem.Text = "Edit";
            this.editeToolStripMenuItem.Click += new System.EventHandler(this.editeToolStripMenuItem_Click);
            // 
            // cbAutherName
            // 
            this.cbAutherName.ContextMenuStrip = this.CMstripAuther;
            this.cbAutherName.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAutherName.FormattingEnabled = true;
            this.cbAutherName.Items.AddRange(new object[] {
            "None"});
            this.cbAutherName.Location = new System.Drawing.Point(161, 268);
            this.cbAutherName.Name = "cbAutherName";
            this.cbAutherName.Size = new System.Drawing.Size(167, 29);
            this.cbAutherName.TabIndex = 18;
            // 
            // CMstripAuther
            // 
            this.CMstripAuther.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMstripAuther.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem1});
            this.CMstripAuther.Name = "CMstripAuther";
            this.CMstripAuther.Size = new System.Drawing.Size(110, 32);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(109, 28);
            this.editToolStripMenuItem1.Text = "Edit";
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.editToolStripMenuItem1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(278, 383);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 22);
            this.label9.TabIndex = 16;
            this.label9.Text = "Number of Copies";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 22);
            this.label8.TabIndex = 14;
            this.label8.Text = "Author Name:";
            // 
            // cbCategory
            // 
            this.cbCategory.ContextMenuStrip = this.CMstripCategory;
            this.cbCategory.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "None"});
            this.cbCategory.Location = new System.Drawing.Point(598, 189);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(200, 29);
            this.cbCategory.TabIndex = 13;
            // 
            // CMstripCategory
            // 
            this.CMstripCategory.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMstripCategory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.CMstripCategory.Name = "CMstripCategory";
            this.CMstripCategory.Size = new System.Drawing.Size(110, 32);
            this.CMstripCategory.Opening += new System.ComponentModel.CancelEventHandler(this.CMstripCategory_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(109, 28);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // lblBookID
            // 
            this.lblBookID.AutoSize = true;
            this.lblBookID.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookID.Location = new System.Drawing.Point(141, 56);
            this.lblBookID.Name = "lblBookID";
            this.lblBookID.Size = new System.Drawing.Size(34, 21);
            this.lblBookID.TabIndex = 12;
            this.lblBookID.Text = "???";
            // 
            // txtAdditionalDetails
            // 
            this.txtAdditionalDetails.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdditionalDetails.Location = new System.Drawing.Point(598, 245);
            this.txtAdditionalDetails.Multiline = true;
            this.txtAdditionalDetails.Name = "txtAdditionalDetails";
            this.txtAdditionalDetails.Size = new System.Drawing.Size(227, 70);
            this.txtAdditionalDetails.TabIndex = 11;
            // 
            // dtpPublicationDate
            // 
            this.dtpPublicationDate.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPublicationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPublicationDate.Location = new System.Drawing.Point(599, 56);
            this.dtpPublicationDate.Name = "dtpPublicationDate";
            this.dtpPublicationDate.Size = new System.Drawing.Size(227, 28);
            this.dtpPublicationDate.TabIndex = 10;
            // 
            // txtISBN
            // 
            this.txtISBN.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtISBN.Location = new System.Drawing.Point(161, 193);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(217, 28);
            this.txtISBN.TabIndex = 8;
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(161, 121);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(217, 28);
            this.txtTitle.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(419, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 22);
            this.label7.TabIndex = 6;
            this.label7.Text = "Additional Details:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(421, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "Category :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(418, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Genre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "ISBN:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Title:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Book ID:";
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Mongolian Baiti", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitel.Location = new System.Drawing.Point(319, 140);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(282, 64);
            this.lblTitel.TabIndex = 2;
            this.lblTitel.Text = "Add Book";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 11;
            this.guna2Button1.BorderThickness = 3;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Button1.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(576, 645);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(133, 54);
            this.guna2Button1.TabIndex = 4;
            this.guna2Button1.Text = "Close";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 11;
            this.btnSave.BorderThickness = 3;
            this.btnSave.CheckedState.Parent = this.btnSave;
            this.btnSave.CustomImages.Parent = this.btnSave;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.Parent = this.btnSave;
            this.btnSave.ImageSize = new System.Drawing.Size(40, 40);
            this.btnSave.Location = new System.Drawing.Point(737, 645);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.Size = new System.Drawing.Size(133, 54);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Library_Manegment_System.Properties.Resources.icons8_orange_book_96;
            this.pictureBox1.Location = new System.Drawing.Point(-3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // frmAddUpdateBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 712);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmAddUpdateBooks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD & Update Books";
            this.Load += new System.EventHandler(this.frmAddUpdateBooks_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NupDNumofCopies)).EndInit();
            this.CMstripPublisher.ResumeLayout(false);
            this.CMstripGenre.ResumeLayout(false);
            this.CMstripAuther.ResumeLayout(false);
            this.CMstripCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label lblBookID;
        private System.Windows.Forms.TextBox txtAdditionalDetails;
        private System.Windows.Forms.DateTimePicker dtpPublicationDate;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAutherName;
        private System.Windows.Forms.ComboBox cbGenre;
        private System.Windows.Forms.TextBox txtBookPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbPublisherName;
        private Guna.UI2.WinForms.Guna2NumericUpDown NupDNumofCopies;
        private Guna.UI2.WinForms.Guna2Button btnAddAuther;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button btnAddPublisher;
        private System.Windows.Forms.Label lblTitel;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button lblAddCategory;
        private Guna.UI2.WinForms.Guna2Button lblAddGenre;
        private System.Windows.Forms.ContextMenuStrip CMstripGenre;
        private System.Windows.Forms.ToolStripMenuItem editeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip CMstripCategory;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip CMstripPublisher;
        private System.Windows.Forms.ToolStripMenuItem editeToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip CMstripAuther;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}