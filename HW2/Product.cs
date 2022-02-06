using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    internal class Product
    {
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
    }
}
