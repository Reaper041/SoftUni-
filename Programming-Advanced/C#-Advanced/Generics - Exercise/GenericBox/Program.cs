
using GenericBox;

int n = int.Parse(Console.ReadLine()!);
List<Box<double>> boxes = new List<Box<double>>();

for (int i = 0; i < n; i++)
{
    double element = double.Parse(Console.ReadLine()!);

    boxes.Add(new Box<double>(element));
}

Box<double> box = new Box<double>(double.Parse(Console.ReadLine()!));

GreaterValuesCount(boxes, box);


static void GreaterValuesCount<T>(List<Box<T>> boxes, Box<T> valueToCompare)
    where T : IComparable
{
    int count = 0;

    foreach (Box<T> box in boxes)
    {
        if (box.Value!.CompareTo(valueToCompare.Value) > 0)
        {
            count++;
        }
    }

    Console.WriteLine(count);
}

//static void SwapIndexes<T>(List<Box<T>> boxes, int firstIndex, int lastIndex)
//{
//    Box<T> curr = boxes[firstIndex];
//    boxes[firstIndex] = boxes[lastIndex];
//    boxes[lastIndex] = curr;

//    Console.WriteLine(string.Join(Environment.NewLine, boxes));
//}