using System;
using System.Collections.Generic;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Text;

namespace MyPayProject
{
    /// <summary>
    /// The class solely used to towards the end of program's process where the all data gets collected to be send to Program class to display and  write .csv file with the new data (id, gross, tax, net and ytd).
    /// </summary>
    class PayRecordWriter
    {
       /// <summary>
       /// a method solely used to write the data into the console as well as .csv file
       /// </summary>
       /// <param name="file">referring to .csv file</param>
       /// <param name="records">all data as mentioned before are recorded here</param>
       /// <param name="writeToConsole">if the condition are met then bool will equal true executing the details into console.</param>
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

