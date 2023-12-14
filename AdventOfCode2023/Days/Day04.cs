namespace AdventOfCode2023.Days
{
    public static class Day04
    {
        public static void Part1()
        {
            var input = File.ReadAllLines("Input/Input04.txt");

            List<Card> cards = input.Select(d => new Card(d)).ToList();

            var result = cards.Sum(d => d.GetPoints());

            Console.WriteLine(result.ToString());
        }

        public static void Part2()
        {
            var input = File.ReadAllLines("Input/Input04.txt");

            List<Card> cards = input.Select(d => new Card(d)).ToList();

            foreach (var card in cards)
            {
                var winCount = card.GetWinCount();

                for (int i = 0; i < winCount; i++)
                {
                    var index = cards.IndexOf(card) + i + 1;
                    cards[index].Count = cards[index].Count + card.Count;
                }
            }

            var result = cards.Sum(d => d.Count);

            Console.WriteLine(result.ToString());
        }
    }

    public class Card
    {
        public Card(string input)
        {
            var part1 = input.Split(':');
            Number = int.Parse(string.Join("", part1[0].Where(char.IsNumber)).ToString());

            var part2 = part1[1].Split("|");
            WinningNumbers = part2[0].Split(" ").Where(d => !string.IsNullOrWhiteSpace(d)).Select(int.Parse).ToList();
            Numbers = part2[1].Split(" ").Where(d => !string.IsNullOrWhiteSpace(d)).Select(int.Parse).ToList();

            Count = 1;
        }

        public int Number { get; set; }

        public List<int> WinningNumbers { get; set; }

        public List<int> Numbers { get; set; }

        public double Count { get; set; }

        public double GetPoints()
        {
            var count = GetWinCount();

            if (count > 0)
            {
                return Math.Pow(2, count - 1);
            }

            return 0;
        }

        public int GetWinCount()
        {
            return Numbers.Intersect(WinningNumbers).Count();
        }
    }
}
