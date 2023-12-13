
using Day2;

// Read the puzzle input
var input = File.ReadAllLines("input.txt");

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
        // Create the game
        var game = new CubeGame(line);

        // Add ids of valid games
        sum += game.IsValid() ? game.Id : 0;
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
        // Create the game
        var game = new CubeGame(line);

        // Add ids of valid games
        sum += game.MinimumPower();
    }

    // Print the results
    return sum;
}
