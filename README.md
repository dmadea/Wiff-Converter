# Wiff-Converter

This simple utility allows to open the AB Sciex `*.wiff` files and export the raw Mass and absorption data to the specified text format as a matrix. It is necessary to include the following vendor libraries:

* Clearcore2.Compression.dll
* Clearcore2.Data.AnalystDataProvider.dll
* Clearcore2.Data.Client.dll
* Clearcore2.Data.CommonInterfaces.dll
* Clearcore2.Data.dll
* Clearcore2.Data.Wiff2.dll
* Clearcore2.Data.WiffReader.dll
* Clearcore2.Devices.Types.dll
* Clearcore2.Domain.Acquisition.dll
* Clearcore2.Infrastructure.dll
* Clearcore2.InternalRawXYProcessing.dll
* Clearcore2.Muni.dll
* Clearcore2.RawXYProcessing.dll
* Clearcore2.StructuredStorage.dll
* Clearcore2.Utility.dll
* Clearcore2.XmlHelpers.dll
* SCIEX.Apis.Data.v1.dll
* Sciex.Clearcore.FMan.dll
* Sciex.Data.Processing.dll
* Sciex.Data.SimpleTypes.dll
* Sciex.Data.XYData.dll
* Sciex.FMan.dll
* Sciex.Wiff.dll

These can be obtained by installing [ProteoWizard](https://proteowizard.sourceforge.io/download.html) (download the version that support to convert vendor files) and copying the files listed above located in the instalation folder to the `Wiff Converter/bin/Release/` folder containing the executable of the utility.


## Use

When loading, both `*.wiff` and `*.wiff.scan` files need to be located in the same folder. If the sample contains the absorption data, corresponding matrix will be exported to the file which start with a prefix `UV_`. MS matrix file will start with `MS_`.