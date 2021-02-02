using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter8
{
    public interface IAdvancedDraw : IDrawable
    {
        void DrawInBoundingBox(int top, int left, int bottom, int right);
        void DrawUpsideDown();
    }
}
