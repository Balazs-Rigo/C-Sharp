using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter15
{
    // This class can be saved to disk.
    [Serializable,Obsolete("Use another vehicle!")]
    public class Motorcycle
    {
        // However, this field will not be persisted.
        [NonSerialized]
        float weightOfCurrentPassengers;
        // These fields are still serializable.
        bool hasRadioSystem;
        bool hasHeadSet;
        bool hasSissyBar;
    }
}
