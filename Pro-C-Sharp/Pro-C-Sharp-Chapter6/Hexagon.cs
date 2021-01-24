using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter6
{
    public class Hexagon:Shape
    {
        public Hexagon() { }
        public Hexagon(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Hexagon", PetName);
        }
    }
}
