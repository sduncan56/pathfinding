

using System.Collections.Generic;

namespace Pathfinding
{
    public class PFNode
    {
        public List<PFNode> _exits = new List<PFNode>();
        public List<PFNode> Exits
        {
            get => _exits;
        }

        public int x {get; set;}
        public int y {get; set;}

        private void AddExit(int x, int y, Dictionary<(int, int),PFNode> existingNodes)
        {
            PFNode node = existingNodes.ContainsKey((x, y)) ? existingNodes[(x, y)] : new PFNode { x = x, y = y };
            existingNodes[(x,y)] = node;
            _exits.Add(node);
        }
        public void CalculateExits(int[][] map, Dictionary<(int, int),PFNode> existingNodes)
        {
            if (x - 1 >= 0 && map[x - 1][y] != 1)
            {
                AddExit(x-1, y, existingNodes);
            }
            if (x + 1 < map.Length && map[x + 1][y] != 1)
            {
                AddExit(x+1, y, existingNodes);
            }

            if (y - 1 >= 0 && map[x][y - 1] != 1)
            {
                AddExit(x, y-1, existingNodes);
            }
            if (y + 1 < map[x].Length && map[x][y + 1] != 1)
            {
                AddExit(x, y+1, existingNodes);
            }

        }
    }
}