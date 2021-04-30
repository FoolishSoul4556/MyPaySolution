using System;
using System.Collections.Generic;
using System.IO;

namespace MyPayProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Due to an error that kepts on appearing the file here saved in MyPayProject\bin\Debug\netcoreapp3.1
            //var results = CsvImporter.ImportPayRecords("Import/employee-payroll-data.csv");
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


        }
    }
}
