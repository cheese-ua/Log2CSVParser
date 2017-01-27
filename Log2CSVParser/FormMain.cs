using System.Windows.Forms;
using Log2CSVParser.Utilities.Log;

namespace Log2CSVParser
{
    public sealed partial class FormMain : Form
    {
        internal static readonly ILogManager log = new FileLogManager("Log\\Log2CSVParser.log");
        public FormMain()
        {
            InitializeComponent();
            Text += " (" + Application.ProductVersion + ") ";
            //tabControl1.TabPages.RemoveAt(2);
            //ExcellCopier.Test();
        }

    }
}