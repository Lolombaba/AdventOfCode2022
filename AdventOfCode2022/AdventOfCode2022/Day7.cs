using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2022
{
    public class Day7
    {
        List<string> _values;
        private int _totalPart1 = 0;
        private Dir _root;
        
        public class Dir
        {
            public string Name { get; set; }
            public List<Dir> Children { get; set; }
            public int Size { get; set; }
            public Dir Parent { get; set; }
        }

        public Day7()
        {
            Init();
            Part1();
            Part2();
        }

        public void Init()
        {
            _values = File.ReadLines("../../../inputs/input_day7.txt").ToList();
        }

        public void Part1()
        {
            Dir currentDirectory = null;

            foreach (var line in _values)
            {
                if (line.StartsWith("$"))
                {
                    if (line.StartsWith("$ cd "))
                    {
                        var tmp = line.Replace("$ cd ", "");

                        if (tmp == "..")
                        {
                            currentDirectory = currentDirectory.Parent;
                        }
                        else
                        {
                            if (currentDirectory == null)
                            {
                                var dir = new Dir { Name = tmp, Size = 0, Children = new List<Dir>() };
                                _root = dir;
                                currentDirectory = dir;
                            }
                            else
                            {
                                var parent = currentDirectory;
                                currentDirectory = currentDirectory.Children.FirstOrDefault(x => x.Name == tmp);
                                currentDirectory.Parent = parent;
                            }
                        }
                    }
                    else if (line.StartsWith("$ ls"))
                    {
                        // you touch my tralala
                    }
                }
                else if (line.StartsWith("dir"))
                {
                    var tmp = line.Replace("dir ", "");
                    var dir = new Dir { Name = tmp, Size = 0, Children = new List<Dir>() };
                    currentDirectory.Children.Add(dir);
                }
                // File
                else
                {
                    var size = Convert.ToInt32(line.Split(" ")[0]);
                    currentDirectory.Size += size;
                }
            }

            GetSize(_root);

            Console.WriteLine(_totalPart1);
        }

        private int GetSize(Dir dir)
        {
            foreach (var child in dir.Children)
            {
                dir.Size += GetSize(child);
            }

            if (dir.Size <= 100000)
                _totalPart1 += dir.Size;

            return dir.Size;
        }

        public void Part2()
        {
            var dirs = new List<Dir>();

            var currentAvailableSpace = 70000000 - _root.Size;

            if (currentAvailableSpace < 30000000)
            {
                var sizeToDelete = 30000000 - currentAvailableSpace;

                GetDirsSuperiorToSize(_root, sizeToDelete, dirs);
                Console.WriteLine(dirs.Min(x => x.Size));
            }
        }

        private void GetDirsSuperiorToSize(Dir dir, int size, List<Dir> dirs)
        {
            if (dir.Size >= size)
                dirs.Add(dir);

            foreach (var child in dir.Children)
            {
                GetDirsSuperiorToSize(child, size, dirs);
            }
        }
    }
}
