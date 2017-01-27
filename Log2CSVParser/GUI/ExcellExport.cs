using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Log2CSVParser.Utilities;
using Log2CSVParser.Utilities.Log;
using Log2CSVParser.Utilities.Structures;
using SpreadsheetLight;

namespace Log2CSVParser.GUI
{
    public partial class ExcellExport : UserControl
    {
        private readonly ILogManager log = FormMain.log;
        private ExcellCopier copier;
        public ExcellExport()
        {
            InitializeComponent();
        }

        private List<List<string>> GetRanges(string rangeStr)
        {
            try{
                return (from r in rangeStr.Split(';', ',')
                        let oneRange = r.Trim().Split(':')
                        where oneRange.Length == 2
                        select ExcellExtension.CreateEnumeratorColumns(oneRange[0].Trim(), oneRange[1].Trim(), log)).ToList();
            } catch (Exception ex){
                log.Error(ex);
                return null;
            }
        }


        private void ctrBtStart_Click(object sender, EventArgs e)
        {
            LockInterface();
            try{
                List<List<string>> rangesSource = GetRanges(ctrTbRangeSource.Text);
                if (rangesSource == null){
                    MessageBox.Show("Error to parse ranges from source file ranges");
                    return;
                }
                if (rangesSource.Count == 0){
                    MessageBox.Show("Source range is empty");
                    return;
                }
                List<List<string>> rangesTemplate = GetRanges(ctrTbRangeTemplate.Text);
                if (rangesTemplate == null){
                    MessageBox.Show("Error to parse ranges from template file ranges");
                    return;
                }

                if (rangesSource.Count != rangesTemplate.Count){
                    MessageBox.Show("Ranges count in source and template not are the same ");
                    return;
                }

                for (int i = 0;i < rangesSource.Count;i++){
                    if (rangesSource[i].Count != rangesTemplate[i].Count){
                        MessageBox.Show("Range N" + i + " in source and template has different size");
                        return;
                    }
                }

                string sourceFile = ctrExSourceName.Text;
                if (!File.Exists(sourceFile)){
                    MessageBox.Show("Source file " + sourceFile + " not exist");
                    return;
                }

                string templateFile = ctrExTemplateName.Text;
                if (!File.Exists(sourceFile)){
                    MessageBox.Show("Template file " + templateFile + " not exist");
                    return;
                }

                if (ctrExSourceWS.SelectedItem == null){
                    MessageBox.Show("Source file " + templateFile + " worksheet is empty");
                    return;
                }


                if (ctrExTemplateWS.SelectedItem == null){
                    MessageBox.Show("Template file " + templateFile + " worksheet is empty");
                    return;
                }

                timer.Enabled = true;
                SimpleProcessResponse response = (copier = new ExcellCopier()).Copy(sourceFile, ctrExSourceWS.SelectedItem.ToString(), rangesSource, templateFile, ctrExTemplateWS.SelectedItem.ToString(), rangesTemplate, log);
                timer.Enabled = false;
                if (response.isOk){
                    if (MessageBox.Show("Created new file: " + response.message + "\nDo you want to open it now?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes){
                        return;
                    }
                    Process.Start(response.message);
                } else
                    MessageBox.Show("Completed with errors\n" + response.message, "Error");

            } catch (Exception ex){
                log.Error(ex);
            } finally{
                UnlockInterface();
            }
        }

        private void LockInterface()
        {
            Enabled = false;
        }

        private void UnlockInterface()
        {
            Enabled = true;
            timer.Enabled = false;
            progressBar.Value = 0;
        }

        private void ctrExSource_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog form = new OpenFileDialog()){
                form.Filter = "Excell files (*.xlsx)|*.xlsx";
                form.FilterIndex = 0;
                if (form.ShowDialog() != DialogResult.OK)
                    return;
                ctrExSourceName.Text = Path.GetFullPath(form.FileName);
                UpdateWorksheet(ctrExSourceName.Text, ctrExSourceWS);
            }
        }

        private void ctrExTemplate_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog form = new OpenFileDialog()){
                form.Filter = "Excell files (*.xlsx)|*.xlsx";
                form.FilterIndex = 0;
                if (form.ShowDialog() != DialogResult.OK)
                    return;
                ctrExTemplateName.Text = Path.GetFullPath(form.FileName);
                UpdateWorksheet(ctrExTemplateName.Text, ctrExTemplateWS);
            }
        }

        private void ctrExSourceName_TextChanged(object sender, EventArgs e)
        {
        }

        private void ctrExTemplateName_TextChanged(object sender, EventArgs e)
        {
        }

        private void UpdateWorksheet(string filePath, ComboBox ctrExTemplateWs)
        {
            try{
                ctrExTemplateWs.DataSource = new List<string>();
                if (!File.Exists(filePath))
                    return;
                using (SLDocument source = new SLDocument(filePath)){
                    List<string> list = source.GetSheetNames();
                    ctrExTemplateWs.DataSource = list;
                    if (list.Count > 0)
                        ctrExTemplateWs.SelectedIndex = 0;

                }

            } catch (Exception ex){
                log.Error(ex);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try{
                if(copier==null)
                    return;
                progressBar.Value = copier.progress;
            } catch (Exception ex){
                log.Error(ex);
            }
        }
    }
}