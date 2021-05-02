using System;
using System.Collections.Generic;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Text;

namespace MyPayProject
{
    class PayRecordWriter
    {
        //TODO: have resident and working class pay record to be transferred into PayRecordWriter
        public static void Write(string file, List<PayRecord> records, bool writeToConsole = false)
        {
            foreach(PayRecord record in records)
            {
                if (writeToConsole)
                {
                    Console.WriteLine(record.GetDetails());
                }
            }

            using (var writer = new StreamWriter(file))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(records);
                }
            }
        }        
    }
}

