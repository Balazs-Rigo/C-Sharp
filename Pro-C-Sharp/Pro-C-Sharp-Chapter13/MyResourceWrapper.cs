using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter13
{
    public class MyResourceWrapper :IDisposable
    {
        // Clean up unmanaged resources here.
        // Beep when destroyed (testing purposes only!)
        ~MyResourceWrapper() => Console.Beep();

        public void Dispose()
        {
            // Clean up unmanaged resources...
            // Dispose other contained disposable objects...
            // Just for a test.
            Console.WriteLine("***** In Dispose! *****");
        }
    }
}
