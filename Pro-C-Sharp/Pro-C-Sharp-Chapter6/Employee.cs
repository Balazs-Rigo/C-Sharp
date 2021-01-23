using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter6
{
    public class Employee
    {
        // Field data.
        private string empName;
        private int empID;
        private float currPay;
        private int empAge;
        private string empSSN;
        protected string empNameProtected;

        // Properties!
        public string Name
        {
            get { return empName; }
            set
            {
                if (value.Length > 15)
                    Console.WriteLine("Error! Name length exceeds 15 characters!");
                else
                    empName = value;
            }
        }
        public int ID
        {
            get { return empID; }
            set { empID = value; }
        }
        public float Pay
        {
            get { return currPay; }
            set { currPay = value; }
        }
        public int Age
        {
            get => empAge;
            set => empAge = value;
        }

        public Employee()
        {

        }

        public Employee(string name, int age, int id, float pay)
        {
            empName = name;
            empAge = age;
            empID = id;
            currPay = pay;
        }

        // Add to the Employee base class.
        public Employee(string name, int age, int id, float pay, string ssn)
        : this(name, age, id, pay)
        {
            empSSN = ssn;
        }
    }
}
