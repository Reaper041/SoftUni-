﻿using System;

namespace Password_Guess
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();

            if (pass != "s3cr3t!P@ssw0rd")
            {
                Console.WriteLine("Wrong password!");
            }
            else
            {
                Console.WriteLine("Welcome");
            }
        }
    }
}
