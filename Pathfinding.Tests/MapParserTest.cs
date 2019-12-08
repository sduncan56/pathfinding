
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

            MapParser mapParser = new MapParser();
            int[][] map = mapParser.ReadTextToMap(mapText);

            Assert.Equal(width,　map.Length);
            Assert.Equal(height, map[0].Length);
            Assert.Equal(2, map[0][6]);
            Assert.Equal(3, map[3][4]);
        }

        [Fact]
        public void ReadTextToMap_TrailingNewLine()
        {
            string mapText =
@"0003
0000
0111
";

            MapParser mapParser = new MapParser();
            int[][] map = mapParser.ReadTextToMap(mapText);

            Assert.Equal(4, map.Length);
            Assert.Equal(3, map[0].Length);
           
        }

        [Fact]
        public void ReadTextToMap_InvalidInput()
        {
            string mapText = "kjfgjdkgfd";
                        MapParser mapParser = new MapParser();
            Assert.Throws<InvalidMapDataException>(() => mapParser.ReadTextToMap(mapText));
        }

        [Fact]
        public void ReadTextToMap_JaggedMap()
        {
            string mapText = 
@"0000
0000
000";
            MapParser mapParser = new MapParser();

            Assert.Throws<InvalidMapDataException>(()=> mapParser.ReadTextToMap(mapText));
        }

    }

}
