namespace Library_Manegment_System
{
    partial class frmAdd_UpdateSubscriptions
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
            this.ctrlMemberCardWhithFilter1 = new Library_Manegment_System.ctrlMemberCardWhithFilter();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.tpSubscriptionInfo = new System.Windows.Forms.TabPage();
            this.gpPaymentInfo = new System.Windows.Forms.GroupBox();
            this.cbPaymentType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblPaymentDetailsID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblPaymentStatus = new System.Windows.Forms.Label();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.lblPaymentID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbSubStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.lblSubscriptionPrice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chbIsSubscribtionActive = new System.Windows.Forms.CheckBox();
            this.cbPlane = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSuscriptionBuUser = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSubscriptionID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTitel = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlPaymentInfo1 = new Library_Manegment_System.ctrlPaymentInfo();
            this.tabControl1.SuspendLayout();
            this.tpMemberInfo.SuspendLayout();
            this.tpSubscriptionInfo.SuspendLayout();
            this.gpPaymentInfo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpMemberInfo);
            this.tabControl1.Controls.Add(this.tpSubscriptionInfo);
            this.tabControl1.Location = new System.Drawing.Point(6, 103);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(888, 583);
            this.tabControl1.TabIndex = 1;
            // 
            // tpMemberInfo
            // 
            this.tpMemberInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpMemberInfo.Controls.Add(this.ctrlMemberCardWhithFilter1);
            this.tpMemberInfo.Controls.Add(this.btnNext);
            this.tpMemberInfo.Location = new System.Drawing.Point(4, 25);
            this.tpMemberInfo.Name = "tpMemberInfo";
            this.tpMemberInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpMemberInfo.Size = new System.Drawing.Size(880, 554);
            this.tpMemberInfo.TabIndex = 0;
            this.tpMemberInfo.Text = "Member Info";
            // 
            // ctrlMemberCardWhithFilter1
            // 
            this.ctrlMemberCardWhithFilter1.FilterEnabled = true;
            this.ctrlMemberCardWhithFilter1.Location = new System.Drawing.Point(12, 3);
            this.ctrlMemberCardWhithFilter1.Name = "ctrlMemberCardWhithFilter1";
            this.ctrlMemberCardWhithFilter1.ShowAddMember = true;
            this.ctrlMemberCardWhithFilter1.Size = new System.Drawing.Size(851, 498);
            this.ctrlMemberCardWhithFilter1.TabIndex = 6;
            // 
            // btnNext
            // 
            this.btnNext.BorderRadius = 11;
            this.btnNext.BorderThickness = 3;
            this.btnNext.CheckedState.Parent = this.btnNext;
            this.btnNext.CustomImages.Parent = this.btnNext;
            this.btnNext.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNext.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.HoverState.Parent = this.btnNext;
            this.btnNext.Location = new System.Drawing.Point(701, 506);
            this.btnNext.Name = "btnNext";
            this.btnNext.ShadowDecoration.Parent = this.btnNext;
            this.btnNext.Size = new System.Drawing.Size(161, 45);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tpSubscriptionInfo
            // 
            this.tpSubscriptionInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpSubscriptionInfo.Controls.Add(this.gpPaymentInfo);
            this.tpSubscriptionInfo.Controls.Add(this.groupBox2);
            this.tpSubscriptionInfo.ForeColor = System.Drawing.Color.Black;
            this.tpSubscriptionInfo.Location = new System.Drawing.Point(4, 25);
            this.tpSubscriptionInfo.Name = "tpSubscriptionInfo";
            this.tpSubscriptionInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpSubscriptionInfo.Size = new System.Drawing.Size(880, 554);
            this.tpSubscriptionInfo.TabIndex = 1;
            this.tpSubscriptionInfo.Text = "Subscription Info";
            // 
            // gpPaymentInfo
            // 
            this.gpPaymentInfo.BackColor = System.Drawing.Color.Gainsboro;
            this.gpPaymentInfo.Controls.Add(this.cbPaymentType);
            this.gpPaymentInfo.Controls.Add(this.lblPaymentDetailsID);
            this.gpPaymentInfo.Controls.Add(this.label12);
            this.gpPaymentInfo.Controls.Add(this.lblPaymentStatus);
            this.gpPaymentInfo.Controls.Add(this.lblPaymentDate);
            this.gpPaymentInfo.Controls.Add(this.lblPaymentID);
            this.gpPaymentInfo.Controls.Add(this.label5);
            this.gpPaymentInfo.Controls.Add(this.label11);
            this.gpPaymentInfo.Controls.Add(this.label15);
            this.gpPaymentInfo.Controls.Add(this.label16);
            this.gpPaymentInfo.Location = new System.Drawing.Point(9, 260);
            this.gpPaymentInfo.Name = "gpPaymentInfo";
            this.gpPaymentInfo.Size = new System.Drawing.Size(864, 249);
            this.gpPaymentInfo.TabIndex = 19;
            this.gpPaymentInfo.TabStop = false;
            this.gpPaymentInfo.Text = "Payment Info";
            // 
            // cbPaymentType
            // 
            this.cbPaymentType.BackColor = System.Drawing.Color.Transparent;
            this.cbPaymentType.BorderColor = System.Drawing.Color.Black;
            this.cbPaymentType.BorderRadius = 11;
            this.cbPaymentType.BorderThickness = 2;
            this.cbPaymentType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaymentType.FocusedColor = System.Drawing.Color.Empty;
            this.cbPaymentType.FocusedState.Parent = this.cbPaymentType;
            this.cbPaymentType.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPaymentType.ForeColor = System.Drawing.Color.Black;
            this.cbPaymentType.FormattingEnabled = true;
            this.cbPaymentType.HoverState.Parent = this.cbPaymentType;
            this.cbPaymentType.ItemHeight = 30;
            this.cbPaymentType.ItemsAppearance.Parent = this.cbPaymentType;
            this.cbPaymentType.Location = new System.Drawing.Point(200, 105);
            this.cbPaymentType.Name = "cbPaymentType";
            this.cbPaymentType.ShadowDecoration.Parent = this.cbPaymentType;
            this.cbPaymentType.Size = new System.Drawing.Size(211, 36);
            this.cbPaymentType.TabIndex = 27;
            // 
            // lblPaymentDetailsID
            // 
            this.lblPaymentDetailsID.AutoSize = true;
            this.lblPaymentDetailsID.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentDetailsID.Location = new System.Drawing.Point(660, 20);
            this.lblPaymentDetailsID.Name = "lblPaymentDetailsID";
            this.lblPaymentDetailsID.Size = new System.Drawing.Size(60, 22);
            this.lblPaymentDetailsID.TabIndex = 18;
            this.lblPaymentDetailsID.Text = "[????]";
            this.lblPaymentDetailsID.Click += new System.EventHandler(this.label10_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(442, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(212, 24);
            this.label12.TabIndex = 17;
            this.label12.Text = "Payment Details ID:";
            // 
            // lblPaymentStatus
            // 
            this.lblPaymentStatus.AutoSize = true;
            this.lblPaymentStatus.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentStatus.ForeColor = System.Drawing.Color.Black;
            this.lblPaymentStatus.Location = new System.Drawing.Point(660, 195);
            this.lblPaymentStatus.Name = "lblPaymentStatus";
            this.lblPaymentStatus.Size = new System.Drawing.Size(60, 22);
            this.lblPaymentStatus.TabIndex = 13;
            this.lblPaymentStatus.Text = "[????]";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = "Payment Date:";
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
            this.groupBox2.Controls.Add(this.cbSubStatus);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.lblSubscriptionPrice);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.chbIsSubscribtionActive);
            this.groupBox2.Controls.Add(this.cbPlane);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblSuscriptionBuUser);
            this.groupBox2.Controls.Add(this.lblEndDate);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lblStartDate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblSubscriptionID);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(865, 246);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Subscription Info";
            // 
            // cbSubStatus
            // 
            this.cbSubStatus.BackColor = System.Drawing.Color.Transparent;
            this.cbSubStatus.BorderColor = System.Drawing.Color.Black;
            this.cbSubStatus.BorderRadius = 11;
            this.cbSubStatus.BorderThickness = 2;
            this.cbSubStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSubStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubStatus.FocusedColor = System.Drawing.Color.Empty;
            this.cbSubStatus.FocusedState.Parent = this.cbSubStatus;
            this.cbSubStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSubStatus.ForeColor = System.Drawing.Color.Black;
            this.cbSubStatus.FormattingEnabled = true;
            this.cbSubStatus.HoverState.Parent = this.cbSubStatus;
            this.cbSubStatus.ItemHeight = 30;
            this.cbSubStatus.Items.AddRange(new object[] {
            "Active",
            "Expired",
            "Pending"});
            this.cbSubStatus.ItemsAppearance.Parent = this.cbSubStatus;
            this.cbSubStatus.Location = new System.Drawing.Point(597, 189);
            this.cbSubStatus.Name = "cbSubStatus";
            this.cbSubStatus.ShadowDecoration.Parent = this.cbSubStatus;
            this.cbSubStatus.Size = new System.Drawing.Size(206, 36);
            this.cbSubStatus.TabIndex = 119;
            this.cbSubStatus.SelectedIndexChanged += new System.EventHandler(this.cbSubStatus_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(409, 197);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(182, 22);
            this.label28.TabIndex = 118;
            this.label28.Text = "Subscription Statu:";
            // 
            // lblSubscriptionPrice
            // 
            this.lblSubscriptionPrice.AutoSize = true;
            this.lblSubscriptionPrice.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubscriptionPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSubscriptionPrice.Location = new System.Drawing.Point(593, 143);
            this.lblSubscriptionPrice.Name = "lblSubscriptionPrice";
            this.lblSubscriptionPrice.Size = new System.Drawing.Size(60, 22);
            this.lblSubscriptionPrice.TabIndex = 26;
            this.lblSubscriptionPrice.Text = "[????]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(409, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 22);
            this.label3.TabIndex = 25;
            this.label3.Text = "Subscription Price:";
            // 
            // chbIsSubscribtionActive
            // 
            this.chbIsSubscribtionActive.AutoSize = true;
            this.chbIsSubscribtionActive.BackColor = System.Drawing.Color.Transparent;
            this.chbIsSubscribtionActive.Enabled = false;
            this.chbIsSubscribtionActive.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbIsSubscribtionActive.Location = new System.Drawing.Point(17, 194);
            this.chbIsSubscribtionActive.Name = "chbIsSubscribtionActive";
            this.chbIsSubscribtionActive.Size = new System.Drawing.Size(220, 25);
            this.chbIsSubscribtionActive.TabIndex = 24;
            this.chbIsSubscribtionActive.Text = "Is Subscription Active";
            this.chbIsSubscribtionActive.UseVisualStyleBackColor = false;
            // 
            // cbPlane
            // 
            this.cbPlane.BackColor = System.Drawing.Color.Transparent;
            this.cbPlane.BorderColor = System.Drawing.Color.Black;
            this.cbPlane.BorderRadius = 11;
            this.cbPlane.BorderThickness = 2;
            this.cbPlane.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPlane.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlane.FocusedColor = System.Drawing.Color.Empty;
            this.cbPlane.FocusedState.Parent = this.cbPlane;
            this.cbPlane.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPlane.ForeColor = System.Drawing.Color.Black;
            this.cbPlane.FormattingEnabled = true;
            this.cbPlane.HoverState.Parent = this.cbPlane;
            this.cbPlane.ItemHeight = 30;
            this.cbPlane.ItemsAppearance.Parent = this.cbPlane;
            this.cbPlane.Location = new System.Drawing.Point(488, 79);
            this.cbPlane.Name = "cbPlane";
            this.cbPlane.ShadowDecoration.Parent = this.cbPlane;
            this.cbPlane.Size = new System.Drawing.Size(284, 36);
            this.cbPlane.TabIndex = 22;
            this.cbPlane.SelectedIndexChanged += new System.EventHandler(this.cbPlane_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(409, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 22);
            this.label4.TabIndex = 21;
            this.label4.Text = "Plane :";
            // 
            // lblSuscriptionBuUser
            // 
            this.lblSuscriptionBuUser.AutoSize = true;
            this.lblSuscriptionBuUser.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuscriptionBuUser.Location = new System.Drawing.Point(621, 22);
            this.lblSuscriptionBuUser.Name = "lblSuscriptionBuUser";
            this.lblSuscriptionBuUser.Size = new System.Drawing.Size(60, 22);
            this.lblSuscriptionBuUser.TabIndex = 16;
            this.lblSuscriptionBuUser.Text = "[????]";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEndDate.Location = new System.Drawing.Point(165, 143);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(60, 22);
            this.lblEndDate.TabIndex = 20;
            this.lblEndDate.Text = "[????]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(409, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 22);
            this.label8.TabIndex = 15;
            this.label8.Text = "Created By User:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 22);
            this.label9.TabIndex = 19;
            this.label9.Text = "End Date:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.Location = new System.Drawing.Point(165, 75);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(60, 22);
            this.lblStartDate.TabIndex = 18;
            this.lblStartDate.Text = "[????]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 22);
            this.label7.TabIndex = 17;
            this.label7.Text = "Start Date:";
            // 
            // lblSubscriptionID
            // 
            this.lblSubscriptionID.AutoSize = true;
            this.lblSubscriptionID.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubscriptionID.Location = new System.Drawing.Point(165, 22);
            this.lblSubscriptionID.Name = "lblSubscriptionID";
            this.lblSubscriptionID.Size = new System.Drawing.Size(60, 22);
            this.lblSubscriptionID.TabIndex = 16;
            this.lblSubscriptionID.Text = "[????]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 22);
            this.label6.TabIndex = 15;
            this.label6.Text = "Subscription ID:";
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Mongolian Baiti", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitel.Location = new System.Drawing.Point(210, 50);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(374, 50);
            this.lblTitel.TabIndex = 4;
            this.lblTitel.Text = "Add Subscriptions";
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
            this.btnClose.Location = new System.Drawing.Point(477, 693);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(161, 45);
            this.btnClose.TabIndex = 9;
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
            this.btnSave.Location = new System.Drawing.Point(707, 694);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.Size = new System.Drawing.Size(161, 45);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrlPaymentInfo1
            // 
            this.ctrlPaymentInfo1.BackColor = System.Drawing.Color.Gainsboro;
            this.ctrlPaymentInfo1.Enabled = false;
            this.ctrlPaymentInfo1.Location = new System.Drawing.Point(9, 259);
            this.ctrlPaymentInfo1.Name = "ctrlPaymentInfo1";
            this.ctrlPaymentInfo1.Size = new System.Drawing.Size(865, 287);
            this.ctrlPaymentInfo1.TabIndex = 17;
            // 
            // frmAdd_UpdateSubscriptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 741);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmAdd_UpdateSubscriptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add&UpdateSubscriptions";
            this.Load += new System.EventHandler(this.frmAdd_UpdateSubscriptions_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpMemberInfo.ResumeLayout(false);
            this.tpSubscriptionInfo.ResumeLayout(false);
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
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private System.Windows.Forms.TabPage tpSubscriptionInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private Guna.UI2.WinForms.Guna2ComboBox cbPlane;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSuscriptionBuUser;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSubscriptionID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTitel;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private ctrlMemberCardWhithFilter ctrlMemberCardWhithFilter1;
        private System.Windows.Forms.CheckBox chbIsSubscribtionActive;
        private System.Windows.Forms.Label lblSubscriptionPrice;
        private System.Windows.Forms.Label label3;
        private ctrlPaymentInfo ctrlPaymentInfo1;
        private System.Windows.Forms.GroupBox gpPaymentInfo;
        private System.Windows.Forms.Label lblPaymentDetailsID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.Label lblPaymentID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private Guna.UI2.WinForms.Guna2ComboBox cbPaymentType;
        private Guna.UI2.WinForms.Guna2ComboBox cbSubStatus;
        private System.Windows.Forms.Label label28;
    }
}