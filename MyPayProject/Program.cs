using System;
using System.Collections.Generic;
using System.IO;


namespace MyPayProject
{
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
            
            ///<summary>
            /// To access the file path in order to access the .csv file
            /// </summary>
            /// <remarks>The use of relativePath is cruical in finding obtaining the data to initialize the data reading process</remarks>
            /// <returns>the string contain the full path</returns>
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

            ///<summary>
            /// To get information from the PayRecordWriter and write data into .csv file.
            /// </summary>
            /// <remarks>This is only executed after all other methods has met its logic and processed.</remarks>
            /// <returns>the string contain the full path and finalises in creating the document inside the Export folder</returns>
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
