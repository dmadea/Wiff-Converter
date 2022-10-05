using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Diagnostics;


using Clearcore2.Data;
using Clearcore2.Data.AnalystDataProvider;
using Clearcore2.Data.DataAccess;
using Clearcore2.Data.DataAccess.SampleData;
using Sciex.Data.XYData;
using Clearcore2.RawXYProcessing;
using System.ComponentModel;
using System.Globalization;

// inspiration from https://github.com/vdemichev/DiaNN/blob/master/WiffReader/WiffReader.cpp
// and https://github.com/ProteoWizard/pwiz/blob/master/pwiz/data/vendor_readers/ABI/Reader_ABI.cpp

namespace WiffReader
{
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

            //string[] names = batch.GetSampleNames();
        }

        public static void printSampleInfo(Sample sample)
        {
            Debug.WriteLine($"Has Mass data: {sample.HasMassSpectrometerData}\n" +
                            $"Has DAD data: {sample.HasDADData}\n" +
                            $"Has ACD data: {sample.HasADCData}");


            SampleInfo si = sample.Details;

            Debug.WriteLine(si.ToString());
        }

        public void SaveAbsorptionMatrix(string prefix = "UV_")
        {
            string? filename = Path.GetFileName(wiffFilePath);
            string newFilename = Path.GetFileNameWithoutExtension(filename);
            string? dirPath = Path.GetDirectoryName(wiffFilePath);

            if (dirPath is null)
                return;

            for (int i = 0; i < numberOfSamples; i++)
            {
                Sample sample = batch.GetSample(i);

                if (!sample.HasDADData)
                    continue;

                newFilename = Path.Combine(dirPath, $"{prefix}{newFilename}-{sample.Details.SampleName}.csv");

                DADSample dadSample = sample.DADSample;
                int nSpectra = dadSample.NumberOfSpectra;

                double[] wavelengths = dadSample.GetWavelengthSpectrum(0).GetActualXValues();
                TotalWavelengthChromatogram twc = dadSample.GetTotalWavelengthChromatogram();
                double[] times = twc.GetActualXValues();

                Debug.Assert(times.Length == nSpectra);

                using (StreamWriter sw = new StreamWriter(new FileStream(newFilename, FileMode.Create, FileAccess.Write), Encoding.UTF8))
                {

                    string firstLine = "min -> wavelength," + string.Join(',', wavelengths.Select(num => num.ToString("G6", CultureInfo.InvariantCulture)));
                    sw.WriteLine(firstLine);

                    for (int j = 0; j < nSpectra; j++)
                    {
                        WavelengthSpectrum ws = dadSample.GetWavelengthSpectrum(j);
                        double[] y = ws.GetActualYValues();
                        Debug.Assert(y.Length == wavelengths.Length);
                        //throw new Exception("Number of points in absorption data are not equal to that of wavelength points");

                        sw.WriteLine(times[j].ToString("G6", CultureInfo.InvariantCulture) + "," + string.Join(',', y.Select(num => num.ToString("G6", CultureInfo.InvariantCulture))));
                    }
                }
            }
        }


        public void test()
        {

            //WiffSampleLocator wsl = new WiffSampleLocator(wiffFilePath, sampleIndex);

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


            printSampleInfo(sample);

            //Reader.printSampleInfo(sample);
            //int i = 0;


        }

        public int GetNumberOfSamples()
        {
            return _provider.GetNumberOfSamples(this.wiffFilePath);

        }





    }
}
