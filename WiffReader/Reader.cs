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
//using Sciex.Data.XYData;
//using Clearcore2.RawXYProcessing;
//using Sciex.FMan;

// inspiration from https://github.com/vdemichev/DiaNN/blob/master/WiffReader/WiffReader.cpp
// and https://github.com/ProteoWizard/pwiz/blob/master/pwiz/data/vendor_readers/ABI/Reader_ABI.cpp

namespace WiffReader
{

    public struct Matrix // C-type stored, row-wise [xData.Length x yData.Length]
    {
        public double[] data;
        public double[] xData;
        public double[] yData;
    }

    internal class Reader
    {

        public int numberOfSamples;

        private AnalystWiffDataProvider _provider;
        private Batch batch;

        public string wiffFilePath;

        public Reader(string filepath)
        {
            wiffFilePath = filepath;
            _provider = new AnalystWiffDataProvider();
            batch = AnalystDataProviderFactory.CreateBatch(wiffFilePath, _provider);
            numberOfSamples = GetNumberOfSamples();
        }

        private void SaveMatrix(Matrix matrix, NumberFormatInfo nfi, string delimiter, string filepath,
                                ExportFormat exportFormat, int sigFigures = 6, string tUnit = "min", string wlUnit = "wavelength")
        {
            string strFormat = $"G{sigFigures}";

            using (StreamWriter sw = new StreamWriter(new FileStream(filepath, FileMode.Create, FileAccess.Write), Encoding.UTF8))
            {
                if (exportFormat == ExportFormat.WavelengthExplicit)
                {
                    string firstLine = $"{tUnit} -> {wlUnit}{delimiter}" + string.Join(delimiter, matrix.xData.Select(num => num.ToString(strFormat, nfi)));
                    sw.WriteLine(firstLine);

                    for (int i = 0; i < matrix.yData.Length; i++)
                    {
                        double[] row = new double[matrix.xData.Length];  // rows of a matrix

                        for (int j = 0; j < matrix.xData.Length; j++)
                        {
                            row[j] = matrix.data[i * matrix.xData.Length + j];
                        }

                        sw.WriteLine(matrix.yData[i].ToString(strFormat, nfi) + delimiter + string.Join(delimiter, row.Select(num => num.ToString(strFormat, nfi))));
                    }
                }
                else
                {
                    string firstLine = $"{wlUnit} -> {tUnit}{delimiter}" + string.Join(delimiter, matrix.yData.Select(num => num.ToString(strFormat, nfi)));
                    sw.WriteLine(firstLine);

                    for (int j = 0; j < matrix.xData.Length; j++)  // for each row
                    {
                        double[] row = new double[matrix.yData.Length]; // columns of a matrix

                        for (int i = 0; i < matrix.yData.Length; i++)
                        {
                            row[i] = matrix.data[i * matrix.xData.Length + j];
                        }

                        sw.WriteLine(matrix.xData[j].ToString(strFormat, nfi) + delimiter + string.Join(delimiter, row.Select(num => num.ToString(strFormat, nfi))));
                    }
                }
            }
        }

        public void SaveMSMatrix(NumberFormatInfo nfi, string delimiter, string fileExtension, string dirPath,
                                 ExportFormat exportFormat, bool normToTIC = false, int sigFigures = 6, string filenamePrefix = "MS_")
        {
            string? filename = Path.GetFileName(wiffFilePath);
            string newFilePath = Path.GetFileNameWithoutExtension(filename);

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

                    string newFileName = $"{filenamePrefix}{newFilePath}-{sample.Details.SampleName}-{mse.Details.Name}.{fileExtension.ToLower()}";
                    newFilePath = Path.Combine(dirPath, newFileName);

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
                    Matrix mat = new()
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

                    SaveMatrix(mat, nfi, delimiter, newFilePath, exportFormat, sigFigures, "min", "m/z");
                }
            }
        }

        public void SaveAbsorptionMatrix(NumberFormatInfo nfi, string delimiter, string fileExtension, string dirPath,
                                         ExportFormat exportFormat, int sigFigures = 6, string filenamePrefix = "UV_")
        {
            string? filename = Path.GetFileName(wiffFilePath);
            string newFilePath = Path.GetFileNameWithoutExtension(filename);

            if (dirPath is null)
                return;

            for (int n = 0; n < numberOfSamples; n++)
            {
                Sample sample = batch.GetSample(n);

                if (!sample.HasDADData)
                    continue;

                string newFileName = $"{filenamePrefix}{newFilePath}-{sample.Details.SampleName}.{fileExtension.ToLower()}";
                newFilePath = Path.Combine(dirPath, newFileName);

                DADSample dadSample = sample.DADSample;
                int nSpectra = dadSample.NumberOfSpectra;

                double[] wavelengths = dadSample.GetWavelengthSpectrum(0).GetActualXValues();
                int nWavelengths = wavelengths.Length;

                TotalWavelengthChromatogram twc = dadSample.GetTotalWavelengthChromatogram();
                double[] times = twc.GetActualXValues();
                Debug.Assert(times.Length == nSpectra);

                // Save data to matrix
                Matrix mat = new()
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

                SaveMatrix(mat, nfi, delimiter, newFilePath, exportFormat, sigFigures, "min", "wavelength");
            }
        }

        /*
        public void test()
        {
            Sample sample = batch.GetSample(0);

            DADSample dadSample = sample.DADSample;
            MassSpectrometerSample msSample = sample.MassSpectrometerSample;

            //int mssCount = msSample.;
            MSExperiment mse = msSample.GetMSExperiment(0);
            int n = mse.Details.NumberOfScans;

            int nDAD = dadSample.NumberOfSpectra;

            double[] wavelengths = dadSample.GetWavelengthSpectrum(0).GetActualXValues();

            for (int i = 0; i < nDAD; i++)
            {
                WavelengthSpectrum ws = dadSample.GetWavelengthSpectrum(i);
                //double[] x = ws.GetActualXValues();
                double[] y = ws.GetActualYValues();
            }


            //printSampleInfo(sample);

            //Reader.printSampleInfo(sample);
            //int i = 0;


        }
        */

        public int GetNumberOfSamples()
        {
            return _provider.GetNumberOfSamples(this.wiffFilePath);
        }

    }
}
