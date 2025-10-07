namespace Library_Manegment_System
{
    partial class frmBookCopiesManagment
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListBookCopies = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtFiter = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbFiterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.btnAddBookCopy = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListBookCopies)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(169, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(507, 50);
            this.label1.TabIndex = 3;
            this.label1.Text = "Book Copies Managment";
            // 
            // dgvListBookCopies
            // 
            this.dgvListBookCopies.AllowUserToAddRows = false;
            this.dgvListBookCopies.AllowUserToDeleteRows = false;
            this.dgvListBookCopies.AllowUserToOrderColumns = true;
            this.dgvListBookCopies.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListBookCopies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListBookCopies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListBookCopies.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvListBookCopies.Location = new System.Drawing.Point(12, 301);
            this.dgvListBookCopies.Name = "dgvListBookCopies";
            this.dgvListBookCopies.ReadOnly = true;
            this.dgvListBookCopies.RowHeadersWidth = 51;
            this.dgvListBookCopies.RowTemplate.Height = 26;
            this.dgvListBookCopies.Size = new System.Drawing.Size(845, 377);
            this.dgvListBookCopies.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(110, 32);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(109, 28);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // cbStatus
            // 
            this.cbStatus.BackColor = System.Drawing.Color.Transparent;
            this.cbStatus.BorderRadius = 11;
            this.cbStatus.BorderThickness = 2;
            this.cbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FillColor = System.Drawing.Color.Teal;
            this.cbStatus.FocusedColor = System.Drawing.Color.Empty;
            this.cbStatus.FocusedState.Parent = this.cbStatus;
            this.cbStatus.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.ForeColor = System.Drawing.Color.Black;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.HoverState.Parent = this.cbStatus;
            this.cbStatus.ItemHeight = 30;
            this.cbStatus.Items.AddRange(new object[] {
            "All",
            "Available",
            "Damaged",
            "Lost",
            "Borrowed",
            "Sold"});
            this.cbStatus.ItemsAppearance.Parent = this.cbStatus;
            this.cbStatus.Location = new System.Drawing.Point(349, 247);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.ShadowDecoration.Parent = this.cbStatus;
            this.cbStatus.Size = new System.Drawing.Size(190, 36);
            this.cbStatus.StartIndex = 0;
            this.cbStatus.TabIndex = 19;
            this.cbStatus.Visible = false;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
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
            this.txtFiter.Location = new System.Drawing.Point(349, 247);
            this.txtFiter.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtFiter.Name = "txtFiter";
            this.txtFiter.PasswordChar = '\0';
            this.txtFiter.PlaceholderText = "";
            this.txtFiter.SelectedText = "";
            this.txtFiter.ShadowDecoration.Parent = this.txtFiter;
            this.txtFiter.Size = new System.Drawing.Size(190, 36);
            this.txtFiter.TabIndex = 18;
            this.txtFiter.TextChanged += new System.EventHandler(this.txtFiter_TextChanged);
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
            "Copy ID",
            "Copy Status"});
            this.cbFiterBy.ItemsAppearance.Parent = this.cbFiterBy;
            this.cbFiterBy.Location = new System.Drawing.Point(129, 247);
            this.cbFiterBy.Name = "cbFiterBy";
            this.cbFiterBy.ShadowDecoration.Parent = this.cbFiterBy;
            this.cbFiterBy.Size = new System.Drawing.Size(175, 36);
            this.cbFiterBy.TabIndex = 17;
            this.cbFiterBy.SelectedIndexChanged += new System.EventHandler(this.cbFiterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 28);
            this.label2.TabIndex = 16;
            this.label2.Text = "Filter by :";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(174, 695);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(34, 24);
            this.lblRecordsCount.TabIndex = 22;
            this.lblRecordsCount.Text = "???";
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblR.Location = new System.Drawing.Point(64, 695);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(104, 24);
            this.lblR.TabIndex = 21;
            this.lblR.Text = "# Records :";
            // 
            // btnAddBookCopy
            // 
            this.btnAddBookCopy.BorderRadius = 6;
            this.btnAddBookCopy.BorderThickness = 2;
            this.btnAddBookCopy.CheckedState.Parent = this.btnAddBookCopy;
            this.btnAddBookCopy.CustomImages.Parent = this.btnAddBookCopy;
            this.btnAddBookCopy.FillColor = System.Drawing.Color.Teal;
            this.btnAddBookCopy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBookCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddBookCopy.HoverState.Parent = this.btnAddBookCopy;
            this.btnAddBookCopy.Location = new System.Drawing.Point(684, 236);
            this.btnAddBookCopy.Name = "btnAddBookCopy";
            this.btnAddBookCopy.ShadowDecoration.Parent = this.btnAddBookCopy;
            this.btnAddBookCopy.Size = new System.Drawing.Size(167, 47);
            this.btnAddBookCopy.TabIndex = 23;
            this.btnAddBookCopy.Text = "Add Copy";
            this.btnAddBookCopy.Click += new System.EventHandler(this.btnAddBookCopy_Click);
            // 
            // frmBookCopiesManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 744);
            this.Controls.Add(this.btnAddBookCopy);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.lblR);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.txtFiter);
            this.Controls.Add(this.cbFiterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvListBookCopies);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmBookCopiesManagment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BookCopies Managment";
            this.Load += new System.EventHandler(this.frmBookCopiesManagment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListBookCopies)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListBookCopies;
        private Guna.UI2.WinForms.Guna2ComboBox cbStatus;
        private Guna.UI2.WinForms.Guna2TextBox txtFiter;
        private Guna.UI2.WinForms.Guna2ComboBox cbFiterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label lblR;
        private Guna.UI2.WinForms.Guna2Button btnAddBookCopy;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    }
}