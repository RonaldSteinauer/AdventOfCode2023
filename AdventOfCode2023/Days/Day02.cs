namespace AdventOfCode2023.Days
{
    public static class Day02
    {
        public static void Part1()
        {
            List<Game> games = new List<Game>();

            var input = File.ReadAllLines("Input/Input02.txt");

            foreach (var line in input)
            {
                games.Add(new Game(line, 12, 13, 14));
            }

            var result = games.Where(d => d.IsValid()).Sum(d => d.Id);

            Console.WriteLine(result.ToString());
        }

        public static void Part2()
        {
            List<Game> games = new List<Game>();

            var input = File.ReadAllLines("Input/Input02.txt");

            foreach (var line in input)
            {
                games.Add(new Game(line, 12, 13, 14));
            }

            var result = games.Select(d => d.GetPower()).Sum();

            Console.WriteLine(result.ToString());
        }
    }

    public class Game
    {
        private int _maxRed;
        private int _maxGreen;
        private int _maxBlue;

        public Game(string input, int maxRed, int maxGreen, int maxBlue)
        {
            _maxRed = maxRed;
            _maxGreen = maxGreen;
            _maxBlue = maxBlue;

            Rounds = new List<Round>();

            var seperateInputs = input.Split(":");

            Id = int.Parse(seperateInputs[0].Replace("Game ", ""));

            var rounds = seperateInputs[1].Split(";", StringSplitOptions.TrimEntries);

            foreach (var round in rounds)
            {
                Rounds.Add(new Round(round));
            }
        }

        public int Id { get; set; }

        public List<Round> Rounds { get; set; }

        public bool IsValid()
        {
            if (MaxRed > _maxRed)
            {
                return false;
            }

            if (MaxGreen > _maxGreen)
            {
                return false;
            }

            if (MaxBlue > _maxBlue)
            {
                return false;
            }

            return true;
        }

        public int GetPower()
        {
            return MaxRed * MaxGreen * MaxBlue;
        }

        private int MaxRed => Rounds.Max(d => d.Red);

        private int MaxGreen => Rounds.Max(d => d.Green);

        private int MaxBlue => Rounds.Max(d => d.Blue);
    }

    public class Round
    {
        public Round(string input)
        {
            var items = input.Split(",", StringSplitOptions.TrimEntries);

            foreach (var item in items)
            {
                if (item.Contains("red"))
                {
                    Red = GetValue("red", item);
                }
                else if (item.Contains("blue"))
                {
                    Blue = GetValue("blue", item);
                }
                else if (item.Contains("green"))
                {
                    Green = GetValue("green", item);
                }
            }
        }

        public int Red { get; set; }

        public int Blue { get; set; }

        public int Green { get; set; }

        private int GetValue(string name, string input)
        {
            int.TryParse(input.Replace(name, string.Empty).Trim(), out int result);

            return result;
        }
    }
}
