using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter6
{
    public class SalesPerson : Employee
    {
        public int SalesNumber { get; set; }

        public SalesPerson()
        {

        }

        public SalesPerson(string fullName, int age, int empID, float currPay, string ssn, 
            int numbOfSales)
            : base(fullName, age, empID, currPay, ssn)
        {
            // This belongs with us!
            SalesNumber = numbOfSales;
        }
    }
}
