using System.Threading;

namespace AdventOfCode2023.Days
{
    public static class Day01
    {
        public static void Part1()
        {
            var input = File.ReadAllLines("Input/Input01.txt");

            var data = input.Select(d => d.Where(k => char.IsDigit(k)).ToArray());

            var numbers = data.Select(d => string.Concat(d[0], d[^1]));

            var result = numbers.Select(int.Parse).Sum();

            Console.WriteLine(result);
        }

        public static void Part2()
        {
            var input = File.ReadAllLines("Input/Input01.txt");

            input = input.Select(d => d.Replace("one", "one1one")
                                       .Replace("two", "two2two")
                                       .Replace("three", "three3three")
                                       .Replace("four", "four4four")
                                       .Replace("five", "five5five")
                                       .Replace("six", "six6six")
                                       .Replace("seven", "seven7seven")
                                       .Replace("eight", "eight8eight")
                                       .Replace("nine", "nine9nine")
            ).ToArray();

            var data = input.Select(d => d.Where(k => char.IsDigit(k)).ToArray());

            var numbers = data.Select(d => string.Concat(d[0], d[^1]));

            var result = numbers.Select(int.Parse).Sum();

            Console.WriteLine(result);
        }
    }
}
