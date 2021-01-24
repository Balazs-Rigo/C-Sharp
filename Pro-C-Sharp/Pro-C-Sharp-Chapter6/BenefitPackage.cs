using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter6
{
    // This new type will function as a contained class.
    public class BenefitPackage
    {
        // Assume we have other members that represent
        // dental/health benefits, and so on.
        public double ComputePayDeduction()
        {
            return 125.0;
        }
    }
}
