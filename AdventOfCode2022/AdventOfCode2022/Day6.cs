using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2022
{
    public class Day6
    {
        string _value;

        public Day6()
        {
            Part1();
            Part2();
        }

        public void Init()
        {
            _value = File.ReadLines("../../../inputs/input_day6.txt").ToList()[0];
        }

        public void Part1()
        {
            Init();

            var list = new List<char>();

            for (int i = 0; i < _value.Length; i++)
            {
                for (int j = i; j < i + 4; j++)
                    list.Add(_value[j]);

                if (list.Distinct().Count() == 4)
                {
                    Console.WriteLine(i + 4);
                    break;
                }
                else
                {
                    list.Clear();
                }
            }
        }

        public void Part2()
        {
            Init();

            var list = new List<char>();

            for (int i = 0; i < _value.Length; i++)
            {
                for (int j = i; j < i + 14; j++)
                    list.Add(_value[j]);

                if (list.Distinct().Count() == 14)
                {
                    Console.WriteLine(i + 14);
                    break;
                }
                else
                {
                    list.Clear();
                }
            }
        }
    }
}
