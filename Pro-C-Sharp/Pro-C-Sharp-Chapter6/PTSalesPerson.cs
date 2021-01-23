using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter6
{
    public sealed class PTSalesPerson : SalesPerson
    {
        public PTSalesPerson()
        {

        }
        public PTSalesPerson(string fullName, int age, int empID,
        float currPay, string ssn, int numbOfSales)
        : base(fullName, age, empID, currPay, ssn, numbOfSales)
        {
        }
        // Assume other members here...
    }
}
