
// Puzzle input
var key = "iwrupvqb";

// Part 1 = 5; Part 2 = 6;
var leadingZeros = 6;

// String to check for
var zeros = "";
for (var i = 0; i < leadingZeros; i++) zeros += "0";

// Use all available processors
Parallel.For(0, int.MaxValue, (idx, state) =>
{
    // Compute hash
    var hash = CreateMD5(key + idx);

    // Check if the hash has leading zeros
    if (hash.Substring(0, leadingZeros) == zeros)
    {
        Console.WriteLine(key + idx);
        Console.WriteLine(hash);
        state.Stop();
    }
});

/// <summary>
/// Create MD5 hash from a string input.
/// Source: https://stackoverflow.com/questions/11454004/calculate-a-md5-hash-from-a-string
/// </summary>
string CreateMD5(string input)
{
    using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
    {
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);
        return Convert.ToHexString(hashBytes);
    }
}
