using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalClass
{
    public class Rational : IComparable 
    {
        private int Numerator { get;}
        private int Denominator { get;}

        public Rational()
        {
             //default constructor 
            Numerator = 0;
            Denominator = 0;
        }
        /// <summary>
        /// Rational constructor that takes 2 ints and simplifies the fraction using GCD function.
        /// stores values as numerator and denominator
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        public Rational(int numerator, int denominator)
        {
            //explicit value constructor that needs to be modified to reduce the fraction into smallest form so 2/4 must be reduced to 1/2
            try
            {
                int temp = GCD(numerator, denominator);
                this.Numerator = numerator / temp;
                this.Denominator = denominator / temp;
            }
            catch(DivideByZeroException divZero)
            {
                throw divZero;
            }


        }
        /// <summary>
        /// Added a private GCD function.
        /// recursive implimentation from online documentation of recursive GCD Formula
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>greatest common divisor</returns>
        private int GCD(int a, int b)
        {
            if (a == 0)
                return b;
            if (b == 0)
                return a;

            if (a > b)
                return GCD(a % b, b);
            else
                return GCD(a, b % a);
        }
        public int CompareTo(object obj)
        {
            try
            {   //compare two rational numbers and return an integer showing how they compare, it is up to you how you are going to handle the conversion of your number to int form 
                Rational otherObj = (Rational)obj;
                if (this.Equals(otherObj))
                {
                    return 0;
                }
                else if (this.Denominator <= otherObj.Denominator)
                {
                    if (this.Numerator > otherObj.Numerator) { return 1; }
                    else if (this.Numerator == otherObj.Numerator) { return 0; }
                }
                else
                {
                    if (this.Denominator > otherObj.Denominator) { return -1; }
                }
                return 0;
            }
            catch (ArgumentException arg)
            {
                throw arg;
            }
            catch(Exception e)
            {
                throw e;
            }

        }
        public override bool Equals(object obj)
        {
            //implement the standard equals method
            Rational otherObj = (Rational)obj;
            if (this.RationalToDecimal() == otherObj.RationalToDecimal())
            {
                return true;
            }
            else return false;

        }

        public override int GetHashCode()
        {
            //you do not have to implement this
            return base.GetHashCode();
        }
        /// <summary>
        /// puts numerator before / and denominator after
        /// checks for 0/number and number/0 and prints appropiate vals
        /// </summary>
        /// <returns>rational string</returns>
        public override string ToString()
        {
            try
            {
                //string must return the fraction in the form a/b and in reduced form
                string strVal = $"{Numerator}/{Denominator}";
                if (Numerator == 0) { strVal = "0"; }
                if (Denominator == 0) { strVal = "Undefined"; }
                return strVal;
            }
            catch(Exception badToStringMethod)
            {
                throw badToStringMethod;
            }
        }
        /// <summary>
        /// addition by creating common denominator and adding the results of cross multiplication
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Rational operator +(Rational a, Rational b)
        {
            return new Rational(a.Numerator * b.Denominator + b.Numerator * a.Denominator,
                a.Denominator * b.Denominator);
        }
        /// <summary>
        /// multiplacation of values numerator to numerator and denominator to denominator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Rational operator *(Rational a, Rational b)
        {
            return new Rational(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }
        /// <summary>
        /// subtraction by creating common denominator and subtracting the results of cross multiplication
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Rational operator -(Rational a, Rational b)
        {
            return new Rational(a.Numerator * b.Denominator - b.Numerator * a.Denominator,
                a.Denominator * b.Denominator);
        }
        /// <summary>
        /// division by cross multiplying numerator to denominator and denominator to numerator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Rational operator /(Rational a, Rational b)
        {
                if (b.Numerator != 0 && b.Denominator != 0)
                {
                    return new Rational(a.Numerator * b.Denominator, a.Denominator * a.Numerator);
                }
                else
                {
                throw new DivideByZeroException();
                }
        }
        /// <summary>
        /// takes the numberator and denominator and converts them to decimal
        /// then divides those 2 decimal numbers and returns the string inerpolation of the result.
        /// </summary>
        /// <returns>string of numberator divded by denominator in decimal form</returns>
        public string RationalToDecimal()
        {
            try
            {
                decimal decimalNumer = Convert.ToDecimal(this.Numerator);
                decimal decimalDenom = Convert.ToDecimal(this.Denominator);
                return ($"{decimalNumer / decimalDenom}");
            }
            catch(Exception e)
            {
                throw e;
            }

        }
    }
}
