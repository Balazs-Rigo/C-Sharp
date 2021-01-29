using System;
using System.Collections;
using System.IO;

namespace Pro_C_Sharp_Chapter7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Custom Exceptions *****\n");
            Car myCar = new Car("Rusty", 90);

            try
            {
                // Trip Arg out of range exception.
                myCar.Accelerate(400);
            }
            catch (CarIsDeadException e) when (e.ErrorTimeStamp.DayOfWeek != DayOfWeek.Monday)
            {
                try
                {
                    FileStream fs = File.Open(@"C:\carErrors.txt", FileMode.Open);
                    
                }
                catch (Exception e2)
                {
                    // Throw an exception that records the new exception,
                    // as well as the message of the first exception.
                    throw new CarIsDeadException(e.Message, e2);
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
