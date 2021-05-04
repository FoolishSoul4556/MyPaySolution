using System;
namespace MyPayProject
{
    public abstract class PayRecord 
    {
        private double[] _hours, _rates; 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hours"></param>
        /// <param name="rates"></param>
        protected PayRecord(int id, double[] hours, double[] rates)
        {
            this.Id = id;
            this._hours = hours;
            this._rates = rates; 
  
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// 
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
        /// 
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
       /// 
       /// </summary>
       /// <returns></returns>
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
