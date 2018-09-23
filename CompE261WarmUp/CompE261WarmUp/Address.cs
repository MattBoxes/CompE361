using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// I used the Official Microsoft Documentation for .NET to understand and impliment the GetType() function and the Equals(Object)
/// https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype?view=netframework-4.7.2
/// https://docs.microsoft.com/en-us/dotnet/api/system.object.equals?view=netframework-4.7.2#System_Object_Equals_System_Object_
/// </summary>
namespace Warmup
{

    public class Address : IComparable<Address>
    {
        public Address(string firstName = null, string lastName = null, string lineOne = null, string lineTwo = null, string city = null, string state = null, int zipCode = 0, DateTime birthDate = default(DateTime), string phoneNumber = null)
        {
            FirstName = firstName;
            LastName = lastName;
            LineOne = lineOne;
            LineTwo = lineTwo;
            City = city;
            State = state;
            ZipCode = zipCode;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }

        /// <summary>
        /// String format of to string function that displays the values of an Address instance by the homework's specification.
        /// </summary>
        /// <returns>The string format outline by the homework</returns>
        public override string ToString()
        {
            return "Name: " + FirstName + " " + LastName + "\n" 
                +  "Address One: " + LineOne + "\n"
                +  "Address Two: " + LineTwo + "\n"
                +  "City: " + City + ", " + State + "\n"
                +  "Phone: " + PhoneNumber + "\n";
        }
        /// <summary>
        /// This function checks if the object passed into the parameter is equal to calling object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>False if null, unequal types, or if any values are unequivalent. Returns True if all values are equivalent</returns>
        public override bool Equals(object obj)
        {   ///Checks if the argument passed in is not null and is of the same address type
            if (obj == null || this.GetType() != obj.GetType()){
                return false;
            }else { /// Checks all values of both objects
                Address arg = (Address)obj;
                return (FirstName == arg.FirstName) && (LastName == arg.LastName) 
                    && (LineOne == arg.LineOne) && (LineTwo == arg.LineTwo) 
                    && (City == arg.City) && (State == arg.State) && (ZipCode == arg.ZipCode)
                    && (BirthDate == arg.BirthDate) && (PhoneNumber == arg.PhoneNumber);
            }
        }
        /// <summary>
        /// Hashes the object
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// This compares Address classes by first their LastName, then FirstName, then Zipcode and returns
        /// a value of -1,0,or 1 depending on the difference by string or integer.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>-1,0,1 depending on checks for LastName,FirstName, and ZipCode</returns>
        public int CompareTo(Address other)
        {
            
            if (this.Equals(other)) { return 0; }
            else if(LastName.CompareTo(other.LastName) == 0) ///First checks Last Name difference
            {
                if(FirstName.CompareTo(other.FirstName) == 0) ///Checks for First Name difference if Last Name is the same
                {
                    return ZipCode.CompareTo(other.ZipCode);/// If last and first name are the same return zipcode difference
                }
                else
                {
                    return FirstName.CompareTo(other.FirstName);/// returns firstname string difference if LastName == 0
                }
            }
            else { return LastName.CompareTo(other.LastName); }///returns lastname string difference if not == 0
    
        }

    }
}
