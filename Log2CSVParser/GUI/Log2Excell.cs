using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Log2CSVParser.Utilities.Log;
using Log2CSVParser.Utilities.Structures;

namespace Log2CSVParser.GUI
{
    public partial class Log2Excell : UserControl
    {
        private readonly ILogManager log = FormMain.log;
        private Parser p;

        public Log2Excell()
        {
            InitializeComponent();
        }



        private void ctrBtSelectSource_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog form = new OpenFileDialog()) {
                if (form.ShowDialog() != DialogResult.OK)
                    return;
                ctrTBSource.Text = Path.GetFullPath(form.FileName);
                ctrTBResult.Text = Path.Combine(Path.GetDirectoryName(ctrTBSource.Text) ?? "", Path.GetFileNameWithoutExtension(ctrTBSource.Text) + ".xlsx");
            }
        }


        private void ctrChBoxIsOrder_CheckedChanged(object sender, EventArgs e)
        {
            ctrLBRows.Visible = ctrChBoxIsOrder.Checked;
            ctrNumRows.Visible = ctrChBoxIsOrder.Checked;
        }

        private void ctrBtStartConvert_Click(object sender, EventArgs e)
        {
            try {
                LockInterface();
                string fileSource = ctrTBSource.Text;
                string fileRes = ctrTBResult.Text;

                if (string.IsNullOrEmpty(fileSource)) {
                    MessageBox.Show("Source file path is empty");
                    return;
                }

                if (string.IsNullOrEmpty(fileRes)) {
                    MessageBox.Show("Result file path is empty");
                    return;
                }

                List<string> filter = ctrTBTickersName.Text.Trim().Length > 0
                    ? ctrTBTickersName.Text.Trim().Split(',', ';').ToList()
                    : new List<string>();
                p = new Parser(fileSource, fileRes, ctrChBoxIsOrder.Checked, ctrUseOnlySellBuy.Checked, filter, (int)ctrNumRows.Value, log);
                timer.Enabled = true;
                SimpleProcessResponse response = p.Start();
                timer.Enabled = false;
                if (response.isOk){
                    if (MessageBox.Show("Successfully completed\nDo you want to open it now?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes) {
                        return;
                    }
                    Process.Start(fileRes);

                }
                else
                    MessageBox.Show("Completed with errors\n" + response.message);

            } catch (Exception ex) {
                log.Error(ex);
                MessageBox.Show("System error\n" + ex.Message);
            } finally {
                UnlockInterface();
                timer.Enabled = false;
                p = null;
                progressBar.Value = 0;
            }
        }

        private void UnlockInterface()
        {
            Enabled = true;
        }

        private void LockInterface()
        {
            Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try {
                progressBar.Value = p?.percent ?? 0;
            } catch {
            }
        }
    }
}
