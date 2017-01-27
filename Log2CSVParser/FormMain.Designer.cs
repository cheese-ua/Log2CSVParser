namespace Log2CSVParser
{
    sealed partial class FormMain
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
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.log2Excell1 = new Log2CSVParser.GUI.Log2Excell();
            this.excellExport1 = new Log2CSVParser.GUI.ExcellExport();
            this.commonSettings1 = new Log2CSVParser.GUI.CommonSettings();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(570, 287);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.log2Excell1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(562, 261);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Converter";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.excellExport1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(562, 261);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Export to Excell";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.commonSettings1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(562, 261);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Common settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // log2Excell1
            // 
            this.log2Excell1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log2Excell1.Location = new System.Drawing.Point(3, 3);
            this.log2Excell1.Name = "log2Excell1";
            this.log2Excell1.Size = new System.Drawing.Size(556, 255);
            this.log2Excell1.TabIndex = 0;
            this.log2Excell1.Load += new System.EventHandler(this.log2Excell1_Load);
            // 
            // excellExport1
            // 
            this.excellExport1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excellExport1.Location = new System.Drawing.Point(3, 3);
            this.excellExport1.Name = "excellExport1";
            this.excellExport1.Size = new System.Drawing.Size(556, 255);
            this.excellExport1.TabIndex = 0;
            // 
            // commonSettings1
            // 
            this.commonSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commonSettings1.Location = new System.Drawing.Point(3, 3);
            this.commonSettings1.Name = "commonSettings1";
            this.commonSettings1.Size = new System.Drawing.Size(556, 255);
            this.commonSettings1.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 287);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log2CSV";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private GUI.Log2Excell log2Excell1;
        private GUI.ExcellExport excellExport1;
        private System.Windows.Forms.TabPage tabPage3;
        private GUI.CommonSettings commonSettings1;
    }
}

