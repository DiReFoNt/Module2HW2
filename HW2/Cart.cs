using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    internal class Cart
    {
        public decimal TotalAmount { get; set; }
        public int ProductsCounter { get; set; }

        public decimal GetTotalAmount()
        {
            return TotalAmount;
        }

        public int GetProductsCounter()
        {
            return ProductsCounter;
        }
    }
}
