using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfIntClass;
using RationalClass;

namespace infRationalClass
{
    public class infRational : Rational
    {
        private InfInt Numerator { get; set; }
        private InfInt Denominator { get; set; }
        private bool Positive;
        public infRational()
        {   //Default Constructor
            Numerator = new InfInt();
            Denominator = new InfInt();
            Positive = true;
        }

        public infRational(InfInt num, InfInt denom)
        {   //explicit value constructor 1
            this.Numerator = num;
            this.Denominator = denom;
            if((Numerator.CompareTo(new InfInt("0")) <0) || Denominator.CompareTo(new InfInt("0")) < 0) // if either numerator or denominator is negative
            {
                if ((Numerator.CompareTo(new InfInt("0")) < 0) && Denominator.CompareTo(new InfInt("0")) < 0)// if both are negative
                {
                    Positive = true;
                }
                else { Positive = false; }
            }
            else { Positive = true; }
        }
        public infRational(string input1, string input2)
        {   //explicit value constructor 2

            this.Numerator = new InfInt(input1);
            this.Denominator = new InfInt(input2);
            if((Numerator.CompareTo(new InfInt("0")) < 0) || Denominator.CompareTo(new InfInt("0")) < 0) // if either numerator or denominator is negative
            {
                if ((Numerator.CompareTo(new InfInt("0")) < 0) && Denominator.CompareTo(new InfInt("0")) < 0)// if both are negative
                {
                    Positive = true;
                }
                else { Positive = false; }
            }
            else { Positive = true; }
        }
    
        public override string ToString()
        {
            try
            {
                //string must return the fraction in the form a/b and in reduced form
                string strVal = $"{Numerator}/{Denominator}";
                if (Numerator == new InfInt("0")) { strVal = "0"; }
                if (Denominator == new InfInt("0")) { strVal = "Undefined"; }
                return strVal;
            }
            catch (Exception badToStringMethod)
            {
                throw badToStringMethod;
            }
        }
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
