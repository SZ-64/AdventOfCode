
// Read the puzzle input
var input = File.ReadAllLines("input.txt");

// List of text numbers
var text = new List<String> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

// Run both parts
Console.WriteLine("Answer for Part One: " + PartOne());
Console.WriteLine("Answer for Part Two: " + PartTwo());

// Calculate the sum of the first and last number of each line
int PartOne()
{
    // Total sum of the numbers found
    var sum = 0;

    // Iterate over each char in the string
    foreach (var line in input)
    {
        // Extract all numbers
        var nums = line.Where(l => Char.IsNumber(l)).ToList();

        // Pair the first and last
        var res = nums[0] + "" + nums[nums.Count - 1];

        // Convert to int
        sum += int.Parse(res);
    }

    // Print the results
    return sum;
}

// Calculate the sum of the first and last number, accounting for text and digits
int PartTwo()
{
    // Total sum of the numbers found
    var sum = 0;

    // Iterate over each char in the string
    foreach (var line in input)
    {
        // Placeholders for the solution
        int firstNum = -1;
        int secondNum = -1;

        // Track the input since the last number to test for number string
        var chars = "";

        // Cycle over each char in the line, looking for numbers
        foreach (var c in line)
        {
            // stores the number found at this char
            var num = -1;

            // Take the char directly if it's a number and clear tracked chars
            if (Char.IsNumber(c))
                num = int.Parse(c + "");

            // Else, append and test for a word
            else
            {
                chars += c;
                var val = TestCharsForWord(chars);
                if (val != -1)
                    num = val;
            }

            // If num is not -1, fill it in
            if (firstNum == -1 && num != -1)
                firstNum = num;
            else if (num != -1)
                secondNum = num;

            // Copy 1st num to 2nd
            if (secondNum == -1)
                secondNum = firstNum;
        }

        // Add the num to the sum
        sum += firstNum * 10 + secondNum;
    }

    // Print the results
    return sum;
}

// Convert a set of chars into a number
int TestCharsForWord(string chars)
{
    var lastIndex = -1;

    foreach (var word in text)
    {
        if (chars.LastIndexOf(word) > lastIndex)
            lastIndex = chars.LastIndexOf(word);
    }

    if (lastIndex < 0)
        return -1;

    var num = chars.Substring(lastIndex);

    return num switch
    {
        "one" => 1,
        "two" => 2,
        "three" => 3,
        "four" => 4,
        "five" => 5,
        "six" => 6,
        "seven" => 7,
        "eight" => 8,
        "nine" => 9,
        _ => -1
    };
}
