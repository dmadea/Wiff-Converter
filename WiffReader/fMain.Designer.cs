namespace WiffReader
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
            ((System.ComponentModel.ISupportInitialize)(this.nudSignificantFigures)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(11, 377);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(97, 23);
            this.btnConvert.TabIndex = 0;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // cbNormalizeToTIC
            // 
            this.cbNormalizeToTIC.AutoSize = true;
            this.cbNormalizeToTIC.Location = new System.Drawing.Point(11, 352);
            this.cbNormalizeToTIC.Name = "cbNormalizeToTIC";
            this.cbNormalizeToTIC.Size = new System.Drawing.Size(175, 19);
            this.cbNormalizeToTIC.TabIndex = 1;
            this.cbNormalizeToTIC.Text = "Normalize MS spectra to TIC";
            this.cbNormalizeToTIC.UseVisualStyleBackColor = true;
            // 
            // tbFilenames
            // 
            this.tbFilenames.Location = new System.Drawing.Point(12, 41);
            this.tbFilenames.Multiline = true;
            this.tbFilenames.Name = "tbFilenames";
            this.tbFilenames.ReadOnly = true;
            this.tbFilenames.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbFilenames.Size = new System.Drawing.Size(354, 95);
            this.tbFilenames.TabIndex = 2;
            this.tbFilenames.WordWrap = false;
            // 
            // btnChangeDir
            // 
            this.btnChangeDir.Location = new System.Drawing.Point(338, 156);
            this.btnChangeDir.Name = "btnChangeDir";
            this.btnChangeDir.Size = new System.Drawing.Size(28, 23);
            this.btnChangeDir.TabIndex = 3;
            this.btnChangeDir.Text = "...";
            this.btnChangeDir.UseVisualStyleBackColor = true;
            this.btnChangeDir.Click += new System.EventHandler(this.btnChangeDir_Click);
            // 
            // tbOutputDir
            // 
            this.tbOutputDir.Location = new System.Drawing.Point(12, 157);
            this.tbOutputDir.Name = "tbOutputDir";
            this.tbOutputDir.ReadOnly = true;
            this.tbOutputDir.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOutputDir.Size = new System.Drawing.Size(320, 23);
            this.tbOutputDir.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Output directory:";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(97, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load Files";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cbDecimalSeparator
            // 
            this.cbDecimalSeparator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDecimalSeparator.FormattingEnabled = true;
            this.cbDecimalSeparator.Location = new System.Drawing.Point(177, 199);
            this.cbDecimalSeparator.Name = "cbDecimalSeparator";
            this.cbDecimalSeparator.Size = new System.Drawing.Size(189, 23);
            this.cbDecimalSeparator.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Decimal separator:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Delimiter:";
            // 
            // cbDelimiter
            // 
            this.cbDelimiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDelimiter.FormattingEnabled = true;
            this.cbDelimiter.Location = new System.Drawing.Point(177, 228);
            this.cbDelimiter.Name = "cbDelimiter";
            this.cbDelimiter.Size = new System.Drawing.Size(189, 23);
            this.cbDelimiter.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "File extension:";
            // 
            // cbExtension
            // 
            this.cbExtension.FormattingEnabled = true;
            this.cbExtension.Location = new System.Drawing.Point(177, 257);
            this.cbExtension.Name = "cbExtension";
            this.cbExtension.Size = new System.Drawing.Size(189, 23);
            this.cbExtension.TabIndex = 5;
            // 
            // nudSignificantFigures
            // 
            this.nudSignificantFigures.Location = new System.Drawing.Point(177, 286);
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
            this.nudSignificantFigures.Size = new System.Drawing.Size(189, 23);
            this.nudSignificantFigures.TabIndex = 6;
            this.nudSignificantFigures.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // lblNumberSig
            // 
            this.lblNumberSig.AutoSize = true;
            this.lblNumberSig.Location = new System.Drawing.Point(11, 283);
            this.lblNumberSig.Name = "lblNumberSig";
            this.lblNumberSig.Size = new System.Drawing.Size(291, 15);
            this.lblNumberSig.TabIndex = 4;
            this.lblNumberSig.Text = "Number of significant figures\\n of exported numbers:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Export format:";
            // 
            // cbExportFormat
            // 
            this.cbExportFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExportFormat.FormattingEnabled = true;
            this.cbExportFormat.Location = new System.Drawing.Point(177, 315);
            this.cbExportFormat.Name = "cbExportFormat";
            this.cbExportFormat.Size = new System.Drawing.Size(189, 23);
            this.cbExportFormat.TabIndex = 5;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 409);
            this.Controls.Add(this.nudSignificantFigures);
            this.Controls.Add(this.cbExtension);
            this.Controls.Add(this.lblNumberSig);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbDelimiter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbExportFormat);
            this.Controls.Add(this.cbDecimalSeparator);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChangeDir);
            this.Controls.Add(this.tbOutputDir);
            this.Controls.Add(this.tbFilenames);
            this.Controls.Add(this.cbNormalizeToTIC);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnConvert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fMain";
            this.Text = "Wiff Converter";
            this.Load += new System.EventHandler(this.fMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSignificantFigures)).EndInit();
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
    }
}