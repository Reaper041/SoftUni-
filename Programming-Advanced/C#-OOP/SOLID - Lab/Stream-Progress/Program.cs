using System;

namespace Stream_Progress
{
    class Program
    {
        static void Main(string[] args)
        {
            File file = new File("Chalga", 40, 2);
            Music music = new Music("Preslava", "Da gori v lyubov", 50, 4);

            StreamProgressInfo fileStream = new StreamProgressInfo(file);
            StreamProgressInfo musicStream = new StreamProgressInfo(music);

            Console.WriteLine(fileStream.CalculateCurrentPercent());
            Console.WriteLine(musicStream.CalculateCurrentPercent());
        }
    }
}
