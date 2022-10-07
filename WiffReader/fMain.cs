//using Clearcore2.Licensing;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Globalization;

namespace WiffReader
{
    public partial class fMain : Form
    {
        public Dictionary<int, string> delimiters;
        public Dictionary<int, string> decimalSeparators;
        public string[]? chosenFilepaths;

        public fMain()
        {
            InitializeComponent();
            delimiters = new Dictionary<int, string>();
            decimalSeparators = new Dictionary<int, string>();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            delimiters.Add(0, "Tabulator");
            delimiters.Add(1, "Comma");
            delimiters.Add(2, "Space");

            decimalSeparators.Add(0, "Comma");
            decimalSeparators.Add(1, "Dot");

            cbExtension.Items.Add("csv");
            cbExtension.Items.Add("txt");

            cbDelimiter.Items.AddRange(delimiters.Values.ToArray());
            cbDecimalSeparator.Items.AddRange(decimalSeparators.Values.ToArray());

            cbDelimiter.SelectedIndex = 0;
            cbDecimalSeparator.SelectedIndex = 0;
            cbExtension.SelectedIndex = 0;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (chosenFilepaths is null)
                return;

            string fileExt = cbExtension.Text;
            CultureInfo decimalSeparator = decimalSeparators[cbDecimalSeparator.SelectedIndex] == "Comma" ? CultureInfo.CurrentCulture : CultureInfo.InvariantCulture;


            foreach (string filename in chosenFilepaths)
            {
                Reader r = new Reader(filename);
                r.SaveAbsorptionMatrix();
            }
            //Console.WriteLine(n);

            //MessageBox.Show(r.GetNumberOfSamples().ToString());




        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.AddExtension = false;
            ofd.Filter = "Wiff files (*.wiff)|*.wiff";
            ofd.RestoreDirectory = true;
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileNames.Length == 0)
                    return;

                chosenFilepaths = ofd.FileNames;

                tbFilenames.Text = string.Join(Environment.NewLine, chosenFilepaths);

                string? dirPath = Path.GetDirectoryName(chosenFilepaths[0]);
                tbOutputDir.Text = dirPath is null ? "" : dirPath;
            }

        }

        private void btnChangeDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fwd = new FolderBrowserDialog();
            fwd.InitialDirectory = tbOutputDir.Text;
            fwd.ShowNewFolderButton = true;

            if (fwd.ShowDialog() == DialogResult.OK)
            {
                tbOutputDir.Text = fwd.SelectedPath;
            }
        }
    }
}