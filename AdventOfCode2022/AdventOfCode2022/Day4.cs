using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2022
{
    public class Day4
    {
        List<string> _values;
    
        public Day4()
        {
            Init();
            Part1();
            Part2();
        }

        public void Init()
        {
            _values = File.ReadLines("../../../inputs/input_day4.txt").ToList();
        }

        public void Part1()
        {
            var numberOfOverlaps = 0;

            foreach (var line in _values)
            {
                var pair1 = line.Split(",")[0];
                var pair2 = line.Split(",")[1];

                var fromPair1 = Convert.ToInt32(pair1.Split("-")[0]);
                var toPair1 = Convert.ToInt32(pair1.Split("-")[1]);

                var fromPair2 = Convert.ToInt32(pair2.Split("-")[0]);
                var toPair2 = Convert.ToInt32(pair2.Split("-")[1]);

                var digitsPair1 = new HashSet<int>();
                var digitsPair2 = new HashSet<int>();

                for (int i = fromPair1; i <= toPair1; i++)
                    digitsPair1.Add(i);

                for (int i = fromPair2; i <= toPair2; i++)
                    digitsPair2.Add(i);

                if (digitsPair1.IsSubsetOf(digitsPair2) || digitsPair2.IsSubsetOf(digitsPair1))
                    numberOfOverlaps++;
            }

            Console.WriteLine(numberOfOverlaps);
        }

        public void Part2()
        {
            var numberOfOverlaps = 0;

            foreach (var line in _values)
            {
                var pair1 = line.Split(",")[0];
                var pair2 = line.Split(",")[1];

                var fromPair1 = Convert.ToInt32(pair1.Split("-")[0]);
                var toPair1 = Convert.ToInt32(pair1.Split("-")[1]);

                var fromPair2 = Convert.ToInt32(pair2.Split("-")[0]);
                var toPair2 = Convert.ToInt32(pair2.Split("-")[1]);

                var digitsPair1 = new HashSet<int>();
                var digitsPair2 = new HashSet<int>();

                for (int i = fromPair1; i <= toPair1; i++)
                    digitsPair1.Add(i);

                for (int i = fromPair2; i <= toPair2; i++)
                    digitsPair2.Add(i);

                if (digitsPair1.Any(x => digitsPair2.Contains(x)) || digitsPair2.Any(x => digitsPair1.Contains(x)))
                    numberOfOverlaps++;
            }

            Console.WriteLine(numberOfOverlaps);
        }
    }
}
