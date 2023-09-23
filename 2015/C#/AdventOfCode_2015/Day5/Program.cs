
// Read the puzzle input
var input = File.ReadAllLines("input.txt");

PartOne();
PartTwo();

Console.ReadLine();

void PartOne()
{
    // Running total of nice strings
    var niceCount = 0;

    // Loop over each string
    foreach (var s in input)
    {
        // Assume the string is nice
        var isNice = true;

        // Check for double characters
        for (var i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1])
            {
                isNice = true;
                break;
            }

            isNice &= false;
        }

        // Check for at least 3 vowels
        isNice &= s
            .Where(x => x == 'a' || x == 'e' || x == 'i' || x == 'o' || x == 'u')
            .OrderBy(c => c)
            .ToList()
            .Count >= 3;

        // Check for exclusion of disallowed substrings
        isNice &= !(
            s.Contains("ab") ||
            s.Contains("cd") ||
            s.Contains("pq") ||
            s.Contains("xy")
        );

        // Increment the nice string count if nice
        niceCount += isNice ? 1 : 0; 
    }

    // Output the results
    Console.WriteLine(niceCount);
}

void PartTwo()
{
    // Running total of nice strings
    var niceCount = 0;

    // Loop over each string
    foreach (var s in input)
    {
        // Flags for each rule (assume false)
        var hasABA = false;
        var hasTwoPair = false;

        // Store pairs for pair rule check
        var pairs = new Dictionary<string, int>();

        // Check the rules against the string
        for (int i = 1; i < s.Length; i++)
        {
            var combo = $"{s[i - 1]}{s[i]}";
            if (pairs.ContainsKey(combo))
            {
                if (i - pairs[combo] > 1)
                {
                    hasTwoPair = true;
                }
            }
            else
            {
                pairs.Add(combo, i);
            }

            if (i >= 2 && s[i - 2] == s[i])
                hasABA = true;
        }

        // Assume the string is nice
        var isNice = hasTwoPair && hasABA;

        // Increment the nice string count if nice
        niceCount += isNice ? 1 : 0;
    }

    // Output the results
    Console.WriteLine(niceCount);
}
