using System;
using System.Collections.Generic;
using System.IO;


namespace MyPayProject
{
    /// <summary>
    /// The first (main) class that get execute when the code is compiled.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Executes the input file path in beginning and exportation process at end
        /// </summary>
        /// <param name="args"></param>
        /// <returns>and returns either the GetInputFolderPath method (for reading the file when program starts) and GetExportFolderPath method (for writing the file before the program ends)</returns>
        static void Main(string[] args)
        {
            //Importing the .csv file linked with csvimporter.cs
            string relativePath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "..",
                    "..",
                    "..",
                    "Import"
                );
            
            string importPath = Path.Combine(relativePath, "employee-payroll-data.csv");
            List<PayRecord> payRecords = CsvImporter.ImportPayRecords(importPath);


            //Exporting the .csv file linked with PayRecordWriter.cs
            string erelativePath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "..",
                    "..",
                    "..",
                    "Export"
                );
                                   
            string exportPath = Path.Combine(erelativePath, $"{DateTime.Now.Ticks}.csv");
            PayRecordWriter.Write(exportPath, payRecords, true);

           
            
            

        }
    }
}
