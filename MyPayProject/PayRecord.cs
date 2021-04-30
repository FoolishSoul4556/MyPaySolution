using System;



namespace MyPayProject
{
    public abstract class PayRecord 
    {
        private double[] _hours, _rates; 

        protected PayRecord(int id, double[] hours, double[] rates)
        {
            this.Id = id;
            this._hours = hours;
            this._rates = rates; 
  
        }

        
        public int Id { get; private set; }
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


        public abstract double Tax { get; }

        public double Net
        {
            get
            {
                return Gross - Tax; 
            }
        }

        //TODO: have resident and working class pay record to be transferred into PayRecordWriter
        public virtual string GetDetails()
        {
            return "";
           
        }

       
    }

}
