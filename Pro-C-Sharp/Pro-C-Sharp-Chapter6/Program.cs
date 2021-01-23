using System;

namespace Pro_C_Sharp_Chapter6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Employee Class Hierarchy *****\n");
            SalesPerson fred = new SalesPerson();
            fred.Age = 31;
            fred.Name = "Fred";
            fred.SalesNumber = 50;
            Console.ReadLine();

            Console.WriteLine("Hello World!");
        }
    }
}
