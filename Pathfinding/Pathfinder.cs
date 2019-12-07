using System;
using System.Collections.Generic;

namespace Pathfinding
{
    public struct PFNode
    {
        public List<PFNode> Neighbours;
        public int x, y;
    }

    public class Pathfinder
    {
        private const int StartType = 2;
        private const int EndType = 3;
        private PFNode FindFirstNodeOfTypeFromMap(int[][] map, int type)
        {
            for (int x = 0; x < map.Length; x++)
            {
                for (int y = 0; y < map.Length; y++)
                {
                    if (map[x][y] == type)
                    {
                        return new PFNode{x=x, y=y};
                    }
                }
            }
            throw new Exception($"Type '{type}' not found in map");
        }
        public Stack<PFNode> FindPath(int[][] map)
        {
            Stack<PFNode> path = new Stack<PFNode>();

            PFNode start = FindFirstNodeOfTypeFromMap(map, StartType);
            PFNode end = FindFirstNodeOfTypeFromMap(map, EndType);


            return path;
        }
    }
}