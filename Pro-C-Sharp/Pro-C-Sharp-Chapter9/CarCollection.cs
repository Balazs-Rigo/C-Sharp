using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter9
{
    public class CarCollection: IEnumerable
    {
        private ArrayList arCars = new ArrayList();
        // Cast for caller.
        public Car GetCar(int pos) => (Car)arCars[pos];
        // Insert only Car objects.
        public void AddCar(Car c)
        { arCars.Add(c); }
        public void ClearCars()
        { arCars.Clear(); }
        public int Count => arCars.Count;
        // Foreach enumeration support.
        IEnumerator IEnumerable.GetEnumerator() => arCars.GetEnumerator();
    }
}
