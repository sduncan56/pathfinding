
using Xunit;
using Pathfinding;

namespace Pathfinding.Tests
{
    public class MapParserTest
    {
        public MapParserTest()
        {

        }

        [Fact]
        public void ReadTextToMap()
        {
            int width = 11;
            int height = 7;

            string mapText = 
@"00000000000
00001001000
00001000100
00010001000
00130010000
00011110000
20000000000";

            Pathfinder pathfinder = new Pathfinder();

            MapParser mapParser = new MapParser();
            int[][] map = mapParser.ReadTextToMap(mapText);

            Assert.Equal(width,　map.Length);
            Assert.Equal(height, map[0].Length);
            Assert.Equal(2, map[0][6]);
            Assert.Equal(3, map[3][4]);
        }

    }

}
