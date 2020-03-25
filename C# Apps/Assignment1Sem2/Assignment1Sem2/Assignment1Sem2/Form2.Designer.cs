namespace Assignment1Sem2
{
    partial class FormAddMember
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
            this.tbGivenName = new System.Windows.Forms.TextBox();
            this.lbGivenName = new System.Windows.Forms.Label();
            this.lbLastName = new System.Windows.Forms.Label();
            this.lbDOB = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.tbDOB1 = new System.Windows.Forms.TextBox();
            this.tbDOB2 = new System.Windows.Forms.TextBox();
            this.tbDOB3 = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lbMembershipID = new System.Windows.Forms.Label();
            this.btnAddMember = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lbExplanation = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNFC = new System.Windows.Forms.RadioButton();
            this.rbCARD = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbGivenName
            // 
            this.tbGivenName.AcceptsReturn = true;
            this.tbGivenName.Location = new System.Drawing.Point(41, 45);
            this.tbGivenName.Name = "tbGivenName";
            this.tbGivenName.Size = new System.Drawing.Size(200, 20);
            this.tbGivenName.TabIndex = 0;
            this.tbGivenName.TextChanged += new System.EventHandler(this.tbGivenName_TextChanged);
            // 
            // lbGivenName
            // 
            this.lbGivenName.AutoSize = true;
            this.lbGivenName.Location = new System.Drawing.Point(38, 29);
            this.lbGivenName.Name = "lbGivenName";
            this.lbGivenName.Size = new System.Drawing.Size(203, 13);
            this.lbGivenName.TabIndex = 1;
            this.lbGivenName.Text = "*Please enter the member\'s GIVEN name:";
            // 
            // lbLastName
            // 
            this.lbLastName.AutoSize = true;
            this.lbLastName.Location = new System.Drawing.Point(38, 78);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(193, 13);
            this.lbLastName.TabIndex = 2;
            this.lbLastName.Text = "Please enter the member\'s LAST name:";
            // 
            // lbDOB
            // 
            this.lbDOB.AutoSize = true;
            this.lbDOB.Location = new System.Drawing.Point(38, 127);
            this.lbDOB.Name = "lbDOB";
            this.lbDOB.Size = new System.Drawing.Size(200, 13);
            this.lbDOB.TabIndex = 4;
            this.lbDOB.Text = "*Please enter the member\'s Date of Birth:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "/";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "/";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(110, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "(dd/MM/yyyy)";
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(41, 94);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(200, 20);
            this.tbLastName.TabIndex = 8;
            // 
            // tbDOB1
            // 
            this.tbDOB1.Location = new System.Drawing.Point(58, 152);
            this.tbDOB1.Name = "tbDOB1";
            this.tbDOB1.Size = new System.Drawing.Size(41, 20);
            this.tbDOB1.TabIndex = 9;
            this.tbDOB1.TextChanged += new System.EventHandler(this.tbDOB1_TextChanged);
            // 
            // tbDOB2
            // 
            this.tbDOB2.Location = new System.Drawing.Point(123, 152);
            this.tbDOB2.Name = "tbDOB2";
            this.tbDOB2.Size = new System.Drawing.Size(42, 20);
            this.tbDOB2.TabIndex = 10;
            this.tbDOB2.TextChanged += new System.EventHandler(this.tbDOB2_TextChanged);
            // 
            // tbDOB3
            // 
            this.tbDOB3.Location = new System.Drawing.Point(189, 152);
            this.tbDOB3.Name = "tbDOB3";
            this.tbDOB3.Size = new System.Drawing.Size(42, 20);
            this.tbDOB3.TabIndex = 11;
            this.tbDOB3.TextChanged += new System.EventHandler(this.tbDOB3_TextChanged);
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(38, 202);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(205, 13);
            this.lbEmail.TabIndex = 12;
            this.lbEmail.Text = "Please enter the member\'s E-mail address:";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(38, 219);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(200, 20);
            this.tbEmail.TabIndex = 14;
            // 
            // lbMembershipID
            // 
            this.lbMembershipID.AutoSize = true;
            this.lbMembershipID.Location = new System.Drawing.Point(26, 16);
            this.lbMembershipID.Name = "lbMembershipID";
            this.lbMembershipID.Size = new System.Drawing.Size(0, 13);
            this.lbMembershipID.TabIndex = 15;
            // 
            // btnAddMember
            // 
            this.btnAddMember.Location = new System.Drawing.Point(12, 291);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(171, 47);
            this.btnAddMember.TabIndex = 16;
            this.btnAddMember.Text = "Add Member";
            this.btnAddMember.UseVisualStyleBackColor = true;
            this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(191, 315);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(191, 291);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 22);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lbExplanation
            // 
            this.lbExplanation.AutoSize = true;
            this.lbExplanation.Location = new System.Drawing.Point(3, 0);
            this.lbExplanation.Name = "lbExplanation";
            this.lbExplanation.Size = new System.Drawing.Size(164, 13);
            this.lbExplanation.TabIndex = 19;
            this.lbExplanation.Text = "ALL fields with a * are mandatory!";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbMembershipID);
            this.groupBox1.Location = new System.Drawing.Point(162, 245);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(104, 43);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Membership ID:";
            // 
            // rbNFC
            // 
            this.rbNFC.AutoSize = true;
            this.rbNFC.Location = new System.Drawing.Point(41, 246);
            this.rbNFC.Name = "rbNFC";
            this.rbNFC.Size = new System.Drawing.Size(90, 17);
            this.rbNFC.TabIndex = 21;
            this.rbNFC.TabStop = true;
            this.rbNFC.Text = "NFC /Phone/";
            this.rbNFC.UseVisualStyleBackColor = true;
            this.rbNFC.CheckedChanged += new System.EventHandler(this.rbNFC_CheckedChanged);
            // 
            // rbCARD
            // 
            this.rbCARD.AutoSize = true;
            this.rbCARD.Location = new System.Drawing.Point(41, 268);
            this.rbCARD.Name = "rbCARD";
            this.rbCARD.Size = new System.Drawing.Size(81, 17);
            this.rbCARD.TabIndex = 22;
            this.rbCARD.TabStop = true;
            this.rbCARD.Text = "NFC /Card/";
            this.rbCARD.UseVisualStyleBackColor = true;
            this.rbCARD.CheckedChanged += new System.EventHandler(this.rbCARD_CheckedChanged);
            // 
            // FormAddMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 352);
            this.Controls.Add(this.rbCARD);
            this.Controls.Add(this.rbNFC);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbExplanation);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddMember);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.tbDOB3);
            this.Controls.Add(this.tbDOB2);
            this.Controls.Add(this.tbDOB1);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbDOB);
            this.Controls.Add(this.lbLastName);
            this.Controls.Add(this.lbGivenName);
            this.Controls.Add(this.tbGivenName);
            this.Name = "FormAddMember";
            this.Text = "Add Member";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbGivenName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbDOB;
        private System.Windows.Forms.Label lbLastName;
        private System.Windows.Forms.Label lbGivenName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.TextBox tbDOB3;
        private System.Windows.Forms.TextBox tbDOB2;
        private System.Windows.Forms.TextBox tbDOB1;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbMembershipID;
        private System.Windows.Forms.Button btnAddMember;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lbExplanation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbNFC;
        private System.Windows.Forms.RadioButton rbCARD;
    }
}