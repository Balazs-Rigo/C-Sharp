using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter6
{
    public class Manager:Employee
    {
        public int StockOptions { get; set; }

        public Manager()
        {

        }

        public Manager(string fullName, int age, int empID,float currPay, string ssn, 
            int numbOfOpts)
            : base(fullName, age, empID, currPay, ssn)
        {
            // This property is defined by the Manager class.
            StockOptions = numbOfOpts;
        }
    }
}
