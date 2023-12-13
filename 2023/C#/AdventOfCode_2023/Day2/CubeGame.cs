namespace Day2
{
    internal class CubeGame
    {
        // Id of this game
        public int Id { get; set; }

        // Rounds of this game
        public List<Dictionary<string, int>> Rounds { get; set; }

        public CubeGame(string line)
        {
            // Initialize the list
            Rounds = new List<Dictionary<string, int>>();

            // Parse the ID
            var tokens = line.Split(' ');
            Id = int.Parse(tokens[1].Substring(0, tokens[1].Length - 1));

            // Parse each game
            var s1 = line.Split(":");
            var s2 = s1[1].Split(";");
            
            foreach(var game in s2)
            {
                var round = new Dictionary<string, int>();

                var s3 = game.Split(',');
                
                foreach(var set in s3)
                {
                    var s4 = set.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    round.Add(s4[1], int.Parse(s4[0]));
                }

                Rounds.Add(round);
            }

        }

        public bool IsValid()
        {
            foreach (var round in Rounds)
            {
                if (round.ContainsKey("red"))
                {
                    if (round["red"] > 12)
                        return false;
                }
                
                if (round.ContainsKey("green"))
                {
                    if (round["green"] > 13)
                        return false;
                }

                if (round.ContainsKey("blue"))
                {
                    if (round["blue"] > 14)
                        return false;
                }
            }

            return true;
        }

        public int MinimumPower()
        {
            int minR = -1;
            int minG = -1;
            int minB = -1;

            foreach (var round in Rounds)
            {
                if (round.ContainsKey("red") && round["red"] > minR)
                    minR = round["red"];

                if (round.ContainsKey("green") && round["green"] > minG)
                    minG = round["green"];

                if (round.ContainsKey("blue") && round["blue"] > minB)
                    minB = round["blue"];
            }

            return
                (minR == -1 ? 1 : minR) * 
                (minG == -1 ? 1 : minG) *
                (minB == -1 ? 1 : minB);
        }
    }
}
