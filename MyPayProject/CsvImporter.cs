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

