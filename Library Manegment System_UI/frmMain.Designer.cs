namespace Library_Manegment_System
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBookCopiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.membersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listMembersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listMemberSubscriptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersManagmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loanBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listLosnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resevationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listReservationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listPurchasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listPaymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crrentUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblJobtitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTimeNow = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.findBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.menuStrip1.Font = new System.Drawing.Font("Lucida Console", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem,
            this.membersToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.loanBooksToolStripMenuItem,
            this.resevationsToolStripMenuItem,
            this.purchasesToolStripMenuItem,
            this.paymentsToolStripMenuItem,
            this.settToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1831, 45);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listBooksToolStripMenuItem,
            this.listBookCopiesToolStripMenuItem,
            this.findBookToolStripMenuItem});
            this.xToolStripMenuItem.Font = new System.Drawing.Font("Lucida Bright", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xToolStripMenuItem.Image = global::Library_Manegment_System.Properties.Resources.icons8_books_50__1_;
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(160, 41);
            this.xToolStripMenuItem.Text = "Books";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
            // 
            // listBooksToolStripMenuItem
            // 
            this.listBooksToolStripMenuItem.Font = new System.Drawing.Font("Lucida Calligraphy", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBooksToolStripMenuItem.Name = "listBooksToolStripMenuItem";
            this.listBooksToolStripMenuItem.Size = new System.Drawing.Size(279, 34);
            this.listBooksToolStripMenuItem.Text = "List Books";
            this.listBooksToolStripMenuItem.Click += new System.EventHandler(this.listBooksToolStripMenuItem_Click);
            // 
            // listBookCopiesToolStripMenuItem
            // 
            this.listBookCopiesToolStripMenuItem.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBookCopiesToolStripMenuItem.Name = "listBookCopiesToolStripMenuItem";
            this.listBookCopiesToolStripMenuItem.Size = new System.Drawing.Size(279, 34);
            this.listBookCopiesToolStripMenuItem.Text = "Add New Book";
            this.listBookCopiesToolStripMenuItem.Click += new System.EventHandler(this.listBookCopiesToolStripMenuItem_Click);
            // 
            // membersToolStripMenuItem
            // 
            this.membersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listMembersToolStripMenuItem,
            this.addNewMemberToolStripMenuItem,
            this.listMemberSubscriptionsToolStripMenuItem});
            this.membersToolStripMenuItem.Font = new System.Drawing.Font("Lucida Bright", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.membersToolStripMenuItem.Image = global::Library_Manegment_System.Properties.Resources.icons8_members_64;
            this.membersToolStripMenuItem.Name = "membersToolStripMenuItem";
            this.membersToolStripMenuItem.Size = new System.Drawing.Size(209, 41);
            this.membersToolStripMenuItem.Text = "Members";
            // 
            // listMembersToolStripMenuItem
            // 
            this.listMembersToolStripMenuItem.Font = new System.Drawing.Font("Lucida Calligraphy", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMembersToolStripMenuItem.Name = "listMembersToolStripMenuItem";
            this.listMembersToolStripMenuItem.Size = new System.Drawing.Size(411, 34);
            this.listMembersToolStripMenuItem.Text = "List Members";
            this.listMembersToolStripMenuItem.Click += new System.EventHandler(this.listMembersToolStripMenuItem_Click);
            // 
            // addNewMemberToolStripMenuItem
            // 
            this.addNewMemberToolStripMenuItem.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewMemberToolStripMenuItem.Name = "addNewMemberToolStripMenuItem";
            this.addNewMemberToolStripMenuItem.Size = new System.Drawing.Size(411, 34);
            this.addNewMemberToolStripMenuItem.Text = "Add New Member";
            this.addNewMemberToolStripMenuItem.Click += new System.EventHandler(this.addNewMemberToolStripMenuItem_Click);
            // 
            // listMemberSubscriptionsToolStripMenuItem
            // 
            this.listMemberSubscriptionsToolStripMenuItem.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMemberSubscriptionsToolStripMenuItem.Name = "listMemberSubscriptionsToolStripMenuItem";
            this.listMemberSubscriptionsToolStripMenuItem.Size = new System.Drawing.Size(411, 34);
            this.listMemberSubscriptionsToolStripMenuItem.Text = "List Member Subscriptions";
            this.listMemberSubscriptionsToolStripMenuItem.Click += new System.EventHandler(this.listMemberSubscriptionsToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersManagmentToolStripMenuItem});
            this.usersToolStripMenuItem.Image = global::Library_Manegment_System.Properties.Resources.icons8_users_50;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(159, 41);
            this.usersToolStripMenuItem.Text = "Users";
            // 
            // usersManagmentToolStripMenuItem
            // 
            this.usersManagmentToolStripMenuItem.Font = new System.Drawing.Font("Lucida Calligraphy", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersManagmentToolStripMenuItem.Name = "usersManagmentToolStripMenuItem";
            this.usersManagmentToolStripMenuItem.Size = new System.Drawing.Size(231, 34);
            this.usersManagmentToolStripMenuItem.Text = "List Users";
            this.usersManagmentToolStripMenuItem.Click += new System.EventHandler(this.usersManagmentToolStripMenuItem_Click);
            // 
            // loanBooksToolStripMenuItem
            // 
            this.loanBooksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listLosnToolStripMenuItem});
            this.loanBooksToolStripMenuItem.Image = global::Library_Manegment_System.Properties.Resources.icons8_book_shelf_1001;
            this.loanBooksToolStripMenuItem.Name = "loanBooksToolStripMenuItem";
            this.loanBooksToolStripMenuItem.Size = new System.Drawing.Size(159, 41);
            this.loanBooksToolStripMenuItem.Text = "Loans";
            // 
            // listLosnToolStripMenuItem
            // 
            this.listLosnToolStripMenuItem.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listLosnToolStripMenuItem.Name = "listLosnToolStripMenuItem";
            this.listLosnToolStripMenuItem.Size = new System.Drawing.Size(204, 32);
            this.listLosnToolStripMenuItem.Text = "List Losn";
            this.listLosnToolStripMenuItem.Click += new System.EventHandler(this.listLosnToolStripMenuItem_Click);
            // 
            // resevationsToolStripMenuItem
            // 
            this.resevationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listReservationsToolStripMenuItem});
            this.resevationsToolStripMenuItem.Image = global::Library_Manegment_System.Properties.Resources.list;
            this.resevationsToolStripMenuItem.Name = "resevationsToolStripMenuItem";
            this.resevationsToolStripMenuItem.Size = new System.Drawing.Size(299, 41);
            this.resevationsToolStripMenuItem.Text = "Reservations";
            // 
            // listReservationsToolStripMenuItem
            // 
            this.listReservationsToolStripMenuItem.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listReservationsToolStripMenuItem.Name = "listReservationsToolStripMenuItem";
            this.listReservationsToolStripMenuItem.Size = new System.Drawing.Size(303, 32);
            this.listReservationsToolStripMenuItem.Text = "List Reservations";
            this.listReservationsToolStripMenuItem.Click += new System.EventHandler(this.listReservationsToolStripMenuItem_Click);
            // 
            // purchasesToolStripMenuItem
            // 
            this.purchasesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listPurchasesToolStripMenuItem});
            this.purchasesToolStripMenuItem.Image = global::Library_Manegment_System.Properties.Resources.icons8_book_shelf_1002;
            this.purchasesToolStripMenuItem.Name = "purchasesToolStripMenuItem";
            this.purchasesToolStripMenuItem.Size = new System.Drawing.Size(239, 41);
            this.purchasesToolStripMenuItem.Text = "Purchases";
            // 
            // listPurchasesToolStripMenuItem
            // 
            this.listPurchasesToolStripMenuItem.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPurchasesToolStripMenuItem.Name = "listPurchasesToolStripMenuItem";
            this.listPurchasesToolStripMenuItem.Size = new System.Drawing.Size(267, 32);
            this.listPurchasesToolStripMenuItem.Text = "List Purchases";
            this.listPurchasesToolStripMenuItem.Click += new System.EventHandler(this.listPurchasesToolStripMenuItem_Click);
            // 
            // paymentsToolStripMenuItem
            // 
            this.paymentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listPaymentsToolStripMenuItem});
            this.paymentsToolStripMenuItem.Image = global::Library_Manegment_System.Properties.Resources.Release_Detained_License_512;
            this.paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
            this.paymentsToolStripMenuItem.Size = new System.Drawing.Size(219, 41);
            this.paymentsToolStripMenuItem.Text = "Payments";
            // 
            // listPaymentsToolStripMenuItem
            // 
            this.listPaymentsToolStripMenuItem.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPaymentsToolStripMenuItem.Name = "listPaymentsToolStripMenuItem";
            this.listPaymentsToolStripMenuItem.Size = new System.Drawing.Size(265, 32);
            this.listPaymentsToolStripMenuItem.Text = "List Payments";
            this.listPaymentsToolStripMenuItem.Click += new System.EventHandler(this.listPaymentsToolStripMenuItem_Click);
            // 
            // settToolStripMenuItem
            // 
            this.settToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crrentUserInfoToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.singOutToolStripMenuItem,
            this.settingToolStripMenuItem});
            this.settToolStripMenuItem.Image = global::Library_Manegment_System.Properties.Resources.account_settings_64;
            this.settToolStripMenuItem.Name = "settToolStripMenuItem";
            this.settToolStripMenuItem.Size = new System.Drawing.Size(359, 41);
            this.settToolStripMenuItem.Text = "Account&Settings";
            // 
            // crrentUserInfoToolStripMenuItem
            // 
            this.crrentUserInfoToolStripMenuItem.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crrentUserInfoToolStripMenuItem.Image = global::Library_Manegment_System.Properties.Resources.user;
            this.crrentUserInfoToolStripMenuItem.Name = "crrentUserInfoToolStripMenuItem";
            this.crrentUserInfoToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.crrentUserInfoToolStripMenuItem.Text = "Crrent User Info";
            this.crrentUserInfoToolStripMenuItem.Click += new System.EventHandler(this.crrentUserInfoToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changePasswordToolStripMenuItem.Image = global::Library_Manegment_System.Properties.Resources.reset_password;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // singOutToolStripMenuItem
            // 
            this.singOutToolStripMenuItem.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singOutToolStripMenuItem.Image = global::Library_Manegment_System.Properties.Resources.icons8_logout;
            this.singOutToolStripMenuItem.Name = "singOutToolStripMenuItem";
            this.singOutToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.singOutToolStripMenuItem.Text = "SingOut";
            this.singOutToolStripMenuItem.Click += new System.EventHandler(this.singOutToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingToolStripMenuItem.Image = global::Library_Manegment_System.Properties.Resources.undraw_settings_2quf;
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(14, 41);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(14, 41);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(14, 41);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Library_Manegment_System.Properties.Resources.photo_1519682337058_a94d519337bc;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lblJobtitle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTimeNow);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1831, 1006);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblJobtitle
            // 
            this.lblJobtitle.AutoSize = true;
            this.lblJobtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblJobtitle.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobtitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblJobtitle.Location = new System.Drawing.Point(1422, 690);
            this.lblJobtitle.Name = "lblJobtitle";
            this.lblJobtitle.Size = new System.Drawing.Size(152, 40);
            this.lblJobtitle.TabIndex = 6;
            this.lblJobtitle.Text = "User Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(1402, 690);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 40);
            this.label2.TabIndex = 5;
            this.label2.Text = "/";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(1210, 586);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 40);
            this.label4.TabIndex = 4;
            this.label4.Text = "Dev By Ali Mousa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(1199, 688);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name:";
            // 
            // lblTimeNow
            // 
            this.lblTimeNow.AutoSize = true;
            this.lblTimeNow.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeNow.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeNow.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTimeNow.Location = new System.Drawing.Point(1328, 642);
            this.lblTimeNow.Name = "lblTimeNow";
            this.lblTimeNow.Size = new System.Drawing.Size(152, 40);
            this.lblTimeNow.TabIndex = 3;
            this.lblTimeNow.Text = "User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(1199, 642);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 40);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date Now:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblUserName.Location = new System.Drawing.Point(1337, 688);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(152, 40);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "User Name:";
            // 
            // findBookToolStripMenuItem
            // 
            this.findBookToolStripMenuItem.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findBookToolStripMenuItem.Name = "findBookToolStripMenuItem";
            this.findBookToolStripMenuItem.Size = new System.Drawing.Size(279, 34);
            this.findBookToolStripMenuItem.Text = "Find Book";
            this.findBookToolStripMenuItem.Click += new System.EventHandler(this.findBookToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1831, 1051);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Managment System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem listBooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem membersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listMembersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersManagmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listBookCopiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loanBooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listLosnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resevationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listReservationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listPurchasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listPaymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settToolStripMenuItem;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTimeNow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem crrentUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewMemberToolStripMenuItem;
        private System.Windows.Forms.Label lblJobtitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem listMemberSubscriptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem findBookToolStripMenuItem;
    }
}