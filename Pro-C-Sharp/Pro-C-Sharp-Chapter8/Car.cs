using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter8
{
    public class Car : IComparable
    {
        public int CarID { get; set; }
        // Constant for maximum speed.
        public const int MaxSpeed = 100;
        // Car properties.

        // Property to return the PetNameComparer.
        public static IComparer SortByPetName
        { get { return (IComparer)new PetNameComparer(); } }
        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";
        // Is the car still operational?
        private bool carIsDead;
        // A car has-a radio.
        private Radio theMusicBox = new Radio();
        // Constructors.
        public Car() { }
        public Car(string name, int currSp, int id)
        {
            CurrentSpeed = currSp;
            PetName = name;
            CarID = id;
        }
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }
        public void CrankTunes(bool state)
        {
            // Delegate request to inner object.
            theMusicBox.TurnOn(state);
        }
        // See if Car has overheated.
        // This time, throw an exception if the user speeds up beyond MaxSpeed.
        public void Accelerate(int delta)
        {
            if (delta < 0)
                throw new
                ArgumentOutOfRangeException("delta", "Speed must be greater than zero!");

            if (carIsDead) 
            {
                Console.WriteLine("{0} is out of order...", PetName);
            }
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                    CurrentSpeed = 0;

                    // We need to call the HelpLink property, thus we need to
                    // create a local variable before throwing the Exception object.
                    CarIsDeadException ex =
                        new CarIsDeadException($"{PetName} has overheated!",
                        "You have a lead foot", DateTime.Now);
                    ex.HelpLink = "http://www.CarsRUs.com";
                    throw ex;
                }
                else
                    Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
            }
        }

        public int CompareTo(object obj)
        {
            Car temp = obj as Car;
            if (temp != null)
                return this.CarID.CompareTo(temp.CarID);
            else
                throw new ArgumentException("Parameter is not a Car!");
        }
    }
}

