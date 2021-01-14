using System;
using System.Diagnostics.Tracing;
using System.Net.Http.Headers;

namespace Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            if (LenghtChecker(password) == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (DigitsChecker(password) == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (DigitsCounter(password) == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (DigitsChecker(password) && DigitsCounter(password) && LenghtChecker(password))
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool DigitsCounter(string password)
        {
            int counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    counter++;
                }
            }

            if (counter >=2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool DigitsChecker(string password)
        {
            bool isDigit = true;
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsDigit(password[i]) || Char.IsLetter(password[i]))
                {
                }
                else
                {
                    isDigit = false;
                }

            }

            if (isDigit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool LenghtChecker(string pass)
        {
            if (pass.Length >= 6 && pass.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
