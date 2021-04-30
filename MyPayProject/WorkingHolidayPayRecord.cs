using MyPayProject.Import;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayProject
{
    class WorkingHolidayPayRecord : PayRecord
    {
        public WorkingHolidayPayRecord(int id, double[] hours, double[] rates, int visa, int yearToDate) : base(id, hours, rates)
        {
            this.yearToDate = yearToDate;
            this.visa = visa;
        }


        public override double Tax
        {
            get
            {
                return TaxCalculator.CalculateWorkingHolidayTax(Gross, yearToDate);
            }
        }

        public int visa { get; set; }

        //TODO: Need total gross and YTD to added
        public int yearToDate { get; set; }

        public override string GetDetails()
        {
            return base.GetDetails();
        }
    }
}
