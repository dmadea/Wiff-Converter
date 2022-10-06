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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(51, 280);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(97, 23);
            this.btnConvert.TabIndex = 0;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbNormalizeToTIC
            // 
            this.cbNormalizeToTIC.AutoSize = true;
            this.cbNormalizeToTIC.Location = new System.Drawing.Point(51, 255);
            this.cbNormalizeToTIC.Name = "cbNormalizeToTIC";
            this.cbNormalizeToTIC.Size = new System.Drawing.Size(175, 19);
            this.cbNormalizeToTIC.TabIndex = 1;
            this.cbNormalizeToTIC.Text = "Normalize MS spectra to TIC";
            this.cbNormalizeToTIC.UseVisualStyleBackColor = true;
            // 
            // tbFilenames
            // 
            this.tbFilenames.Location = new System.Drawing.Point(51, 61);
            this.tbFilenames.Multiline = true;
            this.tbFilenames.Name = "tbFilenames";
            this.tbFilenames.ReadOnly = true;
            this.tbFilenames.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbFilenames.Size = new System.Drawing.Size(218, 95);
            this.tbFilenames.TabIndex = 2;
            // 
            // btnChangeDir
            // 
            this.btnChangeDir.Location = new System.Drawing.Point(241, 177);
            this.btnChangeDir.Name = "btnChangeDir";
            this.btnChangeDir.Size = new System.Drawing.Size(28, 23);
            this.btnChangeDir.TabIndex = 3;
            this.btnChangeDir.Text = "...";
            this.btnChangeDir.UseVisualStyleBackColor = true;
            // 
            // tbOutputDir
            // 
            this.tbOutputDir.Location = new System.Drawing.Point(51, 177);
            this.tbOutputDir.Name = "tbOutputDir";
            this.tbOutputDir.ReadOnly = true;
            this.tbOutputDir.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOutputDir.Size = new System.Drawing.Size(184, 23);
            this.tbOutputDir.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Output directory:";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(51, 32);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(97, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load Files";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(295, 214);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Decimal separator:";
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 342);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChangeDir);
            this.Controls.Add(this.tbOutputDir);
            this.Controls.Add(this.tbFilenames);
            this.Controls.Add(this.cbNormalizeToTIC);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnConvert);
            this.Name = "fMain";
            this.Text = "Wiff Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnConvert;
        private CheckBox cbNormalizeToTIC;
        private TextBox tbFilenames;
        private Button btnOpen;
        private TextBox tbOutputDir;
        private Button btnChangeDir;
        private Label label1;
        private Button btnLoad;
        private ComboBox comboBox1;
        private Label label2;
    }
}