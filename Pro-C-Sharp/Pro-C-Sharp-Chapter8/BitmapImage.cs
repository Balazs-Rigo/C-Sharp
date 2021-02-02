using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter8
{
    public class BitmapImage
    {
        public void Draw()
        {
            Console.WriteLine("Drawing...");
        }
        public void DrawInBoundingBox(int top, int left, int bottom, int right)
        {
            Console.WriteLine("Drawing in a box...");
        }
        public void DrawUpsideDown()
        {
            Console.WriteLine("Drawing upside down!");
        }
    }
}
