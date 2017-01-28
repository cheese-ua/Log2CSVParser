using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Log2CSVParser.Utilities;

namespace Log2CSVParser.GUI
{
    public partial class CommonSettings : UserControl
    {
        public CommonSettings()
        {
            InitializeComponent();
            ctrTBEmptyCell.Text = Config.EmptyCellValue;
            ctrReplaceZero.Checked = Config.ReplaceZero;
        }

        private void ctrTBEmptyCell_TextChanged(object sender, EventArgs e)
        {
            Config.EmptyCellValue = ctrTBEmptyCell.Text;
        }

        private void ctrReplaceZero_CheckedChanged(object sender, EventArgs e)
        {
            Config.ReplaceZero = ctrReplaceZero.Checked;
        }
    }
}
