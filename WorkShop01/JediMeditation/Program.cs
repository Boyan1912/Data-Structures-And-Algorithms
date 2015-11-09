namespace JediMeditation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {

            int N = int.Parse(Console.ReadLine());

            string[] jediNames = Console.ReadLine().Split(' ');

            List<IJedi> jedis = new List<IJedi>();
            List<IJedi> masters = new List<IJedi>();
            List<IJedi> knights = new List<IJedi>();
            List<IJedi> padawans = new List<IJedi>();

            foreach(string name in jediNames)
            {
                if (name[0] == 'm')
                {
                    masters.Add(JediFactory.CreateJedi(name));
                }
                else if (name[0] == 'k')
                {
                    knights.Add(JediFactory.CreateJedi(name));
                }
                else if (name[0] == 'p')
                {
                    padawans.Add(JediFactory.CreateJedi(name));
                }
            }

            jedis.AddRange(masters);
            jedis.AddRange(knights);
            jedis.AddRange(padawans);

            Console.WriteLine(string.Join(" ", jedis));
        }
    }
}
