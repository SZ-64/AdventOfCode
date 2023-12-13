
using Day7;

// Read the puzzle input
var input = File.ReadAllLines("input.txt");

var gates = new Dictionary<string, Gate>();

PartOne();
PartTwo();

Console.ReadLine();

/// <summary>
/// Compute the values for each wire
/// </summary>
void PartOne()
{
    // Process each line of input
    foreach(var line in input)
    {
        // Split line into inputs and outputs
        var tokens = line.Split("->", StringSplitOptions.RemoveEmptyEntries);
        var lhs = tokens[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var rhs = tokens[1];

        // Add the output gate if it's not in the map already
        if (!gates.ContainsKey(rhs))
            gates.Add(rhs, new Gate());

        // Check if this is a direct assignment
        // Otherwise, parse the command and add gates as needed
        if (lhs.Length == 1)
        {
            // Check if the value is a number, and assign it
            // Otherwise, see if the gate exists and add it
            if (ushort.TryParse(lhs[0], out ushort result))
            {
                gates[rhs].Value = result;
            }
            else
            {
                if (gates.ContainsKey(lhs[0]))
                    gates[rhs].Inputs.Add(gates[lhs[0]]);
                else
                    gates.Add(lhs[0], new Gate(Operations.PASSTHROUGH));
            }
        }
        else if (lhs.Length == 2) // NOT
        {
            if (gates.ContainsKey(lhs[1]))
            {
                gates[rhs].Operation = Operations.NOT;
                gates[rhs].Inputs.Add(gates[lhs[1]]);
            }
            else
            {
                gates.Add(lhs[1], new Gate(Operations.NOT));
            }
        }
        else
        {
            // Parse the command
            var cmd = ParseCommand(lhs[1]);

            if (cmd == Operations.LSHIFT || cmd == Operations.RSHIFT)
            {
                if (gates.ContainsKey(lhs[0]))
                {
                    gates[rhs].Inputs.Add(gates[lhs[0]]);
                    gates[rhs].Inputs.Add(new Gate(ushort.Parse(lhs[2])));
                    gates[rhs].Operation = cmd;
                }
                else
                {
                    gates.Add(lhs[0], new Gate(cmd));
                    gates[rhs].Inputs.Add(gates[lhs[0]]);
                    gates[rhs].Inputs.Add(new Gate(ushort.Parse(lhs[2])));
                    gates[rhs].Operation = cmd;
                }
            }
            else if (cmd == Operations.AND || cmd == Operations.OR)
            {
                // THIS IS WHERE i STOEPPED
                if (gates.ContainsKey(lhs[0]))
                {
                    gates[rhs].Inputs.Add(gates[lhs[0]]);
                    gates[rhs].Inputs.Add(new Gate(ushort.Parse(lhs[2])));
                    gates[rhs].Operation = cmd;
                }
                else
                {
                    gates.Add(lhs[0], new Gate(cmd));
                    gates[rhs].Inputs.Add(gates[lhs[0]]);
                    gates[rhs].Inputs.Add(new Gate(ushort.Parse(lhs[2])));
                    gates[rhs].Operation = cmd;
                }
            }
        }

    }

    // Print all of the wires out in order
    foreach(var gate in gates.Keys.OrderBy(k => k))
        Console.WriteLine($"{gate}: {gates[gate].Value}");
}

/// <summary>
/// Returns the command that corrosponds to the input.
/// </summary>
Operations ParseCommand(string cmd)
{
    switch(cmd)
    {
        case nameof(Operations.AND):
            return Operations.AND;
        case nameof(Operations.OR):
            return Operations.OR;
        case nameof(Operations.RSHIFT):
            return Operations.RSHIFT;
        case nameof(Operations.LSHIFT):
            return Operations.LSHIFT;
        default:
            return Operations.PASSTHROUGH;
    }
}

/// <summary>
/// Change the interpritation of the instructions to update brighness.
/// </summary>
void PartTwo()
{
    Console.WriteLine();
}