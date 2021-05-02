using MyPayProject.Import;
using System;

namespace MyPayProject
{
    class WorkingHolidayPayRecord : PayRecord
    {
        public WorkingHolidayPayRecord(int id, double[] hours, double[] rates, int visa, int yearToDate) : base(id, hours, rates)
        {
            this.YearToDate = yearToDate;
            this.visa = visa;
            
        }


        public override double Tax
        {
            get
            {
                return TaxCalculator.CalculateWorkingHolidayTax(Gross, YearToDate);
            }
        }

        public int visa { get; private set; }
        private int ytd;
        public int YearToDate 
        {
            get
            {
                return ytd += Convert.ToInt32(Gross);
            }
            private set { ytd = value; }
            
        }
        
        public override string GetDetails()
        {            
            return base.GetDetails() +
                $"VISA: ${visa}\n" +
                $"YTD: ${YearToDate}\n";
        }
    }
}
