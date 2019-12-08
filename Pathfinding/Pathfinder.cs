using System;
using System.Collections.Generic;
using Priority_Queue;

namespace Pathfinding
{
    public class Pathfinder
    {
        private const int StartType = 2;
        private const int EndType = 3;
        private PFNode FindFirstNodeOfTypeFromMap(int[][] map, int type)
        {
            for (int x = 0; x < map.Length; x++)
            {
                for (int y = 0; y < map[x].Length; y++)
                {
                    if (map[x][y] == type)
                    {
                        return new PFNode{x=x, y=y};
                    }
                }
            }
            throw new Exception($"Type '{type}' not found in map");
        }

        private int CalculateHeuristic(PFNode goal, PFNode node)
        {
            return Math.Abs(goal.x-node.x) + Math.Abs(goal.y-node.y);
        }
        public Stack<PFNode> FindPath(int[][] map)
        {
            SimplePriorityQueue<PFNode> frontier = new SimplePriorityQueue<PFNode>();
            Dictionary<PFNode, PFNode> cameFrom = new Dictionary<PFNode, PFNode>();
            Dictionary<PFNode, int> costSoFar = new Dictionary<PFNode, int>();

            PFNode start = FindFirstNodeOfTypeFromMap(map, StartType);
            PFNode end = FindFirstNodeOfTypeFromMap(map, EndType);

            frontier.Enqueue(start, 0);
            costSoFar[start] = 0;

            Dictionary<(int, int), PFNode> existingNodes = new Dictionary<(int, int), PFNode>();
            existingNodes[(start.x,start.y)] = start;

            while(frontier.Count != 0)
            {
                PFNode current = frontier.Dequeue();

                if (current.x == end.x && current.y == end.y)
                {
                    end = current;
                    break;
                }
                var cfrom = cameFrom.ContainsKey(current) ? cameFrom[current] : null;

                current.CalculateExits(map, existingNodes);

                foreach (PFNode next in current.Exits)
                {
                    int newCost = costSoFar[current] + 1;
                    if (!costSoFar.ContainsKey(next) || newCost < costSoFar[next])
                    {
                        costSoFar[next] = newCost;
                        int priority = newCost+CalculateHeuristic(end, next);
                        frontier.Enqueue(next, priority);
                        cameFrom[next] = current;
                    }
                }
            }

            Stack<PFNode> path = new Stack<PFNode>();


            PFNode cur = end;
            while (cameFrom.ContainsKey(cur))
            {
                path.Push(cur);
                cur = cameFrom[cur];
            }

            return path;
        }
    }
}