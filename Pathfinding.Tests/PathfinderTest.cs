using System;
using Xunit;
using Pathfinding;
using System.Collections.Generic;


namespace Pathfinding.Tests
{
    public class PathfinderTest
    {
        public PathfinderTest()
        {


        }

        [Fact]
        public void FindPath_True()
        {
            string mapText = 
@"00000000000
00001001000
00001000100
00010001000
00130010000
00011110000
20000000000";

            var map = new MapParser().ReadTextToMap(mapText);
            Pathfinder pathfinder = new Pathfinder();
                    
            Stack<PFNode> path = pathfinder.FindPath(map);

            Assert.True(path.Count != 0, "Path not found");
            
            PFNode node = path.Pop();
            Assert.Equal(1, node.x);
            Assert.Equal(6, node.y);

            int count = 1;
            while (path.Count != 0)
            {
                count++;
                node = path.Pop();
                Assert.True(map[node.x][node.y] != 1, "includes a wall");
            }
            Assert.Equal(17, count);
        }

        [Fact]
        public void FindPath_NoPath()
        {
            string mapText =
@"0000
0020
1111
0000
3000";
            var map = new MapParser().ReadTextToMap(mapText);
            Pathfinder pathfinder = new Pathfinder();
                    
            Stack<PFNode> path = pathfinder.FindPath(map);

            Assert.Equal(0, path.Count);
        }
    }
}
