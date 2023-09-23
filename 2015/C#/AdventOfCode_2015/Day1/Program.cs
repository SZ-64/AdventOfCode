
// Variable to keep track of the current floor
var floor = 0;

// Variable to keep track of when floor goes negative
var basementPos = 0;

// Read the puzzle input
var input = File.ReadAllText("input.txt");

// Iterate over each char in the string
for (int i = 0; i < input.Length; i++) {

    // Check if underground and this is the first time
    if (floor < 0 && basementPos == 0)
        basementPos = i;

    // Add a floor for ( and subtract for )
    if (input[i] == '(')
        floor++;
    else if (input[i] == ')')
        floor--;
}

// Print the results
Console.WriteLine(floor);
Console.WriteLine(basementPos);
