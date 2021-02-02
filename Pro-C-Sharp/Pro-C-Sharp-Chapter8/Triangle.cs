using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter8
{
    public class Triangle:Shape,IPointy
    {
        public Triangle() { }
        public Triangle(string name) : base(name) { }
        public override void Draw()
        { Console.WriteLine("Drawing {0} the Triangle", PetName); }

        // IPointy implementation.
        public byte Points
        {
            get { return 3; }
        }
    }
}
