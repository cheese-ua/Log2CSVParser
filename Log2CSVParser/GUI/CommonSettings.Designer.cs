namespace Log2CSVParser.GUI
{
    partial class CommonSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.ctrTBEmptyCell = new System.Windows.Forms.TextBox();
            this.ctrReplaceZero = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Empty cell values";
            // 
            // ctrTBEmptyCell
            // 
            this.ctrTBEmptyCell.Location = new System.Drawing.Point(34, 32);
            this.ctrTBEmptyCell.Name = "ctrTBEmptyCell";
            this.ctrTBEmptyCell.Size = new System.Drawing.Size(154, 20);
            this.ctrTBEmptyCell.TabIndex = 36;
            this.ctrTBEmptyCell.TextChanged += new System.EventHandler(this.ctrTBEmptyCell_TextChanged);
            // 
            // ctrReplaceZero
            // 
            this.ctrReplaceZero.AutoSize = true;
            this.ctrReplaceZero.Location = new System.Drawing.Point(18, 69);
            this.ctrReplaceZero.Name = "ctrReplaceZero";
            this.ctrReplaceZero.Size = new System.Drawing.Size(135, 17);
            this.ctrReplaceZero.TabIndex = 38;
            this.ctrReplaceZero.Text = "Replace zeroes with \"\"";
            this.ctrReplaceZero.UseVisualStyleBackColor = true;
            this.ctrReplaceZero.CheckedChanged += new System.EventHandler(this.ctrReplaceZero_CheckedChanged);
            // 
            // CommonSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrReplaceZero);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrTBEmptyCell);
            this.Name = "CommonSettings";
            this.Size = new System.Drawing.Size(803, 325);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ctrTBEmptyCell;
        private System.Windows.Forms.CheckBox ctrReplaceZero;
    }
}
