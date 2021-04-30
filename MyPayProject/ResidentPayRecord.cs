using MyPayProject.Import;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyPayProject
{
    class ResidentPayRecord : PayRecord
    {
        public ResidentPayRecord(int id, double[] hours, double[] rates) : base(id, hours, rates) { }


        public override double Tax
        {
            get
            {
                return TaxCalculator.CalculateResidentialTax(Gross);
            }
        }

        public override string GetDetails()
        {
            return base.GetDetails();
        }
    }
}