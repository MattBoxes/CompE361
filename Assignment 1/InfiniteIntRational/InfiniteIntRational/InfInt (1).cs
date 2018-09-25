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

        
        public InfInt(string input){
            try
            {
                // taking size as DIGITS and not actual input.length as in rest of the program DIGITS is used
                this.Integer = new int[DIGITS];
                for (int i = 0; i < input.Length; i++)
                {
                    Integer[DIGITS - input.Length + i] = input[i] - '0';
                }

                if (input[0] != '-')
                    this.Positive = true;
                else
                    this.Positive = false;
            }
            catch(IndexOutOfRangeException tooBig)
            {
                Console.WriteLine($"you input is too big");
                throw tooBig;
            }
            catch(Exception e) { throw e; }

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

                for (int i = 0; i >= 0; i++)
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
            InfInt temp = new InfInt();
            return temp;
        }

        public InfInt Divide(InfInt divValue)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Had longer method but found easier solution. joins array into a string
        /// </summary>
        /// <returns>string of value</returns>
        public override string ToString()
        {
<<<<<<< HEAD
            throw new NotImplementedException();
=======
            return string.Join("", Integer);
>>>>>>> refs/remotes/origin/master
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
                            return -1;
                        else if (Integer[i] < otherInt.Integer[i])
                            return 1;
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
