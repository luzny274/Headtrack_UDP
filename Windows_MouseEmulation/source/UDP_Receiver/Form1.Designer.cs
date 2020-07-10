namespace UDP_Receiver
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SensitivityX = new System.Windows.Forms.HScrollBar();
            this.comboBoxX = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.yawLabel = new System.Windows.Forms.Label();
            this.pitchLabel = new System.Windows.Forms.Label();
            this.rollLabel = new System.Windows.Forms.Label();
            this.invertX = new System.Windows.Forms.CheckBox();
            this.SensitivityY = new System.Windows.Forms.HScrollBar();
            this.comboBoxY = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.invertY = new System.Windows.Forms.CheckBox();
            this.portNumber = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.ipLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.portNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // SensitivityX
            // 
            this.SensitivityX.Location = new System.Drawing.Point(124, 155);
            this.SensitivityX.Maximum = 2000;
            this.SensitivityX.Name = "SensitivityX";
            this.SensitivityX.Size = new System.Drawing.Size(361, 21);
            this.SensitivityX.TabIndex = 0;
            this.SensitivityX.Value = 100;
            this.SensitivityX.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SensitivityX_Scroll);
            // 
            // comboBoxX
            // 
            this.comboBoxX.FormattingEnabled = true;
            this.comboBoxX.Location = new System.Drawing.Point(59, 131);
            this.comboBoxX.Name = "comboBoxX";
            this.comboBoxX.Size = new System.Drawing.Size(121, 21);
            this.comboBoxX.TabIndex = 1;
            this.comboBoxX.SelectedIndexChanged += new System.EventHandler(this.comboBoxX_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(26, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "X:";
            // 
            // yawLabel
            // 
            this.yawLabel.AutoSize = true;
            this.yawLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.yawLabel.Location = new System.Drawing.Point(194, 18);
            this.yawLabel.Name = "yawLabel";
            this.yawLabel.Size = new System.Drawing.Size(58, 23);
            this.yawLabel.TabIndex = 3;
            this.yawLabel.Text = "Yaw: ";
            // 
            // pitchLabel
            // 
            this.pitchLabel.AutoSize = true;
            this.pitchLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pitchLabel.Location = new System.Drawing.Point(194, 50);
            this.pitchLabel.Name = "pitchLabel";
            this.pitchLabel.Size = new System.Drawing.Size(64, 23);
            this.pitchLabel.TabIndex = 3;
            this.pitchLabel.Text = "Pitch: ";
            // 
            // rollLabel
            // 
            this.rollLabel.AutoSize = true;
            this.rollLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rollLabel.Location = new System.Drawing.Point(194, 82);
            this.rollLabel.Name = "rollLabel";
            this.rollLabel.Size = new System.Drawing.Size(58, 23);
            this.rollLabel.TabIndex = 3;
            this.rollLabel.Text = "Roll: ";
            // 
            // invertX
            // 
            this.invertX.AutoSize = true;
            this.invertX.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.invertX.Location = new System.Drawing.Point(186, 130);
            this.invertX.Name = "invertX";
            this.invertX.Size = new System.Drawing.Size(72, 25);
            this.invertX.TabIndex = 4;
            this.invertX.Text = "Invert";
            this.invertX.UseVisualStyleBackColor = true;
            this.invertX.CheckedChanged += new System.EventHandler(this.invertX_CheckedChanged);
            // 
            // SensitivityY
            // 
            this.SensitivityY.Location = new System.Drawing.Point(124, 221);
            this.SensitivityY.Maximum = 2000;
            this.SensitivityY.Name = "SensitivityY";
            this.SensitivityY.Size = new System.Drawing.Size(361, 21);
            this.SensitivityY.TabIndex = 0;
            this.SensitivityY.Value = 100;
            this.SensitivityY.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SensitivityY_Scroll);
            // 
            // comboBoxY
            // 
            this.comboBoxY.FormattingEnabled = true;
            this.comboBoxY.Location = new System.Drawing.Point(59, 197);
            this.comboBoxY.Name = "comboBoxY";
            this.comboBoxY.Size = new System.Drawing.Size(121, 21);
            this.comboBoxY.TabIndex = 1;
            this.comboBoxY.SelectedIndexChanged += new System.EventHandler(this.comboBoxY_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(26, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y:";
            // 
            // invertY
            // 
            this.invertY.AutoSize = true;
            this.invertY.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.invertY.Location = new System.Drawing.Point(186, 196);
            this.invertY.Name = "invertY";
            this.invertY.Size = new System.Drawing.Size(72, 25);
            this.invertY.TabIndex = 4;
            this.invertY.Text = "Invert";
            this.invertY.UseVisualStyleBackColor = true;
            this.invertY.CheckedChanged += new System.EventHandler(this.invertY_CheckedChanged);
            // 
            // portNumber
            // 
            this.portNumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.portNumber.Location = new System.Drawing.Point(228, 307);
            this.portNumber.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.portNumber.Name = "portNumber";
            this.portNumber.Size = new System.Drawing.Size(120, 26);
            this.portNumber.TabIndex = 5;
            this.portNumber.Value = new decimal(new int[] {
            4242,
            0,
            0,
            0});
            this.portNumber.ValueChanged += new System.EventHandler(this.portNumber_ValueChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.Green;
            this.button1.Location = new System.Drawing.Point(217, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ipLabel.Location = new System.Drawing.Point(120, 266);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(149, 21);
            this.ipLabel.TabIndex = 7;
            this.ipLabel.Text = "Local IP Address: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(26, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sensitivity: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(26, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Sensitivity: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(171, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Port: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 381);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.portNumber);
            this.Controls.Add(this.invertY);
            this.Controls.Add(this.invertX);
            this.Controls.Add(this.rollLabel);
            this.Controls.Add(this.pitchLabel);
            this.Controls.Add(this.yawLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxY);
            this.Controls.Add(this.comboBoxX);
            this.Controls.Add(this.SensitivityY);
            this.Controls.Add(this.SensitivityX);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "HeadtrackMouseEmulation";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.portNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar SensitivityX;
        private System.Windows.Forms.ComboBox comboBoxX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label yawLabel;
        private System.Windows.Forms.Label pitchLabel;
        private System.Windows.Forms.Label rollLabel;
        private System.Windows.Forms.CheckBox invertX;
        private System.Windows.Forms.HScrollBar SensitivityY;
        private System.Windows.Forms.ComboBox comboBoxY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox invertY;
        private System.Windows.Forms.NumericUpDown portNumber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

