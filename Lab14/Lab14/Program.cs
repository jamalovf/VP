using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{

    class Program
    {
        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        static void Main(string[] args)
        {
            String randomLozinka = RandomString(4, true);
            int n = 4;
            Console.WriteLine("Lozinkata e: {0}", randomLozinka);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Obidi se da ja pogodis lozinkata: ");
                String proba = Console.ReadLine();
                bool dalieUspesno = proba.Equals(randomLozinka);
                if (dalieUspesno)
                {
                    Console.WriteLine("Cestitki, ja pogodivte lozinkata!!!");
                    break;

                }
            }
            Console.ReadKey();
        }
    }
}
