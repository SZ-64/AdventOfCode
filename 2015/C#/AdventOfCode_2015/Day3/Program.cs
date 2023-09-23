using Common.Grid;

PartOne();
PartTwo();

/// <summary>
/// Track Santa's house deliveries.
/// </summary>
void PartOne()
{
    // Store the current position
    var pos = new Point { X = 0, Y = 0 };

    // Read the puzzle input
    var input = File.ReadAllText("input.txt");

    // Map to store unique houses and presents delivered
    var houseList = new Dictionary<Point, int>
    {
        { pos, 1 }
    };

    // Iterate over each direction
    foreach (var dir in input)
    {
        // Update current position
        pos = MoveLocation(pos, dir);

        // Add the house to the list or update the count
        if (houseList.ContainsKey(pos))
            houseList[pos]++;
        else
            houseList.Add(pos, 1);
    }

    // Print the results
    Console.WriteLine(houseList.Keys.Count);
}

/// <summary>
/// Track Santa's and Robo-Santa's movements
/// </summary>
void PartTwo()
{
    // Store both Santa's and Robo-Santa's position
    var santaPos = new Point { X = 0, Y = 0 };
    var roboPos = new Point { X = 0, Y = 0 };

    // Read the puzzle input
    var input = File.ReadAllText("input.txt");

    // Map to store unique houses and presents delivered
    var houseList = new Dictionary<Point, int>
    {
        { santaPos, 1 }
    };

    // Iterate over each direction
    for (var i = 0; i < input.Length; i++)
    {
        // Update Santa if even, Robo-Santa if odd
        Point curPoint;
        if (i % 2 == 0)
        {
            santaPos = MoveLocation(santaPos, input[i]);
            curPoint = santaPos;
        }
        else
        {
            roboPos = MoveLocation(roboPos, input[i]);
            curPoint = roboPos;
        }

        // Add the house to the list or update the count
        if (houseList.ContainsKey(curPoint))
            houseList[curPoint]++;
        else
            houseList.Add(curPoint, 1);
    }

    // Print the results
    Console.WriteLine(houseList.Keys.Count);
}

/// <summary>
/// Moves a point according to the specified direction.
/// </summary>
Point MoveLocation(Point curLoc, char dir)
{
    // Parse curLoc
    var x = curLoc.X;
    var y = curLoc.Y;

    // Update the position
    if (dir == '^')
        y++;
    else if (dir == 'v')
        y--;
    else if (dir == '>')
        x++;
    else if (dir == '<')
        x--;

    // Return the new point
    return new Point { X = x, Y = y };
}
