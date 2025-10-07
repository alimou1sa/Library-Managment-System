namespace Library_Manegment_System
{
    partial class frmLoanBook
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpMemberInfo = new System.Windows.Forms.TabPage();
            this.btnNext1 = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlMemberCardWhithFilter1 = new Library_Manegment_System.ctrlMemberCardWhithFilter();
            this.tpBookInfo = new System.Windows.Forms.TabPage();
            this.btnNext2 = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlBookCardWithFilter1 = new Library_Manegment_System.ctrlBookCardWithFilter();
            this.tpLoanInfo = new System.Windows.Forms.TabPage();
            this.gpPaymentInfo = new System.Windows.Forms.GroupBox();
            this.lblDays = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbPaymentType = new System.Windows.Forms.ComboBox();
            this.lblPaymentStatus = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.lblPaymentID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.lblLoanDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblReturnByUser = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLoanID = new System.Windows.Forms.Label();
            this.lblLoanByUser = new System.Windows.Forms.Label();
            this.lblCopyID = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tpMemberInfo.SuspendLayout();
            this.tpBookInfo.SuspendLayout();
            this.tpLoanInfo.SuspendLayout();
            this.gpPaymentInfo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpMemberInfo);
            this.tabControl1.Controls.Add(this.tpBookInfo);
            this.tabControl1.Controls.Add(this.tpLoanInfo);
            this.tabControl1.Location = new System.Drawing.Point(-1, 111);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(867, 599);
            this.tabControl1.TabIndex = 0;
            // 
            // tpMemberInfo
            // 
            this.tpMemberInfo.Controls.Add(this.btnNext1);
            this.tpMemberInfo.Controls.Add(this.ctrlMemberCardWhithFilter1);
            this.tpMemberInfo.Location = new System.Drawing.Point(4, 25);
            this.tpMemberInfo.Name = "tpMemberInfo";
            this.tpMemberInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpMemberInfo.Size = new System.Drawing.Size(859, 570);
            this.tpMemberInfo.TabIndex = 0;
            this.tpMemberInfo.Text = "MemberInfo";
            this.tpMemberInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext1
            // 
            this.btnNext1.BorderRadius = 11;
            this.btnNext1.BorderThickness = 3;
            this.btnNext1.CheckedState.Parent = this.btnNext1;
            this.btnNext1.CustomImages.Parent = this.btnNext1;
            this.btnNext1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNext1.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext1.ForeColor = System.Drawing.Color.White;
            this.btnNext1.HoverState.Parent = this.btnNext1;
            this.btnNext1.Location = new System.Drawing.Point(690, 507);
            this.btnNext1.Name = "btnNext1";
            this.btnNext1.ShadowDecoration.Parent = this.btnNext1;
            this.btnNext1.Size = new System.Drawing.Size(161, 45);
            this.btnNext1.TabIndex = 8;
            this.btnNext1.Text = "Next";
            this.btnNext1.Click += new System.EventHandler(this.btnNext1_Click);
            // 
            // ctrlMemberCardWhithFilter1
            // 
            this.ctrlMemberCardWhithFilter1.FilterEnabled = true;
            this.ctrlMemberCardWhithFilter1.Location = new System.Drawing.Point(0, 0);
            this.ctrlMemberCardWhithFilter1.Name = "ctrlMemberCardWhithFilter1";
            this.ctrlMemberCardWhithFilter1.ShowAddMember = true;
            this.ctrlMemberCardWhithFilter1.Size = new System.Drawing.Size(859, 498);
            this.ctrlMemberCardWhithFilter1.TabIndex = 0;
            this.ctrlMemberCardWhithFilter1.OnMemberSelected += new System.EventHandler<Library_Manegment_System.ctrlMemberCardWhithFilter.MemberSelectedEventArgs>(this.ctrlMemberCardWhithFilter1_OnMemberSelected);
            // 
            // tpBookInfo
            // 
            this.tpBookInfo.Controls.Add(this.btnNext2);
            this.tpBookInfo.Controls.Add(this.ctrlBookCardWithFilter1);
            this.tpBookInfo.Location = new System.Drawing.Point(4, 25);
            this.tpBookInfo.Name = "tpBookInfo";
            this.tpBookInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpBookInfo.Size = new System.Drawing.Size(859, 570);
            this.tpBookInfo.TabIndex = 1;
            this.tpBookInfo.Text = "BookInfo";
            this.tpBookInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext2
            // 
            this.btnNext2.BorderRadius = 11;
            this.btnNext2.BorderThickness = 3;
            this.btnNext2.CheckedState.Parent = this.btnNext2;
            this.btnNext2.CustomImages.Parent = this.btnNext2;
            this.btnNext2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNext2.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext2.ForeColor = System.Drawing.Color.White;
            this.btnNext2.HoverState.Parent = this.btnNext2;
            this.btnNext2.Location = new System.Drawing.Point(687, 505);
            this.btnNext2.Name = "btnNext2";
            this.btnNext2.ShadowDecoration.Parent = this.btnNext2;
            this.btnNext2.Size = new System.Drawing.Size(161, 45);
            this.btnNext2.TabIndex = 8;
            this.btnNext2.Text = "Next";
            this.btnNext2.Click += new System.EventHandler(this.btnNext2_Click);
            // 
            // ctrlBookCardWithFilter1
            // 
            this.ctrlBookCardWithFilter1.BackColor = System.Drawing.Color.Gainsboro;
            this.ctrlBookCardWithFilter1.FilterEnabled = true;
            this.ctrlBookCardWithFilter1.Location = new System.Drawing.Point(6, 6);
            this.ctrlBookCardWithFilter1.Name = "ctrlBookCardWithFilter1";
            this.ctrlBookCardWithFilter1.ShowAddBook = true;
            this.ctrlBookCardWithFilter1.Size = new System.Drawing.Size(847, 482);
            this.ctrlBookCardWithFilter1.TabIndex = 0;
            // 
            // tpLoanInfo
            // 
            this.tpLoanInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpLoanInfo.Controls.Add(this.gpPaymentInfo);
            this.tpLoanInfo.Controls.Add(this.groupBox2);
            this.tpLoanInfo.Location = new System.Drawing.Point(4, 25);
            this.tpLoanInfo.Name = "tpLoanInfo";
            this.tpLoanInfo.Size = new System.Drawing.Size(859, 570);
            this.tpLoanInfo.TabIndex = 2;
            this.tpLoanInfo.Text = "Loan Info";
            // 
            // gpPaymentInfo
            // 
            this.gpPaymentInfo.BackColor = System.Drawing.Color.Gainsboro;
            this.gpPaymentInfo.Controls.Add(this.lblDays);
            this.gpPaymentInfo.Controls.Add(this.label10);
            this.gpPaymentInfo.Controls.Add(this.cbPaymentType);
            this.gpPaymentInfo.Controls.Add(this.lblPaymentStatus);
            this.gpPaymentInfo.Controls.Add(this.lblAmount);
            this.gpPaymentInfo.Controls.Add(this.lblPaymentDate);
            this.gpPaymentInfo.Controls.Add(this.lblPaymentID);
            this.gpPaymentInfo.Controls.Add(this.label9);
            this.gpPaymentInfo.Controls.Add(this.label11);
            this.gpPaymentInfo.Controls.Add(this.label13);
            this.gpPaymentInfo.Controls.Add(this.label15);
            this.gpPaymentInfo.Controls.Add(this.label16);
            this.gpPaymentInfo.Enabled = false;
            this.gpPaymentInfo.Location = new System.Drawing.Point(9, 314);
            this.gpPaymentInfo.Name = "gpPaymentInfo";
            this.gpPaymentInfo.Size = new System.Drawing.Size(839, 234);
            this.gpPaymentInfo.TabIndex = 17;
            this.gpPaymentInfo.TabStop = false;
            this.gpPaymentInfo.Text = "Payment Info";
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.Location = new System.Drawing.Point(615, 109);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(60, 22);
            this.lblDays.TabIndex = 18;
            this.lblDays.Text = "[????]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(442, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(153, 24);
            this.label10.TabIndex = 17;
            this.label10.Text = "Days of delay:";
            // 
            // cbPaymentType
            // 
            this.cbPaymentType.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPaymentType.FormattingEnabled = true;
            this.cbPaymentType.ItemHeight = 22;
            this.cbPaymentType.Location = new System.Drawing.Point(213, 107);
            this.cbPaymentType.Name = "cbPaymentType";
            this.cbPaymentType.Size = new System.Drawing.Size(196, 30);
            this.cbPaymentType.TabIndex = 16;
            // 
            // lblPaymentStatus
            // 
            this.lblPaymentStatus.AutoSize = true;
            this.lblPaymentStatus.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentStatus.Location = new System.Drawing.Point(631, 195);
            this.lblPaymentStatus.Name = "lblPaymentStatus";
            this.lblPaymentStatus.Size = new System.Drawing.Size(60, 22);
            this.lblPaymentStatus.TabIndex = 13;
            this.lblPaymentStatus.Text = "[????]";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(615, 20);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(60, 22);
            this.lblAmount.TabIndex = 12;
            this.lblAmount.Text = "[????]";
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.AutoSize = true;
            this.lblPaymentDate.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentDate.Location = new System.Drawing.Point(209, 197);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.Size = new System.Drawing.Size(60, 22);
            this.lblPaymentDate.TabIndex = 11;
            this.lblPaymentDate.Text = "[????]";
            // 
            // lblPaymentID
            // 
            this.lblPaymentID.AutoSize = true;
            this.lblPaymentID.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentID.Location = new System.Drawing.Point(209, 20);
            this.lblPaymentID.Name = "lblPaymentID";
            this.lblPaymentID.Size = new System.Drawing.Size(60, 22);
            this.lblPaymentID.TabIndex = 8;
            this.lblPaymentID.Text = "[????]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 196);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 24);
            this.label9.TabIndex = 6;
            this.label9.Text = "Payment Date:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(442, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(176, 24);
            this.label11.TabIndex = 4;
            this.label11.Text = "Payment Status:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(442, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 24);
            this.label13.TabIndex = 3;
            this.label13.Text = "Amount:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(17, 108);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(161, 24);
            this.label15.TabIndex = 1;
            this.label15.Text = "Payment Type:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(17, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(131, 24);
            this.label16.TabIndex = 0;
            this.label16.Text = "PaymentID:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.Controls.Add(this.lblReturnDate);
            this.groupBox2.Controls.Add(this.lblLoanDate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblDueDate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblReturnByUser);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblLoanID);
            this.groupBox2.Controls.Add(this.lblLoanByUser);
            this.groupBox2.Controls.Add(this.lblCopyID);
            this.groupBox2.Location = new System.Drawing.Point(9, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(839, 293);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loan Info";
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.AutoSize = true;
            this.lblReturnDate.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnDate.Location = new System.Drawing.Point(615, 211);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(60, 22);
            this.lblReturnDate.TabIndex = 16;
            this.lblReturnDate.Text = "[????]";
            // 
            // lblLoanDate
            // 
            this.lblLoanDate.AutoSize = true;
            this.lblLoanDate.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoanDate.Location = new System.Drawing.Point(620, 120);
            this.lblLoanDate.Name = "lblLoanDate";
            this.lblLoanDate.Size = new System.Drawing.Size(60, 22);
            this.lblLoanDate.TabIndex = 15;
            this.lblLoanDate.Text = "[????]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "LoanID :";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDueDate.Location = new System.Drawing.Point(620, 39);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(60, 22);
            this.lblDueDate.TabIndex = 14;
            this.lblDueDate.Text = "[????]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(442, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 24);
            this.label7.TabIndex = 8;
            this.label7.Text = "Return Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(442, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Loan Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "CopyID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loan By User :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "Return By User :";
            // 
            // lblReturnByUser
            // 
            this.lblReturnByUser.AutoSize = true;
            this.lblReturnByUser.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnByUser.Location = new System.Drawing.Point(209, 249);
            this.lblReturnByUser.Name = "lblReturnByUser";
            this.lblReturnByUser.Size = new System.Drawing.Size(60, 22);
            this.lblReturnByUser.TabIndex = 9;
            this.lblReturnByUser.Text = "[????]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(442, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Due Date :";
            // 
            // lblLoanID
            // 
            this.lblLoanID.AutoSize = true;
            this.lblLoanID.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoanID.Location = new System.Drawing.Point(211, 41);
            this.lblLoanID.Name = "lblLoanID";
            this.lblLoanID.Size = new System.Drawing.Size(60, 22);
            this.lblLoanID.TabIndex = 6;
            this.lblLoanID.Text = "[????]";
            // 
            // lblLoanByUser
            // 
            this.lblLoanByUser.AutoSize = true;
            this.lblLoanByUser.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoanByUser.Location = new System.Drawing.Point(209, 178);
            this.lblLoanByUser.Name = "lblLoanByUser";
            this.lblLoanByUser.Size = new System.Drawing.Size(60, 22);
            this.lblLoanByUser.TabIndex = 7;
            this.lblLoanByUser.Text = "[????]";
            // 
            // lblCopyID
            // 
            this.lblCopyID.AutoSize = true;
            this.lblCopyID.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyID.Location = new System.Drawing.Point(209, 108);
            this.lblCopyID.Name = "lblCopyID";
            this.lblCopyID.Size = new System.Drawing.Size(60, 22);
            this.lblCopyID.TabIndex = 4;
            this.lblCopyID.Text = "[????]";
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 11;
            this.btnClose.BorderThickness = 3;
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Location = new System.Drawing.Point(479, 721);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(161, 45);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 11;
            this.btnSave.BorderThickness = 3;
            this.btnSave.CheckedState.Parent = this.btnSave;
            this.btnSave.CustomImages.Parent = this.btnSave;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.Parent = this.btnSave;
            this.btnSave.Location = new System.Drawing.Point(690, 721);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.Size = new System.Drawing.Size(161, 45);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Mongolian Baiti", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitel.Location = new System.Drawing.Point(250, 44);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(355, 64);
            this.lblTitel.TabIndex = 12;
            this.lblTitel.Text = "Borrow Book";
            // 
            // frmLoanBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 792);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmLoanBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Borrow Book";
            this.Load += new System.EventHandler(this.frmBorrowBook2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpMemberInfo.ResumeLayout(false);
            this.tpBookInfo.ResumeLayout(false);
            this.tpLoanInfo.ResumeLayout(false);
            this.gpPaymentInfo.ResumeLayout(false);
            this.gpPaymentInfo.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpMemberInfo;
        private System.Windows.Forms.TabPage tpBookInfo;
        private ctrlMemberCardWhithFilter ctrlMemberCardWhithFilter1;
        private ctrlBookCardWithFilter ctrlBookCardWithFilter1;
        private System.Windows.Forms.TabPage tpLoanInfo;
        private Guna.UI2.WinForms.Guna2Button btnNext1;
        private Guna.UI2.WinForms.Guna2Button btnNext2;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.GroupBox gpPaymentInfo;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbPaymentType;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.Label lblPaymentID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblReturnDate;
        private System.Windows.Forms.Label lblLoanDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblReturnByUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLoanID;
        private System.Windows.Forms.Label lblLoanByUser;
        private System.Windows.Forms.Label lblCopyID;
    }
}