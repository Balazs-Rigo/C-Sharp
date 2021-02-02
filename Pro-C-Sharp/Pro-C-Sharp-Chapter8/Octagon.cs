using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter8
{
    public class Octagon : IDrawToForm, IDrawToMemory, IDrawToPrinter
    {
        // Explicitly bind Draw() implementations
     // to a given interface.
        void IDrawToForm.Draw()
        {
            Console.WriteLine("Drawing to form...");
        }
        void IDrawToMemory.Draw()
        {
            Console.WriteLine("Drawing to memory...");
        }
        void IDrawToPrinter.Draw()
        {
            Console.WriteLine("Drawing to a printer...");
        }
    }
}
