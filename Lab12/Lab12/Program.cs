using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    class Program
    {
        static void calculate(ref int min, ref int max, ref double sredna_vrednost, int[] numbers)
        {
            min = numbers[0];
            max = numbers[0];
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (min < numbers[i])
                    min = numbers[i];
                if (max > numbers[i])
                    max = numbers[i];
                sum += numbers[i];
            }
            sredna_vrednost = (double)sum / numbers.Length;
        }

        static void Main(string[] args)
        {
            int n;
            int izbor = 0;
            int max = 0;
            int min = 0;
            int broj;
            double sredna_vrednost = 0;
            Console.Write("Vnesete go brojot na broevi na koi sto sakate da presmetate sredna vrednost: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Vnesete 1 dokolku sakate da gi vnesuvate broevite ili 2 dokolku sakate da se generiraat slucajno: ");
            izbor = Convert.ToInt32(Console.ReadLine());
            int[] numbers = new int[n];
            if (izbor == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write("Vnesete go {0}-viot broj: ", i + 1);
                    numbers[i] = Convert.ToInt32(Console.ReadLine());
                }
                calculate(ref min, ref max, ref sredna_vrednost, numbers);
            }
            else if (izbor == 2)
            {
                Random random = new Random();
                for (int i = 0; i < n; i++)
                {
                    broj = random.Next(1, 1000);
                    numbers[i] = broj;
                    Console.WriteLine("{0}-viot random generiran broj e : {1}", i + 1, broj);
                }
                calculate(ref min, ref max, ref sredna_vrednost, numbers);

            }
            Console.WriteLine("Od vnesenite broevi najgolem e {0}, najmal e {1}, a srednata vrednost e {2}", min, max, sredna_vrednost);
            Console.ReadKey();

        }
    }
}
