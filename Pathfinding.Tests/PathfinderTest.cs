using System;
using Xunit;
using Pathfinding;


namespace Pathfinding.Tests
{
    public class PathfinderTest
    {
        public PathfinderTest()
        {
            int width = 11;
            int height = 7;

            string mapText = @"
            00000000000
            00001001000
            00001000100
            00010001000
            00130010000
            00011110000
            20000000000
            ";

            //Assert.Equal(mapText.Length, width*height);

        }

        [Fact]
        public void FindPath_True()
        {
            Pathfinder pathfinder = new Pathfinder();
            
            
            bool yay =pathfinder.FindPath();

           // Assert.True(yay, "oh no");
        }
    }
}
