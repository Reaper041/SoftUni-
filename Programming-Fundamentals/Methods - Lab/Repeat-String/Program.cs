using System;
using System.Linq;
using System.Text;

namespace Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int repeatTimes = int.Parse(Console.ReadLine());

            RepeatString(text, repeatTimes);
        }

        static void RepeatString(string text, int repeatTimes)
        {
            StringBuilder newText = new StringBuilder();

            for (int i = 0; i < repeatTimes; i++)
            {
                newText.Append(text);
            }

            Console.WriteLine(newText);
        }
    }
}
