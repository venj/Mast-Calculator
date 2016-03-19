namespace Mast_Calculator
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
            this.CalculateButton = new System.Windows.Forms.Button();
            this.MaximumLoadTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TotalHeightTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.InitialHeightTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SingleRingRadioButton = new System.Windows.Forms.RadioButton();
            this.DualRingRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SameRadioButton = new System.Windows.Forms.RadioButton();
            this.NotSameRadioButton = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.OptimizeResultCheckBox = new System.Windows.Forms.CheckBox();
            this.HeightDeltaTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MinimumColumeComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.DatabasePathTextBox = new System.Windows.Forms.TextBox();
            this.ChooseButton = new System.Windows.Forms.Button();
            this.CustomDataBaseRadioButton = new System.Windows.Forms.RadioButton();
            this.DefaultDataBaseRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CalculateButton);
            this.groupBox1.Controls.Add(this.MaximumLoadTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TotalHeightTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.InitialHeightTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 107);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic Options";
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(325, 16);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(80, 80);
            this.CalculateButton.TabIndex = 6;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // MaximumLoadTextBox
            // 
            this.MaximumLoadTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximumLoadTextBox.Location = new System.Drawing.Point(134, 73);
            this.MaximumLoadTextBox.Name = "MaximumLoadTextBox";
            this.MaximumLoadTextBox.Size = new System.Drawing.Size(185, 23);
            this.MaximumLoadTextBox.TabIndex = 5;
            this.MaximumLoadTextBox.TextChanged += new System.EventHandler(this.MaximumLoadTextBox_TextChanged);
            this.MaximumLoadTextBox.Leave += new System.EventHandler(this.MaximumLoadTextBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Maximum Load (kg)";
            // 
            // TotalHeightTextBox
            // 
            this.TotalHeightTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TotalHeightTextBox.Location = new System.Drawing.Point(134, 44);
            this.TotalHeightTextBox.Name = "TotalHeightTextBox";
            this.TotalHeightTextBox.Size = new System.Drawing.Size(185, 23);
            this.TotalHeightTextBox.TabIndex = 3;
            this.TotalHeightTextBox.TextChanged += new System.EventHandler(this.TotalHeightTextBox_TextChanged);
            this.TotalHeightTextBox.Leave += new System.EventHandler(this.TotalHeightTextBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(28, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Height (m)";
            // 
            // InitialHeightTextBox
            // 
            this.InitialHeightTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InitialHeightTextBox.Location = new System.Drawing.Point(134, 17);
            this.InitialHeightTextBox.Name = "InitialHeightTextBox";
            this.InitialHeightTextBox.Size = new System.Drawing.Size(185, 23);
            this.InitialHeightTextBox.TabIndex = 1;
            this.InitialHeightTextBox.TextChanged += new System.EventHandler(this.InitialHeightTextBox_TextChanged);
            this.InitialHeightTextBox.Leave += new System.EventHandler(this.InitialHeightTextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Initial Height (m)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SingleRingRadioButton);
            this.groupBox2.Controls.Add(this.DualRingRadioButton);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(13, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(128, 89);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Piston Type";
            // 
            // SingleRingRadioButton
            // 
            this.SingleRingRadioButton.AutoSize = true;
            this.SingleRingRadioButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SingleRingRadioButton.Location = new System.Drawing.Point(10, 53);
            this.SingleRingRadioButton.Name = "SingleRingRadioButton";
            this.SingleRingRadioButton.Size = new System.Drawing.Size(91, 21);
            this.SingleRingRadioButton.TabIndex = 11;
            this.SingleRingRadioButton.TabStop = true;
            this.SingleRingRadioButton.Text = "Single Ring";
            this.SingleRingRadioButton.UseVisualStyleBackColor = true;
            // 
            // DualRingRadioButton
            // 
            this.DualRingRadioButton.AutoSize = true;
            this.DualRingRadioButton.Checked = true;
            this.DualRingRadioButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DualRingRadioButton.Location = new System.Drawing.Point(10, 26);
            this.DualRingRadioButton.Name = "DualRingRadioButton";
            this.DualRingRadioButton.Size = new System.Drawing.Size(82, 21);
            this.DualRingRadioButton.TabIndex = 10;
            this.DualRingRadioButton.TabStop = true;
            this.DualRingRadioButton.Text = "Dual Ring";
            this.DualRingRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SameRadioButton);
            this.groupBox3.Controls.Add(this.NotSameRadioButton);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(14, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(128, 95);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Movable Height";
            // 
            // SameRadioButton
            // 
            this.SameRadioButton.AutoSize = true;
            this.SameRadioButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SameRadioButton.Location = new System.Drawing.Point(9, 56);
            this.SameRadioButton.Name = "SameRadioButton";
            this.SameRadioButton.Size = new System.Drawing.Size(58, 21);
            this.SameRadioButton.TabIndex = 11;
            this.SameRadioButton.TabStop = true;
            this.SameRadioButton.Text = "Same";
            this.SameRadioButton.UseVisualStyleBackColor = true;
            // 
            // NotSameRadioButton
            // 
            this.NotSameRadioButton.AutoSize = true;
            this.NotSameRadioButton.Checked = true;
            this.NotSameRadioButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NotSameRadioButton.Location = new System.Drawing.Point(9, 29);
            this.NotSameRadioButton.Name = "NotSameRadioButton";
            this.NotSameRadioButton.Size = new System.Drawing.Size(84, 21);
            this.NotSameRadioButton.TabIndex = 10;
            this.NotSameRadioButton.TabStop = true;
            this.NotSameRadioButton.Text = "Not Same";
            this.NotSameRadioButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(22, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Minimum Colume";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.OptimizeResultCheckBox);
            this.groupBox4.Controls.Add(this.HeightDeltaTextBox);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.MinimumColumeComboBox);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(148, 127);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(276, 104);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Other Options";
            // 
            // OptimizeResultCheckBox
            // 
            this.OptimizeResultCheckBox.AutoSize = true;
            this.OptimizeResultCheckBox.Checked = true;
            this.OptimizeResultCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OptimizeResultCheckBox.Location = new System.Drawing.Point(138, 78);
            this.OptimizeResultCheckBox.Name = "OptimizeResultCheckBox";
            this.OptimizeResultCheckBox.Size = new System.Drawing.Size(124, 21);
            this.OptimizeResultCheckBox.TabIndex = 16;
            this.OptimizeResultCheckBox.Text = "Optimize Results";
            this.OptimizeResultCheckBox.UseVisualStyleBackColor = true;
            // 
            // HeightDeltaTextBox
            // 
            this.HeightDeltaTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HeightDeltaTextBox.Location = new System.Drawing.Point(138, 49);
            this.HeightDeltaTextBox.Name = "HeightDeltaTextBox";
            this.HeightDeltaTextBox.Size = new System.Drawing.Size(132, 23);
            this.HeightDeltaTextBox.TabIndex = 7;
            this.HeightDeltaTextBox.TextChanged += new System.EventHandler(this.HeightDeltaTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(19, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Height Delta (mm)";
            // 
            // MinimumColumeComboBox
            // 
            this.MinimumColumeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MinimumColumeComboBox.FormattingEnabled = true;
            this.MinimumColumeComboBox.Items.AddRange(new object[] {
            "Any",
            "30",
            "46",
            "60",
            "75",
            "90",
            "110",
            "130",
            "150",
            "170",
            "190",
            "215"});
            this.MinimumColumeComboBox.Location = new System.Drawing.Point(138, 19);
            this.MinimumColumeComboBox.Name = "MinimumColumeComboBox";
            this.MinimumColumeComboBox.Size = new System.Drawing.Size(132, 25);
            this.MinimumColumeComboBox.TabIndex = 14;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.DatabasePathTextBox);
            this.groupBox5.Controls.Add(this.ChooseButton);
            this.groupBox5.Controls.Add(this.CustomDataBaseRadioButton);
            this.groupBox5.Controls.Add(this.DefaultDataBaseRadioButton);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(148, 238);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(276, 78);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Mast Database";
            // 
            // DatabasePathTextBox
            // 
            this.DatabasePathTextBox.Enabled = false;
            this.DatabasePathTextBox.Location = new System.Drawing.Point(149, 45);
            this.DatabasePathTextBox.Name = "DatabasePathTextBox";
            this.DatabasePathTextBox.Size = new System.Drawing.Size(121, 23);
            this.DatabasePathTextBox.TabIndex = 15;
            // 
            // ChooseButton
            // 
            this.ChooseButton.Enabled = false;
            this.ChooseButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChooseButton.Location = new System.Drawing.Point(82, 45);
            this.ChooseButton.Name = "ChooseButton";
            this.ChooseButton.Size = new System.Drawing.Size(61, 23);
            this.ChooseButton.TabIndex = 14;
            this.ChooseButton.Text = "Choose";
            this.ChooseButton.UseVisualStyleBackColor = true;
            this.ChooseButton.Click += new System.EventHandler(this.ChooseButton_Click);
            // 
            // CustomDataBaseRadioButton
            // 
            this.CustomDataBaseRadioButton.AutoSize = true;
            this.CustomDataBaseRadioButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CustomDataBaseRadioButton.Location = new System.Drawing.Point(6, 45);
            this.CustomDataBaseRadioButton.Name = "CustomDataBaseRadioButton";
            this.CustomDataBaseRadioButton.Size = new System.Drawing.Size(70, 21);
            this.CustomDataBaseRadioButton.TabIndex = 13;
            this.CustomDataBaseRadioButton.TabStop = true;
            this.CustomDataBaseRadioButton.Text = "Custom";
            this.CustomDataBaseRadioButton.UseVisualStyleBackColor = true;
            this.CustomDataBaseRadioButton.CheckedChanged += new System.EventHandler(this.dataBaseRadioButton_CheckedChanged);
            // 
            // DefaultDataBaseRadioButton
            // 
            this.DefaultDataBaseRadioButton.AutoSize = true;
            this.DefaultDataBaseRadioButton.Checked = true;
            this.DefaultDataBaseRadioButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DefaultDataBaseRadioButton.Location = new System.Drawing.Point(6, 22);
            this.DefaultDataBaseRadioButton.Name = "DefaultDataBaseRadioButton";
            this.DefaultDataBaseRadioButton.Size = new System.Drawing.Size(67, 21);
            this.DefaultDataBaseRadioButton.TabIndex = 12;
            this.DefaultDataBaseRadioButton.TabStop = true;
            this.DefaultDataBaseRadioButton.Text = "Default";
            this.DefaultDataBaseRadioButton.UseVisualStyleBackColor = true;
            this.DefaultDataBaseRadioButton.CheckedChanged += new System.EventHandler(this.dataBaseRadioButton_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 329);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Mast Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TotalHeightTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox InitialHeightTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MaximumLoadTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton SingleRingRadioButton;
        private System.Windows.Forms.RadioButton DualRingRadioButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton SameRadioButton;
        private System.Windows.Forms.RadioButton NotSameRadioButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox MinimumColumeComboBox;
        private System.Windows.Forms.TextBox HeightDeltaTextBox;
        private System.Windows.Forms.CheckBox OptimizeResultCheckBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton CustomDataBaseRadioButton;
        private System.Windows.Forms.RadioButton DefaultDataBaseRadioButton;
        private System.Windows.Forms.Button ChooseButton;
        private System.Windows.Forms.TextBox DatabasePathTextBox;
    }
}

