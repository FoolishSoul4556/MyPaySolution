using System;
using System.Collections;
using System.Collections.Generic;
using CsvHelper;
using System.IO;
using System.Globalization;

namespace MyPayProject
{
    class CsvImporter
    {
        /// <summary>
        /// To process the importing of the .csv file
        /// </summary>
        /// <remarks>the use of the library CsvHelper has made this process much more faster</remarks>
        /// <param name="file">The string file is linked with the main program to access the file</param>
        /// <returns>The payroll gather the information from it headers (row) and data(column) into a List that is accessible through the PayRecord class.</returns>
        public static List<PayRecord> ImportPayRecords(string file)
        {
            List<PayRecord> payroll = new List<PayRecord>();
            Dictionary<int, List<double>> hours = new Dictionary<int, List<double>>();
            Dictionary<int, List<double>> rates = new Dictionary<int, List<double>>();
            Dictionary<int, string> visa = new Dictionary<int, string>();
            Dictionary<int, string> yearToDate = new Dictionary<int, string>();

            //CsvHelper code
            using (StreamReader reader = new StreamReader(file))

            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {

                var records = csv.GetRecords<dynamic>();

                //Reads the header line
                csv.Read();
                csv.ReadHeader();


                //Reads all other lines
                while (csv.Read())
                {

                    int id = int.Parse(csv.GetField("EmployeeId"));
                    double hour = double.Parse(csv.GetField("Hours"));
                    double rate = double.Parse(csv.GetField("Rate"));
                    string visas = csv.GetField("Visa");
                    string yearToDates = csv.GetField("YearToDate");

                    visa.TryAdd(id, visas);
                    yearToDate.TryAdd(id, yearToDates);

                    AddHours(hours, id, hour);
                    AddRates(rates, id, rate);
                }
            }
            
            static void AddHours(Dictionary<int, List<double>> hours, int id, double hour)
            {
                List<double> empHours;
                if (hours.TryGetValue(id, out empHours))
                {
                    empHours.Add(hour);
                }
                else
                {
                    empHours = new List<double>();
                    empHours.Add(hour);
                    hours.Add(id, empHours);
                }
            }

            static void AddRates(Dictionary<int, List<double>> rates, int id, double rate)
            {
                List<double> empRates;
                if (rates.TryGetValue(id, out empRates))
                {
                    empRates.Add(rate);
                }
                else
                {
                    empRates = new List<double>();
                    empRates.Add(rate);
                    rates.Add(id, empRates);
                }
            }

            foreach (int id in hours.Keys)
            {

                double[] Hour = hours[id].ToArray();
                double[] Rate = rates[id].ToArray();
                string Visa = visa[id];
                string YearToDate = yearToDate[id];
                PayRecord payRecord = CreatePayRecord(id, Hour, Rate, Visa, YearToDate);
                payroll.Add(payRecord);
            }

            return payroll;
        }


        /// <summary>
        /// Receives information from the ImportPayRecord and split the data
        /// </summary>
        /// <remarks>The data is send to the child classes of PayRecord, as the ResidentPayRecord and WorkingHolidayPayRecord methods have different data require in there parameter</remarks>
        /// <param name="id">The EmployeeID, important in gathering the correct hours, rates, visa and yearToDate.</param>
        /// <param name="hours">A array (list) of all the hours</param>
        /// <param name="rates">A array (list) of all the rates</param>
        /// <param name="visa">A string to be used identify who's not a resdient</param>
        /// <param name="yearToDate">Another data like the visa to identify who is not a resident</param>
        /// <returns>The 'if' & 'else' statements helps in returning the information to the right classes, as the visa and yearToDate only applies to the WorkingHolidayPayRecord.</returns>
        public static PayRecord CreatePayRecord(int id, double[] hours, double[] rates, string visa, string yearToDate)
        {
            if (visa != "" && yearToDate != "")
            {
                int V = int.Parse(visa);
                int ytd = int.Parse(yearToDate);
                return new WorkingHolidayPayRecord(id, hours, rates, V, ytd);
            }
            else
            {
                return new ResidentPayRecord(id, hours, rates);
            }

        }



    }


}

