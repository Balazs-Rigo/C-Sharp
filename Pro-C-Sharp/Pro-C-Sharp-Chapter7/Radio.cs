using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter7
{
    public class Radio
    {
        public void TurnOn(bool on)
        {
            Console.WriteLine(on ? "Jamming..." : "Quiet time...");
        }
    }
}
