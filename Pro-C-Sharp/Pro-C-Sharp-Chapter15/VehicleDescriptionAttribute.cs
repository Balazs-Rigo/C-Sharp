using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter15
{
    public class VehicleDescriptionAttribute: System.Attribute
    {
        public string Description { get; set; }

        public VehicleDescriptionAttribute(string vehicalDescription) => 
            Description = vehicalDescription;
        public VehicleDescriptionAttribute() { }

    }
}
