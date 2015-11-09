namespace _01
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string line = "";
            var dict = new SortedDictionary<string, string>();
            using (StreamReader reader = new StreamReader("../../students.txt"))
            {
                while((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split('|');
                    string course = data[data.Length - 1].Trim();
                    string firstName = data[0].Trim();
                    string lastName = data[1].Trim();
                    string fullName = firstName + " " + lastName;
                    if (!dict.ContainsKey(course))
                    {
                        dict[course] = fullName;
                    }
                    else
                    {
                        var names = (dict[course] + (", " + fullName)).Split(',')
                                          .OrderBy(n => n);
                        dict[course] = string.Join(", ", names);
                    }
                }
            }
            foreach (var value in dict)
            {
                Console.WriteLine("{0}: {1}", value.Key, value.Value);
            }
            Console.ReadKey();
        }    
    }
}
