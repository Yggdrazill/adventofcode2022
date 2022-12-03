List<string> input = new List<string>();
var logFile = File.ReadAllLines("input.txt");
foreach (var s in logFile) input.Add(s);

var elfCalDict = new Dictionary<int, int>();
var i = 0;
foreach (var item in input)
{
    if (string.IsNullOrEmpty(item)) ++i;
    else
    {
        if (elfCalDict.ContainsKey(i)) elfCalDict[i] += Int32.Parse(item);
        else elfCalDict.Add(i, Int32.Parse(item));
    }
}
var elfwithMostFood = elfCalDict.MaxBy(x => x.Value);

Console.WriteLine($"Elf: {elfwithMostFood.Key}, Cal: {elfwithMostFood.Value}");