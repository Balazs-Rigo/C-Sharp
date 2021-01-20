using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter5
{
    public class Motorcycle
    {
        public int driverIntensity;
        public string driverName;
        // Constructor chaining.
        public Motorcycle()
        {
            Console.WriteLine("In default ctor");
        }
        public Motorcycle(int intensity)
        : this(intensity, "")
        {
            Console.WriteLine("In ctor taking an int");
        }
        // This is the 'master' constructor that does all the real work.
        
        public Motorcycle(string name)
        : this(0, name)
        {
            Console.WriteLine("In ctor taking a string");
        }
        public Motorcycle(int intensity = 0, string name = "")
        {
            if (intensity > 10)
            {
                intensity = 10;
            }
            driverIntensity = intensity;
            driverName = name;
        }
    }
}
