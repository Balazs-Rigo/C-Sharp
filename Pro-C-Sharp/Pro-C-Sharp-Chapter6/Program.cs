using System;

namespace Pro_C_Sharp_Chapter6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Polymorphism *****\n");
            Hexagon hex = new Hexagon("Beth");
            hex.Draw();
            Circle cir = new Circle("Cindy");
            // Calls base class implementation!
            cir.Draw();


            Console.ReadLine();
        }
    }
}
