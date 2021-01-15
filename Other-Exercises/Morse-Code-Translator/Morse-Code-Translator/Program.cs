using System;
using System.Text;

namespace Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();


            foreach (var letter in text)
            {
                if (letter == ".-")
                {
                    sb.Append('A');
                }
                else if (letter == "-...")
                {
                    sb.Append('B');
                }
                else if (letter == "-.-.")
                {
                    sb.Append('C');
                }
                else if (letter == "-..")
                {
                    sb.Append('D');
                }
                else if (letter == ".")
                {
                    sb.Append('E');
                }
                else if (letter == "..-.")
                {
                    sb.Append('F');
                }
                else if (letter == "--.")
                {
                    sb.Append('G');
                }
                else if (letter == "....")
                {
                    sb.Append('H');
                }
                else if (letter == "..")
                {
                    sb.Append('I');
                }
                else if (letter == ".---")
                {
                    sb.Append('J');
                }
                else if (letter == "-.-")
                {
                    sb.Append('K');
                }
                else if (letter == ".-..")
                {
                    sb.Append('L');
                }
                else if (letter == "--")
                {
                    sb.Append('M');
                }
                else if (letter == "-.")
                {
                    sb.Append('N');
                }
                else if (letter == "---")
                {
                    sb.Append('O');
                }
                else if (letter == ".--.")
                {
                    sb.Append('P');
                }
                else if (letter == "--.-")
                {
                    sb.Append('Q');
                }
                else if (letter == ".-.")
                {
                    sb.Append('R');
                }
                else if (letter == "...")
                {
                    sb.Append('S');
                }
                else if (letter == "-")
                {
                    sb.Append('T');
                }
                else if (letter == "..-")
                {
                    sb.Append('U');
                }
                else if (letter == "...-")
                {
                    sb.Append('V');
                }
                else if (letter == ".--")
                {
                    sb.Append('W');
                }
                else if (letter == "-..-")
                {
                    sb.Append('X');
                }
                else if (letter == "-.--")
                {
                    sb.Append('Y');
                }
                else if (letter == "--..")
                {
                    sb.Append('Z');
                }
                else if (letter == "|")
                {
                    sb.Append(' ');
                }
            }

            Console.WriteLine(sb);
        }
    }
}
