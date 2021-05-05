using MyPayProject.Import;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayProject.Import
{
    /// <summary>
    /// Created solely to calculate the tax, however there are two methods to calculate based of the different employee's data processed through.
    /// </summary>
    class TaxCalculator
    {

        /// <summary>
        /// Only the ResidentPayRecord data can go through this method has it meets the data needed to be proceed
        /// </summary>
        /// <param name="gross">This data is receieved through the ResidentPayRecord class, a total of hours multiplied by rates by the amount shifts the employee has done</param>
        /// <returns>different values are returned based on what the gross is</returns>
        public static double CalculateResidentialTax(double gross)
        {
            if (gross > -1 && gross <= 72)
            {
                return (0.19 * gross) - 0.19;
            }
            else if (gross > 72 && gross <= 361)
            {
                return (0.2342 * gross) - 3.213;
            }
            else if (gross > 361 && gross <= 932)
            {
                return (0.3477 * gross) - 44.2476;
            }
            else if (gross > 932 && gross <= 1380)
            {
                return (0.345 * gross) - 41.7311;
            }
            else if (gross > 1380 && gross <= 3111)
            {
                return (0.39 * gross) - 103.8657;
            }
            else if (gross > 3111 && gross <= 999999)
            {
                return (0.47 * gross) - 352.7888;
            }

            return 0;
        }

        /// <summary>
        /// Only the WorkingHolidayPayRecord data can go through this method has it meets the data needed to be proceed
        /// </summary>
        /// <param name="gross">This data is receieved through the WorkingHolidayClass class, a total of hours multiplied by rates by the amount shifts the employee has done</param>
        /// <param name="yearToDate">The data is only used to identify that only Working Holiday employee's information can only go through</param>
        /// <returns>different values are returned based on what the gross is</returns>
        public static double CalculateWorkingHolidayTax(double gross, double yearToDate)
        {
            if (gross > -1 && gross <= 37000)
            {
                return gross * 0.15;
            }
            else if (gross > 37000 && gross <= 90000)
            {
                return gross * 0.32;
            }
            else if (gross > 90000 && gross <= 180000)
            {
                return gross * 0.37;
            }
            else if (gross > 180000 && gross <= 9999999)
            {
                return gross * 0.45;
            }


            return 0;

        }


    }
}
