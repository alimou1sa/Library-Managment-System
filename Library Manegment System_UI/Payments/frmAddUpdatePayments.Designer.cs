namespace Library_Manegment_System
{
    partial class frmAddUpdatePayments
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
            this.gpPaymentInfo = new System.Windows.Forms.GroupBox();
            this.lblEntityName = new System.Windows.Forms.Label();
            this.lllbb = new System.Windows.Forms.Label();
            this.lblEntityID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCrateByUser = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.cbPaymentType = new System.Windows.Forms.ComboBox();
            this.lblPaymentStatus = new System.Windows.Forms.Label();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.lblPaymentID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblTitel = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbgMemberInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlMemberCardWhithFilter1 = new Library_Manegment_System.ctrlMemberCardWhithFilter();
            this.tbgPaymentInfo = new System.Windows.Forms.TabPage();
            this.lblPaymentDetailsID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gpPaymentInfo.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbgMemberInfo.SuspendLayout();
            this.tbgPaymentInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpPaymentInfo
            // 
            this.gpPaymentInfo.BackColor = System.Drawing.Color.Gainsboro;
            this.gpPaymentInfo.Controls.Add(this.lblPaymentDetailsID);
            this.gpPaymentInfo.Controls.Add(this.label6);
            this.gpPaymentInfo.Controls.Add(this.lblEntityName);
            this.gpPaymentInfo.Controls.Add(this.lllbb);
            this.gpPaymentInfo.Controls.Add(this.lblEntityID);
            this.gpPaymentInfo.Controls.Add(this.label4);
            this.gpPaymentInfo.Controls.Add(this.lblCrateByUser);
            this.gpPaymentInfo.Controls.Add(this.label3);
            this.gpPaymentInfo.Controls.Add(this.label2);
            this.gpPaymentInfo.Controls.Add(this.lblAmount);
            this.gpPaymentInfo.Controls.Add(this.cbPaymentType);
            this.gpPaymentInfo.Controls.Add(this.lblPaymentStatus);
            this.gpPaymentInfo.Controls.Add(this.lblPaymentDate);
            this.gpPaymentInfo.Controls.Add(this.lblPaymentID);
            this.gpPaymentInfo.Controls.Add(this.label9);
            this.gpPaymentInfo.Controls.Add(this.label11);
            this.gpPaymentInfo.Controls.Add(this.label15);
            this.gpPaymentInfo.Controls.Add(this.label16);
            this.gpPaymentInfo.Location = new System.Drawing.Point(5, 13);
            this.gpPaymentInfo.Name = "gpPaymentInfo";
            this.gpPaymentInfo.Size = new System.Drawing.Size(843, 416);
            this.gpPaymentInfo.TabIndex = 19;
            this.gpPaymentInfo.TabStop = false;
            this.gpPaymentInfo.Text = "Payment Info";
            this.gpPaymentInfo.Enter += new System.EventHandler(this.gpPaymentInfo_Enter);
            // 
            // lblEntityName
            // 
            this.lblEntityName.AutoSize = true;
            this.lblEntityName.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntityName.Location = new System.Drawing.Point(672, 280);
            this.lblEntityName.Name = "lblEntityName";
            this.lblEntityName.Size = new System.Drawing.Size(60, 22);
            this.lblEntityName.TabIndex = 22;
            this.lblEntityName.Text = "[????]";
            // 
            // lllbb
            // 
            this.lllbb.AutoSize = true;
            this.lllbb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lllbb.Location = new System.Drawing.Point(469, 278);
            this.lllbb.Name = "lllbb";
            this.lllbb.Size = new System.Drawing.Size(140, 24);
            this.lllbb.TabIndex = 21;
            this.lllbb.Text = "Entity Name:";
            // 
            // lblEntityID
            // 
            this.lblEntityID.AutoSize = true;
            this.lblEntityID.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntityID.Location = new System.Drawing.Point(207, 353);
            this.lblEntityID.Name = "lblEntityID";
            this.lblEntityID.Size = new System.Drawing.Size(60, 22);
            this.lblEntityID.TabIndex = 20;
            this.lblEntityID.Text = "[????]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 24);
            this.label4.TabIndex = 19;
            this.label4.Text = "Entity ID:";
            // 
            // lblCrateByUser
            // 
            this.lblCrateByUser.AutoSize = true;
            this.lblCrateByUser.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrateByUser.ForeColor = System.Drawing.Color.Black;
            this.lblCrateByUser.Location = new System.Drawing.Point(672, 101);
            this.lblCrateByUser.Name = "lblCrateByUser";
            this.lblCrateByUser.Size = new System.Drawing.Size(60, 22);
            this.lblCrateByUser.TabIndex = 18;
            this.lblCrateByUser.Text = "[????]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(469, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 24);
            this.label3.TabIndex = 17;
            this.label3.Text = "Create By User:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(469, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Amount:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAmount.Location = new System.Drawing.Point(672, 27);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(60, 22);
            this.lblAmount.TabIndex = 7;
            this.lblAmount.Text = "[????]";
            // 
            // cbPaymentType
            // 
            this.cbPaymentType.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPaymentType.FormattingEnabled = true;
            this.cbPaymentType.ItemHeight = 22;
            this.cbPaymentType.Location = new System.Drawing.Point(206, 180);
            this.cbPaymentType.Name = "cbPaymentType";
            this.cbPaymentType.Size = new System.Drawing.Size(199, 30);
            this.cbPaymentType.TabIndex = 16;
            // 
            // lblPaymentStatus
            // 
            this.lblPaymentStatus.AutoSize = true;
            this.lblPaymentStatus.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentStatus.ForeColor = System.Drawing.Color.Black;
            this.lblPaymentStatus.Location = new System.Drawing.Point(672, 189);
            this.lblPaymentStatus.Name = "lblPaymentStatus";
            this.lblPaymentStatus.Size = new System.Drawing.Size(60, 22);
            this.lblPaymentStatus.TabIndex = 13;
            this.lblPaymentStatus.Text = "[????]";
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.AutoSize = true;
            this.lblPaymentDate.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentDate.Location = new System.Drawing.Point(207, 276);
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
            this.label9.Location = new System.Drawing.Point(15, 275);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 24);
            this.label9.TabIndex = 6;
            this.label9.Text = "Payment Date:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(469, 189);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(176, 24);
            this.label11.TabIndex = 4;
            this.label11.Text = "Payment Status:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(17, 183);
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
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Mongolian Baiti", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitel.Location = new System.Drawing.Point(249, -8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(379, 64);
            this.lblTitel.TabIndex = 20;
            this.lblTitel.Text = "Add Payments";
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
            this.btnClose.Location = new System.Drawing.Point(449, 642);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(161, 45);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
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
            this.btnSave.Location = new System.Drawing.Point(687, 641);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.Size = new System.Drawing.Size(161, 45);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbgMemberInfo);
            this.tabControl1.Controls.Add(this.tbgPaymentInfo);
            this.tabControl1.Location = new System.Drawing.Point(2, 57);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(864, 580);
            this.tabControl1.TabIndex = 23;
            // 
            // tbgMemberInfo
            // 
            this.tbgMemberInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbgMemberInfo.Controls.Add(this.btnNext);
            this.tbgMemberInfo.Controls.Add(this.ctrlMemberCardWhithFilter1);
            this.tbgMemberInfo.Location = new System.Drawing.Point(4, 25);
            this.tbgMemberInfo.Name = "tbgMemberInfo";
            this.tbgMemberInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbgMemberInfo.Size = new System.Drawing.Size(856, 551);
            this.tbgMemberInfo.TabIndex = 0;
            this.tbgMemberInfo.Text = "Member Info";
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
            this.btnNext.Location = new System.Drawing.Point(681, 501);
            this.btnNext.Name = "btnNext";
            this.btnNext.ShadowDecoration.Parent = this.btnNext;
            this.btnNext.Size = new System.Drawing.Size(161, 45);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlMemberCardWhithFilter1
            // 
            this.ctrlMemberCardWhithFilter1.FilterEnabled = true;
            this.ctrlMemberCardWhithFilter1.Location = new System.Drawing.Point(1, 3);
            this.ctrlMemberCardWhithFilter1.Name = "ctrlMemberCardWhithFilter1";
            this.ctrlMemberCardWhithFilter1.ShowAddMember = true;
            this.ctrlMemberCardWhithFilter1.Size = new System.Drawing.Size(851, 498);
            this.ctrlMemberCardWhithFilter1.TabIndex = 0;
            // 
            // tbgPaymentInfo
            // 
            this.tbgPaymentInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbgPaymentInfo.Controls.Add(this.gpPaymentInfo);
            this.tbgPaymentInfo.Location = new System.Drawing.Point(4, 25);
            this.tbgPaymentInfo.Name = "tbgPaymentInfo";
            this.tbgPaymentInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbgPaymentInfo.Size = new System.Drawing.Size(856, 551);
            this.tbgPaymentInfo.TabIndex = 1;
            this.tbgPaymentInfo.Text = "Payment Info";
            // 
            // lblPaymentDetailsID
            // 
            this.lblPaymentDetailsID.AutoSize = true;
            this.lblPaymentDetailsID.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentDetailsID.Location = new System.Drawing.Point(209, 101);
            this.lblPaymentDetailsID.Name = "lblPaymentDetailsID";
            this.lblPaymentDetailsID.Size = new System.Drawing.Size(60, 22);
            this.lblPaymentDetailsID.TabIndex = 24;
            this.lblPaymentDetailsID.Text = "[????]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(206, 24);
            this.label6.TabIndex = 23;
            this.label6.Text = "Payment DetailsID:";
            // 
            // frmAddUpdatePayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 688);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmAddUpdatePayments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddUpdatePayments";
            this.Load += new System.EventHandler(this.frmAddUpdatePayments_Load);
            this.gpPaymentInfo.ResumeLayout(false);
            this.gpPaymentInfo.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tbgMemberInfo.ResumeLayout(false);
            this.tbgPaymentInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpPaymentInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.ComboBox cbPaymentType;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.Label lblPaymentID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblTitel;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.Label lblCrateByUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEntityName;
        private System.Windows.Forms.Label lllbb;
        private System.Windows.Forms.Label lblEntityID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbgMemberInfo;
        private System.Windows.Forms.TabPage tbgPaymentInfo;
        private ctrlMemberCardWhithFilter ctrlMemberCardWhithFilter1;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private System.Windows.Forms.Label lblPaymentDetailsID;
        private System.Windows.Forms.Label label6;
    }
}