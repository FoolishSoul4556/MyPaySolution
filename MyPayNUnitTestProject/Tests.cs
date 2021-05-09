using MyPayProject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyPayNUnitTestProject
{
    public class Tests
    {        
        private List<PayRecord> _records;
        [SetUp]
        public void Setup() 
        {
            string inputFolderPath = GetInputFolderPath();
            string finalPath = Path.Combine(inputFolderPath, "employee-payroll-data.csv");
            _records = CsvImporter.ImportPayRecords(finalPath);



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

        [Test]
        public void TestImport() 
        {
           Assert.IsNotNull(_records);
           Assert.AreEqual(_records.Count, 5);
        }

        [Test]
        public void TestGross() 
        {            
            Assert.AreEqual(_records[0].Gross, 652.00);
            Assert.AreEqual(_records[1].Gross, 418.00);
            Assert.AreEqual(_records[2].Gross, 2202);
            Assert.AreEqual(_records[3].Gross, 1104);
            Assert.AreEqual(_records[4].Gross, 1797.45);
            
        }

        [Test]
        public void TestTax() 
        {
            Assert.AreEqual(_records[0].Tax, 182.45);
            Assert.AreEqual(_records[1].Tax, 133.76);
            Assert.AreEqual(_records[2].Tax, 754.91);
            Assert.AreEqual(_records[3].Tax, 339.15);
            Assert.AreEqual(_records[4].Tax, 597.14);
        }

        [Test]
        public void TestNet() 
        {
            Assert.AreEqual(_records[0].Net, 469.55);
            Assert.AreEqual(_records[1].Net, 284.24);
            Assert.AreEqual(_records[2].Net, 1447.09);
            Assert.AreEqual(_records[3].Net, 764.85);
            Assert.AreEqual(_records[4].Net, 1200.31);
        }

        [Test]
        public void TestExport() 
        {
            
                string erelativePath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "..",
                    "..",
                    "..",
                    "Export"
                );

              
            
            string exportPath = Path.Combine(erelativePath, "Testresults.csv");
            PayRecordWriter.Write(exportPath, _records, true);

            Assert.IsTrue(File.Exists(exportPath));
        }
    }
}
