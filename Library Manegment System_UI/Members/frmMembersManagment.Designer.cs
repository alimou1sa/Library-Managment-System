namespace Library_Manegment_System
{
    partial class frmMembersManagment
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
            this.dgvListMembers = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memberDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrowBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memberSubscriptionDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showListSubscriptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewSubscriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbIsActive = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtFiter = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbFiterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.cbSubscriptionStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAddMember = new Guna.UI2.WinForms.Guna2Button();
            this.btnPeopleManagment = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMembers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(562, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(743, 85);
            this.label1.TabIndex = 2;
            this.label1.Text = "Members Managment";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvListMembers
            // 
            this.dgvListMembers.AllowUserToAddRows = false;
            this.dgvListMembers.AllowUserToDeleteRows = false;
            this.dgvListMembers.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListMembers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListMembers.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvListMembers.Location = new System.Drawing.Point(13, 347);
            this.dgvListMembers.Name = "dgvListMembers";
            this.dgvListMembers.ReadOnly = true;
            this.dgvListMembers.RowHeadersWidth = 51;
            this.dgvListMembers.RowTemplate.Height = 26;
            this.dgvListMembers.Size = new System.Drawing.Size(1764, 483);
            this.dgvListMembers.TabIndex = 3;
            this.dgvListMembers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.memberDetailsToolStripMenuItem,
            this.deleteMemberToolStripMenuItem,
            this.borrowBookToolStripMenuItem,
            this.memberSubscriptionDetailsToolStripMenuItem,
            this.showListSubscriptionsToolStripMenuItem,
            this.renewSubscriptionToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(330, 214);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(329, 30);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // memberDetailsToolStripMenuItem
            // 
            this.memberDetailsToolStripMenuItem.Name = "memberDetailsToolStripMenuItem";
            this.memberDetailsToolStripMenuItem.Size = new System.Drawing.Size(329, 30);
            this.memberDetailsToolStripMenuItem.Text = "Member Details ";
            this.memberDetailsToolStripMenuItem.Click += new System.EventHandler(this.memberDetailsToolStripMenuItem_Click);
            // 
            // deleteMemberToolStripMenuItem
            // 
            this.deleteMemberToolStripMenuItem.Name = "deleteMemberToolStripMenuItem";
            this.deleteMemberToolStripMenuItem.Size = new System.Drawing.Size(329, 30);
            this.deleteMemberToolStripMenuItem.Text = "Delete MemberID";
            this.deleteMemberToolStripMenuItem.Click += new System.EventHandler(this.deleteMemberToolStripMenuItem_Click);
            // 
            // borrowBookToolStripMenuItem
            // 
            this.borrowBookToolStripMenuItem.Name = "borrowBookToolStripMenuItem";
            this.borrowBookToolStripMenuItem.Size = new System.Drawing.Size(329, 30);
            this.borrowBookToolStripMenuItem.Text = "Borrow Book";
            this.borrowBookToolStripMenuItem.Click += new System.EventHandler(this.borrowBookToolStripMenuItem_Click);
            // 
            // memberSubscriptionDetailsToolStripMenuItem
            // 
            this.memberSubscriptionDetailsToolStripMenuItem.Name = "memberSubscriptionDetailsToolStripMenuItem";
            this.memberSubscriptionDetailsToolStripMenuItem.Size = new System.Drawing.Size(329, 30);
            this.memberSubscriptionDetailsToolStripMenuItem.Text = "Member Subscription Details";
            this.memberSubscriptionDetailsToolStripMenuItem.Click += new System.EventHandler(this.memberSubscriptionDetailsToolStripMenuItem_Click);
            // 
            // showListSubscriptionsToolStripMenuItem
            // 
            this.showListSubscriptionsToolStripMenuItem.Name = "showListSubscriptionsToolStripMenuItem";
            this.showListSubscriptionsToolStripMenuItem.Size = new System.Drawing.Size(329, 30);
            this.showListSubscriptionsToolStripMenuItem.Text = "Show List Subscriptions";
            this.showListSubscriptionsToolStripMenuItem.Click += new System.EventHandler(this.showListSubscriptionsToolStripMenuItem_Click);
            // 
            // renewSubscriptionToolStripMenuItem
            // 
            this.renewSubscriptionToolStripMenuItem.Name = "renewSubscriptionToolStripMenuItem";
            this.renewSubscriptionToolStripMenuItem.Size = new System.Drawing.Size(329, 30);
            this.renewSubscriptionToolStripMenuItem.Text = "Renew Subscription";
            this.renewSubscriptionToolStripMenuItem.Click += new System.EventHandler(this.renewSubscriptionToolStripMenuItem_Click);
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
            this.cbIsActive.Location = new System.Drawing.Point(383, 292);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.ShadowDecoration.Parent = this.cbIsActive;
            this.cbIsActive.Size = new System.Drawing.Size(229, 36);
            this.cbIsActive.StartIndex = 0;
            this.cbIsActive.TabIndex = 12;
            this.cbIsActive.Visible = false;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // txtFiter
            // 
            this.txtFiter.BackColor = System.Drawing.Color.Transparent;
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
            this.txtFiter.Location = new System.Drawing.Point(383, 292);
            this.txtFiter.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtFiter.Name = "txtFiter";
            this.txtFiter.PasswordChar = '\0';
            this.txtFiter.PlaceholderText = "";
            this.txtFiter.SelectedText = "";
            this.txtFiter.ShadowDecoration.Parent = this.txtFiter;
            this.txtFiter.Size = new System.Drawing.Size(229, 36);
            this.txtFiter.TabIndex = 11;
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
            "MemberID",
            "SubscriptionID",
            "NationalNo",
            "Full Name",
            "Subscription Status",
            "Is Active",
            "Library Card Number"});
            this.cbFiterBy.ItemsAppearance.Parent = this.cbFiterBy;
            this.cbFiterBy.Location = new System.Drawing.Point(134, 292);
            this.cbFiterBy.Name = "cbFiterBy";
            this.cbFiterBy.ShadowDecoration.Parent = this.cbFiterBy;
            this.cbFiterBy.Size = new System.Drawing.Size(205, 36);
            this.cbFiterBy.TabIndex = 10;
            this.cbFiterBy.SelectedIndexChanged += new System.EventHandler(this.cbFiterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 28);
            this.label2.TabIndex = 9;
            this.label2.Text = "Filter by :";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(118, 846);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(34, 24);
            this.lblRecordsCount.TabIndex = 14;
            this.lblRecordsCount.Text = "???";
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblR.Location = new System.Drawing.Point(12, 846);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(104, 24);
            this.lblR.TabIndex = 13;
            this.lblR.Text = "# Records :";
            // 
            // cbSubscriptionStatus
            // 
            this.cbSubscriptionStatus.BackColor = System.Drawing.Color.Transparent;
            this.cbSubscriptionStatus.BorderRadius = 11;
            this.cbSubscriptionStatus.BorderThickness = 2;
            this.cbSubscriptionStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSubscriptionStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubscriptionStatus.FillColor = System.Drawing.Color.Teal;
            this.cbSubscriptionStatus.FocusedColor = System.Drawing.Color.Empty;
            this.cbSubscriptionStatus.FocusedState.Parent = this.cbSubscriptionStatus;
            this.cbSubscriptionStatus.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSubscriptionStatus.ForeColor = System.Drawing.Color.Black;
            this.cbSubscriptionStatus.FormattingEnabled = true;
            this.cbSubscriptionStatus.HoverState.Parent = this.cbSubscriptionStatus;
            this.cbSubscriptionStatus.ItemHeight = 30;
            this.cbSubscriptionStatus.Items.AddRange(new object[] {
            "All",
            "Active",
            "Expired",
            "Pending"});
            this.cbSubscriptionStatus.ItemsAppearance.Parent = this.cbSubscriptionStatus;
            this.cbSubscriptionStatus.Location = new System.Drawing.Point(383, 292);
            this.cbSubscriptionStatus.Name = "cbSubscriptionStatus";
            this.cbSubscriptionStatus.ShadowDecoration.Parent = this.cbSubscriptionStatus;
            this.cbSubscriptionStatus.Size = new System.Drawing.Size(229, 36);
            this.cbSubscriptionStatus.StartIndex = 0;
            this.cbSubscriptionStatus.TabIndex = 15;
            this.cbSubscriptionStatus.Visible = false;
            this.cbSubscriptionStatus.SelectedIndexChanged += new System.EventHandler(this.cbGender_SelectedIndexChanged);
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
            this.btnAddMember.Location = new System.Drawing.Point(1590, 281);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.ShadowDecoration.Parent = this.btnAddMember;
            this.btnAddMember.Size = new System.Drawing.Size(163, 47);
            this.btnAddMember.TabIndex = 16;
            this.btnAddMember.Text = "Add MemberID";
            this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
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
            this.btnPeopleManagment.Location = new System.Drawing.Point(1384, 281);
            this.btnPeopleManagment.Name = "btnPeopleManagment";
            this.btnPeopleManagment.ShadowDecoration.Parent = this.btnPeopleManagment;
            this.btnPeopleManagment.Size = new System.Drawing.Size(177, 47);
            this.btnPeopleManagment.TabIndex = 18;
            this.btnPeopleManagment.Text = "People Managment";
            this.btnPeopleManagment.Click += new System.EventHandler(this.btnPeopleManagment_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Library_Manegment_System.Properties.Resources.icons8_members_100;
            this.pictureBox1.Location = new System.Drawing.Point(796, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 183);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // frmMembersManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1776, 879);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnPeopleManagment);
            this.Controls.Add(this.btnAddMember);
            this.Controls.Add(this.cbSubscriptionStatus);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.lblR);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.txtFiter);
            this.Controls.Add(this.cbFiterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvListMembers);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMembersManagment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Members Managment";
            this.Load += new System.EventHandler(this.frmMembersManagment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMembers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListMembers;
        private Guna.UI2.WinForms.Guna2ComboBox cbIsActive;
        private Guna.UI2.WinForms.Guna2TextBox txtFiter;
        private Guna.UI2.WinForms.Guna2ComboBox cbFiterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label lblR;
        private Guna.UI2.WinForms.Guna2ComboBox cbSubscriptionStatus;
        private Guna.UI2.WinForms.Guna2Button btnAddMember;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem memberDetailsToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2Button btnPeopleManagment;
        private System.Windows.Forms.ToolStripMenuItem deleteMemberToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem borrowBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem memberSubscriptionDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showListSubscriptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewSubscriptionToolStripMenuItem;
    }
}