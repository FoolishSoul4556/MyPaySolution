using MyPayProject.Import;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyPayProject
{
    /// <summary>
    /// A class created for different employee based on their data received through the .csv file
    /// </summary>
    /// <remarks>Inherits the information needed to override the parent class' methods.</remarks>
    class ResidentPayRecord : PayRecord
    {
        /// <summary>
        /// Helps in retrieving data from csvimporter class
        /// </summary>
        /// <param name="id">Emplouyee Id</param>
        /// <param name="hours">An array of hours</param>
        /// <param name="rates">An array of rates</param>
        public ResidentPayRecord(int id, double[] hours, double[] rates) : base(id, hours, rates) { }

        /// <summary>
        /// used to override the Tax getter method in the PayRecord class
        /// </summary>
        /// <remarks>Sends the information needed to the TaxCalculator, also pass the data type inside the parameters</remarks>
        public override double Tax
        {
            get
            {
                return TaxCalculator.CalculateResidentialTax(Gross);
            }
        }

        /// <summary>
        /// Override the method in PayRecord to send the Resident details to whichever class calls for the method.
        /// </summary>
        /// <returns>An string with data type need shown in the console</returns>
        public override string GetDetails()
        {
            return base.GetDetails() + 
                $"------------- EMPLOYEE: {Id} ------------\n" +
                $"GROSS: {Gross:C}\n" +
                $"NET: {Net:C}\n" +
                $"TAX: {Tax:C}\n";
        }
    }
}