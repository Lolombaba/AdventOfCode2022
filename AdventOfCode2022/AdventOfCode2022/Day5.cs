using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2022
{
    public class Day5
    {
        List<string> _values;
        List<string> _moves;
        Dictionary<int, LinkedList<string>> _stacks;


        public Day5()
        {
            Part1();
            Part2();
        }

        public void Init()
        {
            _values = File.ReadLines("../../../inputs/input_day5.txt").ToList();
            _stacks = new Dictionary<int, LinkedList<string>>();

            foreach (var line in _values)
            {
                if (line == "")
                    break;

                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];
                    if (c == '[')
                    {
                        var letter = line[i + 1].ToString();
                        int queueNumber = (i / 4)+1;

                        if (_stacks.ContainsKey(queueNumber))
                            _stacks[queueNumber].AddFirst(letter);
                        else
                        {
                            _stacks[queueNumber] = new LinkedList<string>();
                            _stacks[queueNumber].AddFirst(letter);
                        }
                    }
                }
            }

            _moves = _values.Where(x => x.StartsWith("move")).ToList();
        }

        public void Part1()
        {
            Init();
            foreach (var move in _moves)
            {
                var readable = move.Replace("move ", "").Replace("from ",",").Replace("to ",",").Split(",");
                var nbToMove = Convert.ToInt32(readable[0]);
                var sourceQueue = Convert.ToInt32(readable[1]);
                var destQueue = Convert.ToInt32(readable[2]);

                for (int i = 0; i < nbToMove; i++)
                {
                    var letterToMove = _stacks[sourceQueue].Last.Value;
                    _stacks[sourceQueue].RemoveLast();
                    _stacks[destQueue].AddLast(letterToMove);
                }
            }

            foreach (var queue in _stacks.OrderBy(x => x.Key).Select(x => x.Value))
            {
                Console.WriteLine(queue.Last.Value);
            }
        }

        public void Part2()
        {
            Init();
            foreach (var move in _moves)
            {
                var readable = move.Replace("move ", "").Replace("from ", ",").Replace("to ", ",").Split(",");
                var nbToMove = Convert.ToInt32(readable[0]);
                var sourceQueue = Convert.ToInt32(readable[1]);
                var destQueue = Convert.ToInt32(readable[2]);

                var listToMove = new List<string>();

                for (int i = 0; i < nbToMove; i++)
                {
                    listToMove.Add(_stacks[sourceQueue].Last.Value);
                    _stacks[sourceQueue].RemoveLast();
                }

                for (int i = listToMove.Count-1; i >= 0; i--)
                {
                    _stacks[destQueue].AddLast(listToMove.ElementAt(i));
                }
            }

            Console.WriteLine();
            foreach (var queue in _stacks.OrderBy(x => x.Key).Select(x => x.Value))
            {
                Console.WriteLine(queue.Last.Value);
            }
        }
    }
}
