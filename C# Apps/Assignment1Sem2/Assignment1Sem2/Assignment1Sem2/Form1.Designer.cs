namespace Assignment1Sem2
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPaid = new System.Windows.Forms.Button();
            this.btnRemoveMember = new System.Windows.Forms.Button();
            this.btnAddMember = new System.Windows.Forms.Button();
            this.cbBilliards = new System.Windows.Forms.CheckBox();
            this.cbDance = new System.Windows.Forms.CheckBox();
            this.cbGym = new System.Windows.Forms.CheckBox();
            this.cbSwimmingPool = new System.Windows.Forms.CheckBox();
            this.lbPackageName = new System.Windows.Forms.Label();
            this.listBoxMembers = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbForget = new System.Windows.Forms.Label();
            this.lbWish = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbAnnouncement = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbCARD = new System.Windows.Forms.RadioButton();
            this.rbNFC = new System.Windows.Forms.RadioButton();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.pbAccess = new System.Windows.Forms.PictureBox();
            this.lbLogo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccess)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Khaki;
            this.groupBox1.Controls.Add(this.btnPaid);
            this.groupBox1.Controls.Add(this.btnRemoveMember);
            this.groupBox1.Controls.Add(this.btnAddMember);
            this.groupBox1.Controls.Add(this.cbBilliards);
            this.groupBox1.Controls.Add(this.cbDance);
            this.groupBox1.Controls.Add(this.cbGym);
            this.groupBox1.Controls.Add(this.cbSwimmingPool);
            this.groupBox1.Controls.Add(this.lbPackageName);
            this.groupBox1.Controls.Add(this.listBoxMembers);
            this.groupBox1.Location = new System.Drawing.Point(12, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 359);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Members";
            // 
            // btnPaid
            // 
            this.btnPaid.Location = new System.Drawing.Point(366, 271);
            this.btnPaid.Name = "btnPaid";
            this.btnPaid.Size = new System.Drawing.Size(87, 23);
            this.btnPaid.TabIndex = 8;
            this.btnPaid.Text = "User Paid";
            this.btnPaid.UseVisualStyleBackColor = true;
            this.btnPaid.Click += new System.EventHandler(this.btnPaid_Click);
            // 
            // btnRemoveMember
            // 
            this.btnRemoveMember.Location = new System.Drawing.Point(184, 325);
            this.btnRemoveMember.Name = "btnRemoveMember";
            this.btnRemoveMember.Size = new System.Drawing.Size(133, 23);
            this.btnRemoveMember.TabIndex = 7;
            this.btnRemoveMember.Text = "Remove Member";
            this.btnRemoveMember.UseVisualStyleBackColor = true;
            this.btnRemoveMember.Click += new System.EventHandler(this.btnRemoveMember_Click);
            // 
            // btnAddMember
            // 
            this.btnAddMember.Location = new System.Drawing.Point(7, 325);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(130, 23);
            this.btnAddMember.TabIndex = 6;
            this.btnAddMember.Text = "Add Member";
            this.btnAddMember.UseVisualStyleBackColor = true;
            this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
            // 
            // cbBilliards
            // 
            this.cbBilliards.AutoSize = true;
            this.cbBilliards.Location = new System.Drawing.Point(376, 232);
            this.cbBilliards.Name = "cbBilliards";
            this.cbBilliards.Size = new System.Drawing.Size(61, 17);
            this.cbBilliards.TabIndex = 5;
            this.cbBilliards.Text = "Billiards";
            this.cbBilliards.UseVisualStyleBackColor = true;
            this.cbBilliards.Click += new System.EventHandler(this.cbBilliards_Click);
            // 
            // cbDance
            // 
            this.cbDance.AutoSize = true;
            this.cbDance.Location = new System.Drawing.Point(376, 195);
            this.cbDance.Name = "cbDance";
            this.cbDance.Size = new System.Drawing.Size(58, 17);
            this.cbDance.TabIndex = 4;
            this.cbDance.Text = "Dance";
            this.cbDance.UseVisualStyleBackColor = true;
            this.cbDance.Click += new System.EventHandler(this.cbDance_Click);
            // 
            // cbGym
            // 
            this.cbGym.AutoSize = true;
            this.cbGym.Location = new System.Drawing.Point(376, 154);
            this.cbGym.Name = "cbGym";
            this.cbGym.Size = new System.Drawing.Size(47, 17);
            this.cbGym.TabIndex = 3;
            this.cbGym.Text = "Gym";
            this.cbGym.UseVisualStyleBackColor = true;
            this.cbGym.Click += new System.EventHandler(this.cbGym_Click);
            // 
            // cbSwimmingPool
            // 
            this.cbSwimmingPool.AutoSize = true;
            this.cbSwimmingPool.Location = new System.Drawing.Point(376, 118);
            this.cbSwimmingPool.Name = "cbSwimmingPool";
            this.cbSwimmingPool.Size = new System.Drawing.Size(97, 17);
            this.cbSwimmingPool.TabIndex = 2;
            this.cbSwimmingPool.Text = "Swimming Pool";
            this.cbSwimmingPool.UseVisualStyleBackColor = true;
            this.cbSwimmingPool.Click += new System.EventHandler(this.cbSwimmingPool_Click);
            // 
            // lbPackageName
            // 
            this.lbPackageName.AutoSize = true;
            this.lbPackageName.Location = new System.Drawing.Point(363, 81);
            this.lbPackageName.Name = "lbPackageName";
            this.lbPackageName.Size = new System.Drawing.Size(103, 13);
            this.lbPackageName.TabIndex = 1;
            this.lbPackageName.Text = "Packages Selected:";
            // 
            // listBoxMembers
            // 
            this.listBoxMembers.FormattingEnabled = true;
            this.listBoxMembers.Location = new System.Drawing.Point(7, 42);
            this.listBoxMembers.Name = "listBoxMembers";
            this.listBoxMembers.Size = new System.Drawing.Size(310, 277);
            this.listBoxMembers.TabIndex = 0;
            this.listBoxMembers.SelectedIndexChanged += new System.EventHandler(this.listBoxMembers_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Pink;
            this.groupBox2.Controls.Add(this.lbForget);
            this.groupBox2.Controls.Add(this.lbWish);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lbAnnouncement);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.rbCARD);
            this.groupBox2.Controls.Add(this.rbNFC);
            this.groupBox2.Controls.Add(this.tbCode);
            this.groupBox2.Controls.Add(this.cbArea);
            this.groupBox2.Controls.Add(this.pbAccess);
            this.groupBox2.Location = new System.Drawing.Point(574, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 359);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Access";
            // 
            // lbForget
            // 
            this.lbForget.AutoSize = true;
            this.lbForget.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbForget.Location = new System.Drawing.Point(8, 313);
            this.lbForget.Name = "lbForget";
            this.lbForget.Size = new System.Drawing.Size(200, 17);
            this.lbForget.TabIndex = 10;
            this.lbForget.Text = "Do not forget your phone !";
            // 
            // lbWish
            // 
            this.lbWish.AutoSize = true;
            this.lbWish.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWish.Location = new System.Drawing.Point(35, 280);
            this.lbWish.Name = "lbWish";
            this.lbWish.Size = new System.Drawing.Size(133, 17);
            this.lbWish.TabIndex = 9;
            this.lbWish.Text = "Happy something";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Enter code here:";
            // 
            // lbAnnouncement
            // 
            this.lbAnnouncement.AutoSize = true;
            this.lbAnnouncement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAnnouncement.Location = new System.Drawing.Point(9, 260);
            this.lbAnnouncement.Name = "lbAnnouncement";
            this.lbAnnouncement.Size = new System.Drawing.Size(189, 20);
            this.lbAnnouncement.TabIndex = 8;
            this.lbAnnouncement.Text = "Welcome, Mr. Vasilev !";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Which scanner does the member use ?";
            // 
            // rbCARD
            // 
            this.rbCARD.AutoSize = true;
            this.rbCARD.Location = new System.Drawing.Point(25, 75);
            this.rbCARD.Name = "rbCARD";
            this.rbCARD.Size = new System.Drawing.Size(90, 17);
            this.rbCARD.TabIndex = 5;
            this.rbCARD.TabStop = true;
            this.rbCARD.Text = "Card Scanner";
            this.rbCARD.UseVisualStyleBackColor = true;
            this.rbCARD.CheckedChanged += new System.EventHandler(this.rbCARD_CheckedChanged);
            // 
            // rbNFC
            // 
            this.rbNFC.AutoSize = true;
            this.rbNFC.Location = new System.Drawing.Point(25, 51);
            this.rbNFC.Name = "rbNFC";
            this.rbNFC.Size = new System.Drawing.Size(121, 17);
            this.rbNFC.TabIndex = 4;
            this.rbNFC.TabStop = true;
            this.rbNFC.Text = "NFC Phone scanner";
            this.rbNFC.UseVisualStyleBackColor = true;
            this.rbNFC.CheckedChanged += new System.EventHandler(this.rbNFC_CheckedChanged);
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(25, 127);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(172, 20);
            this.tbCode.TabIndex = 1;
            this.tbCode.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cbArea
            // 
            this.cbArea.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Items.AddRange(new object[] {
            "Billiards",
            "Gym",
            "Swimming Pool",
            "Dance"});
            this.cbArea.Location = new System.Drawing.Point(28, 168);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(169, 21);
            this.cbArea.TabIndex = 0;
            this.cbArea.DropDownClosed += new System.EventHandler(this.cbArea_DropDownClosed);
            // 
            // pbAccess
            // 
            this.pbAccess.Location = new System.Drawing.Point(9, 215);
            this.pbAccess.Name = "pbAccess";
            this.pbAccess.Size = new System.Drawing.Size(199, 141);
            this.pbAccess.TabIndex = 3;
            this.pbAccess.TabStop = false;
            // 
            // lbLogo
            // 
            this.lbLogo.AutoSize = true;
            this.lbLogo.Font = new System.Drawing.Font("Arial", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogo.Location = new System.Drawing.Point(151, 9);
            this.lbLogo.Name = "lbLogo";
            this.lbLogo.Size = new System.Drawing.Size(498, 63);
            this.lbLogo.TabIndex = 2;
            this.lbLogo.Text = "L I F E S P O R T S";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbLogo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "LIFESPORTS Managing App";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemoveMember;
        private System.Windows.Forms.Button btnAddMember;
        private System.Windows.Forms.CheckBox cbBilliards;
        private System.Windows.Forms.CheckBox cbDance;
        private System.Windows.Forms.CheckBox cbGym;
        private System.Windows.Forms.CheckBox cbSwimmingPool;
        private System.Windows.Forms.Label lbPackageName;
        private System.Windows.Forms.ListBox listBoxMembers;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbAccess;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.ComboBox cbArea;
        private System.Windows.Forms.Label lbLogo;
        private System.Windows.Forms.Button btnPaid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbAnnouncement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbCARD;
        private System.Windows.Forms.RadioButton rbNFC;
        private System.Windows.Forms.Label lbWish;
        private System.Windows.Forms.Label lbForget;
    }
}

