namespace Library_Manegment_System
{
    partial class frmReservationsManagments
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
            this.cbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtFiter = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbFiterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvListReservations = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListReservations)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            "Reserved",
            "Conver To Borrowing",
            "Cancelled"});
            this.cbStatus.ItemsAppearance.Parent = this.cbStatus;
            this.cbStatus.Location = new System.Drawing.Point(411, 291);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.ShadowDecoration.Parent = this.cbStatus;
            this.cbStatus.Size = new System.Drawing.Size(229, 36);
            this.cbStatus.StartIndex = 0;
            this.cbStatus.TabIndex = 35;
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
            this.txtFiter.Location = new System.Drawing.Point(411, 291);
            this.txtFiter.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtFiter.Name = "txtFiter";
            this.txtFiter.PasswordChar = '\0';
            this.txtFiter.PlaceholderText = "";
            this.txtFiter.SelectedText = "";
            this.txtFiter.ShadowDecoration.Parent = this.txtFiter;
            this.txtFiter.Size = new System.Drawing.Size(229, 36);
            this.txtFiter.TabIndex = 34;
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
            "Reservation ID",
            "Reservations Status",
            "Book ID",
            "User Name",
            "MemberID",
            "Library Card Number"});
            this.cbFiterBy.ItemsAppearance.Parent = this.cbFiterBy;
            this.cbFiterBy.Location = new System.Drawing.Point(129, 291);
            this.cbFiterBy.Name = "cbFiterBy";
            this.cbFiterBy.ShadowDecoration.Parent = this.cbFiterBy;
            this.cbFiterBy.Size = new System.Drawing.Size(227, 36);
            this.cbFiterBy.TabIndex = 33;
            this.cbFiterBy.SelectedIndexChanged += new System.EventHandler(this.cbFiterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 28);
            this.label2.TabIndex = 32;
            this.label2.Text = "Filter by :";
            // 
            // dgvListReservations
            // 
            this.dgvListReservations.AllowUserToAddRows = false;
            this.dgvListReservations.AllowUserToDeleteRows = false;
            this.dgvListReservations.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListReservations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListReservations.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvListReservations.Location = new System.Drawing.Point(8, 366);
            this.dgvListReservations.Name = "dgvListReservations";
            this.dgvListReservations.ReadOnly = true;
            this.dgvListReservations.RowHeadersWidth = 51;
            this.dgvListReservations.RowTemplate.Height = 26;
            this.dgvListReservations.Size = new System.Drawing.Size(1764, 463);
            this.dgvListReservations.TabIndex = 31;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editeToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.reservationDetailsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(225, 88);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // editeToolStripMenuItem
            // 
            this.editeToolStripMenuItem.Name = "editeToolStripMenuItem";
            this.editeToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.editeToolStripMenuItem.Text = "Edite ";
            this.editeToolStripMenuItem.Click += new System.EventHandler(this.editeToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // reservationDetailsToolStripMenuItem
            // 
            this.reservationDetailsToolStripMenuItem.Name = "reservationDetailsToolStripMenuItem";
            this.reservationDetailsToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.reservationDetailsToolStripMenuItem.Text = "Reservation Details";
            this.reservationDetailsToolStripMenuItem.Click += new System.EventHandler(this.reservationDetailsToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(563, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(854, 85);
            this.label1.TabIndex = 30;
            this.label1.Text = "Reservations Managment";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(126, 850);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(34, 24);
            this.lblRecordsCount.TabIndex = 37;
            this.lblRecordsCount.Text = "???";
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblR.Location = new System.Drawing.Point(20, 850);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(104, 24);
            this.lblR.TabIndex = 36;
            this.lblR.Text = "# Records :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Library_Manegment_System.Properties.Resources.undraw_Add_tasks_re_s5yj__3_;
            this.pictureBox1.Location = new System.Drawing.Point(790, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(412, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // frmReservationsManagments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1780, 883);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.lblR);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.txtFiter);
            this.Controls.Add(this.cbFiterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvListReservations);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmReservationsManagments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Reservations";
            this.Load += new System.EventHandler(this.frmReservationsManagments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListReservations)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cbStatus;
        private Guna.UI2.WinForms.Guna2TextBox txtFiter;
        private Guna.UI2.WinForms.Guna2ComboBox cbFiterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvListReservations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editeToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservationDetailsToolStripMenuItem;
    }
}