namespace Log2CSVParser.GUI
{
    partial class Log2Excell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Log2Excell));
            this.ctrLBRows = new System.Windows.Forms.Label();
            this.ctrNumRows = new System.Windows.Forms.NumericUpDown();
            this.ctrUseOnlySellBuy = new System.Windows.Forms.CheckBox();
            this.ctrTBTickersName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrTbSeparator = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.ctrBtStartConvert = new System.Windows.Forms.Button();
            this.ctrChBoxIsOrder = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrTBResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrBtSelectSource = new System.Windows.Forms.Button();
            this.ctrTBSource = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ctrNumRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrLBRows
            // 
            this.ctrLBRows.AutoSize = true;
            this.ctrLBRows.Location = new System.Drawing.Point(157, 145);
            this.ctrLBRows.Name = "ctrLBRows";
            this.ctrLBRows.Size = new System.Drawing.Size(121, 13);
            this.ctrLBRows.TabIndex = 48;
            this.ctrLBRows.Text = "Blank rows before ticket";
            // 
            // ctrNumRows
            // 
            this.ctrNumRows.Location = new System.Drawing.Point(284, 140);
            this.ctrNumRows.Name = "ctrNumRows";
            this.ctrNumRows.Size = new System.Drawing.Size(58, 20);
            this.ctrNumRows.TabIndex = 47;
            this.ctrNumRows.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ctrUseOnlySellBuy
            // 
            this.ctrUseOnlySellBuy.AutoSize = true;
            this.ctrUseOnlySellBuy.Checked = true;
            this.ctrUseOnlySellBuy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ctrUseOnlySellBuy.Location = new System.Drawing.Point(158, 116);
            this.ctrUseOnlySellBuy.Name = "ctrUseOnlySellBuy";
            this.ctrUseOnlySellBuy.Size = new System.Drawing.Size(153, 17);
            this.ctrUseOnlySellBuy.TabIndex = 46;
            this.ctrUseOnlySellBuy.Text = "Use \"Buy\" and \"Sell\" entry";
            this.ctrUseOnlySellBuy.UseVisualStyleBackColor = true;
            // 
            // ctrTBTickersName
            // 
            this.ctrTBTickersName.Location = new System.Drawing.Point(109, 169);
            this.ctrTBTickersName.Name = "ctrTBTickersName";
            this.ctrTBTickersName.Size = new System.Drawing.Size(264, 20);
            this.ctrTBTickersName.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Tickers name";
            // 
            // ctrTbSeparator
            // 
            this.ctrTbSeparator.Location = new System.Drawing.Point(109, 139);
            this.ctrTbSeparator.Name = "ctrTbSeparator";
            this.ctrTbSeparator.Size = new System.Drawing.Size(28, 20);
            this.ctrTbSeparator.TabIndex = 43;
            this.ctrTbSeparator.Text = ",";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Column separator";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(446, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(17, 195);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(401, 21);
            this.progressBar.TabIndex = 40;
            // 
            // ctrBtStartConvert
            // 
            this.ctrBtStartConvert.Location = new System.Drawing.Point(446, 193);
            this.ctrBtStartConvert.Name = "ctrBtStartConvert";
            this.ctrBtStartConvert.Size = new System.Drawing.Size(75, 23);
            this.ctrBtStartConvert.TabIndex = 39;
            this.ctrBtStartConvert.Text = "Convert";
            this.ctrBtStartConvert.UseVisualStyleBackColor = true;
            this.ctrBtStartConvert.Click += new System.EventHandler(this.ctrBtStartConvert_Click);
            // 
            // ctrChBoxIsOrder
            // 
            this.ctrChBoxIsOrder.AutoSize = true;
            this.ctrChBoxIsOrder.Checked = true;
            this.ctrChBoxIsOrder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ctrChBoxIsOrder.Location = new System.Drawing.Point(17, 116);
            this.ctrChBoxIsOrder.Name = "ctrChBoxIsOrder";
            this.ctrChBoxIsOrder.Size = new System.Drawing.Size(124, 17);
            this.ctrChBoxIsOrder.TabIndex = 38;
            this.ctrChBoxIsOrder.Text = "Order by ticker name";
            this.ctrChBoxIsOrder.UseVisualStyleBackColor = true;
            this.ctrChBoxIsOrder.CheckedChanged += new System.EventHandler(this.ctrChBoxIsOrder_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Result file (csv)";
            // 
            // ctrTBResult
            // 
            this.ctrTBResult.Location = new System.Drawing.Point(33, 74);
            this.ctrTBResult.Name = "ctrTBResult";
            this.ctrTBResult.Size = new System.Drawing.Size(340, 20);
            this.ctrTBResult.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Source file (log)";
            // 
            // ctrBtSelectSource
            // 
            this.ctrBtSelectSource.Location = new System.Drawing.Point(381, 28);
            this.ctrBtSelectSource.Name = "ctrBtSelectSource";
            this.ctrBtSelectSource.Size = new System.Drawing.Size(37, 23);
            this.ctrBtSelectSource.TabIndex = 34;
            this.ctrBtSelectSource.Text = "...";
            this.ctrBtSelectSource.UseVisualStyleBackColor = true;
            this.ctrBtSelectSource.Click += new System.EventHandler(this.ctrBtSelectSource_Click);
            // 
            // ctrTBSource
            // 
            this.ctrTBSource.Location = new System.Drawing.Point(33, 28);
            this.ctrTBSource.Name = "ctrTBSource";
            this.ctrTBSource.Size = new System.Drawing.Size(340, 20);
            this.ctrTBSource.TabIndex = 33;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick_1);
            // 
            // Log2Excell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrLBRows);
            this.Controls.Add(this.ctrNumRows);
            this.Controls.Add(this.ctrUseOnlySellBuy);
            this.Controls.Add(this.ctrTBTickersName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ctrTbSeparator);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.ctrBtStartConvert);
            this.Controls.Add(this.ctrChBoxIsOrder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrTBResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrBtSelectSource);
            this.Controls.Add(this.ctrTBSource);
            this.Name = "Log2Excell";
            this.Size = new System.Drawing.Size(537, 225);
            ((System.ComponentModel.ISupportInitialize)(this.ctrNumRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ctrLBRows;
        private System.Windows.Forms.NumericUpDown ctrNumRows;
        private System.Windows.Forms.CheckBox ctrUseOnlySellBuy;
        private System.Windows.Forms.TextBox ctrTBTickersName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ctrTbSeparator;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button ctrBtStartConvert;
        private System.Windows.Forms.CheckBox ctrChBoxIsOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ctrTBResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ctrBtSelectSource;
        private System.Windows.Forms.TextBox ctrTBSource;
        private System.Windows.Forms.Timer timer;
    }
}
