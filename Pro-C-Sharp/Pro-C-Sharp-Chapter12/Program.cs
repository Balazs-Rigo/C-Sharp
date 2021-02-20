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

            Console.WriteLine("***** Fun with Query Expressions *****\n");
            // This array will be the basis of our testing...

            ProductInfo[] itemsInStock = GetItemsInStock();

            Array objs = GetProjectedSubset(itemsInStock);
            foreach (object o in objs)
            {
                Console.WriteLine(o); // Calls ToString() on each anonymous object.
            }

            Console.WriteLine();
            DisplayDiff();
            Console.WriteLine();
            DisplayIntersection();
            Console.WriteLine();
            DisplayConcatNoDups();
            Console.WriteLine();
            AggregateOps();

            Console.ReadLine();
        }

        static void QueryStringWithOperators()
        {
            Console.WriteLine("***** Using Query Operators *****");
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter",
                "System Shock 2"};

            var subset = from game in currentVideoGames
                         where game.Contains(" ")
                         orderby game
                         select game;

            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }

        static void QueryStringsWithEnumerableAndLambdas2()
        {
            Console.WriteLine("***** Using Enumerable / Lambda Expressions *****");
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter",
                "System Shock 2"};
            // Break it down!
            var gamesWithSpaces = currentVideoGames.Where(game => game.Contains(" "));
            var orderedGames = gamesWithSpaces.OrderBy(game => game);
            var subset = orderedGames.Select(game => game);
            foreach (var game in subset)
                Console.WriteLine("Item: {0}", game);
            Console.WriteLine();
        }

        static void QueryStringsWithEnumerableAndLambdas()
        {
            Console.WriteLine("***** Using Enumerable / Lambda Expressions *****");
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter",
                "System Shock 2"};
            // Build a query expression using extension methods
            // granted to the Array via the Enumerable type.
            var subset = currentVideoGames.Where(game => game.Contains(" "))
            .OrderBy(game => game).Select(game => game);
            // Print out the results.
            foreach (var game in subset)
                Console.WriteLine("Item: {0}", game);
            Console.WriteLine();
        }

        static void AggregateOps()
        {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };
            // Various aggregation examples.
            Console.WriteLine("Max temp: {0}", (from t in winterTemps select t).Max());
            Console.WriteLine("Min temp: {0}", (from t in winterTemps select t).Min());
            Console.WriteLine("Average temp: {0}", (from t in winterTemps select t).Average());
            Console.WriteLine("Sum of all temps: {0}", (from t in winterTemps select t).Sum());
        }

        static void DisplayUnion()
        {
            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };
            // Get the union of these containers.
            var carUnion = (from c in myCars select c).Union(from c2 in yourCars select c2);
            Console.WriteLine("Here is everything:");
            foreach (string s in carUnion)
                Console.WriteLine(s); // Prints all common members.
        }

        static void DisplayConcatNoDups()
        {
            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };
            var carConcat = (from c in myCars select c).Concat(from c2 in yourCars select c2);
            // Prints:
            // Yugo Aztec BMW Saab.
            Console.WriteLine("Distinct: ");
            foreach (string s in carConcat.Distinct())
                Console.WriteLine(s);
        }

        static void DisplayConcat()
        {
            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };
            var carConcat = (from c in myCars select c).Concat(from c2 in yourCars select c2);
            // Prints:
            // Yugo Aztec BMW BMW Saab Aztec.
            foreach (string s in carConcat)
                Console.WriteLine(s);
        }

        static void DisplayIntersection()
        {
            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };
            // Get the common members.
            var carIntersect = (from c in myCars select c).Intersect(from c2 in yourCars select c2);
            Console.WriteLine("Here is what we have in common:");
            foreach (string s in carIntersect)
                Console.WriteLine(s); // Prints Aztec and BMW.
        }

        static void DisplayDiff()
        {
            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };
            var carDiff = (from c in myCars select c).Except(from c2 in yourCars select c2);
            Console.WriteLine("Here is what you don't have, but I do:");
            foreach (string s in carDiff)
                Console.WriteLine(s); // Prints Yugo.
        }

        static void GetCountFromQuery()
        {
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter",
                "System Shock 2"};
            // Get count from the query.
            int numb = (from g in currentVideoGames where g.Length > 6 select g).Count();
            // Print out the number of items.
            Console.WriteLine("{0} items honor the LINQ query.", numb);
        }

        static ProductInfo[] GetItemsInStock()
        {
            ProductInfo[] itemsInStock = new[] {
                new ProductInfo
                { Name = "Mac's Coffee", Description = "Coffee with TEETH", NumberInStock = 24 },
                new ProductInfo
                { Name = "Milk Maid Milk", Description = "Milk cow's love", NumberInStock = 100 },
                new ProductInfo
                { Name = "Pure Silk Tofu", Description = "Bland as Possible", NumberInStock = 120 },
                new ProductInfo
                { Name = "Crunchy Pops", Description = "Cheezy, peppery goodness", NumberInStock = 2 },
                new ProductInfo
                { Name = "RipOff Water", Description = "From the tap to your wallet", NumberInStock = 100 },
                new ProductInfo
                { Name = "Classic Valpo Pizza", Description = "Everyone lovespizza!", NumberInStock = 73 }
            };

            return itemsInStock;
        }

        // Return value is now an Array.
        static Array GetProjectedSubset(ProductInfo[] products)
        {
            var nameDesc = from p in products select new { p.Name, p.Description };
            // Map set of anonymous objects to an Array object.
            return nameDesc.ToArray();
        }

        static void GetOverstock(ProductInfo[] products)
        {
            Console.WriteLine("The overstock items!");
            // Get only the items where we have more than
            // 25 in stock.
            var overstock = from p in products where p.NumberInStock > 25 select p;
            foreach (ProductInfo c in overstock)
            {
                Console.WriteLine(c.ToString());
            }
        }

        static void ListProductNames(ProductInfo[] products)
        {
            // Now get only the names of the products.
            Console.WriteLine("Only product names:");
            var names = from p in products select p.Name;
            foreach (var n in names)
            {
                Console.WriteLine("Name: {0}", n);
            }
        }

        static void SelectEverything(ProductInfo[] products)
        {
            // Get everything!
            Console.WriteLine("All product details:");
            var allProducts = from p in products select p;
            foreach (var prod in allProducts)
            {
                Console.WriteLine(prod.ToString());
            }
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
