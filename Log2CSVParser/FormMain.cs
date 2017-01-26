using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Log2CSVParser.Utilities;
using Log2CSVParser.Utilities.Log;
using Log2CSVParser.Utilities.Structures;

namespace Log2CSVParser
{
    public sealed partial class FormMain : Form
    {
        internal static readonly ILogManager log = new FileLogManager("Log\\Log2CSVParser.log");
        public FormMain()
        {
            InitializeComponent();
            Text += " (" + Application.ProductVersion + ")";
        }



    }
}