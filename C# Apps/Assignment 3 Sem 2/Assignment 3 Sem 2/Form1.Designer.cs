namespace Assignment_3_Sem_2
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
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.lbComLog = new System.Windows.Forms.ListBox();
            this.timerLb = new System.Windows.Forms.Timer(this.components);
            this.lblComLog = new System.Windows.Forms.Label();
            this.lbSensors = new System.Windows.Forms.ListBox();
            this.lblSensors = new System.Windows.Forms.Label();
            this.lblNamel = new System.Windows.Forms.Label();
            this.lblValuel = new System.Windows.Forms.Label();
            this.lblUnitl = new System.Windows.Forms.Label();
            this.lblDatel = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(176, 83);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(433, 292);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Press to start the server";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbComLog
            // 
            this.lbComLog.FormattingEnabled = true;
            this.lbComLog.ItemHeight = 16;
            this.lbComLog.Location = new System.Drawing.Point(520, 50);
            this.lbComLog.Name = "lbComLog";
            this.lbComLog.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbComLog.Size = new System.Drawing.Size(268, 388);
            this.lbComLog.TabIndex = 1;
            // 
            // timerLb
            // 
            this.timerLb.Enabled = true;
            this.timerLb.Interval = 10;
            this.timerLb.Tick += new System.EventHandler(this.timerLb_Tick);
            // 
            // lblComLog
            // 
            this.lblComLog.AutoSize = true;
            this.lblComLog.Location = new System.Drawing.Point(517, 19);
            this.lblComLog.Name = "lblComLog";
            this.lblComLog.Size = new System.Drawing.Size(136, 17);
            this.lblComLog.TabIndex = 3;
            this.lblComLog.Text = "Communication Log:";
            // 
            // lbSensors
            // 
            this.lbSensors.FormattingEnabled = true;
            this.lbSensors.ItemHeight = 16;
            this.lbSensors.Location = new System.Drawing.Point(225, 50);
            this.lbSensors.Name = "lbSensors";
            this.lbSensors.Size = new System.Drawing.Size(264, 388);
            this.lbSensors.TabIndex = 4;
            this.lbSensors.SelectedIndexChanged += new System.EventHandler(this.lbSensors_SelectedIndexChanged);
            // 
            // lblSensors
            // 
            this.lblSensors.AutoSize = true;
            this.lblSensors.Location = new System.Drawing.Point(225, 19);
            this.lblSensors.Name = "lblSensors";
            this.lblSensors.Size = new System.Drawing.Size(134, 17);
            this.lblSensors.TabIndex = 5;
            this.lblSensors.Text = "Sensors connected:";
            // 
            // lblNamel
            // 
            this.lblNamel.AutoSize = true;
            this.lblNamel.Location = new System.Drawing.Point(21, 50);
            this.lblNamel.Name = "lblNamel";
            this.lblNamel.Size = new System.Drawing.Size(49, 17);
            this.lblNamel.TabIndex = 6;
            this.lblNamel.Text = "Name:";
            // 
            // lblValuel
            // 
            this.lblValuel.AutoSize = true;
            this.lblValuel.Location = new System.Drawing.Point(21, 122);
            this.lblValuel.Name = "lblValuel";
            this.lblValuel.Size = new System.Drawing.Size(105, 17);
            this.lblValuel.TabIndex = 7;
            this.lblValuel.Text = "Average Value:";
            // 
            // lblUnitl
            // 
            this.lblUnitl.AutoSize = true;
            this.lblUnitl.Location = new System.Drawing.Point(21, 208);
            this.lblUnitl.Name = "lblUnitl";
            this.lblUnitl.Size = new System.Drawing.Size(37, 17);
            this.lblUnitl.TabIndex = 8;
            this.lblUnitl.Text = "Unit:";
            // 
            // lblDatel
            // 
            this.lblDatel.AutoSize = true;
            this.lblDatel.Location = new System.Drawing.Point(21, 291);
            this.lblDatel.Name = "lblDatel";
            this.lblDatel.Size = new System.Drawing.Size(86, 17);
            this.lblDatel.TabIndex = 9;
            this.lblDatel.Text = "Date added:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(24, 71);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 17);
            this.lblName.TabIndex = 10;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(24, 143);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(0, 17);
            this.lblValue.TabIndex = 11;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(24, 229);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(0, 17);
            this.lblUnit.TabIndex = 12;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(27, 312);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 17);
            this.lblDate.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblDatel);
            this.Controls.Add(this.lblUnitl);
            this.Controls.Add(this.lblValuel);
            this.Controls.Add(this.lblNamel);
            this.Controls.Add(this.lblSensors);
            this.Controls.Add(this.lbSensors);
            this.Controls.Add(this.lblComLog);
            this.Controls.Add(this.lbComLog);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        public System.Windows.Forms.ListBox lbComLog;
        private System.Windows.Forms.Timer timerLb;
        private System.Windows.Forms.Label lblComLog;
        private System.Windows.Forms.ListBox lbSensors;
        private System.Windows.Forms.Label lblSensors;
        private System.Windows.Forms.Label lblNamel;
        private System.Windows.Forms.Label lblValuel;
        private System.Windows.Forms.Label lblUnitl;
        private System.Windows.Forms.Label lblDatel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblDate;
    }
}

