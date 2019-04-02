using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{
    enum PasswordStrength : byte
    {
        easy = 1,
        normal = 2,
        hard = 3
    }
    class Program
    {
        static string[] generatePassword(PasswordStrength passwordStrength)
        {
            string[] generatedPasswords = new string[3];
            Random rand = new Random();
            string randomPassword = "";
            if ((byte)passwordStrength == 1)
            {
                string possibleChars = "abcdefghijklmnopqrstuvwxyz";
                char[] possibleChars_array = possibleChars.ToCharArray();
                for (int i = 0; i < 3; i++)
                {
                    randomPassword = "";
                    for (int j = 0; j < 6; j++)
                    {
                        randomPassword += possibleChars_array[rand.Next(0, possibleChars_array.Length - 1)];
                    }
                    generatedPasswords[i] = randomPassword;
                }
            }
            else if ((byte)passwordStrength == 2)
            {
                string possibleChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                char[] possibleChars_array = possibleChars.ToCharArray();
                for (int i = 0; i < 3; i++)
                {
                    randomPassword = "";
                    int maxLength = rand.Next(6, 11);
                    for (int j = 0; j < maxLength; j++)
                    {
                        randomPassword += possibleChars_array[rand.Next(0, possibleChars_array.Length - 1)];
                    }
                    generatedPasswords[i] = randomPassword;
                }
            }
            else if ((byte)passwordStrength == 3)
            {
                string possibleChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789,./;'-=~`[]<>?:|{ } ";
                char[] possibleChars_array = possibleChars.ToCharArray();
                for (int i = 0; i < 3; i++)
                {
                    randomPassword = "";
                    int maxLength = rand.Next(10, 21);
                    for (int j = 0; j < maxLength; j++)
                    {
                        randomPassword += possibleChars_array[rand.Next(0, possibleChars_array.Length - 1)];
                    }
                    generatedPasswords[i] = randomPassword;
                }
            }
            return generatedPasswords;
        }
        static void Main(string[] args)
        {
            Console.Write("Vnesete gi vasite lozinki: ");
            string passLine = Console.ReadLine();
            char[] delimiter = { ' ' };
            string[] parts = passLine.Split(delimiter);
            string[] easyPasswords = generatePassword(PasswordStrength.easy);
            string[] normalPasswords = generatePassword(PasswordStrength.normal);
            string[] hardPasswords = generatePassword(PasswordStrength.hard);
            bool flag = false;
            for (int i = 0; i < 3; i++)
            {
                string easyPass = easyPasswords[i];
                string normalPass = normalPasswords[i];
                string hardPass = hardPasswords[i];
                for (int j = 0; j < parts.Length; j++)
                {
                    if (parts[j] == easyPass || parts[j] == normalPass || parts[j] == hardPass)
                    {
                        Console.WriteLine("Pogodok, go pogodivte password-ot: {0}", parts[j]);
                        flag = true;
                    }
                }
            }
            if (!flag)
                Console.WriteLine("Ne pogodivte nitu eden password.");
            Console.Write("Random geneniranite 'easy' passwordi bea: ");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("{0} ", easyPasswords[i]);
            }
            Console.WriteLine();
            Console.Write("Random geneniranite 'normal' passwordi bea: ");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("{0} ", normalPasswords[i]);
            }
            Console.WriteLine();
            Console.Write("Random geneniranite 'hard' passwordi bea: ");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("{0} ", hardPasswords[i]);
            }
            Console.ReadKey();

        }
    }
}
