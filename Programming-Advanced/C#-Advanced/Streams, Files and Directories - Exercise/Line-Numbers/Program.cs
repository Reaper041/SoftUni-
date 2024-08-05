using (StreamReader streamReader = new StreamReader("../../../text.txt") )
{
    string line = streamReader.ReadLine()!;
    int counter = 1;

    using (StreamWriter streamWriter = new StreamWriter("../../../result.txt"))
    {
        List<char> punctuationMarks = new List<char>()
            {
                '-', ',', '.', '!', '?', '\''
            };
        while (line != null)
        {
            int punctuationMarksCount = 0;
            

            foreach (char c in punctuationMarks)
            {
                if (line.Contains(c))
                {
                    punctuationMarksCount++;
                }
            }
            

            streamWriter.WriteLine($"Line {counter}: {line} ({line.Length})({punctuationMarksCount})");

            line = streamReader.ReadLine()!;
            counter++;
        }
    }
}