using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter5
{
    public static class TimeUtilClass
    {
        public static void PrintTime()
            => Console.WriteLine(DateTime.Now.ToShortTimeString());
        public static void PrintDate()
            => Console.WriteLine(DateTime.Today.ToShortDateString());
    }
}
