using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter8
{
    public class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PointDescription desc = new PointDescription();

        public Point(int xPos, int yPos, string petName)
        {
            X = xPos; Y = yPos;
            desc.PetName = petName;
        }
        public Point(int xPos, int yPos)
        {
            X = xPos; Y = yPos;
        }
        public Point() { }
        // Override Object.ToString().
        public override string ToString()
        => $"X = {X}; Y = {Y}; Name = {desc.PetName};\nID = {desc.PointID}\n";
        // Return a copy of the current object.
        public object Clone() => this.MemberwiseClone();
    }
}
