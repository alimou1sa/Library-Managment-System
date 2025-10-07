namespace Library_Manegment_System
{
    partial class frmPurchasesBook
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
            this.tpBookInfo = new System.Windows.Forms.TabPage();
            this.btnNext1 = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlBookCardWithFilter1 = new Library_Manegment_System.ctrlBookCardWithFilter();
            this.tpMemberInfo = new System.Windows.Forms.TabPage();
            this.btnNext2 = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlMemberCardWhithFilter1 = new Library_Manegment_System.ctrlMemberCardWhithFilter();
            this.tpPurchasesBookInfo = new System.Windows.Forms.TabPage();
            this.gpPaymentInfo = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.cbPaymentType = new System.Windows.Forms.ComboBox();
            this.lblPaymentStatus = new System.Windows.Forms.Label();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.lblPaymentID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.NupdCopiesPurchased = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCreateByUser = new System.Windows.Forms.Label();
            this.lblPurchaseID = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tpBookInfo.SuspendLayout();
            this.tpMemberInfo.SuspendLayout();
            this.tpPurchasesBookInfo.SuspendLayout();
            this.gpPaymentInfo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NupdCopiesPurchased)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpBookInfo);
            this.tabControl1.Controls.Add(this.tpMemberInfo);
            this.tabControl1.Controls.Add(this.tpPurchasesBookInfo);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(8, 126);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(857, 582);
            this.tabControl1.TabIndex = 0;
            // 
            // tpBookInfo
            // 
            this.tpBookInfo.BackColor = System.Drawing.Color.White;
            this.tpBookInfo.Controls.Add(this.btnNext1);
            this.tpBookInfo.Controls.Add(this.ctrlBookCardWithFilter1);
            this.tpBookInfo.Location = new System.Drawing.Point(4, 25);
            this.tpBookInfo.Name = "tpBookInfo";
            this.tpBookInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpBookInfo.Size = new System.Drawing.Size(849, 553);
            this.tpBookInfo.TabIndex = 0;
            this.tpBookInfo.Text = "BooK Info";
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
            this.btnNext1.Location = new System.Drawing.Point(670, 486);
            this.btnNext1.Name = "btnNext1";
            this.btnNext1.ShadowDecoration.Parent = this.btnNext1;
            this.btnNext1.Size = new System.Drawing.Size(161, 45);
            this.btnNext1.TabIndex = 13;
            this.btnNext1.Text = "Next";
            this.btnNext1.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // ctrlBookCardWithFilter1
            // 
            this.ctrlBookCardWithFilter1.FilterEnabled = true;
            this.ctrlBookCardWithFilter1.Location = new System.Drawing.Point(12, 6);
            this.ctrlBookCardWithFilter1.Name = "ctrlBookCardWithFilter1";
            this.ctrlBookCardWithFilter1.ShowAddBook = true;
            this.ctrlBookCardWithFilter1.Size = new System.Drawing.Size(819, 462);
            this.ctrlBookCardWithFilter1.TabIndex = 0;
            // 
            // tpMemberInfo
            // 
            this.tpMemberInfo.Controls.Add(this.btnNext2);
            this.tpMemberInfo.Controls.Add(this.ctrlMemberCardWhithFilter1);
            this.tpMemberInfo.Location = new System.Drawing.Point(4, 25);
            this.tpMemberInfo.Name = "tpMemberInfo";
            this.tpMemberInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpMemberInfo.Size = new System.Drawing.Size(849, 553);
            this.tpMemberInfo.TabIndex = 1;
            this.tpMemberInfo.Text = "Member Info";
            this.tpMemberInfo.UseVisualStyleBackColor = true;
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
            this.btnNext2.Location = new System.Drawing.Point(682, 499);
            this.btnNext2.Name = "btnNext2";
            this.btnNext2.ShadowDecoration.Parent = this.btnNext2;
            this.btnNext2.Size = new System.Drawing.Size(161, 45);
            this.btnNext2.TabIndex = 12;
            this.btnNext2.Text = "Next";
            this.btnNext2.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // ctrlMemberCardWhithFilter1
            // 
            this.ctrlMemberCardWhithFilter1.FilterEnabled = true;
            this.ctrlMemberCardWhithFilter1.Location = new System.Drawing.Point(0, 4);
            this.ctrlMemberCardWhithFilter1.Name = "ctrlMemberCardWhithFilter1";
            this.ctrlMemberCardWhithFilter1.ShowAddMember = true;
            this.ctrlMemberCardWhithFilter1.Size = new System.Drawing.Size(843, 499);
            this.ctrlMemberCardWhithFilter1.TabIndex = 0;
            // 
            // tpPurchasesBookInfo
            // 
            this.tpPurchasesBookInfo.Controls.Add(this.gpPaymentInfo);
            this.tpPurchasesBookInfo.Controls.Add(this.groupBox2);
            this.tpPurchasesBookInfo.Location = new System.Drawing.Point(4, 25);
            this.tpPurchasesBookInfo.Name = "tpPurchasesBookInfo";
            this.tpPurchasesBookInfo.Size = new System.Drawing.Size(849, 553);
            this.tpPurchasesBookInfo.TabIndex = 2;
            this.tpPurchasesBookInfo.Text = "Purchases Book Info";
            this.tpPurchasesBookInfo.UseVisualStyleBackColor = true;
            // 
            // gpPaymentInfo
            // 
            this.gpPaymentInfo.BackColor = System.Drawing.Color.Gainsboro;
            this.gpPaymentInfo.Controls.Add(this.label2);
            this.gpPaymentInfo.Controls.Add(this.lblTotalPrice);
            this.gpPaymentInfo.Controls.Add(this.cbPaymentType);
            this.gpPaymentInfo.Controls.Add(this.lblPaymentStatus);
            this.gpPaymentInfo.Controls.Add(this.lblPaymentDate);
            this.gpPaymentInfo.Controls.Add(this.lblPaymentID);
            this.gpPaymentInfo.Controls.Add(this.label9);
            this.gpPaymentInfo.Controls.Add(this.label11);
            this.gpPaymentInfo.Controls.Add(this.label15);
            this.gpPaymentInfo.Controls.Add(this.label16);
            this.gpPaymentInfo.Location = new System.Drawing.Point(6, 294);
            this.gpPaymentInfo.Name = "gpPaymentInfo";
            this.gpPaymentInfo.Size = new System.Drawing.Size(833, 249);
            this.gpPaymentInfo.TabIndex = 18;
            this.gpPaymentInfo.TabStop = false;
            this.gpPaymentInfo.Text = "Payment Info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(443, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Price:";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalPrice.Location = new System.Drawing.Point(637, 25);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(60, 22);
            this.lblTotalPrice.TabIndex = 7;
            this.lblTotalPrice.Text = "[????]";
            // 
            // cbPaymentType
            // 
            this.cbPaymentType.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPaymentType.FormattingEnabled = true;
            this.cbPaymentType.ItemHeight = 22;
            this.cbPaymentType.Location = new System.Drawing.Point(213, 107);
            this.cbPaymentType.Name = "cbPaymentType";
            this.cbPaymentType.Size = new System.Drawing.Size(199, 30);
            this.cbPaymentType.TabIndex = 16;
            // 
            // lblPaymentStatus
            // 
            this.lblPaymentStatus.AutoSize = true;
            this.lblPaymentStatus.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPaymentStatus.Location = new System.Drawing.Point(631, 195);
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
            this.groupBox2.Controls.Add(this.NupdCopiesPurchased);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtpPurchaseDate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblCreateByUser);
            this.groupBox2.Controls.Add(this.lblPurchaseID);
            this.groupBox2.Location = new System.Drawing.Point(6, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(837, 270);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Purchases Info";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // NupdCopiesPurchased
            // 
            this.NupdCopiesPurchased.BackColor = System.Drawing.Color.Transparent;
            this.NupdCopiesPurchased.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NupdCopiesPurchased.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.NupdCopiesPurchased.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.NupdCopiesPurchased.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NupdCopiesPurchased.DisabledState.Parent = this.NupdCopiesPurchased;
            this.NupdCopiesPurchased.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.NupdCopiesPurchased.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.NupdCopiesPurchased.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NupdCopiesPurchased.FocusedState.Parent = this.NupdCopiesPurchased;
            this.NupdCopiesPurchased.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NupdCopiesPurchased.ForeColor = System.Drawing.Color.Black;
            this.NupdCopiesPurchased.Location = new System.Drawing.Point(669, 162);
            this.NupdCopiesPurchased.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NupdCopiesPurchased.Name = "NupdCopiesPurchased";
            this.NupdCopiesPurchased.ShadowDecoration.Parent = this.NupdCopiesPurchased;
            this.NupdCopiesPurchased.Size = new System.Drawing.Size(96, 45);
            this.NupdCopiesPurchased.TabIndex = 12;
            this.NupdCopiesPurchased.UpDownButtonFillColor = System.Drawing.Color.Teal;
            this.NupdCopiesPurchased.ValueChanged += new System.EventHandler(this.NupdCopiesPurchased_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "PurchaseID :";
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPurchaseDate.Location = new System.Drawing.Point(625, 66);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(165, 29);
            this.dtpPurchaseDate.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(443, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Purchase Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(443, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Copies Purchased :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "Create By User :";
            // 
            // lblCreateByUser
            // 
            this.lblCreateByUser.AutoSize = true;
            this.lblCreateByUser.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateByUser.Location = new System.Drawing.Point(220, 185);
            this.lblCreateByUser.Name = "lblCreateByUser";
            this.lblCreateByUser.Size = new System.Drawing.Size(60, 22);
            this.lblCreateByUser.TabIndex = 9;
            this.lblCreateByUser.Text = "[????]";
            // 
            // lblPurchaseID
            // 
            this.lblPurchaseID.AutoSize = true;
            this.lblPurchaseID.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchaseID.Location = new System.Drawing.Point(211, 71);
            this.lblPurchaseID.Name = "lblPurchaseID";
            this.lblPurchaseID.Size = new System.Drawing.Size(60, 22);
            this.lblPurchaseID.TabIndex = 6;
            this.lblPurchaseID.Text = "[????]";
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
            this.btnClose.Location = new System.Drawing.Point(475, 714);
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
            this.btnSave.Location = new System.Drawing.Point(694, 714);
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
            this.lblTitel.Location = new System.Drawing.Point(254, 45);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(412, 64);
            this.lblTitel.TabIndex = 13;
            this.lblTitel.Text = "Purchases Book";
            // 
            // frmPurchasesBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 775);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmPurchasesBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchases Book";
            this.Load += new System.EventHandler(this.frmPurchasesBook_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpBookInfo.ResumeLayout(false);
            this.tpMemberInfo.ResumeLayout(false);
            this.tpPurchasesBookInfo.ResumeLayout(false);
            this.gpPaymentInfo.ResumeLayout(false);
            this.gpPaymentInfo.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NupdCopiesPurchased)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpBookInfo;
        private System.Windows.Forms.TabPage tpMemberInfo;
        private System.Windows.Forms.TabPage tpPurchasesBookInfo;
        private ctrlBookCardWithFilter ctrlBookCardWithFilter1;
        private ctrlMemberCardWhithFilter ctrlMemberCardWhithFilter1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCreateByUser;
        private System.Windows.Forms.Label lblPurchaseID;
        private System.Windows.Forms.Label lblTotalPrice;
        private Guna.UI2.WinForms.Guna2NumericUpDown NupdCopiesPurchased;
        private System.Windows.Forms.GroupBox gpPaymentInfo;
        private System.Windows.Forms.ComboBox cbPaymentType;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.Label lblPaymentID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private Guna.UI2.WinForms.Guna2Button btnNext2;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnNext1;
        private System.Windows.Forms.Label lblTitel;
    }
}