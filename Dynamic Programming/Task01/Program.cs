//namespace Task01
//{
//    using System.Collections.Generic;

//    //  * _Example_: `M=10kg`, `N=6`, products:
//    //    * beer – weight=3, cost=2
//    //    * vodka – weight=8, cost=12
//    //    * cheese – weight=4, cost=5
//    //    * `nuts – weight=1, cost=4`
//    //    * ham – weight=2, cost=3
//    //    * `whiskey – weight=8, cost=13`
//    //* _Optimal solution_:
//    //    * nuts + whiskey
//    //    * weight = 9
//    //    * cost = 17
//    class Program
//    {
//        static void Main()
//        {

//            var products = new string[] { "beer", "vodka", "cheese", "nuts", "ham", "whiskey" };
//            var weight = new int[] { 3, 8, 4, 1, 2, 8 };
//            var costs = new[] { 2, 12, 5, 4, 3, 13 };

//            for (int i = 0; i < products.Length; i++)
//            {

//            }

//        }

//        private void FindMaxSubSum(int start, int[] weights, int[]costs)
//        {
//            int sum = 0;
//            var indexesSubSum = new List<int>();
//            var sums = new List<int>();
//            for (int i = start; i < costs.Length; i++)
//            {
//                sum = costs[i];
//                sums.Add(costs[i]);
//                for (int j = 0; j < sums.Count; j++)
//                {

//                }

//            }


//        }

//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;

class Product : IComparable
{
    public string Name { get; private set; }
    public int Weight { get; private set; }
    public int Price { get; private set; }

    public Product(string name, int weight, int price)
    {
        this.Name = name;
        this.Weight = weight;
        this.Price = price;
    }

    public override string ToString()
    {
        return string.Format("Name: {0}, Weight: {1}, Price: {2}", this.Name, this.Weight, this.Price);
    }

    public int CompareTo(object obj)
    {
        if (this.Price > (obj as Product).Price)
        {
            return 1;
        }
        else if(this.Price < (obj as Product).Price)
        {
            return -1;
        }
        else
        {
            return 0;
        }

    }
    
}

class Program
{
    static void Main()
    {
        var numbers = new[]
        {
            new Product("beer", 3, 2),
            new Product("vodka", 8, 12),
            new Product("cheese", 4, 5),
            new Product("nuts", 1, 4),
            new Product("ham", 2, 3),
            new Product("whiskey", 8, 13),
        };

        int capacity = 10;

        var best = Enumerable.Repeat(1, numbers.Length).ToArray();
        var parents = Enumerable.Repeat(-1, numbers.Length).ToArray();

        var bestLength = 1;
        var bestEnd = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (numbers[i].CompareTo(numbers[j]) > 0 && best[j] + 1 > best[i])
                {
                    best[i] = best[j] + 1;
                    parents[i] = j;
                }

                if (bestLength < best[i])
                {
                    bestLength = best[i];
                    bestEnd = i;
                }
            }
        }

        var sequence = new Stack<int>();

        for (; bestEnd != -1; bestEnd = parents[bestEnd])
        {
            sequence.Push(numbers[bestEnd].Price);
        }

        Console.WriteLine(string.Join(" ", sequence));

        Console.WriteLine(string.Join(" ", numbers));
        Console.WriteLine(string.Join(" ", best));
        Console.WriteLine(string.Join(" ", parents));
    }
}
