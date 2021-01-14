using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int cakePieces = width * length;

            string cakePiecesTaken = Console.ReadLine();
            int sum = 0;
            bool isEnought = true;
            while (cakePiecesTaken != "STOP")
            {
                sum += int.Parse(cakePiecesTaken);
                if (sum > cakePieces)
                {
                    isEnought = false;
                    break;
                }
                cakePiecesTaken = Console.ReadLine();
            }

            if (isEnought == false)
            {
                Console.WriteLine($"No more cake left! You need {sum - cakePieces} pieces more.");
            }
            else
            {
                Console.WriteLine($"{cakePieces - sum} pieces are left.");
            }
        }
    }
}
