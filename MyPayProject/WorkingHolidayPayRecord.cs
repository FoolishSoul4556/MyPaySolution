using MyPayProject.Import;
using System;

namespace MyPayProject
{
    /// <summary>
    /// A class created for different employee based on their data received through the .csv file
    /// </summary>
    /// <remarks>Inherits the information needed to override the parent class' methods.</remarks>
    class WorkingHolidayPayRecord : PayRecord
    {
        public WorkingHolidayPayRecord(int id, double[] hours, double[] rates, int visa, int yearToDate) : base(id, hours, rates)
        {
            this.YearToDate = yearToDate;
            this.visa = visa;
            
        }

        /// <summary>
        /// used to override the Tax getter method in the PayRecord class
        /// </summary>
        /// <remarks>Sends the information needed to the TaxCalculator, also pass the data type inside the parameters</remarks>
        public override double Tax
        {
            get
            {
                var TT = TaxCalculator.CalculateWorkingHolidayTax(Gross, YearToDate);
                return Math.Round(TT, 2);
            }
        }

        /// <summary>
        /// Gets information needed from the WorkingHolidayPayRecord method, which this information later sends to the GetDetails method.
        /// </summary>
        public int visa { get; private set; }
        /// <summary>
        /// An variable created to collect the value needed to do mathematic calculation to the YearToDate getter and setter
        /// </summary>
        private int ytd;
        /// <summary>
        /// Gets the information from the WorkingHolidayPayRecord method as well but getter returns ytd and setter is used set ytd as it's value
        /// </summary>
        /// <remarks>ytd equals the initial YearToDate amount added by the double convert to int gross data</remarks>
        public int YearToDate 
        {
            get
            {
                return ytd += Convert.ToInt32(Gross);
            }
            private set { ytd = value; }
            
        }

        /// <summary>
        /// Override the method in PayRecord to send the Working Holiday person's details to whichever class calls for the method.
        /// </summary>
        /// <returns>An string with data type need shown in the console</returns>
        /// <remarks>The ':C' is used to display the values as currency</remarks>
        public override string GetDetails()
        {            
            return base.GetDetails() +
                $"------------- EMPLOYEE: {Id} ------------\n" +
                $"GROSS: {Gross:C}\n" +
                $"NET: {Net:C}\n" +
                $"TAX: {Tax:C}\n" +
                $"VISA: {visa}\n" +
                $"YTD: {YearToDate:C}\n";
        }
    }
}
