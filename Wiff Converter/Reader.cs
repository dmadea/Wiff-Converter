using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel;
using System.Globalization;

using Clearcore2.Data;
using Clearcore2.Data.AnalystDataProvider;
using Clearcore2.Data.DataAccess;
using Clearcore2.Data.DataAccess.SampleData;

namespace Wiff_Converter
{

    public struct Matrix // C-type stored, row-wise [xData.Length x yData.Length]
    {
        public double[] data;
        public double[] xData;
        public double[] yData;
    }

    internal class Reader
    {

        // Properties
        public int numberOfSamples;
        private AnalystWiffDataProvider _provider;
        private Batch batch;
        public string wiffFilePath;

        // Methods
        public Reader(string filepath)
        {
            wiffFilePath = filepath;
            _provider = new AnalystWiffDataProvider();
            batch = AnalystDataProviderFactory.CreateBatch(wiffFilePath, _provider);
            numberOfSamples = GetNumberOfSamples();
        }

        /// Finds nearest index of a value in a sorted array.
        public static int FindNearestIndex(double[] array, double value)
        {
            // https://stackoverflow.com/questions/41277957/get-closest-value-in-an-array
            int idx = Array.BinarySearch<double>(array, value);
            idx = idx < 0 ? ~idx : idx;

            idx = idx == array.Length ? array.Length - 1 : idx;

            if (idx == 0 | idx == array.Length - 1)
                return idx;

            if (array[idx] - value <= value - array[idx - 1])
            {
                return idx;
            }
            else
            {
                return idx - 1;
            }
        }


        private void SaveMatrix(Matrix matrix, NumberFormatInfo nfi, string delimiter, string filepath,
                                ExportFormat exportFormat, int sigFigures = 6,
                                string tUnit = "min", string wlUnit = "wavelength",
                                double? x0 = null, double? x1 = null, double? y0 = null, double? y1 = null)
        {
            string strFormat = $"G{sigFigures}";

            // indexes of the matrix dimensions
            int idxX0, idxX1, idxY0, idxY1;

            idxX0 = x0 == null ? 0 : FindNearestIndex(matrix.xData, (double)x0);
            idxX1 = x1 == null ? matrix.xData.Length - 1 : FindNearestIndex(matrix.xData, (double)x1);
            idxY0 = y0 == null ? 0 : FindNearestIndex(matrix.yData, (double)y0);
            idxY1 = y1 == null ? matrix.yData.Length - 1 : FindNearestIndex(matrix.yData, (double)y1);

            using (StreamWriter sw = new StreamWriter(new FileStream(filepath, FileMode.Create, FileAccess.Write), Encoding.UTF8))
            {
                if (exportFormat == ExportFormat.WavelengthExplicit)
                {
                    string firstLine = $"{tUnit} -> {wlUnit}{delimiter}" + string.Join(delimiter, matrix.xData.Select(num => num.ToString(strFormat, nfi)).ToArray(), idxX0, idxX1 - idxX0 + 1);
                    sw.WriteLine(firstLine);

                    for (int i = idxY0; i <= idxY1; i++)
                    {
                        double[] row = new double[idxX1 - idxX0 + 1];  // rows of a matrix

                        for (int j = idxX0; j <= idxX1; j++)
                        {
                            row[j - idxX0] = matrix.data[i * matrix.xData.Length + j];
                        }

                        sw.WriteLine(matrix.yData[i].ToString(strFormat, nfi) + delimiter + string.Join(delimiter, row.Select(num => num.ToString(strFormat, nfi))));
                    }
                }
                else
                {
                    string firstLine = $"{wlUnit} -> {tUnit}{delimiter}" + string.Join(delimiter, matrix.yData.Select(num => num.ToString(strFormat, nfi)).ToArray(), idxY0, idxY1 - idxY0 + 1);
                    sw.WriteLine(firstLine);

                    for (int j = idxX0; j <= idxX1; j++)  // for each row
                    {
                        double[] row = new double[idxY1 - idxY0 + 1]; // columns of a matrix

                        for (int i = idxY0; i <= idxY1; i++)
                        {
                            row[i - idxY0] = matrix.data[i * matrix.xData.Length + j];
                        }

                        sw.WriteLine(matrix.xData[j].ToString(strFormat, nfi) + delimiter + string.Join(delimiter, row.Select(num => num.ToString(strFormat, nfi))));
                    }
                }
            }
        }

