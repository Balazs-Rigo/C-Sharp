using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter11
{
    public static class AnnoyingExtensions
    {
        public static void PrintDataAndBeep(this System.Collections.IEnumerable iterator)
        {
            foreach (var item in iterator)
            {
                Console.WriteLine(item);
                Console.Beep();
            }
        }
    }
}
