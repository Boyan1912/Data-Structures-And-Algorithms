namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            //Write a program that counts how many times each word from given text file words.txt appears in it.The character casing differences should be ignored.The result words should be ordered by their number of occurrences in the text. Example:

            //This is the TEXT.Text, text, text – THIS TEXT!Is this the text?
            //is -> 2
            //the-> 2
            //this-> 3
            //text-> 6

            var dict = new Dictionary<string, int>();
            using (StreamReader reader = new StreamReader("../../TextFile.txt"))
            {
                string text = reader.ReadToEnd();
                
                string[] words = text.Split(new[] { ' ', '.', '!', ',', '-', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
                
                foreach (string word in words)
                {
                    string wordCaseIncesitive = word.ToLower();
                    if (!dict.ContainsKey(wordCaseIncesitive))
                    {
                        dict[wordCaseIncesitive] = 1;
                    }
                    else
                    {
                        dict[wordCaseIncesitive]++;
                    }
                }
                
            }

            var sorted = dict.OrderBy(w => w.Value);
            foreach (var val in sorted)
            {
                Console.WriteLine("{0} -> {1}", val.Key, val.Value);
            }
        }
    }
}
