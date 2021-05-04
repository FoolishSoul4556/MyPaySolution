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
       /// <summary>
       /// 
       /// </summary>
       /// <param name="file"></param>
       /// <param name="records"></param>
       /// <param name="writeToConsole"></param>
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

