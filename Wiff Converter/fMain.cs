using System;
//using System.Diagnostics;
//using System.Linq;
//using System.Windows.Forms;
//using System.Xml.Linq;
using System.IO;
using System.Globalization;
//using System.Collections.Generic;
//using System.Threading;
using System.Threading.Tasks;
//using System.Collections.Concurrent;

namespace Wiff_Converter
{
    public enum ExportFormat
    {
        TimeExplicit = 0,
        WavelengthExplicit = 1
    }

    public partial class fMain
    {

        private double? TryParse(string text, NumberStyles ns, IFormatProvider formatProvider)
        {
            if (text.Trim() == String.Empty)
                return null;

            if (double.TryParse(text, ns, formatProvider, out double result))
                return result;

            return null;
        }

        public void cliConvert(string[] chosenFilepaths)
        {

            string dirPath = Path.GetDirectoryName(chosenFilepaths[0]);

            string fileExt = "csv";
            string delimiter = ",";
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            int sigFigures = 6;
            ExportFormat exportFormat = ExportFormat.WavelengthExplicit;
            bool norm2TIC = false;

            // Other values pulled originally from form. Typically Null in Form, but can be number.
            double? t0, t1, w0, w1, m0, m1;
            t0 = TryParse("", NumberStyles.Any, nfi);
            t1 = TryParse("", NumberStyles.Any, nfi);
            w0 = TryParse("", NumberStyles.Any, nfi);
            w1 = TryParse("", NumberStyles.Any, nfi);
            m0 = TryParse("", NumberStyles.Any, nfi);
            m1 = TryParse("", NumberStyles.Any, nfi);

            Parallel.ForEach(chosenFilepaths, filepath =>
            {
                // This will read the chosenFiles and write the needed files at dirPath.
                Reader r = new Reader(filepath);
                r.SaveAbsorptionMatrix(nfi, delimiter, fileExt, dirPath, exportFormat, sigFigures, w0, w1, t0, t1);
                r.SaveMSMatrix(nfi, delimiter, fileExt, dirPath, exportFormat, norm2TIC, sigFigures, m0, m1, t0, t1);
            });

        }

    }
}
