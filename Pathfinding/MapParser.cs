
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Pathfinding
{
    public class MapParser
    {
        public int[][] ReadTextToMap(string text)
        {
            List<List<int> > listMap = new List<List<int>>();;
            List<int> curRow = new List<int>();
            foreach (var c in text)
            {
                if (c.ToString() == Environment.NewLine)
                {
                    listMap.Add(curRow);
                    curRow = new List<int>();
                }
                else if (Char.IsDigit(c))
                {
                    curRow.Add(int.Parse(c.ToString()));
                }
                else
                {
                    //throw new Exception($"Map input must be digit or newline. Was {c}");
                }
            }
            listMap.Add(curRow);

            //dodgy swapping - clean this later.
            int[][] map = new int[listMap[0].Count][];
            for (int x = 0; x < listMap[0].Count; x++)
            {
                map[x] = new int[listMap.Count];
                for (int y = 0; y < listMap.Count; y++)
                {
                    map[x][y] = listMap[y][x];
                }
            }

            return map;
        }

        public int[][] ReadTextToMap(string text, int width, int height)
        {
            Console.WriteLine(text);
            int[][] map = new int[width][];

            for (int x = 0; x < width; x++)
            {
                map[x] = new int[height];
                for (int y = 0; y < height; y++)
                {
                    // if (x*width+y < text.Length)
                    // {
                    Console.WriteLine(text[x*height+y]);
                    //text[x*width+y].ToString()
                    map[x][y] = int.Parse(text[x*height+y].ToString());
                   // }
                }
            }

            return map;            
        }
    }
}