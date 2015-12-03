namespace RepeatingPattern
{
    using System;
    using System.Linq;
    using System.Text;

    //BGCoder Time & Memory Limits Solution

    class Program
    {
        static void Main()
        {

            string text = Console.ReadLine();
            var result = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                result.Append(text[i]);
                int currentPatternLength = result.Length;
                string patternAtEnd = text.Substring(text.Length - currentPatternLength, currentPatternLength);

                if (result.ToString() == patternAtEnd)
                {
                    result.Append(string.Concat(Enumerable.Repeat(patternAtEnd, text.Length / patternAtEnd.Length - 1).ToArray()));

                    if (result.ToString() == text)
                    {
                        result.Length = currentPatternLength;
                        break;
                    }
                    else
                    {
                        result.Length = currentPatternLength;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
