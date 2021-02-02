using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter8
{
    public class ThreeDCircle : Circle, IDraw3D
    {
        // Hide the PetName property above me.
        public new string PetName { get; set; }
        // Hide any Draw() implementation above me.
        public new void Draw()
        {
            Console.WriteLine("Drawing a 3D Circle");
        }

        public void Draw3D()
        {
            Console.WriteLine("Drawing Circle in 3D!");
        }
    }
}
