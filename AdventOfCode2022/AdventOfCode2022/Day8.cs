using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2022
{
    public class Day8
    {
        List<string> _values;
        int[][] _treeGrid;
        int _nbVisible;
        int _nbRows;
        int _nbCols;

        public Day8()
        {
            Init();
            Part1();
            Part2();
        }

        public void Init()
        {
            _values = File.ReadLines("../../../inputs/input_day8.txt").ToList();
            _nbRows = _values.Count;
            _nbCols = _values[0].Length;

            _treeGrid = new int[_nbRows][];

            int i = 0;
            foreach (var line in _values)
            {
                _treeGrid[i] = new int[_nbCols];

                int j = 0;
                foreach (char nb in line)
                {
                    _treeGrid[i][j] = Convert.ToInt32(nb.ToString());
                    j++;
                }
                i++;
            }
        }

        public void Part1()
        {
            for (int i = 0; i < _nbRows; i++)
            {
                for (int j = 0; j < _nbCols; j++)
                {
                    // in corner/sides
                    if (i == 0 || i == _nbRows - 1 || j == 0 || j == _nbCols - 1)
                    {
                        _nbVisible++;
                        continue;
                    }

                    // inside
                    var toTheLeft = _treeGrid[i][0..j];

                    if (toTheLeft.All(x => x < _treeGrid[i][j]))
                    {
                        _nbVisible++;
                        continue;
                    }

                    int rightIndex = j + 1;
                    var toTheRight = _treeGrid[i][rightIndex.._nbCols];

                    if (toTheRight.All(x => x < _treeGrid[i][j]))
                    {
                        _nbVisible++;
                        continue;
                    }

                    var toTheTop = GetToTheTop(i, j);
                    if (toTheTop.All(x => x < _treeGrid[i][j]))
                    {
                        _nbVisible++;
                        continue;
                    }

                    var toTheBottom = GetToTheBottom(i, j);
                    if (toTheBottom.All(x => x < _treeGrid[i][j]))
                    {
                        _nbVisible++;
                        continue;
                    }
                }
            }

            Console.WriteLine(_nbVisible);
        }

        public List<int> GetToTheTop(int row, int col)
        {
            var list = new List<int>();
            for (int i = row-1; i >= 0; i--)
            {
                list.Add(_treeGrid[i][col]);
            }
            return list;
        }

        public List<int> GetToTheBottom(int row, int col)
        {
            var list = new List<int>();
            for (int i = row+1; i < _nbRows; i++)
            {
                list.Add(_treeGrid[i][col]);
            }
            return list;
        }

        public void Part2()
        {
            int maxView = 0;

            for (int i = 0; i < _nbRows; i++)
            {
                for (int j = 0; j < _nbCols; j++)
                {
                    int left = 0, right = 0, top = 0, bottom = 0;

                    // in corner/sides
                    if (i == 0 || i == _nbRows - 1 || j == 0 || j == _nbCols - 1)
                        continue;

                    // inside
                    var toTheLeft = _treeGrid[i][0..j];

                    foreach (var value in toTheLeft.Reverse())
                    {
                        if (value >= _treeGrid[i][j])
                        {
                            left++;
                            break;
                        }
                        else
                            left++;
                    }

                    int rightIndex = j + 1;
                    var toTheRight = _treeGrid[i][rightIndex.._nbCols];

                    foreach (var value in toTheRight)
                    {
                        if (value >= _treeGrid[i][j])
                        {
                            right++;
                            break;
                        }
                        else
                            right++;
                    }

                    var toTheTop = GetToTheTop(i, j);
                    foreach (var value in toTheTop)
                    {
                        if (value >= _treeGrid[i][j])
                        {
                            top++;
                            break;
                        }
                        else
                            top++;
                    }

                    var toTheBottom = GetToTheBottom(i, j);
                    foreach (var value in toTheBottom)
                    {
                        if (value >= _treeGrid[i][j])
                        {
                            bottom++;
                            break;
                        }
                        else
                            bottom++;
                    }

                    var tmp = left * right * top * bottom;
                    if (tmp > maxView)
                        maxView = tmp;
                }
            }

            Console.WriteLine(maxView);
        }
    }
}
