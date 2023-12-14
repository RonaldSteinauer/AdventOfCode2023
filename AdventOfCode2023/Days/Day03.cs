using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Days
{
    public static class Day03
    {
        public static void Part1()
        {
            List<MElement> Markers = new List<MElement>();
            List<NElement> Numbers = new List<NElement>();

            var input = File.ReadAllLines("Input/Input03.txt");

            for (var y = 0; y < input.Length; y++)
            {
                string number = string.Empty;
                List<Point> points = new List<Point>();

                for (var x = 0; x < input[y].Length; x++)
                {
                    var item = input[y][x];
                    if (!char.IsNumber(item) && item != '.')
                    {
                        Markers.Add(new MElement(item, x, y));
                    }

                    if (char.IsNumber(item))
                    {
                        number += item;
                        points.Add(new Point(x, y));
                    }
                    else if (!string.IsNullOrWhiteSpace(number))
                    {
                        Numbers.Add(new NElement(number, points));
                        number = string.Empty;
                        points = new List<Point>();
                    }
                }

                if (!string.IsNullOrWhiteSpace(number))
                {
                    Numbers.Add(new NElement(number, points));
                }
            }

            List<Point> checkPoints = new List<Point>();
            Markers.ForEach(d => checkPoints.AddRange(d.GenerateCheckpoints()));

            var result = Numbers.Where(d => d.IsRelevant(checkPoints)).Sum(d => d.Number);

            Console.WriteLine(result.ToString());
        }

        public static void Part2()
        {
            List<MElement> Markers = new List<MElement>();
            List<NElement> Numbers = new List<NElement>();

            var input = File.ReadAllLines("Input/Input03.txt");

            for (var y = 0; y < input.Length; y++)
            {
                string number = string.Empty;
                List<Point> points = new List<Point>();

                for (var x = 0; x < input[y].Length; x++)
                {
                    var item = input[y][x];
                    if (!char.IsNumber(item) && item != '.')
                    {
                        Markers.Add(new MElement(item, x, y));
                    }

                    if (char.IsNumber(item))
                    {
                        number += item;
                        points.Add(new Point(x, y));
                    }
                    else if (!string.IsNullOrWhiteSpace(number))
                    {
                        Numbers.Add(new NElement(number, points));
                        number = string.Empty;
                        points = new List<Point>();
                    }
                }

                if (!string.IsNullOrWhiteSpace(number))
                {
                    Numbers.Add(new NElement(number, points));
                }
            }

            List<Point> checkPoints = new List<Point>();
            var areas = Markers.Where(d => d.Marker == '*').Select(d => d.GenerateCheckArea()).ToList();

            List<int> products = new List<int>();
            foreach (var area in areas)
            {
                var numbers = Numbers.Where(d => d.IsRelevant(area)).Select(d => d.Number).ToList();

                if (numbers.Count == 2)
                {
                    products.Add(numbers[0] * numbers[1]);
                }
            }

            var result = products.Sum();

            Console.WriteLine(result.ToString());
        }
    }

    public class MElement
    {
        public MElement(char marker, int x, int y)
        {
            Marker = marker;

            Position = new Point(x, y);
        }

        public char Marker { get; set; }

        public Point Position { get; set; }

        public IEnumerable<Point> GenerateCheckpoints()
        {
            yield return new Point(Position.X - 1, Position.Y - 1);
            yield return new Point(Position.X, Position.Y - 1);
            yield return new Point(Position.X + 1, Position.Y - 1);
            yield return new Point(Position.X - 1, Position.Y);
            yield return new Point(Position.X + 1, Position.Y);
            yield return new Point(Position.X - 1, Position.Y + 1);
            yield return new Point(Position.X, Position.Y + 1);
            yield return new Point(Position.X + 1, Position.Y + 1);
        }

        public Rectangle GenerateCheckArea()
        {
            return new Rectangle(new Point(Position.X - 1, Position.Y - 1), new Size(3, 3));
        }
    }

    public class NElement
    {
        public NElement(string number, List<Point> points)
        {
            Number = int.Parse(number);

            NumberString = number;

            Points = points;
        }

        public int Number { get; set; }

        public string NumberString { get; set; }

        public List<Point> Points { get; set; }

        public bool IsRelevant(List<Point> checkPoints)
        {
            foreach (var point in Points)
            {
                if (checkPoints.Any(d => d == point))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsRelevant(Rectangle checkArea)
        {
            foreach (var point in Points)
            {
                if (checkArea.Contains(point))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
