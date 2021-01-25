using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter6
{
    public class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; }
        public Person(string fName, string lName, int personAge)
        {
            FirstName = fName;
            LastName = lName;
            Age = personAge;
        }
        public Person() { }

    }
}
