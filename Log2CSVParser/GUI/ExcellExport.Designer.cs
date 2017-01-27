namespace Log2CSVParser.GUI
{
    partial class ExcellExport
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ctrBtStart = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.ctrTbRangeTemplate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ctrTbRangeSource = new System.Windows.Forms.TextBox();
            this.ctrExTemplate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ctrExTemplateName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ctrExSource = new System.Windows.Forms.Button();
            this.ctrExSourceName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrExSourceWS = new System.Windows.Forms.ComboBox();
            this.ctrExTemplateWS = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ctrBtStart
            // 
            this.ctrBtStart.Location = new System.Drawing.Point(475, 224);
            this.ctrBtStart.Name = "ctrBtStart";
            this.ctrBtStart.Size = new System.Drawing.Size(75, 23);
            this.ctrBtStart.TabIndex = 43;
            this.ctrBtStart.Text = "Copy";
            this.ctrBtStart.UseVisualStyleBackColor = true;
            this.ctrBtStart.Click += new System.EventHandler(this.ctrBtStart_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Range cells";
            // 
            // ctrTbRangeTemplate
            // 
            this.ctrTbRangeTemplate.Location = new System.Drawing.Point(29, 167);
            this.ctrTbRangeTemplate.Name = "ctrTbRangeTemplate";
            this.ctrTbRangeTemplate.Size = new System.Drawing.Size(195, 20);
            this.ctrTbRangeTemplate.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "Range cells";
            // 
            // ctrTbRangeSource
            // 
            this.ctrTbRangeSource.Location = new System.Drawing.Point(29, 65);
            this.ctrTbRangeSource.Name = "ctrTbRangeSource";
            this.ctrTbRangeSource.Size = new System.Drawing.Size(195, 20);
            this.ctrTbRangeSource.TabIndex = 39;
            // 
            // ctrExTemplate
            // 
            this.ctrExTemplate.Location = new System.Drawing.Point(475, 128);
            this.ctrExTemplate.Name = "ctrExTemplate";
            this.ctrExTemplate.Size = new System.Drawing.Size(37, 23);
            this.ctrExTemplate.TabIndex = 38;
            this.ctrExTemplate.Text = "...";
            this.ctrExTemplate.UseVisualStyleBackColor = true;
            this.ctrExTemplate.Click += new System.EventHandler(this.ctrExTemplate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Result file template (xlsx)";
            // 
            // ctrExTemplateName
            // 
            this.ctrExTemplateName.Location = new System.Drawing.Point(29, 128);
            this.ctrExTemplateName.Name = "ctrExTemplateName";
            this.ctrExTemplateName.ReadOnly = true;
            this.ctrExTemplateName.Size = new System.Drawing.Size(440, 20);
            this.ctrExTemplateName.TabIndex = 36;
            this.ctrExTemplateName.TextChanged += new System.EventHandler(this.ctrExTemplateName_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Source file (xlsx)";
            // 
            // ctrExSource
            // 
            this.ctrExSource.Location = new System.Drawing.Point(475, 26);
            this.ctrExSource.Name = "ctrExSource";
            this.ctrExSource.Size = new System.Drawing.Size(37, 23);
            this.ctrExSource.TabIndex = 34;
            this.ctrExSource.Text = "...";
            this.ctrExSource.UseVisualStyleBackColor = true;
            this.ctrExSource.Click += new System.EventHandler(this.ctrExSource_Click);
            // 
            // ctrExSourceName
            // 
            this.ctrExSourceName.Location = new System.Drawing.Point(29, 26);
            this.ctrExSourceName.Name = "ctrExSourceName";
            this.ctrExSourceName.ReadOnly = true;
            this.ctrExSourceName.Size = new System.Drawing.Size(440, 20);
            this.ctrExSourceName.TabIndex = 33;
            this.ctrExSourceName.TextChanged += new System.EventHandler(this.ctrExSourceName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Worksheet";
            // 
            // ctrExSourceWS
            // 
            this.ctrExSourceWS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrExSourceWS.FormattingEnabled = true;
            this.ctrExSourceWS.Location = new System.Drawing.Point(250, 64);
            this.ctrExSourceWS.Name = "ctrExSourceWS";
            this.ctrExSourceWS.Size = new System.Drawing.Size(219, 21);
            this.ctrExSourceWS.TabIndex = 46;
            // 
            // ctrExTemplateWS
            // 
            this.ctrExTemplateWS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrExTemplateWS.FormattingEnabled = true;
            this.ctrExTemplateWS.Location = new System.Drawing.Point(250, 167);
            this.ctrExTemplateWS.Name = "ctrExTemplateWS";
            this.ctrExTemplateWS.Size = new System.Drawing.Size(219, 21);
            this.ctrExTemplateWS.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Worksheet";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(13, 224);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(440, 23);
            this.progressBar.TabIndex = 49;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ExcellExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.ctrExTemplateWS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrExSourceWS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrBtStart);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ctrTbRangeTemplate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ctrTbRangeSource);
            this.Controls.Add(this.ctrExTemplate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ctrExTemplateName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ctrExSource);
            this.Controls.Add(this.ctrExSourceName);
            this.Name = "ExcellExport";
            this.Size = new System.Drawing.Size(607, 269);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ctrBtStart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ctrTbRangeTemplate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ctrTbRangeSource;
        private System.Windows.Forms.Button ctrExTemplate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ctrExTemplateName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ctrExSource;
        private System.Windows.Forms.TextBox ctrExSourceName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ctrExSourceWS;
        private System.Windows.Forms.ComboBox ctrExTemplateWS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer timer;
    }
}
