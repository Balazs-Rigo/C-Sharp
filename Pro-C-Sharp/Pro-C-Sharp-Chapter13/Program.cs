using System;
using System.Linq;

namespace Pro_C_Sharp_Chapter13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Lazy Instantiation *****\n");
            // This caller does not care about getting all songs,
            // but indirectly created 10,000 objects!
            MediaPlayer myPlayer = new MediaPlayer();
            myPlayer.Play();
            Console.ReadLine();
        }

        static void MakeACar()
        {
            // If myCar is the only reference to the Car object, 
            //it *may* be destroyed when this method returns.
            Car myCar = new Car();
            myCar = null;
        }
    }
}
