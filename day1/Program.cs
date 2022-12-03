List<string> input = new List<string>();
var logFile = File.ReadAllLines("input.txt");
foreach (var s in logFile) input.Add(s);

var elfCalDict = new Dictionary<int, int>();
var index = 0;
foreach (var item in input)
{
    if (string.IsNullOrEmpty(item)) ++index;
    else
    {
        if (elfCalDict.ContainsKey(index)) elfCalDict[index] += Int32.Parse(item);
        else elfCalDict.Add(index, Int32.Parse(item));
    }
}

var topThreeElfs = new Dictionary<int, int>();
for (int i = 0; i < 3; i++)
{
    var elfwithMostFood = elfCalDict.MaxBy(x => x.Value);
    topThreeElfs.Add(elfwithMostFood.Key, elfwithMostFood.Value);
    elfCalDict.Remove(elfwithMostFood.Key);
}
Console.WriteLine($"Elfs: {string.Join(", ", topThreeElfs.Keys)}, Cals: {topThreeElfs.Sum(x => x.Value)} ({string.Join(", ", topThreeElfs.Values)})");