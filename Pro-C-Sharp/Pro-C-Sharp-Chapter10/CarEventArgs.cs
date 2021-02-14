using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter10
{
    public class CarEventArgs : EventArgs
    {
        public readonly string msg;
        public CarEventArgs(string message)
        {
            msg = message;
        }
    }
}
