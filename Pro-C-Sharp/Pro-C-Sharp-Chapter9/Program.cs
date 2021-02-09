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
            // Make a collection to observe and add a few Person objects.
            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
                new Person{ FirstName = "Peter", LastName = "Murphy", Age = 52 },
                new Person{ FirstName = "Kevin", LastName = "Key", Age = 48 },
            };
            // Wire up the CollectionChanged event.
            people.CollectionChanged += people_CollectionChanged;

            people.Add(new Person("Tim","Corey",32));
            people.Add(new Person("George","Hammond",55));
            people.Add(new Person("Jack", "O'Neill", 44));

            people.RemoveAt(2);

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
