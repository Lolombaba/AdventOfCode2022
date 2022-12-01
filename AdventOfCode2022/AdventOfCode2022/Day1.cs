using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2022
{
    public class Day1
    {
        private Dictionary<int, int> _dico = new Dictionary<int, int>();

        public Day1()
        {
            Init();
            Part1();
            Part2();
        }

        public void Init()
        {
            var values = File.ReadLines("../../../inputs/input_day1.txt").ToList();

            var i = 0;
            var totalCalories = 0;
            foreach (var calorie in values)
            {
                // a new challenger
                if (string.IsNullOrEmpty(calorie))
                {
                    _dico.Add(i, totalCalories);
                    i++;
                    totalCalories = 0;
                    continue;
                }

                var value = Convert.ToInt32(calorie);
                totalCalories = totalCalories + value;
            }
        }

        public void Part1()
        {
            var max = _dico.Max(x => x.Value);
            Console.WriteLine(max);
        }

        public void Part2()
        {
            var top3calories = _dico.OrderByDescending(x => x.Value).Take(3).Sum(x => x.Value);
            Console.WriteLine(top3calories);
        }
    }
}
