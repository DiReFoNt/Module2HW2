using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    internal class Cart
    {
        private List<Product> _productsCart = new List<Product>();
        private decimal _totalAmount;
        private int _productsCounter;
        public Cart()
        {
        }

        public void ChangeCart(List<Product> shopWindow, string product)
        {
            if (product.StartsWith('+') || product.StartsWith('-'))
            {
                if (product.StartsWith('+'))
                {
                    bool productOutShop = false;
                    product = product.Substring(1);
                    string productToUpper = Convert.ToString(product[0]).ToUpper();
                    product = product.Replace(product[0], Convert.ToChar(productToUpper));
                    for (int i = 0; i < shopWindow.Count; i++)
                    {
                        for (int j = 0; j < _productsCart.Count; j++)
                        {
                            if (product == _productsCart[j].Name & productOutShop == false)
                            {
                                _totalAmount += _productsCart[j].Price;
                                productOutShop = true;
                                ++_productsCounter;
                            }
                        }

                        if (product == shopWindow[i].Name & productOutShop == false)
                        {
                            _productsCart.Add(shopWindow[i]);
                            _totalAmount += shopWindow[i].Price;
                            productOutShop = true;
                            ++_productsCounter;
                        }
                    }

                    if (productOutShop == false)
                    {
                        Console.WriteLine("The product is out of stock");
                    }
                }

                if (product.StartsWith('-'))
                {
                    bool productOutShop = false;
                    product = product.Substring(1);
                    string productToUpper = Convert.ToString(product[0]).ToUpper();
                    product = product.Replace(product[0], Convert.ToChar(productToUpper));
                    for (int i = 0; i < _productsCart.Count; i++)
                    {
                        if (product == _productsCart[i].Name)
                        {
                            _totalAmount -= _productsCart[i].Price;
                            _productsCounter -= 1;
                            productOutShop = true;
                        }
                    }

                    if (productOutShop == false)
                    {
                        Console.WriteLine("Product not in cart");
                    }
                }
            }
            else
            {
                Console.WriteLine("Choose one of the available commands");
                product = Convert.ToString(Console.ReadLine());
                ChangeCart(shopWindow, product);
            }
        }

        public void GetOrder(decimal totalAmount, int productsCounter)
        {
            Random orderNumber = new Random();
            Console.WriteLine($"\nYour order number {orderNumber.Next(1, 1000)} has been successfully created");
            Console.WriteLine($"Total {productsCounter} products worth {totalAmount}$");
            Console.WriteLine($"Date of creation {DateTime.Now}");
            Console.WriteLine("\nThank you for your purchase!");
        }

        public decimal GetTotalAmount()
        {
            return _totalAmount;
        }

        public int GetProductsCounter()
        {
            return _productsCounter;
        }
    }
}
