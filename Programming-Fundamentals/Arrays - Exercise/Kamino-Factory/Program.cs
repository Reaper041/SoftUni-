using System;
using System.Linq;
using System.Threading.Channels;

namespace Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            string sequence = Console.ReadLine();

            int maxValue = int.MinValue;
            int maxValueInArr = int.MinValue;
            string bestSequence = string.Empty;
            int bestSequenceIndex = 0;
            int index = 0;
            while (sequence != "Clone them!")
            {
                index++;
                int[] sequenceNums = sequence
                    .Split('!')
                    .Select(int.Parse)
                    .ToArray();
                
                int onesCount = 0;
                int total = 0;
                for (int i = 0; i < sequenceNums.Length; i++)
                {
                    
                    if (sequenceNums[i] == 1)
                    {
                        onesCount++;
                        total++;
                    }
                    else
                    {
                        onesCount = 0;
                    }
                    if (onesCount > maxValueInArr)
                    {
                        maxValueInArr = onesCount;
                    }
                }

                if (maxValueInArr > maxValue && total > maxValueInArr)
                {
                    bestSequenceIndex = index;
                    maxValue = total;
                    bestSequence = string.Join(' ', sequenceNums);
                }
                sequence = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {maxValue}.");
            Console.WriteLine($"{bestSequence}");
        }
    }
}
