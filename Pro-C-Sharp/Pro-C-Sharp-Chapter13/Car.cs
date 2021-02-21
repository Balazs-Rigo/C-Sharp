using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter13
{
    public class Car
    {
        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }
        public Car() { }
        public Car(string name, int speed)
        {
            PetName = name;
            CurrentSpeed = speed;
        }
        public override string ToString() => $"{PetName} is going {CurrentSpeed} MPH";
    }
}

