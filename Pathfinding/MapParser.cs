
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Pathfinding
{
    public class InvalidMapDataException : Exception
    {
        public InvalidMapDataException(string message):base(message)
        {}
    }
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
                } else if (c == '\r' || c == '\n')
                {/*ignore extras - Environemnt.Newline should pick up the relevent one*/}
                else
                {
                    throw new InvalidMapDataException($"Map input must be digit or newline. Was {c}");
                }
            }
            if (curRow.Count != 0)
                listMap.Add(curRow);

            int[][] map = new int[listMap[0].Count][];

            try
            {
                for (int x = 0; x < listMap[0].Count; x++)
                {
                    map[x] = new int[listMap.Count];
                    for (int y = 0; y < listMap.Count; y++)
                    {
                        map[x][y] = listMap[y][x];
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new InvalidMapDataException("Invalid map: Rows not of consistent lengths");
            }

            return map;
        }
    }
}