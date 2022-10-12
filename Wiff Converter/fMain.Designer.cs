using System.Windows.Forms;

namespace Wiff_Converter
{
    partial class fMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConvert = new System.Windows.Forms.Button();
            this.cbNormalizeToTIC = new System.Windows.Forms.CheckBox();
            this.tbFilenames = new System.Windows.Forms.TextBox();
            this.btnChangeDir = new System.Windows.Forms.Button();
            this.tbOutputDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cbDecimalSeparator = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDelimiter = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbExtension = new System.Windows.Forms.ComboBox();
            this.nudSignificantFigures = new System.Windows.Forms.NumericUpDown();
            this.lblNumberSig = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbExportFormat = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbCropT0 = new System.Windows.Forms.TextBox();
            this.tbCropW0 = new System.Windows.Forms.TextBox();
            this.tbCropM0 = new System.Windows.Forms.TextBox();
            this.tbCropT1 = new System.Windows.Forms.TextBox();
            this.tbCropW1 = new System.Windows.Forms.TextBox();
            this.tbCropM1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudSignificantFigures)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(280, 417);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(110, 20);
            this.btnConvert.TabIndex = 17;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // cbNormalizeToTIC
            // 
            this.cbNormalizeToTIC.AutoSize = true;
            this.cbNormalizeToTIC.Location = new System.Drawing.Point(10, 420);
            this.cbNormalizeToTIC.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbNormalizeToTIC.Name = "cbNormalizeToTIC";
            this.cbNormalizeToTIC.Size = new System.Drawing.Size(161, 17);
            this.cbNormalizeToTIC.TabIndex = 16;
            this.cbNormalizeToTIC.Text = "Normalize MS spectra to TIC";
            this.cbNormalizeToTIC.UseVisualStyleBackColor = true;
            // 
            // tbFilenames
            // 
            this.tbFilenames.Location = new System.Drawing.Point(10, 36);
            this.tbFilenames.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbFilenames.Multiline = true;
            this.tbFilenames.Name = "tbFilenames";
            this.tbFilenames.ReadOnly = true;
            this.tbFilenames.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbFilenames.Size = new System.Drawing.Size(380, 83);
            this.tbFilenames.TabIndex = 1;
            this.tbFilenames.WordWrap = false;
            // 
            // btnChangeDir
            // 
            this.btnChangeDir.Location = new System.Drawing.Point(366, 141);
            this.btnChangeDir.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnChangeDir.Name = "btnChangeDir";
            this.btnChangeDir.Size = new System.Drawing.Size(24, 20);
            this.btnChangeDir.TabIndex = 4;
            this.btnChangeDir.Text = "...";
            this.btnChangeDir.UseVisualStyleBackColor = true;
            this.btnChangeDir.Click += new System.EventHandler(this.btnChangeDir_Click);
            // 
            // tbOutputDir
            // 
            this.tbOutputDir.Location = new System.Drawing.Point(10, 141);
            this.tbOutputDir.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbOutputDir.Name = "tbOutputDir";
            this.tbOutputDir.ReadOnly = true;
            this.tbOutputDir.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOutputDir.Size = new System.Drawing.Size(352, 20);
            this.tbOutputDir.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Output directory:";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(10, 10);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(83, 20);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load Files";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cbDecimalSeparator
            // 
            this.cbDecimalSeparator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDecimalSeparator.FormattingEnabled = true;
            this.cbDecimalSeparator.Location = new System.Drawing.Point(167, 13);
            this.cbDecimalSeparator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbDecimalSeparator.Name = "cbDecimalSeparator";
            this.cbDecimalSeparator.Size = new System.Drawing.Size(203, 21);
            this.cbDecimalSeparator.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Decimal separator:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Delimiter:";
            // 
            // cbDelimiter
            // 
            this.cbDelimiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDelimiter.FormattingEnabled = true;
            this.cbDelimiter.Location = new System.Drawing.Point(167, 40);
            this.cbDelimiter.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbDelimiter.Name = "cbDelimiter";
            this.cbDelimiter.Size = new System.Drawing.Size(203, 21);
            this.cbDelimiter.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 70);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "File extension:";
            // 
            // cbExtension
            // 
            this.cbExtension.FormattingEnabled = true;
            this.cbExtension.Location = new System.Drawing.Point(167, 67);
            this.cbExtension.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbExtension.Name = "cbExtension";
            this.cbExtension.Size = new System.Drawing.Size(203, 21);
            this.cbExtension.TabIndex = 7;
            // 
            // nudSignificantFigures
            // 
            this.nudSignificantFigures.Location = new System.Drawing.Point(167, 94);
            this.nudSignificantFigures.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nudSignificantFigures.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudSignificantFigures.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSignificantFigures.Name = "nudSignificantFigures";
            this.nudSignificantFigures.Size = new System.Drawing.Size(203, 20);
            this.nudSignificantFigures.TabIndex = 8;
            this.nudSignificantFigures.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // lblNumberSig
            // 
            this.lblNumberSig.AutoSize = true;
            this.lblNumberSig.Location = new System.Drawing.Point(5, 91);
            this.lblNumberSig.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumberSig.Name = "lblNumberSig";
            this.lblNumberSig.Size = new System.Drawing.Size(253, 13);
            this.lblNumberSig.TabIndex = 4;
            this.lblNumberSig.Text = "Number of significant figures\\n of exported numbers:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 123);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Export format:";
            // 
            // cbExportFormat
            // 
            this.cbExportFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExportFormat.FormattingEnabled = true;
            this.cbExportFormat.Location = new System.Drawing.Point(167, 120);
            this.cbExportFormat.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbExportFormat.Name = "cbExportFormat";
            this.cbExportFormat.Size = new System.Drawing.Size(203, 21);
            this.cbExportFormat.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbCropM1);
            this.groupBox1.Controls.Add(this.tbCropM0);
            this.groupBox1.Controls.Add(this.tbCropW1);
            this.groupBox1.Controls.Add(this.tbCropW0);
            this.groupBox1.Controls.Add(this.tbCropT1);
            this.groupBox1.Controls.Add(this.tbCropT0);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(10, 323);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 91);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Matrix crop options";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.nudSignificantFigures);
            this.groupBox2.Controls.Add(this.cbDecimalSeparator);
            this.groupBox2.Controls.Add(this.cbExtension);
            this.groupBox2.Controls.Add(this.cbExportFormat);
            this.groupBox2.Controls.Add(this.lblNumberSig);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbDelimiter);
            this.groupBox2.Location = new System.Drawing.Point(10, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 150);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Export options";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 40);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Start:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(183, 16);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Wavelength";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(92, 16);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Time";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 64);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "End:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(306, 16);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "m/z";
            // 
            // tbCropT0
            // 
            this.tbCropT0.Location = new System.Drawing.Point(58, 37);
            this.tbCropT0.Name = "tbCropT0";
            this.tbCropT0.Size = new System.Drawing.Size(100, 20);
            this.tbCropT0.TabIndex = 10;
            // 
            // tbCropW0
            // 
            this.tbCropW0.Location = new System.Drawing.Point(164, 37);
            this.tbCropW0.Name = "tbCropW0";
            this.tbCropW0.Size = new System.Drawing.Size(100, 20);
            this.tbCropW0.TabIndex = 12;
            // 
            // tbCropM0
            // 
            this.tbCropM0.Location = new System.Drawing.Point(270, 37);
            this.tbCropM0.Name = "tbCropM0";
            this.tbCropM0.Size = new System.Drawing.Size(100, 20);
            this.tbCropM0.TabIndex = 14;
            // 
            // tbCropT1
            // 
            this.tbCropT1.Location = new System.Drawing.Point(58, 61);
            this.tbCropT1.Name = "tbCropT1";
            this.tbCropT1.Size = new System.Drawing.Size(100, 20);
            this.tbCropT1.TabIndex = 11;
            // 
            // tbCropW1
            // 
            this.tbCropW1.Location = new System.Drawing.Point(164, 61);
            this.tbCropW1.Name = "tbCropW1";
            this.tbCropW1.Size = new System.Drawing.Size(100, 20);
            this.tbCropW1.TabIndex = 13;
            // 
            // tbCropM1
            // 
            this.tbCropM1.Location = new System.Drawing.Point(270, 61);
            this.tbCropM1.Name = "tbCropM1";
            this.tbCropM1.Size = new System.Drawing.Size(100, 20);
            this.tbCropM1.TabIndex = 15;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 443);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cbNormalizeToTIC);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChangeDir);
            this.Controls.Add(this.tbOutputDir);
            this.Controls.Add(this.tbFilenames);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnConvert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "fMain";
            this.Text = "Wiff Converter";
            this.Load += new System.EventHandler(this.fMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSignificantFigures)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnConvert;
        private CheckBox cbNormalizeToTIC;
        private TextBox tbFilenames;
        private TextBox tbOutputDir;
        private Button btnChangeDir;
        private Label label1;
        private Button btnLoad;
        private ComboBox cbDecimalSeparator;
        private Label label2;
        private Label label3;
        private ComboBox cbDelimiter;
        private Label label4;
        private ComboBox cbExtension;
        private NumericUpDown nudSignificantFigures;
        private Label lblNumberSig;
        private Label label5;
        private ComboBox cbExportFormat;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label8;
        private Label label7;
        private Label label9;
        private Label label6;
        private TextBox tbCropM1;
        private TextBox tbCropM0;
        private TextBox tbCropW1;
        private TextBox tbCropW0;
        private TextBox tbCropT1;
        private TextBox tbCropT0;
        private Label label10;
    }
}