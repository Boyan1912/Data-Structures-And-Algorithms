namespace Palindromize
{
    using System;
    using System.Text;

    class Program
    {
        static void Main()
        {
            string word = Console.ReadLine();

            int halfLength = word.Length / 2;

            var result = new StringBuilder();
            for (int i = 0; i < halfLength; i++)
            {
                char endchar = word[word.Length - 1 - i];
                if (word[i] == endchar)
                {
                    result.Append(endchar);
                    if (result.Length == halfLength)
                    {
                        result.Clear();
                        result.Append(word);
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            
            if (result.Length < halfLength && result.Length > 0)
            {
                int initialLength = result.Length;
                for (int i = 0; i < halfLength; i++)
                {
                    result.Insert(0, word[initialLength + i]);
                }

                if (word.Length % 2 == 1)
                {
                    result.Insert(0, word[halfLength + 1]);
                }
                result.Insert(0, word.Substring(0, halfLength + 1));
            }

            else if (result.Length == 0)
            {
                char lastLetter = word[word.Length - 1];
                int firstOccurence = word.IndexOf(lastLetter);
                result.Append(word);
                for (int i = 0; i < firstOccurence; i++)
                {
                    result.Append(word[firstOccurence - 1 - i]);
                }
            }
            Console.WriteLine(result);
        }
    }
}
