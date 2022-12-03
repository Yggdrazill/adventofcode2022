List<KeyValuePair<char, char>> input = new();
var logFile = File.ReadAllLines("input.txt");
foreach (var s in logFile)
{
    input.Add(new KeyValuePair<char, char>(s[0], s[2]));
}

int totalscoreM1 = 0;
int totalscoreM2 = 0;

var scoreDiscM1 = new Dictionary<char, int> {
    { 'A', 1},
    { 'B', 2},
    { 'C', 3},
    { 'Y', 2},
    { 'X', 1},
    { 'Z', 3}
};


var scoreDiscM2 = new Dictionary<char, int> {
    { 'A', 1},
    { 'B', 2},
    { 'C', 3},
    { 'Y', 3},
    { 'X', 0},
    { 'Z', 6}
};

foreach (var game in input)
{
    var myScore = scoreDiscM1[game.Value];
    totalscoreM1 += myScore;
    var oppScore = scoreDiscM1[game.Key];

    if (myScore == oppScore) totalscoreM1 += 3;
    else if (myScore == 1 && oppScore == 3) totalscoreM1 += 6;
    else if (myScore == 2 && oppScore == 1) totalscoreM1 += 6;
    else if (myScore == 3 && oppScore == 2) totalscoreM1 += 6;
}


foreach (var game in input)
{
    var MyResult = scoreDiscM2[game.Value];
    totalscoreM2 += MyResult;
    var oppScore = scoreDiscM2[game.Key];

    if (MyResult == 6)
    {
        switch (oppScore)
        {
            case 1: totalscoreM2 += 2; break;
            case 2: totalscoreM2 += 3; break;
            case 3: totalscoreM2 += 1; break;
        }
    }
    else if (MyResult == 3)
    {
        totalscoreM2 += oppScore;
    }
    else
    {
        switch (oppScore)
        {
            case 1: totalscoreM2 += 3; break;
            case 2: totalscoreM2 += 1; break;
            case 3: totalscoreM2 += 2; break;
        }
    }
}

System.Console.WriteLine(totalscoreM1);
System.Console.WriteLine(totalscoreM2);
