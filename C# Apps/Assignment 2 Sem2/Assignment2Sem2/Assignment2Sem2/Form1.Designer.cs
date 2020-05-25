namespace Assignment2Sem2
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
            this.cbOp = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lbDesc = new System.Windows.Forms.Label();
            this.lbNumberOfGates = new System.Windows.Forms.Label();
            this.lbGates = new System.Windows.Forms.ListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbOp
            // 
            this.cbOp.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOp.FormattingEnabled = true;
            this.cbOp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbOp.Items.AddRange(new object[] {
            "NOT Gate",
            "AND Gate",
            "OR Gate",
            "XOR Gate",
            "Half Adder",
            "Full Adder"});
            this.cbOp.Location = new System.Drawing.Point(46, 72);
            this.cbOp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbOp.Name = "cbOp";
            this.cbOp.Size = new System.Drawing.Size(331, 21);
            this.cbOp.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(46, 107);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(330, 24);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lbDesc
            // 
            this.lbDesc.AutoSize = true;
            this.lbDesc.Location = new System.Drawing.Point(9, 29);
            this.lbDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(164, 15);
            this.lbDesc.TabIndex = 2;
            this.lbDesc.Text = "Please select a GATE to add:";
            // 
            // lbNumberOfGates
            // 
            this.lbNumberOfGates.AutoSize = true;
            this.lbNumberOfGates.Location = new System.Drawing.Point(9, 7);
            this.lbNumberOfGates.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNumberOfGates.Name = "lbNumberOfGates";
            this.lbNumberOfGates.Size = new System.Drawing.Size(0, 15);
            this.lbNumberOfGates.TabIndex = 3;
            // 
            // lbGates
            // 
            this.lbGates.FormattingEnabled = true;
            this.lbGates.Location = new System.Drawing.Point(11, 149);
            this.lbGates.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbGates.Name = "lbGates";
            this.lbGates.Size = new System.Drawing.Size(397, 173);
            this.lbGates.TabIndex = 4;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(116, 326);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(193, 29);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 362);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lbGates);
            this.Controls.Add(this.lbNumberOfGates);
            this.Controls.Add(this.lbDesc);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cbOp);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lbDesc;
        private System.Windows.Forms.Label lbNumberOfGates;
        private System.Windows.Forms.ListBox lbGates;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ComboBox cbOp;
    }
}

