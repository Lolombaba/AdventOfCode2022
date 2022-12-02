using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2022
{
    public class Day2
    {
        List<string> _values;

        public Day2()
        {
            Init();
            Part1();
            Part2();
        }

        public void Init()
        {
            _values = File.ReadLines("../../../inputs/input_day2.txt").ToList();
        }

        public void Part1()
        {
            Dictionary<(string, string), int> rules = new Dictionary<(string, string), int>();
            rules.Add(("X", "A"), 4);
            rules.Add(("X", "B"), 1);
            rules.Add(("X", "C"), 7);
            rules.Add(("Y", "A"), 8);
            rules.Add(("Y", "B"), 5);
            rules.Add(("Y", "C"), 2);
            rules.Add(("Z", "A"), 3);
            rules.Add(("Z", "B"), 9);
            rules.Add(("Z", "C"), 6);

            var totalPoints = 0;
            
            foreach (var line in _values)
            {
                var splitted = line.Split(" ");

                var play1 = splitted[0];
                var play2 = splitted[1];

                totalPoints += rules[(play2, play1)];
            }

            Console.WriteLine(totalPoints);
        }

        public void Part2()
        {
            Dictionary<(string, string), int> rules = new Dictionary<(string, string), int>();

            rules.Add(("A", "X"), 3);
            rules.Add(("A", "Y"), 4);
            rules.Add(("A", "Z"), 8);
            rules.Add(("B", "X"), 1);
            rules.Add(("B", "Y"), 5);
            rules.Add(("B", "Z"), 9);
            rules.Add(("C", "X"), 2);
            rules.Add(("C", "Y"), 6);
            rules.Add(("C", "Z"), 7);

            var totalPoints = 0;

            foreach (var line in _values)
            {
                var splitted = line.Split(" ");

                var play1 = splitted[0];
                var winType = splitted[1];

                totalPoints += rules[(play1, winType)];
            }

            Console.WriteLine(totalPoints);
        }
    }
}
