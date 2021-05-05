using System;
namespace MyPayProject
{
    /// <summary>
    /// An abstract class, can't be instantiate however the child class can override its method.
    /// </summary>
    /// <remarks>Contains information in order to calculate gross, tax and net</remarks>
    public abstract class PayRecord 
    {
        /// <summary>
        /// used to collect the hours and rate given in the parameter to be used in the class.
        /// </summary>
        private double[] _hours, _rates; 
        /// <summary>
        /// used to retrieve the information above and to be applied to data inside the method.
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <param name="hours">An array of hours</param>
        /// <param name="rates">An array of rates</param>
        protected PayRecord(int id, double[] hours, double[] rates)
        {
            this.Id = id;
            this._hours = hours;
            this._rates = rates; 
  
        }

        /// <summary>
        /// Receives the information regarding the employee's ID. Helps in gather all other data in shift to be calculate together
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Through the use of Id being the same in certain rows, the gross can be calculate by using array of hours and rates that has the same Id.
        /// </summary>
        public double Gross 
        { 
            get 
            {
                double gross = 0; 
                for (int i = 0; i < _hours.Length; i++)
                {
                    gross += _hours[i] * _rates[i];
                }
                return gross; 
            } 
        }

        /// <summary>
        /// Having this method helps the child classes to override and pass in the correct information to separate how tax is calculated based on type of employee.
        /// </summary>
        public abstract double Tax { get; }
        /// <summary>
        /// 
        /// </summary>
        public double Net
        {
            get
            {   
                return Gross - Tax; 
            }
        }

        /// <summary>
        /// This method is also overriden by the child classes with appropriate data based on the different of employee PayRecord classes.
        /// </summary>
        /// <returns>a empty string which can be overriden in the child classes</returns>
        public virtual string GetDetails()
        {

            return "";

                //My intial code that before looking at the assessment.
                //$"------------- EMPLOYEE: {Id} ------------\n" +
                //$"GROSS: {Gross:C}\n" +
                //$"NET: {Net:C}\n" +
                //$"TAX: {Tax:C}\n";
           
        }

       
    }

}
