namespace Library_Manegment_System
{
    partial class frmBooksManagment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvShowBooks = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusCopiesBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loanBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddBooks = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFiterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblR = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.txtFiter = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbForAll = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowBooks)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvShowBooks
            // 
            this.dgvShowBooks.AllowUserToAddRows = false;
            this.dgvShowBooks.AllowUserToDeleteRows = false;
            this.dgvShowBooks.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvShowBooks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvShowBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowBooks.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvShowBooks.Location = new System.Drawing.Point(12, 304);
            this.dgvShowBooks.Name = "dgvShowBooks";
            this.dgvShowBooks.ReadOnly = true;
            this.dgvShowBooks.RowHeadersWidth = 51;
            this.dgvShowBooks.RowTemplate.Height = 26;
            this.dgvShowBooks.Size = new System.Drawing.Size(1505, 405);
            this.dgvShowBooks.TabIndex = 0;
            this.dgvShowBooks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.showToolStripMenuItem,
            this.deleteBookToolStripMenuItem,
            this.addBookToolStripMenuItem,
            this.statusCopiesBookToolStripMenuItem,
            this.loanBookToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(293, 172);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(292, 28);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(292, 28);
            this.showToolStripMenuItem.Text = "Show Book Details";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // deleteBookToolStripMenuItem
            // 
            this.deleteBookToolStripMenuItem.Name = "deleteBookToolStripMenuItem";
            this.deleteBookToolStripMenuItem.Size = new System.Drawing.Size(292, 28);
            this.deleteBookToolStripMenuItem.Text = "Delete Book";
            this.deleteBookToolStripMenuItem.Click += new System.EventHandler(this.deleteBookToolStripMenuItem_Click);
            // 
            // addBookToolStripMenuItem
            // 
            this.addBookToolStripMenuItem.Name = "addBookToolStripMenuItem";
            this.addBookToolStripMenuItem.Size = new System.Drawing.Size(292, 28);
            this.addBookToolStripMenuItem.Text = "Add Book";
            this.addBookToolStripMenuItem.Click += new System.EventHandler(this.addBookToolStripMenuItem_Click);
            // 
            // statusCopiesBookToolStripMenuItem
            // 
            this.statusCopiesBookToolStripMenuItem.Name = "statusCopiesBookToolStripMenuItem";
            this.statusCopiesBookToolStripMenuItem.Size = new System.Drawing.Size(292, 28);
            this.statusCopiesBookToolStripMenuItem.Text = "Manage Status Copies Book";
            this.statusCopiesBookToolStripMenuItem.Click += new System.EventHandler(this.statusCopiesBookToolStripMenuItem_Click);
            // 
            // loanBookToolStripMenuItem
            // 
            this.loanBookToolStripMenuItem.Name = "loanBookToolStripMenuItem";
            this.loanBookToolStripMenuItem.Size = new System.Drawing.Size(292, 28);
            this.loanBookToolStripMenuItem.Text = "Borrow Book";
            this.loanBookToolStripMenuItem.Click += new System.EventHandler(this.loanBookToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(596, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 64);
            this.label1.TabIndex = 1;
            this.label1.Text = "Books Managment";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnAddBooks
            // 
            this.btnAddBooks.BorderRadius = 6;
            this.btnAddBooks.BorderThickness = 2;
            this.btnAddBooks.CheckedState.Parent = this.btnAddBooks;
            this.btnAddBooks.CustomImages.Parent = this.btnAddBooks;
            this.btnAddBooks.FillColor = System.Drawing.Color.Teal;
            this.btnAddBooks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBooks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddBooks.HoverState.Parent = this.btnAddBooks;
            this.btnAddBooks.Location = new System.Drawing.Point(1333, 231);
            this.btnAddBooks.Name = "btnAddBooks";
            this.btnAddBooks.ShadowDecoration.Parent = this.btnAddBooks;
            this.btnAddBooks.Size = new System.Drawing.Size(163, 47);
            this.btnAddBooks.TabIndex = 2;
            this.btnAddBooks.Text = "Add Book";
            this.btnAddBooks.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter by :";
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
            this.cbFiterBy.ItemHeight = 28;
            this.cbFiterBy.Items.AddRange(new object[] {
            "None",
            "BookID",
            "Title",
            "ISBN",
            "Genre",
            "Publisher Name",
            "Category Name",
            "Auther Name",
            "Book Price"});
            this.cbFiterBy.ItemsAppearance.Parent = this.cbFiterBy;
            this.cbFiterBy.Location = new System.Drawing.Point(132, 231);
            this.cbFiterBy.Name = "cbFiterBy";
            this.cbFiterBy.ShadowDecoration.Parent = this.cbFiterBy;
            this.cbFiterBy.Size = new System.Drawing.Size(189, 34);
            this.cbFiterBy.TabIndex = 4;
            this.cbFiterBy.SelectedIndexChanged += new System.EventHandler(this.cbFiterBy_SelectedIndexChanged);
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblR.Location = new System.Drawing.Point(22, 712);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(104, 24);
            this.lblR.TabIndex = 5;
            this.lblR.Text = "# Records :";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(128, 712);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(34, 24);
            this.lblRecordsCount.TabIndex = 6;
            this.lblRecordsCount.Text = "???";
            // 
            // txtFiter
            // 
            this.txtFiter.BackColor = System.Drawing.Color.White;
            this.txtFiter.BorderColor = System.Drawing.Color.Black;
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
            this.txtFiter.Location = new System.Drawing.Point(381, 231);
            this.txtFiter.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtFiter.Name = "txtFiter";
            this.txtFiter.PasswordChar = '\0';
            this.txtFiter.PlaceholderText = "";
            this.txtFiter.SelectedText = "";
            this.txtFiter.ShadowDecoration.Parent = this.txtFiter;
            this.txtFiter.Size = new System.Drawing.Size(203, 34);
            this.txtFiter.TabIndex = 7;
            this.txtFiter.TextChanged += new System.EventHandler(this.txtFiter_TextChanged);
            this.txtFiter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiter_KeyPress);
            // 
            // cbForAll
            // 
            this.cbForAll.BackColor = System.Drawing.Color.Transparent;
            this.cbForAll.BorderRadius = 11;
            this.cbForAll.BorderThickness = 2;
            this.cbForAll.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbForAll.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbForAll.FillColor = System.Drawing.Color.Teal;
            this.cbForAll.FocusedColor = System.Drawing.Color.Empty;
            this.cbForAll.FocusedState.Parent = this.cbForAll;
            this.cbForAll.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbForAll.ForeColor = System.Drawing.Color.Black;
            this.cbForAll.FormattingEnabled = true;
            this.cbForAll.HoverState.Parent = this.cbForAll;
            this.cbForAll.ItemHeight = 28;
            this.cbForAll.Items.AddRange(new object[] {
            "None"});
            this.cbForAll.ItemsAppearance.Parent = this.cbForAll;
            this.cbForAll.Location = new System.Drawing.Point(381, 231);
            this.cbForAll.Name = "cbForAll";
            this.cbForAll.ShadowDecoration.Parent = this.cbForAll;
            this.cbForAll.Size = new System.Drawing.Size(203, 34);
            this.cbForAll.StartIndex = 0;
            this.cbForAll.TabIndex = 8;
            this.cbForAll.SelectedIndexChanged += new System.EventHandler(this.cbForAll_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Library_Manegment_System.Properties.Resources.undraw_books_wxzz;
            this.pictureBox1.Location = new System.Drawing.Point(657, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(249, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // frmBooksManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1531, 781);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbForAll);
            this.Controls.Add(this.txtFiter);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.lblR);
            this.Controls.Add(this.cbFiterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddBooks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvShowBooks);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmBooksManagment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Books";
            this.Load += new System.EventHandler(this.frmListBooks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowBooks)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShowBooks;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnAddBooks;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cbFiterBy;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblRecordsCount;
        private Guna.UI2.WinForms.Guna2TextBox txtFiter;
        private Guna.UI2.WinForms.Guna2ComboBox cbForAll;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusCopiesBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loanBookToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}