namespace Library_Manegment_System
{
    partial class ctrlMemberSubscriptionInfo
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
            this.ctrlSubscriptiomInfo1 = new Library_Manegment_System.ctrlSubscriptiomInfo();
            this.ctrlMemberCard1 = new Library_Manegment_System.ctrlMemberCard();
            this.SuspendLayout();
            // 
            // ctrlSubscriptiomInfo1
            // 
            this.ctrlSubscriptiomInfo1.BackColor = System.Drawing.Color.Gainsboro;
            this.ctrlSubscriptiomInfo1.Location = new System.Drawing.Point(3, 403);
            this.ctrlSubscriptiomInfo1.Name = "ctrlSubscriptiomInfo1";
            this.ctrlSubscriptiomInfo1.Size = new System.Drawing.Size(848, 201);
            this.ctrlSubscriptiomInfo1.TabIndex = 0;
            // 
            // ctrlMemberCard1
            // 
            this.ctrlMemberCard1.Location = new System.Drawing.Point(1, 2);
            this.ctrlMemberCard1.Name = "ctrlMemberCard1";
            this.ctrlMemberCard1.Size = new System.Drawing.Size(850, 401);
            this.ctrlMemberCard1.TabIndex = 1;
            // 
            // ctrlMemberSubscriptionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.ctrlMemberCard1);
            this.Controls.Add(this.ctrlSubscriptiomInfo1);
            this.Name = "ctrlMemberSubscriptionInfo";
            this.Size = new System.Drawing.Size(854, 612);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlSubscriptiomInfo ctrlSubscriptiomInfo1;
        private ctrlMemberCard ctrlMemberCard1;
    }
}
