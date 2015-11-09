namespace OrderedBag
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Wintellect.PowerCollections;

    class Program
    {
        private const int CountProducts = 500000;
        private const int PriceSearches = 20000;

        static void Main()
        {

            OrderedBag<Product> bag = new OrderedBag<Product>();
            Random rand = new Random();
            for (int i = 0; i < CountProducts; i++)
            {
                bag.Add(GetRandomProduct(rand));
            }

            decimal minPrice = 0M;
            for (int i = 0; i < PriceSearches; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                decimal maxPrice = minPrice + 100M;
                var result = GetProductsInPriceRange(bag, minPrice, maxPrice);
                Console.WriteLine(new string('$', 79));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("First 20 Products in Price Range {0:C} - {1:C}: ", minPrice, maxPrice);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (result.Count() < 1) { Console.Write("None\n"); }
                Console.WriteLine(string.Join(" | ", result));
                minPrice += 100;
                Thread.Sleep(500);
            }
        }

        private static IEnumerable<Product> GetProductsInPriceRange(OrderedBag<Product> bag, decimal min, decimal max)
        {
            Product minProduct = bag.FirstOrDefault(p => p.Price >= min);
            Product maxProduct = bag.FirstOrDefault(p => p.Price >= max);
            var result = bag.Range(minProduct, true, maxProduct, false);
            return result.Take(20);
        }

        static Product GetRandomProduct(Random rnd)
        {
            int number = rnd.Next(0, 1000);
            string name = string.Format("Product #{0}", number.ToString().PadLeft(5, '0'));

            decimal price = (decimal)rnd.NextDouble() * rnd.Next(1, 20000);

            return new Product(name, price);
        }
    }
}
