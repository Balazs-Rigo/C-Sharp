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

        // Contain a BenefitPackage object.
        protected BenefitPackage empBenefits = new BenefitPackage();

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

        public string SocialSecurityNumber { get => empSSN; set => empSSN = value; }

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

        // Expose certain benefit behaviors of object.
        public double GetBenefitCost()
        { return empBenefits.ComputePayDeduction(); }
        // Expose object through a custom property.
        public BenefitPackage Benefits
        {
            get { return empBenefits; }
            set { empBenefits = value; }
        }

        // This method can now be "overridden" by a derived class.
        public virtual void GiveBonus(float amount)
        {
            Pay += amount;
        }

        public virtual void DisplayStats()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("ID: {0}", ID);
            Console.WriteLine("Age: {0}", Age);
            Console.WriteLine("Pay: {0}", Pay);
            Console.WriteLine("SSN: {0}", SocialSecurityNumber);
        }
    }
}
