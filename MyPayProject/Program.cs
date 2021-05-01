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

            //TODO: Change file path
            PayRecordWriter.Write(finalPath, payRecords, true);
            

        }
    }
}
