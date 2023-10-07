
// Read the puzzle input
using Common.Grid;
using Day6;

var input = File.ReadAllLines("input.txt");
var lights = new Dictionary<int, Light>();

InitializeLights();
PartOne();
PartTwo();

Console.ReadLine();

/// <summary>
/// Count how many lights are still on after all of the instructions.
/// </summary>
void PartOne()
{
    // Instantiate the light processor to use
    var lightProcessor = new LightProcessor();

    // Parse and run each instruction
    ProcessInstructions(lightProcessor.LightFunction);

    // Count all of the lights that are on
    Console.WriteLine(lights.Values.Where(l => l.IsOn).ToList().Count);
}

/// <summary>
/// Change the interpritation of the instructions to update brighness.
/// </summary>
void PartTwo()
{
    // Instantiate the light processor to use
    var lightProcessor = new BrightnessProcessor();

    // Parse and run each instruction
    ProcessInstructions(lightProcessor.LightFunction);

    // Sum all of the brightness values
    Console.WriteLine(lights.Values.Sum(l => l.Brightness));
}

/// <summary>
/// Processes each instruction in the list of instructions.
/// Takes in a function to determine which action should be called.
/// </summary>
void ProcessInstructions(Func<string, Action<Dictionary<int, Light>, Point, Point>> commandParser)
{
    // Process each instruction one line at a time
    foreach (var line in input)
    {
        // Split the line into tokens for easier parsing
        var tokens = line.Split(' ');

        // This will be checked repeatedly
        var isToggle = tokens.Length == 4;

        // Parse the light coordinates in the instruction
        var l1 = isToggle ? tokens[1].Split(',') : tokens[2].Split(',');
        var l2 = isToggle ? tokens[3].Split(',') : tokens[4].Split(',');

        // Convert the coordinates into points
        var p1 = new Point { X = int.Parse(l1[0]), Y = int.Parse(l1[1]) };
        var p2 = new Point { X = int.Parse(l2[0]), Y = int.Parse(l2[1]) };

        // Determine which operation to perform based on the instruction
        var command = commandParser.Invoke(isToggle ? tokens[0] : tokens[1]);

        // Run the command
        command.Invoke(lights, p1, p2);
    }
}

/// <summary>
/// Fills the grid with lights, each with their own unique ID
/// for quick reference, and initially set to the OFF state.
/// </summary>
void InitializeLights()
{
    for (int y = 0; y < GridSettings.MAX_HEIGHT; y++)
        for (int x = 0; x < GridSettings.MAX_HEIGHT; x++)
            lights[x + y * GridSettings.MAX_WIDTH] = new Light(x, y);
}
