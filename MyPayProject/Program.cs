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
            
            string inputFolderPath = GetInputFolderPath();
            string finalPath = Path.Combine(inputFolderPath, "employee-payroll-data.csv");
            List<PayRecord> payRecords = CsvImporter.ImportPayRecords(finalPath);
            

            
            static string GetInputFolderPath()
            {
                string relativePath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "..",
                    "..",
                    "..",
                    "Import"
                );
                return Path.GetFullPath(relativePath);
            }

            string ExportFolderPath = GetExportFolderPath();
            string exportPath = Path.Combine(ExportFolderPath, $"{DateTime.Now.Ticks}.csv");
            PayRecordWriter.Write(exportPath, payRecords, true);

           
            static string GetExportFolderPath()
            {
                string erelativePath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "..",
                    "..",
                    "..",
                    "Export"
                );
                
                return Path.GetFullPath(erelativePath);
            }
            

        }
    }
}
