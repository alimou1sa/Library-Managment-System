namespace Library_Manegment_System
{
    partial class frmMemberSubscribtionManagment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbIsActive = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtFiter = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbFiterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvListSubscriptions = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.cbSubscriptionStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAddMember = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListSubscriptions)).BeginInit();
            this.SuspendLayout();
            // 
            // cbIsActive
            // 
            this.cbIsActive.BackColor = System.Drawing.Color.Transparent;
            this.cbIsActive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cbIsActive.Location = new System.Drawing.Point(403, 230);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.ShadowDecoration.Parent = this.cbIsActive;
            this.cbIsActive.Size = new System.Drawing.Size(229, 36);
            this.cbIsActive.StartIndex = 0;
            this.cbIsActive.TabIndex = 35;
            this.cbIsActive.Visible = false;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // txtFiter
            // 
            this.txtFiter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFiter.DefaultText = "";
            this.txtFiter.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFiter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFiter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFiter.DisabledState.Parent = this.txtFiter;
            this.txtFiter.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFiter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFiter.FocusedState.Parent = this.txtFiter;
            this.txtFiter.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiter.ForeColor = System.Drawing.Color.Black;
            this.txtFiter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFiter.HoverState.Parent = this.txtFiter;
            this.txtFiter.Location = new System.Drawing.Point(378, 284);
            this.txtFiter.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtFiter.Name = "txtFiter";
            this.txtFiter.PasswordChar = '\0';
            this.txtFiter.PlaceholderText = "";
            this.txtFiter.SelectedText = "";
            this.txtFiter.ShadowDecoration.Parent = this.txtFiter;
            this.txtFiter.Size = new System.Drawing.Size(229, 36);
            this.txtFiter.TabIndex = 34;
            this.txtFiter.TextChanged += new System.EventHandler(this.txtFiter_TextChanged);
            // 
            // cbFiterBy
            // 
            this.cbFiterBy.BackColor = System.Drawing.Color.Transparent;
            this.cbFiterBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFiterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiterBy.FocusedColor = System.Drawing.Color.Empty;
            this.cbFiterBy.FocusedState.Parent = this.cbFiterBy;
            this.cbFiterBy.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFiterBy.ForeColor = System.Drawing.Color.Black;
            this.cbFiterBy.FormattingEnabled = true;
            this.cbFiterBy.HoverState.Parent = this.cbFiterBy;
            this.cbFiterBy.ItemHeight = 30;
            this.cbFiterBy.Items.AddRange(new object[] {
            "None",
            "SubscriptionID",
            "MemberID",
            "Is Active",
            "Subscription Status",
            "Plan Name"});
            this.cbFiterBy.ItemsAppearance.Parent = this.cbFiterBy;
            this.cbFiterBy.Location = new System.Drawing.Point(129, 284);
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
            this.label2.Location = new System.Drawing.Point(19, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 28);
            this.label2.TabIndex = 32;
            this.label2.Text = "Filter by :";
            // 
            // dgvListSubscriptions
            // 
            this.dgvListSubscriptions.AllowUserToAddRows = false;
            this.dgvListSubscriptions.AllowUserToDeleteRows = false;
            this.dgvListSubscriptions.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListSubscriptions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListSubscriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListSubscriptions.Location = new System.Drawing.Point(8, 359);
            this.dgvListSubscriptions.Name = "dgvListSubscriptions";
            this.dgvListSubscriptions.ReadOnly = true;
            this.dgvListSubscriptions.RowHeadersWidth = 51;
            this.dgvListSubscriptions.RowTemplate.Height = 26;
            this.dgvListSubscriptions.Size = new System.Drawing.Size(1764, 463);
            this.dgvListSubscriptions.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(638, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(845, 85);
            this.label1.TabIndex = 30;
            this.label1.Text = "Subscription Managment";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(122, 841);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(34, 24);
            this.lblRecordsCount.TabIndex = 37;
            this.lblRecordsCount.Text = "???";
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblR.Location = new System.Drawing.Point(16, 841);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(104, 24);
            this.lblR.TabIndex = 36;
            this.lblR.Text = "# Records :";
            // 
            // cbSubscriptionStatus
            // 
            this.cbSubscriptionStatus.BackColor = System.Drawing.Color.Transparent;
            this.cbSubscriptionStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSubscriptionStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubscriptionStatus.FocusedColor = System.Drawing.Color.Empty;
            this.cbSubscriptionStatus.FocusedState.Parent = this.cbSubscriptionStatus;
            this.cbSubscriptionStatus.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSubscriptionStatus.ForeColor = System.Drawing.Color.Black;
            this.cbSubscriptionStatus.FormattingEnabled = true;
            this.cbSubscriptionStatus.HoverState.Parent = this.cbSubscriptionStatus;
            this.cbSubscriptionStatus.ItemHeight = 30;
            this.cbSubscriptionStatus.Items.AddRange(new object[] {
            "All",
            "New",
            "ReNew",
            "Cancel"});
            this.cbSubscriptionStatus.ItemsAppearance.Parent = this.cbSubscriptionStatus;
            this.cbSubscriptionStatus.Location = new System.Drawing.Point(470, 284);
            this.cbSubscriptionStatus.Name = "cbSubscriptionStatus";
            this.cbSubscriptionStatus.ShadowDecoration.Parent = this.cbSubscriptionStatus;
            this.cbSubscriptionStatus.Size = new System.Drawing.Size(229, 36);
            this.cbSubscriptionStatus.StartIndex = 0;
            this.cbSubscriptionStatus.TabIndex = 38;
            this.cbSubscriptionStatus.Visible = false;
            this.cbSubscriptionStatus.SelectedIndexChanged += new System.EventHandler(this.cbSubscriptionStatus_SelectedIndexChanged);
            // 
            // btnAddMember
            // 
            this.btnAddMember.BorderRadius = 7;
            this.btnAddMember.BorderThickness = 2;
            this.btnAddMember.CheckedState.Parent = this.btnAddMember;
            this.btnAddMember.CustomImages.Parent = this.btnAddMember;
            this.btnAddMember.FillColor = System.Drawing.Color.Teal;
            this.btnAddMember.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddMember.HoverState.Parent = this.btnAddMember;
            this.btnAddMember.Location = new System.Drawing.Point(1538, 292);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.ShadowDecoration.Parent = this.btnAddMember;
            this.btnAddMember.Size = new System.Drawing.Size(191, 47);
            this.btnAddMember.TabIndex = 39;
            this.btnAddMember.Text = "Add Subscription";
            this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
            // 
            // frmMemberSubscribtionManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1780, 883);
            this.Controls.Add(this.btnAddMember);
            this.Controls.Add(this.cbSubscriptionStatus);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.lblR);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.txtFiter);
            this.Controls.Add(this.cbFiterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvListSubscriptions);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMemberSubscribtionManagment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Member Subscriptionan";
            this.Load += new System.EventHandler(this.frmMemberSubscribtionManagment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListSubscriptions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cbIsActive;
        private Guna.UI2.WinForms.Guna2TextBox txtFiter;
        private Guna.UI2.WinForms.Guna2ComboBox cbFiterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvListSubscriptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label lblR;
        private Guna.UI2.WinForms.Guna2ComboBox cbSubscriptionStatus;
        private Guna.UI2.WinForms.Guna2Button btnAddMember;
    }
}