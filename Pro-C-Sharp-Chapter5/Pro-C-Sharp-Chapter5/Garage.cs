using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter5
{
    public class Garage
    {
        // The hidden int backing field is set to zero!
        public int NumberOfCars { get; set; } = 100;
        // The hidden Car backing field is set to null!
        public Car MyAuto { get; set; }
    }
}
