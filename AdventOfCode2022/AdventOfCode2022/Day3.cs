using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2022
{
    public static class CharExtension
    {
        public static int GetValue(this char c)
        {
            if (char.IsUpper(c))
                return ((short)c) - 38;

            return ((short)c) - 96;
        }
    }

    public class Day3
    {
        List<string> _values;
    
        public Day3()
        {
            Init();
            Part1();
            Part2();
        }

        public void Init()
        {
            _values = File.ReadLines("../../../inputs/input_day3.txt").ToList();
        }

        public void Part1()
        {
            var priorities = 0;

            foreach (var rucksack in _values)
            {
                var firstPart = rucksack.Substring(0, rucksack.Length / 2);
                var secondPart = rucksack.Substring(firstPart.Length, firstPart.Length);
                var inCommon = firstPart.Intersect(secondPart);

                priorities += inCommon.Select(x => x.GetValue()).Sum();
            }

            Console.WriteLine(priorities);
        }

        public void Part2()
        {
            var priorities = 0;
            var group = new List<string>();
            
            foreach (var rucksack in _values)
            {
                group.Add(rucksack);

                if (group.Count == 3)
                {
                    var inCommon = group[0].Intersect(group[1]).Intersect(group[2]);
                    priorities += inCommon.Select(x => x.GetValue()).Sum();

                    group.Clear();
                }
            }

            Console.WriteLine(priorities);
        }
    }
}
