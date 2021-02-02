using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter8
{
    public abstract class Shape
    {
        public Shape(string name = "NoName")
        { PetName = name; }
        public string PetName { get; set; }
        // A single virtual method.
        public virtual void Draw()
        {
            Console.WriteLine("Inside Shape.Draw()");
        }
    }
}
