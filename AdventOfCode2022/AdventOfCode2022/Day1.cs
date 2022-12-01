using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2022
{
    public class Day1
    {
        private List<int> _list = new List<int>();

        public Day1()
        {
            Init();
            Part1();
            Part2();
        }

        public void Init()
        {
            var values = File.ReadLines("../../../inputs/input_day1.txt").ToList();

            var totalCalories = 0;
            foreach (var calorie in values)
            {
                // a new challenger
                if (string.IsNullOrEmpty(calorie))
                {
                    _list.Add(totalCalories);
                    totalCalories = 0;
                    continue;
                }

                var value = Convert.ToInt32(calorie);
                totalCalories = totalCalories + value;
            }
        }

        public void Part1()
        {
            var max = _list.Max();
            Console.WriteLine(max);
        }

        public void Part2()
        {
            var top3calories = _list.OrderByDescending(x => x).Take(3).Sum();
            Console.WriteLine(top3calories);
        }
    }
}
