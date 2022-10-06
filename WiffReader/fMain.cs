//using Clearcore2.Licensing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WiffReader
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            OpenFileDialog ofd = new OpenFileDialog();

            ofd.AddExtension = false;
            ofd.Filter = "Wiff files (*.wiff)|*.wiff";
            ofd.RestoreDirectory = true;
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] filenames = ofd.FileNames;

                //string fname = "C:\\Users\\dominik\\Documents\\RealTimeSync\\Projects\\2020- Bilirubin & dipyrrinones\\Biopyrrins\\HPLC-MS\\DMbp005\\DMbp005.wiff";

                foreach (string filename in filenames)
                {
                    Reader r = new Reader(filename);
                    r.SaveAbsorptionMatrix();
                }

                //Console.WriteLine(n);
            }

            //MessageBox.Show(r.GetNumberOfSamples().ToString());




        }
    }
}