using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class Supermarket
    {
        private Cart _cart = new Cart();
        private List<Product> _shopWindow = new List<Product>();
        private List<Product> _productsCart = new List<Product>();
        private Order _order = new Order();
        public Supermarket()
        {
            _shopWindow.Add(new Product("Potato", 10));
            _shopWindow.Add(new Product("Banana", 31));
            _shopWindow.Add(new Product("Avocado", 122));
            _shopWindow.Add(new Product("Cabbage", 20));
            _shopWindow.Add(new Product("Mango", 51));
            _shopWindow.Add(new Product("Apple Gala", 13));
            _shopWindow.Add(new Product("Beet", 15));
            _shopWindow.Add(new Product("Grapes Blue", 38));
            _shopWindow.Add(new Product("Garnet", 47));
            _shopWindow.Add(new Product("Mushrooms Champignons", 61));
            _shopWindow.Add(new Product("Pear", 34));

            Console.WriteLine("The product is in stock, the price is for 1 kg.");
            for (int i = 0; i < _shopWindow.Count; i++)
            {
                Console.WriteLine($"{_shopWindow[i].Name} ({_shopWindow[i].Price}$)");
            }
        }

        public void ChangeShopCart()
        {
            int productsCounter = _cart.GetProductsCounter();
            decimal totalAmount = _cart.GetTotalAmount();
            Console.WriteLine("To add an item to your cart, enter: +Name");
            Console.WriteLine("To remove an item from your cart, enter: -Name");
            Console.WriteLine("To place your order, enter : Create");
            string product = " ";
            while (true)
            {
                product = Convert.ToString(Console.ReadLine());
                if (product == "Create")
                {
                    _order.GetOrder(totalAmount, productsCounter);
                    break;
                }

                ChangeCart(_shopWindow, product);
                productsCounter = _cart.GetProductsCounter();
                totalAmount = _cart.GetTotalAmount();
                Console.WriteLine($"Now there are {productsCounter} items in the cart for the amount: {totalAmount}$");
            }
        }

        private void ChangeCart(List<Product> shopWindow, string product)
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
                                _cart.TotalAmount += _productsCart[j].Price;
                                productOutShop = true;
                                ++_cart.ProductsCounter;
                            }
                        }

                        if (product == shopWindow[i].Name & productOutShop == false)
                        {
                            _productsCart.Add(shopWindow[i]);
                            _cart.TotalAmount += shopWindow[i].Price;
                            productOutShop = true;
                            ++_cart.ProductsCounter;
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
                            _cart.TotalAmount -= _productsCart[i].Price;
                            _cart.ProductsCounter -= 1;
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
    }
}
