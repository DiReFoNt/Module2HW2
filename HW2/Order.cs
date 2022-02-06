using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    internal class Order
    {
        public void GetOrder(decimal totalAmount, int productsCounter)
        {
            Random orderNumber = new Random();
            Console.WriteLine($"\nYour order number {orderNumber.Next(1, 1000)} has been successfully created");
            Console.WriteLine($"Total {productsCounter} products worth {totalAmount}$");
            Console.WriteLine($"Date of creation {DateTime.Now}");
            Console.WriteLine("\nThank you for your purchase!");
        }
    }
}
