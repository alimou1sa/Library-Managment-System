namespace Library_Manegment_System
{
    partial class frmUsersManagments
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvShowUserList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.cbGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbIsActive = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtFiter = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbFiterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddUser = new Guna.UI2.WinForms.Guna2Button();
            this.btnPeopleManagment = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowUserList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(588, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(623, 85);
            this.label1.TabIndex = 3;
            this.label1.Text = "Users Managment";
            // 
            // dgvShowUserList
            // 
            this.dgvShowUserList.AllowUserToAddRows = false;
            this.dgvShowUserList.AllowUserToDeleteRows = false;
            this.dgvShowUserList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShowUserList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShowUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowUserList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvShowUserList.Location = new System.Drawing.Point(12, 377);
            this.dgvShowUserList.Name = "dgvShowUserList";
            this.dgvShowUserList.ReadOnly = true;
            this.dgvShowUserList.RowHeadersWidth = 51;
            this.dgvShowUserList.RowTemplate.Height = 26;
            this.dgvShowUserList.Size = new System.Drawing.Size(1762, 444);
            this.dgvShowUserList.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.userDetailsToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.addUserToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(175, 116);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(174, 28);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // userDetailsToolStripMenuItem
            // 
            this.userDetailsToolStripMenuItem.Image = global::Library_Manegment_System.Properties.Resources.undraw_user_account_fvqa;
            this.userDetailsToolStripMenuItem.Name = "userDetailsToolStripMenuItem";
            this.userDetailsToolStripMenuItem.Size = new System.Drawing.Size(174, 28);
            this.userDetailsToolStripMenuItem.Text = "User Details";
            this.userDetailsToolStripMenuItem.Click += new System.EventHandler(this.userDetailsToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(174, 28);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(174, 28);
            this.addUserToolStripMenuItem.Text = "Add User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(118, 850);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(34, 24);
            this.lblRecordsCount.TabIndex = 16;
            this.lblRecordsCount.Text = "???";
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblR.Location = new System.Drawing.Point(12, 850);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(104, 24);
            this.lblR.TabIndex = 15;
            this.lblR.Text = "# Records :";
            // 
            // cbGender
            // 
            this.cbGender.BackColor = System.Drawing.Color.Transparent;
            this.cbGender.BorderRadius = 11;
            this.cbGender.BorderThickness = 2;
            this.cbGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.FillColor = System.Drawing.Color.Teal;
            this.cbGender.FocusedColor = System.Drawing.Color.Empty;
            this.cbGender.FocusedState.Parent = this.cbGender;
            this.cbGender.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGender.ForeColor = System.Drawing.Color.Black;
            this.cbGender.FormattingEnabled = true;
            this.cbGender.HoverState.Parent = this.cbGender;
            this.cbGender.ItemHeight = 30;
            this.cbGender.Items.AddRange(new object[] {
            "All",
            "Male",
            "Female"});
            this.cbGender.ItemsAppearance.Parent = this.cbGender;
            this.cbGender.Location = new System.Drawing.Point(387, 322);
            this.cbGender.Name = "cbGender";
            this.cbGender.ShadowDecoration.Parent = this.cbGender;
            this.cbGender.Size = new System.Drawing.Size(229, 36);
            this.cbGender.StartIndex = 0;
            this.cbGender.TabIndex = 21;
            this.cbGender.Visible = false;
            this.cbGender.SelectedIndexChanged += new System.EventHandler(this.cbGender_SelectedIndexChanged);
            // 
            // cbIsActive
            // 
            this.cbIsActive.BackColor = System.Drawing.Color.Transparent;
            this.cbIsActive.BorderRadius = 11;
            this.cbIsActive.BorderThickness = 2;
            this.cbIsActive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActive.FillColor = System.Drawing.Color.Teal;
            this.cbIsActive.FocusedColor = System.Drawing.Color.Empty;
            this.cbIsActive.FocusedState.Parent = this.cbIsActive;
            this.cbIsActive.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsActive.ForeColor = System.Drawing.Color.Black;
            this.cbIsActive.FormattingEnabled = true;
            this.cbIsActive.HoverState.Parent = this.cbIsActive;
            this.cbIsActive.ItemHeight = 30;
            this.cbIsActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsActive.ItemsAppearance.Parent = this.cbIsActive;
            this.cbIsActive.Location = new System.Drawing.Point(387, 322);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.ShadowDecoration.Parent = this.cbIsActive;
            this.cbIsActive.Size = new System.Drawing.Size(229, 36);
            this.cbIsActive.StartIndex = 0;
            this.cbIsActive.TabIndex = 20;
            this.cbIsActive.Visible = false;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // txtFiter
            // 
            this.txtFiter.BorderRadius = 11;
            this.txtFiter.BorderThickness = 2;
            this.txtFiter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFiter.DefaultText = "";
            this.txtFiter.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFiter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFiter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFiter.DisabledState.Parent = this.txtFiter;
            this.txtFiter.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFiter.FillColor = System.Drawing.Color.Teal;
            this.txtFiter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFiter.FocusedState.Parent = this.txtFiter;
            this.txtFiter.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiter.ForeColor = System.Drawing.Color.Black;
            this.txtFiter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFiter.HoverState.Parent = this.txtFiter;
            this.txtFiter.Location = new System.Drawing.Point(387, 322);
            this.txtFiter.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtFiter.Name = "txtFiter";
            this.txtFiter.PasswordChar = '\0';
            this.txtFiter.PlaceholderText = "";
            this.txtFiter.SelectedText = "";
            this.txtFiter.ShadowDecoration.Parent = this.txtFiter;
            this.txtFiter.Size = new System.Drawing.Size(229, 36);
            this.txtFiter.TabIndex = 19;
            this.txtFiter.TextChanged += new System.EventHandler(this.txtFiter_TextChanged);
            this.txtFiter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiter_KeyPress);
            // 
            // cbFiterBy
            // 
            this.cbFiterBy.BackColor = System.Drawing.Color.Transparent;
            this.cbFiterBy.BorderRadius = 11;
            this.cbFiterBy.BorderThickness = 2;
            this.cbFiterBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFiterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiterBy.FillColor = System.Drawing.Color.Teal;
            this.cbFiterBy.FocusedColor = System.Drawing.Color.Empty;
            this.cbFiterBy.FocusedState.Parent = this.cbFiterBy;
            this.cbFiterBy.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFiterBy.ForeColor = System.Drawing.Color.Black;
            this.cbFiterBy.FormattingEnabled = true;
            this.cbFiterBy.HoverState.Parent = this.cbFiterBy;
            this.cbFiterBy.ItemHeight = 30;
            this.cbFiterBy.Items.AddRange(new object[] {
            "None",
            "User ID",
            "User Name",
            "NationalNo",
            "Gendor Caption",
            "Is Active",
            "Job Title",
            "Salary",
            "Full Name"});
            this.cbFiterBy.ItemsAppearance.Parent = this.cbFiterBy;
            this.cbFiterBy.Location = new System.Drawing.Point(138, 322);
            this.cbFiterBy.Name = "cbFiterBy";
            this.cbFiterBy.ShadowDecoration.Parent = this.cbFiterBy;
            this.cbFiterBy.Size = new System.Drawing.Size(205, 36);
            this.cbFiterBy.TabIndex = 18;
            this.cbFiterBy.SelectedIndexChanged += new System.EventHandler(this.cbFiterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 28);
            this.label2.TabIndex = 17;
            this.label2.Text = "Filter by :";
            // 
            // btnAddUser
            // 
            this.btnAddUser.BorderRadius = 7;
            this.btnAddUser.BorderThickness = 2;
            this.btnAddUser.CheckedState.Parent = this.btnAddUser;
            this.btnAddUser.CustomImages.Parent = this.btnAddUser;
            this.btnAddUser.FillColor = System.Drawing.Color.Teal;
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddUser.HoverState.Parent = this.btnAddUser;
            this.btnAddUser.Location = new System.Drawing.Point(1583, 311);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.ShadowDecoration.Parent = this.btnAddUser;
            this.btnAddUser.Size = new System.Drawing.Size(163, 47);
            this.btnAddUser.TabIndex = 22;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnPeopleManagment
            // 
            this.btnPeopleManagment.BorderRadius = 7;
            this.btnPeopleManagment.BorderThickness = 2;
            this.btnPeopleManagment.CheckedState.Parent = this.btnPeopleManagment;
            this.btnPeopleManagment.CustomImages.Parent = this.btnPeopleManagment;
            this.btnPeopleManagment.FillColor = System.Drawing.Color.Teal;
            this.btnPeopleManagment.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeopleManagment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPeopleManagment.HoverState.Parent = this.btnPeopleManagment;
            this.btnPeopleManagment.Location = new System.Drawing.Point(1381, 311);
            this.btnPeopleManagment.Name = "btnPeopleManagment";
            this.btnPeopleManagment.ShadowDecoration.Parent = this.btnPeopleManagment;
            this.btnPeopleManagment.Size = new System.Drawing.Size(177, 47);
            this.btnPeopleManagment.TabIndex = 23;
            this.btnPeopleManagment.Text = "People Managment";
            this.btnPeopleManagment.Click += new System.EventHandler(this.btnPeopleManagment_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Library_Manegment_System.Properties.Resources.icons8_users_100;
            this.pictureBox1.Location = new System.Drawing.Point(789, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 222);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // frmUsersManagments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1780, 883);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnPeopleManagment);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.txtFiter);
            this.Controls.Add(this.cbFiterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.lblR);
            this.Controls.Add(this.dgvShowUserList);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmUsersManagments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users Managment";
            this.Load += new System.EventHandler(this.frmUsersManagments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowUserList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvShowUserList;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label lblR;
        private Guna.UI2.WinForms.Guna2ComboBox cbGender;
        private Guna.UI2.WinForms.Guna2ComboBox cbIsActive;
        private Guna.UI2.WinForms.Guna2TextBox txtFiter;
        private Guna.UI2.WinForms.Guna2ComboBox cbFiterBy;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnAddUser;
        private Guna.UI2.WinForms.Guna2Button btnPeopleManagment;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}