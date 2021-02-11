using System;
using System.Collections;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pro_C_Sharp_Chapter9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Custom Generic Methods *****\n");
            // Swap 2 ints.
            int a = 10, b = 90;
            Console.WriteLine("Before swap: {0}, {1}", a, b);
            Swap<int>(ref a, ref b);
            Console.WriteLine("After swap: {0}, {1}", a, b);
            Console.WriteLine();
            // Swap 2 strings.
            string s1 = "Hello", s2 = "There";
            Console.WriteLine("Before swap: {0} {1}!", s1, s2);
            Swap<string>(ref s1, ref s2);
            Console.WriteLine("After swap: {0} {1}!", s1, s2);

            // This method will swap any two items.
            // as specified by the type parameter <T>.
            static void Swap<T>(ref T a, ref T b)
            {
            Console.WriteLine("You sent the Swap() method a {0}", typeof(T));
            T temp = a;
            a = b;
            b = temp;
            }

            static void people_CollectionChanged(object sender, System.Collections.Specialized.
            NotifyCollectionChangedEventArgs e)
            {
                // What was the action that caused the event?
                Console.WriteLine("Action for this event: {0}", e.Action);
                // They removed something.
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    Console.WriteLine("Here are the OLD items:");
                    foreach (Person p in e.OldItems)
                    {
                        Console.WriteLine(p.ToString());
                    }
                    Console.WriteLine();
                }
                // They added something.
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    // Now show the NEW items that were inserted.
                    Console.WriteLine("Here are the NEW items:");
                    foreach (Person p in e.NewItems)
                    {
                        Console.WriteLine(p.ToString());
                    }
                }
            }


            Console.ReadLine();
        }
    

        static void UseSortedSet()
        {
            // Make some people with different ages.
            SortedSet<Person> setOfPeople = new SortedSet<Person>(new SortPeopleByAge())
            {
                new Person {FirstName= "Homer", LastName="Simpson", Age=47},
                new Person {FirstName= "Marge", LastName="Simpson", Age=45},
                new Person {FirstName= "Lisa", LastName="Simpson", Age=9},
                new Person {FirstName= "Bart", LastName="Simpson", Age=8}
            };
            // Note the items are sorted by age!
            foreach (Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();
            // Add a few new people, with various ages.
            setOfPeople.Add(new Person { FirstName = "Saku", LastName = "Jones", Age = 1 });
            setOfPeople.Add(new Person { FirstName = "Mikko", LastName = "Jones", Age = 32 });

            // Still sorted by age!
            foreach (Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }
        }

        private static void UseDictionary()
        {
            // Populate using Add() method
            Dictionary<string, Person> peopleA = new Dictionary<string, Person>();

            peopleA.Add("Homer", new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            peopleA.Add("Marge", new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            peopleA.Add("Lisa", new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

            // Get Homer.
            Person homer = peopleA["Homer"];
            Console.WriteLine(homer);
            // Populate with initialization syntax.
            Dictionary<string, Person> peopleB = new Dictionary<string, Person>()
            {
                { "Homer", new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 } },
                { "Marge", new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 } },
                { "Lisa", new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 } }
            };
            // Get Lisa.
            Person lisa = peopleB["Lisa"];
            Console.WriteLine(lisa);
        }
    }
}
