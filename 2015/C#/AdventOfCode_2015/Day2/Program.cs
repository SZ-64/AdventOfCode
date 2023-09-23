
// Total wrapping page sq ft need
var sqft = 0;

// Total ribbon length needed
var length = 0;

// Read the puzzle input
var input = File.ReadAllLines("input.txt");

// Iterate over each box size
foreach (var boxSize in input)
{
    
    // Split int [l, w, h]
    var sides = boxSize.Split('x');
    var l = int.Parse(sides[0]);
    var w = int.Parse(sides[1]);
    var h = int.Parse(sides[2]);

    // Get the min side
    var minSideArea = new [] { l * w, w * h, h * l }.Min();

    // Get the surface area
    var surfArea = 2 * ((l * w) + (w * h) + (h * l));

    // Add the two for the total for this box
    var boxTotal = surfArea + minSideArea;

    // Add the box total to running total
    sqft += boxTotal;

    // Ribbon is perimeter of smallest face
    var ribbon = new []
    {
        l + l + w + w,
        w + w + h + h,
        h + h + l + l
    }.Min();

    // Ribbon for the bow
    var bow = l * w * h;

    // Ribbon for the bow
    var ribbonTotal = bow + ribbon;

    // Ribbon for the box
    length += ribbonTotal;
}

// Print the results
Console.WriteLine(sqft);
Console.WriteLine(length);
