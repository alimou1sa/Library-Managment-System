namespace Library_Manegment_System
{
    partial class ctrlPurchasesBookInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkelblShowMember = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCopiesPurchased = new System.Windows.Forms.Label();
            this.lblCreateByUser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPurchaseDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMemberID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPurchaseID = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ctrBookInfo1 = new Library_Manegment_System.ctrBookInfo();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.lblTotalPrice);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblPurchaseID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblMemberID);
            this.groupBox1.Controls.Add(this.linkelblShowMember);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblCopiesPurchased);
            this.groupBox1.Controls.Add(this.lblCreateByUser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblPurchaseDate);
            this.groupBox1.Location = new System.Drawing.Point(3, 369);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(815, 211);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PurchasInfo";
            // 
            // linkelblShowMember
            // 
            this.linkelblShowMember.AutoSize = true;
            this.linkelblShowMember.Enabled = false;
            this.linkelblShowMember.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkelblShowMember.Location = new System.Drawing.Point(239, 175);
            this.linkelblShowMember.Name = "linkelblShowMember";
            this.linkelblShowMember.Size = new System.Drawing.Size(174, 21);
            this.linkelblShowMember.TabIndex = 28;
            this.linkelblShowMember.TabStop = true;
            this.linkelblShowMember.Text = "Show Member Info";
            this.linkelblShowMember.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkelblShowMember_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 24);
            this.label6.TabIndex = 24;
            this.label6.Text = "Create By User :";
            // 
            // lblCopiesPurchased
            // 
            this.lblCopiesPurchased.AutoSize = true;
            this.lblCopiesPurchased.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopiesPurchased.Location = new System.Drawing.Point(614, 89);
            this.lblCopiesPurchased.Name = "lblCopiesPurchased";
            this.lblCopiesPurchased.Size = new System.Drawing.Size(60, 22);
            this.lblCopiesPurchased.TabIndex = 27;
            this.lblCopiesPurchased.Text = "[????]";
            // 
            // lblCreateByUser
            // 
            this.lblCreateByUser.AutoSize = true;
            this.lblCreateByUser.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateByUser.Location = new System.Drawing.Point(187, 89);
            this.lblCreateByUser.Name = "lblCreateByUser";
            this.lblCreateByUser.Size = new System.Drawing.Size(60, 22);
            this.lblCreateByUser.TabIndex = 23;
            this.lblCreateByUser.Text = "[????]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(411, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 24);
            this.label2.TabIndex = 26;
            this.label2.Text = "Copies Purchased:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(411, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 24);
            this.label4.TabIndex = 19;
            this.label4.Text = "Purchase Date :";
            // 
            // lblPurchaseDate
            // 
            this.lblPurchaseDate.AutoSize = true;
            this.lblPurchaseDate.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchaseDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPurchaseDate.Location = new System.Drawing.Point(614, 32);
            this.lblPurchaseDate.Name = "lblPurchaseDate";
            this.lblPurchaseDate.Size = new System.Drawing.Size(60, 22);
            this.lblPurchaseDate.TabIndex = 25;
            this.lblPurchaseDate.Text = "[????]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 24);
            this.label1.TabIndex = 32;
            this.label1.Text = "MemberID:";
            // 
            // lblMemberID
            // 
            this.lblMemberID.AutoSize = true;
            this.lblMemberID.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberID.Location = new System.Drawing.Point(187, 136);
            this.lblMemberID.Name = "lblMemberID";
            this.lblMemberID.Size = new System.Drawing.Size(60, 22);
            this.lblMemberID.TabIndex = 31;
            this.lblMemberID.Text = "[????]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 24);
            this.label3.TabIndex = 33;
            this.label3.Text = "PurchaseID :";
            // 
            // lblPurchaseID
            // 
            this.lblPurchaseID.AutoSize = true;
            this.lblPurchaseID.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchaseID.Location = new System.Drawing.Point(187, 33);
            this.lblPurchaseID.Name = "lblPurchaseID";
            this.lblPurchaseID.Size = new System.Drawing.Size(60, 22);
            this.lblPurchaseID.TabIndex = 34;
            this.lblPurchaseID.Text = "[????]";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.Location = new System.Drawing.Point(614, 136);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(60, 22);
            this.lblTotalPrice.TabIndex = 36;
            this.lblTotalPrice.Text = "[????]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(411, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 24);
            this.label7.TabIndex = 35;
            this.label7.Text = "Total Price:";
            // 
            // ctrBookInfo1
            // 
            this.ctrBookInfo1.Location = new System.Drawing.Point(3, 3);
            this.ctrBookInfo1.Name = "ctrBookInfo1";
            this.ctrBookInfo1.Size = new System.Drawing.Size(815, 363);
            this.ctrBookInfo1.TabIndex = 0;
            // 
            // ctrlPurchasesBookInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrBookInfo1);
            this.Name = "ctrlPurchasesBookInfo";
            this.Size = new System.Drawing.Size(822, 587);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrBookInfo ctrBookInfo1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkelblShowMember;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCopiesPurchased;
        private System.Windows.Forms.Label lblCreateByUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPurchaseDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMemberID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPurchaseID;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label label7;
    }
}
