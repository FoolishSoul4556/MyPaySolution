using System;
using System.Collections.Generic;
using System.IO;


namespace MyPayProject
{
    class Program
    {
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
