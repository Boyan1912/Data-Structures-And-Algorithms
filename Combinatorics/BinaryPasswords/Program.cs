namespace BinaryPasswords
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {

            string input = Console.ReadLine();

            long unknownPositions = input.Count(ch => ch == '*');
            // Variations (with repetitions) = n ^ k
            ulong result = (ulong)Math.Pow(2, unknownPositions);
            Console.WriteLine(result);
        }
    }
}
