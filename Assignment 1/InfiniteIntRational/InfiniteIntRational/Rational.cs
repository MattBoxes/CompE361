using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalClass
{
    public class Rational : IComparable
    {
        private int Numerator { get; }
        private int Denominator { get; }

        public Rational()
        {
            //default constructor 
            Numerator = 0;
            Denominator = 0;
        }
        public Rational(int numerator, int denominator)
        {
            //explicit value constructor that needs to be modified to reduce the fraction into smallest form so 2/4 must be reduced to 1/2
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public int CompareTo(object obj)
        {
            //compare two rational numbers and return an integer showing how they compare, it is up to you how you are going to handle the conversion of your number to int form 
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            //implement the standard equals method
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            //you do not have to implement this
            return base.GetHashCode();
        }

        public override string ToString()
        {
            //string must return the fraction in the form a/b and in reduced form
            return base.ToString();
        }

        public static Rational operator +(Rational a, Rational b)
        {
            return new Rational(a.Numerator * b.Denominator + b.Numerator * a.Denominator,
                a.Denominator * b.Denominator);
        }
        public static Rational operator *(Rational a, Rational b)
        {
            return new Rational(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static Rational operator -(Rational a, Rational b)
        {
            throw new NotImplementedException();
        }

        public static Rational operator /(Rational a, Rational b)
        {
            return new Rational(a.Numerator * b.Denominator + b.Numerator * a.Denominator,
                a.Denominator * b.Denominator);
        }

        public string RationalToDecimal()
        {
            throw new NotImplementedException();
        }
    }
}
