using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Pro_C_Sharp_Chapter12
{
    class Program
    {
        static void Main(string[] args)
        {
            DeclareImplicitVars();
            Console.WriteLine("***** Fun with LINQ to Objects *****\n");
            Console.WriteLine();
            QueryOverStrings();
            Console.WriteLine();
            QueryOverStringsWithExtensionMethods();
            Console.WriteLine();
            QueryOverStringsLongHand();
            Console.WriteLine();
            QueryOverInts();

            Console.WriteLine();
            Console.WriteLine("EqualityTest: ");

            Console.WriteLine("***** LINQ over ArrayList *****");
            // Here is a nongeneric collection of cars.
            ArrayList myCars = new ArrayList() {
                new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
            };
            // Transform ArrayList into an IEnumerable<T>-compatible type.
            var myCarsEnum = myCars.OfType<Car>();
            // Create a query expression targeting the compatible type.
            var fastCars = from c in myCarsEnum where c.Speed > 55 select c;
            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }

            Console.WriteLine();

            OfTypeAsFilter();

            Console.ReadLine();
        }

        static void OfTypeAsFilter()
        {
            // Extract the ints from the ArrayList.
            ArrayList myStuff = new ArrayList();
            myStuff.AddRange(new object[] { 10, 400, 8, false, new Car(), "string data" });
            var myInts = myStuff.OfType<int>();
            // Prints out 10, 400, and 8.
            foreach (int i in myInts)
            {
                Console.WriteLine("Int value: {0}", i);
            }
        }

        static void ReflectOverQueryResults
            (object resultSet, string queryType = "Query Expressions")
{
            Console.WriteLine($"***** Info about your query using {queryType} *****");
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
            Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName().Name);
        }

        static void QueryOverStringsLongHand()
        {
            // Assume we have an array of strings.
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter",
                "System Shock 2"};

            string[] gamesWithSpaces = new string[5];
            for (int i = 0; i < currentVideoGames.Length; i++)
            {
                if (currentVideoGames[i].Contains(" "))
                    gamesWithSpaces[i] = currentVideoGames[i];
            }
            // Now sort them.
            Array.Sort(gamesWithSpaces);
            // Print out the results.
            foreach (string s in gamesWithSpaces)
            {
                if (s != null)
                    Console.WriteLine("Item: {0}", s);
            }
            Console.WriteLine();
        }

        static void QueryOverStrings()
        {
            // Assume we have an array of strings.
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter",
                "System Shock 2"};
            // Build a query expression to find the items in the array
            // that have an embedded space.
            IEnumerable<string> subset = from g in currentVideoGames
                                         where g.Contains(" ")
                                         orderby g
                                         select g;

            ReflectOverQueryResults(subset);

            Console.WriteLine();
            // Print out the results.
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }

        static void QueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            // Print only items less than 10.
            var subset = (from i in numbers where i < 10 select i).ToList();
            foreach (var i in subset)
                Console.WriteLine("Item: {0}", i);
            ReflectOverQueryResults(subset);
        }

        static void QueryOverStringsWithExtensionMethods()
        {
            // Assume we have an array of strings.
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter",
                "System Shock 2"};

            // Build a query expression to find the items in the array
            // that have an embedded space.
            IEnumerable<string> subset =
            currentVideoGames.Where(g => g.Contains(" ")).OrderBy(g => g).Select(g => g);
            
            ReflectOverQueryResults(subset, "Extension Methods");

            // Print out the results.
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }

        static void DeclareImplicitVars()
        {
            // Implicitly typed local variables.
            var myInt = 0;
            var myBool = true;
            var myString = "Time, marches on...";
            // Print out the underlying type.
            Console.WriteLine("myInt is a: {0}", myInt.GetType().Name);
            Console.WriteLine("myBool is a: {0}", myBool.GetType().Name);
            Console.WriteLine("myString is a: {0}", myString.GetType().Name);
        }

        static void LambdaExpressionSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            // C# lambda expression.
            List<int> evenNumbers = list.FindAll(i => (i % 2) == 0);
            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }
    }    
}
