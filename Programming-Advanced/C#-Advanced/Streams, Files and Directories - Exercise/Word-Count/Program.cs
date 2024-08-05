Dictionary<string, int> result = new Dictionary<string, int>();

using (StreamReader streamReader = new StreamReader("../../../words.txt"))
{
    string word = streamReader.ReadLine()!;

    while (word != null)
    {
        int wordTimesCount = 0;

        using (StreamReader streamReaderText = new StreamReader("../../../text.txt"))
        {
            string[] textChunks = streamReaderText.ReadToEnd().Split(" ").ToArray();

            foreach (string chunk in textChunks)
            {
                if (chunk.Contains(word))
                {
                    wordTimesCount++;
                }
            }
        }

        result[word] = wordTimesCount;

        word = streamReader.ReadLine()!;
    }
}

using (StreamWriter writer = new StreamWriter("../../../actualResult.txt", true))
{
    foreach (var pair in result.OrderByDescending(w => w.Value))
    {
        writer.WriteLine($"{pair.Key} - {pair.Value}");
    }
}