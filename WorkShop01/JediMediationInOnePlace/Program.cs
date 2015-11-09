namespace JediMediationInOnePlace
    {
    using System;
    using System.Text;

    public class Program
    {
        static void Main()
        {

            int N = int.Parse(Console.ReadLine());

            string[] jediNames = Console.ReadLine().Split(' ');

            var masters = new StringBuilder();
            var knights = new StringBuilder();
            var padawans = new StringBuilder();

            for (int i = 0; i < N; i++)
            {
                if (jediNames[i][0] == 'm')
                {
                    masters.Append(jediNames[i] + ' ');
                }
                else if (jediNames[i][0] == 'k')
                {
                    knights.Append(jediNames[i] + ' ');
                }
                else if (jediNames[i][0] == 'p')
                {
                    padawans.Append(jediNames[i] + ' ');
                }
            }

            knights.Append(padawans.ToString().TrimEnd());
            masters.Append(knights);
            
            Console.WriteLine(masters);
        }       
    }
}