        public void SaveMSMatrix(NumberFormatInfo nfi, string delimiter, string fileExtension, string dirPath,
                                 ExportFormat exportFormat, bool normToTIC = false, int sigFigures = 6,
                                 double? mz0 = null, double? mz1 = null, double? t0 = null, double? t1 = null,
                                 string filenamePrefix = "MS_")
        {
            string filename = Path.GetFileName(wiffFilePath);
            string filePath = Path.GetFileNameWithoutExtension(filename);

            if (dirPath is null)
                return;

            for (int n = 0; n < numberOfSamples; n++) // for each sample
            {
                Sample sample = batch.GetSample(n);

                if (!sample.HasMassSpectrometerData)
                    continue;

                MassSpectrometerSample msSample = sample.MassSpectrometerSample;

                // Check if the mass scan file is present
                try
                {
                    msSample.GetMSExperiment(0).GetMassSpectrum(0);
                }
                catch (Exception)
                {
                    throw;
                }

                int m = msSample.ExperimentCount;

                for (int nExp = 0; nExp < m; nExp++)  // for each MS experiment
                {
                    MSExperiment mse = msSample.GetMSExperiment(nExp);
                    int nScans = mse.Details.NumberOfScans;

                    double startMass, endMass, stepSize, diffMass;
                    startMass = mse.Details.StartMass;
                    endMass = mse.Details.EndMass;
                    diffMass = endMass - startMass;
                    FullScanMassRange mri = (FullScanMassRange)mse.Details.MassRangeInfo[0];
                    stepSize = mri.StepSize;

                    string newFileName = $"{filenamePrefix}{filePath}-{sample.Details.SampleName}-{mse.Details.Name}.{fileExtension.ToLower()}";
                    string newFilePath = Path.Combine(dirPath, newFileName);

                    int nMz = (int)((endMass - startMass) / stepSize) + 1;

                    double[] mzArr = new double[nMz];

                    for (int i = 0; i < nMz; i++)
                    {
                        mzArr[i] = startMass + stepSize * i;
                    }

                    TotalIonChromatogram tic = mse.GetTotalIonChromatogram();
                    double[] times = tic.GetActualXValues();
                    double[] ticYData = tic.GetActualYValues();
                    Debug.Assert(times.Length == nScans);

                    // Save data to matrix
                    Matrix mat = new Matrix
                    {
                        data = new double[nMz * nScans],
                        xData = mzArr,
                        yData = times
                    };

                    for (int i = 0; i < nScans; i++)
                    {
                        MassSpectrum ms = mse.GetMassSpectrum(i);
                        double[] xvals = ms.GetActualXValues();
                        double[] yvals = ms.GetActualYValues();

                        for (int j = 0; j < xvals.Length; j++)
                        {
                            // calculate the index of the m/z value into the evenly spaced matrix
                            int idx = (int)Math.Round((xvals[j] - startMass) * (nMz - 1) / diffMass);
                            mat.data[i * nMz + idx] = normToTIC ? yvals[j] / ticYData[i] : yvals[j];
                        }
                    }

                    SaveMatrix(mat, nfi, delimiter, newFilePath, exportFormat, sigFigures, "min", "m/z", mz0, mz1, t0, t1);
                }
            }
        }

        public void SaveAbsorptionMatrix(NumberFormatInfo nfi, string delimiter, string fileExtension, string dirPath,
                                         ExportFormat exportFormat, int sigFigures = 6,
                                         double? w0 = null, double? w1 = null, double? t0 = null, double? t1 = null,
                                         string filenamePrefix = "UV_")
        {
            string filename = Path.GetFileName(wiffFilePath);
            string filePath = Path.GetFileNameWithoutExtension(filename);

            if (dirPath is null)
                return;

            for (int n = 0; n < numberOfSamples; n++)
            {
                Sample sample = batch.GetSample(n);

                if (!sample.HasDADData)
                    continue;

                string newFileName = $"{filenamePrefix}{filePath}-{sample.Details.SampleName}.{fileExtension.ToLower()}";
                string newFilePath = Path.Combine(dirPath, newFileName);

                DADSample dadSample = sample.DADSample;
                int nSpectra = dadSample.NumberOfSpectra;

                double[] wavelengths = dadSample.GetWavelengthSpectrum(0).GetActualXValues();
                int nWavelengths = wavelengths.Length;

                TotalWavelengthChromatogram twc = dadSample.GetTotalWavelengthChromatogram();
                double[] times = twc.GetActualXValues();
                Debug.Assert(times.Length == nSpectra);

                // Save data to matrix
                Matrix mat = new Matrix
                {
                    data = new double[nWavelengths * nSpectra],
                    xData = wavelengths,
                    yData = times
                };

                // Populate the matrix
                for (int i = 0; i < nSpectra; i++)
                {
                    WavelengthSpectrum ws = dadSample.GetWavelengthSpectrum(i);
                    double[] y = ws.GetActualYValues();
                    Debug.Assert(y.Length == nWavelengths);
                    //throw new Exception("Number of points in absorption data are not equal to that of wavelength points");

                    for (int j = 0; j < nWavelengths; j++)
                    {
                        mat.data[i * nWavelengths + j] = y[j];
                    }
                }

                SaveMatrix(mat, nfi, delimiter, newFilePath, exportFormat, sigFigures, "min", "wavelength", w0, w1, t0, t1);
            }
        }

        public int GetNumberOfSamples()
        {
            return _provider.GetNumberOfSamples(this.wiffFilePath);
        }

    }
}
