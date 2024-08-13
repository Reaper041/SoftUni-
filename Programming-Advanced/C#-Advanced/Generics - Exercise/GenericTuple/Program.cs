
using GenericTuple;

string[] firstInput = Console.ReadLine()!.Split(' ').ToArray();
string firstTupleKey = $"{firstInput[0]} {firstInput[1]}";

GenericTuple.Tuple<string, string> firstTuple = new GenericTuple.Tuple<string, string>(firstTupleKey, firstInput[2]);

Console.WriteLine(firstTuple);

string[] secondInput = Console.ReadLine()!.Split(" ").ToArray();
string secondTupleKey = secondInput[0];
int secondTupleValue = int.Parse(secondInput[1]);

GenericTuple.Tuple<string, int> secondTuple = new GenericTuple.Tuple<string, int>(secondTupleKey, secondTupleValue);

Console.WriteLine(secondTuple);

string[] thirdInput = Console.ReadLine()!.Split(" ").ToArray();
int thirdTupleKey = int.Parse(thirdInput[0]);
double thirdTupleValue = double.Parse(thirdInput[1]);

GenericTuple.Tuple<int, double> thirdTuple = new GenericTuple.Tuple<int, double>(thirdTupleKey, thirdTupleValue);

Console.WriteLine(thirdTuple);