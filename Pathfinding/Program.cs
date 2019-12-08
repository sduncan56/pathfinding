using System;

namespace Pathfinding
{
    public class Program
    {
        static void Main()
        {
            string currentInput = string.Empty;
            Console.WriteLine("Enter map followed by a return, or 'exit' to quit");
            while (true)
            {
                string input = Console.ReadLine();

                if (input == string.Empty)
                {
                    try {
                        MapParser mapParser = new MapParser();
                        var map = mapParser.ReadTextToMap(currentInput);
                        Pathfinder pathfinder = new Pathfinder();
                        var path = pathfinder.FindPath(map);
                        Console.WriteLine($"Path length: {path.Count}");
                    }
                    catch (InvalidMapDataException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    currentInput = string.Empty;
                    Console.WriteLine("Enter map followed by a return, or 'exit' to quit");

                }
                else if (input == "exit" || input == "quit")
                {
                    break;
                }
                else{
                    currentInput+=$"{input+Environment.NewLine}";
                }
            }
        }
    }
}
