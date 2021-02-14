using System;
using System.Collections.Generic;

namespace Pro_C_Sharp_Chapter10
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Events
            /*
            Console.WriteLine("***** Fun with Events *****\n");
            Car c1 = new Car("SlugBug", 100, 10);

            // Register event handlers.
            c1.AboutToBlow += CarAboutToBlow;
            c1.Exploded += CarExploded;

            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            c1.Exploded -= CarExploded;

            Console.WriteLine("\n***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            */
            #endregion

            #region Anonymous Methods
            /*
            Console.WriteLine("***** Anonymous Methods *****\n");
            int aboutToBlowCounter = 0;
            // Make a car as usual.
            Car c1 = new Car("SlugBug", 100, 10);
            // Register event handlers as anonymous methods.
            c1.AboutToBlow += delegate
            {
                aboutToBlowCounter++;
                Console.WriteLine("Eek! Going too fast!");
            };
            c1.AboutToBlow += delegate (object sender, CarEventArgs e)
            {
                aboutToBlowCounter++;
                Console.WriteLine("Critical Message from Car: {0}", e.msg);
            };
            // This will eventually trigger the events.
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            Console.WriteLine("AboutToBlow event was fired {0} times.",
            aboutToBlowCounter);
            */
            #endregion

            #region Lambda

            Console.WriteLine("***** Fun with Lambdas *****\n");
            TraditionalDelegateSyntax();

            #endregion

            Console.ReadLine();
        }

        static void AnonymousMethodSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            // Now, use a C# lambda expression.
            List<int> evenNumbers = list.FindAll(i => (i % 2) == 0);
            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

        static void TraditionalDelegateSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            // Call FindAll() using traditional delegate syntax.
            Predicate<int> callback = IsEvenNumber;
            List<int> evenNumbers = list.FindAll(callback);
            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

        // Target for the Predicate<> delegate.
        static bool IsEvenNumber(int i)
        {
            // Is it an even number?
            return (i % 2) == 0;
        }

        #region Targets for events
        public static void CarAboutToBlow(object sender, CarEventArgs e)
        {
            // Just to be safe, perform a
            // runtime check before casting.
            if (sender is Car c)
            {
                Console.WriteLine("Critical Message from {0}: {1}", c.PetName, e.msg);
            }
        }

        public static void CarExploded(object sender, CarEventArgs e)
        { Console.WriteLine(e.msg); }
        #endregion
    }
}
