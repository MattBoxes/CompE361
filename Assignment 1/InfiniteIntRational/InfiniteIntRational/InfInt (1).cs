using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfIntClass
{
    public class InfInt : IComparable
    {
        private const int DIGITS = 40; //max size is 40
        private int[] Integer { get; set; } //array containing our infint
        private bool Positive { get; set; } //is it positive

        //default value constructor
        public InfInt()
        {
            Integer = new int[DIGITS];
            Positive = true;
        }

        /// <summary>
        /// Takes in string input and transfers it into int array called Integer.
        /// loop through string length and check if valid numerical chars before putting into array.
        /// puts numbers at end of array for easier operation on values.
        /// checks for negative at beginning.
        /// Does not remove non numerical values but just uses their character code as a value.
        /// Recieved portion of this code from StackExchange
        /// </summary>
        /// <param name="input"></param>
        public InfInt(string input)
        {
            try
            {
                Integer = new int[DIGITS];
                for (int i = 0; i < input.Length; i++)

                    if (input[i] >= '0' && input[i] <= '9')
                    {
                        Integer[DIGITS - input.Length + i] = input[i] - '0';
                    }



                if (input[0] != '-')
                    this.Positive = true;
                else
                    this.Positive = false;

            }
            catch (FormatException text)
            {
                Console.WriteLine("Not a valid number");
                throw text;
            }

            catch (IndexOutOfRangeException tooBig)
            {
                Console.WriteLine($"you input is too big");
                throw tooBig;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
           


//freebie add courtesy of professor amack
public InfInt Add(InfInt addValue)
        {
            InfInt temp = new InfInt();
            if (Positive == addValue.Positive)
            {
                temp = AddPositives(addValue);
            }
            //addvalue is negative
            else if (Positive && (!addValue.Positive))
            {
                addValue.Positive = true;
                if (IsGreaterThan(addValue))
                {
                    temp = SubtractPositives(addValue);
                }
                else
                {
                    temp = addValue.SubtractPositives(this);
                    temp.Positive = false;
                }

                addValue.Positive = false;
            }
            else if (!Positive && addValue.Positive)
            {
                addValue.Positive = false;

                if (IsGreaterThan(addValue))
                {
                    temp = addValue.SubtractPositives(this);
                }
                else
                {
                    temp = SubtractPositives(addValue);
                    temp.Positive = false;
                }

                addValue.Positive = true;
            }
            return temp;
        }
        /// <summary>
        /// Follow same convention as AddPositives except the using subtraction and checking for a negative value
        /// to account for a borrow of the next value
        /// </summary>
        /// <param name="addValue"></param>
        /// <returns></returns>
        private InfInt SubtractPositives(InfInt addValue)
        {
            InfInt temp = new InfInt();
            int borrow = 0;
            //iterate the infint
            for (int i = DIGITS - 1; i >= 0; i--)
            {
                temp.Integer[i] = Integer[i] - addValue.Integer[i] - borrow;
                //determine if we need to carry the 1 
                if (temp.Integer[i] < 0)
                {
                    temp.Integer[i] += 10; //reduce to 0-9
                    borrow = 1;
                }
                else
                {
                    borrow = 0;
                }
            }

            if (!Positive)
            {
                temp.Positive = false;
            }

            return temp;
        }
        /// <summary>
        /// Checks if argument passed in is greater than or equal to calling function
        /// </summary>
        /// <param name="addValue"></param>
        /// <returns>true if greater than, false if not</returns>
        private bool IsGreaterThan(InfInt addValue)
        {
            bool isGreater = true;
            if (Positive && !addValue.Positive)
            {
                isGreater = true;
            }
            else if (!Positive && addValue.Positive)
            {
                isGreater = false;
            }
            else if (!Positive && !addValue.Positive)
            {

                for (int i = DIGITS - 1; i >= 0; i--)
                {
                    if (Integer[i] < addValue.Integer[i])
                    {
                        isGreater = true;
                    }
                    else if (Integer[i] > addValue.Integer[i])
                    {
                        isGreater = false;
                    }
                }
            }
            else
            {
                for (int i = DIGITS - 1; i >= 0; i--)
                {
                    if (Integer[i] > addValue.Integer[i])
                    {
                        isGreater = true;
                    }
                    else if (Integer[i] < addValue.Integer[i])
                    {
                        isGreater = false;
                    }
                }
            }

            return isGreater;
        }
        /// <summary>
        /// Adds two values if both are postive, check with greather than
        /// </summary>
        /// <param name="addValue"></param>
        /// <returns></returns>
        private InfInt AddPositives(InfInt addValue)
        {
            InfInt temp = new InfInt();
            int carry = 0;
            //iterate the infint
            for (int i = DIGITS - 1; i >= 0; i--)
            {
                temp.Integer[i] = Integer[i] + addValue.Integer[i] + carry;
                //determine if we need to carry the 1 
                if (temp.Integer[i] > 9)
                {
                    temp.Integer[i] %= 10; //reduce to 0-9
                    carry = 1;
                }
                else
                {
                    carry = 0;
                }
            }

            if (!Positive)
            {
                temp.Positive = false;
            }

            return temp;
        }
        /// <summary>
        /// Subtracts from InfInt by looping through array at DIGITS-1 to 0
        /// uses helper functions like greaterthan and subtractpositives
        /// </summary>
        /// <param name="subtractValue"></param>
        /// <returns>negative or positive InfInt Value</returns>
        public InfInt Subtract(InfInt subtractValue)
        {
            InfInt temp = new InfInt(); // temporary result

            // subtractValue is negative
            if (Positive && (!subtractValue.Positive))
            {
                temp = AddPositives(subtractValue);
            }
            // this InfInt is negative
            else if (!Positive && subtractValue.Positive)
            {
                temp = AddPositives(subtractValue);
            }
            // at this point, both InfInts have the same sign
            else
            {
                bool isPositive = Positive; // original sign
                bool resultPositive = Positive; // sign of the result

                // set both to positive so we can compare absolute values
                Positive = true;
                subtractValue.Positive = true;

                if (this.IsGreaterThan(subtractValue))
                {
                    temp = this.SubtractPositives(subtractValue);
                }
                else
                {
                    temp = subtractValue.SubtractPositives(this);
                    resultPositive = !isPositive; // flip the sign
                }

                Positive = isPositive;
                subtractValue.Positive = isPositive;
                temp.Positive = resultPositive;
            }

            return temp;
        }

        public InfInt Multiply(InfInt multValue)
        {
            InfInt temp = new InfInt("0");
            int carry = 0;
            if ((multValue.ToString() == "0" || multValue.ToString() == "-0") || (this.ToString() == "0" || this.ToString() == "-0"))
            {
                temp = new InfInt("0");
                return temp;
            }
            else
            {
                for (int i = (DIGITS - 1); i >= 0; i--)
                {
                    int offset = i;
                    carry = 0;

                for (int j = (DIGITS - 1); j >= 0; j--)
                        {
                            temp.Integer[j+offset] = temp.Integer[j+offset] + (this.Integer[i] * multValue.Integer[j]) + carry;
                            if (temp.Integer[j] > 9)
                            {
                                carry = temp.Integer[j] / 10;
                                temp.Integer[j] %= 10;
                            }
                            else carry = 0;
                        }
                }
                return temp;
            }

        }
        /// <summary>
        /// calling function is divided by value passed in.
        /// 
        /// </summary>
        /// <param name="divValue"></param>
        /// <returns></returns>
        public InfInt Divide(InfInt divValue)
        {
            InfInt quotient = new InfInt();
            InfInt Dividend = this; // assigned to new infint because 'this' is read only
            try
            {
                if (divValue.ToString() == "0" || divValue.ToString() == "-0") //cannot divide by 0
                {
                    Console.WriteLine("Cannot Divide by 0");
                    return null;
                }
                else
                {
                   
                    // if the divisor is not bigger than dividend the divide
                    while (Dividend.IsGreaterThan(divValue))
                    { // if the divisor is not bigger than dividend the divide
                        
                        Dividend = Dividend.Subtract(divValue);
                        quotient = quotient.Add(new InfInt("1")); // increment quotient
                      
                    }
                    return quotient;
                }
            }
            catch(FormatException badDivisor)
            {
                throw badDivisor;
            }
        }
        /// <summary>
        /// joins array into string then trims remaining zeros. will then add negative sign if needed
        /// </summary>
        /// <returns>string of value</returns>
        public override string ToString()
        {
            
            string strVal = string.Join("", Integer);
            strVal = strVal.TrimStart('0');
            if (strVal == "") { strVal = "0"; }
            if (!Positive) { strVal = $"-{strVal}"; };

            return strVal;

        }

        public int CompareTo(object obj)
        {
            try
            {
                InfInt otherInt = (InfInt)obj;
                if (Integer.ToString() == otherInt.ToString()) //check if exact same value before looping
                {
                    return 0;
                }
                else
                {
                    for (int i = 0; i < DIGITS; i++)
                    {
                        if (Integer[i] > otherInt.Integer[i])
                            return 1;
                        else if (Integer[i] < otherInt.Integer[i])
                            return -1;
                    }
                    return 0;
                    
                }
            }
            catch (Exception e)
            {
                throw e;
            }
    }
}


    

}
