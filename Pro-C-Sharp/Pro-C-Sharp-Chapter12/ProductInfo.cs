using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter12
{
    public class ProductInfo
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int NumberInStock { get; set; } = 0;
        public override string ToString()
        => $"Name={Name}, Description={Description}, Number in Stock={NumberInStock}";
    }
}
