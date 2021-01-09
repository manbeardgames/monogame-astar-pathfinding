using Pathfinding;
using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * This is just a quick test of the implemetned A* in the Pathfinding project.
             * This test will create a 6 row x 10 column grid, as represented by the 
             * drawing below. After creating the grid, we will use the AStarSearch class
             * to find the shorest path from the start to the goal.  Finally we'll draw 
             * a representation of the grid with the shortest path to a console window.
             */


            /*  
             *  The following is a representation of the grid that will be implemented
             *  S = Starting Point
             *  W = Wall
             *  G = Goal/Ending Point.
             *  
             *         0     1     2     3     4     5     6     7     8     9
             *      |-----|-----|-----|-----|-----|-----|-----|-----|-----|-----|
             *      |     |     |     |     |     |     |     |     |     |     |
             *  0   |  S  |     |     |     |     |     |     |     |     |  W  |
             *      |     |     |     |     |     |     |     |     |     |     |
             *      |-----|-----|-----|-----|-----|-----|-----|-----|-----|-----|
             *      |     |     |     |     |     |     |     |     |     |     |
             *  1   |     |  W  |  W  |  W  |  W  |  W  |  W  |  W  |     |  W  |
             *      |     |     |     |     |     |     |     |     |     |     |
             *      |-----|-----|-----|-----|-----|-----|-----|-----|-----|-----|
             *      |     |     |     |     |     |     |     |     |     |     |
             *  2   |     |  W  |     |     |     |     |  W  |     |     |  W  |
             *      |     |     |     |     |     |     |     |     |     |     |
             *      |-----|-----|-----|-----|-----|-----|-----|-----|-----|-----|
             *      |     |     |     |     |     |     |     |     |     |     |
             *  3   |     |     |     |  W  |  W  |     |  W  |     |     |     |
             *      |     |     |     |     |     |     |     |     |     |     |
             *      |-----|-----|-----|-----|-----|-----|-----|-----|-----|-----|
             *      |     |     |     |     |     |     |     |     |     |     |
             *  4   |  W  |  W  |  W  |  W  |  W  |     |  W  |  W  |  W  |     |
             *      |     |     |     |     |     |     |     |     |     |     |
             *      |-----|-----|-----|-----|-----|-----|-----|-----|-----|-----|
             *      |     |     |     |     |     |     |     |     |     |     |
             *  5   |  W  |  W  |  W  |  W  |  W  |     |     |     |     |  G  |
             *      |     |     |     |     |     |     |     |     |     |     |
             *      |-----|-----|-----|-----|-----|-----|-----|-----|-----|-----|
                
            */

            SquareGrid grid = new SquareGrid(6, 10);
            //  Row 1
            grid.walls.Add(new Location(10 - 1, 1 - 1));

            //  Row 2 walls
            grid.walls.Add(new Location(2 - 1, 2 - 1));
            grid.walls.Add(new Location(3 - 1, 2 - 1));
            grid.walls.Add(new Location(4 - 1, 2 - 1));
            grid.walls.Add(new Location(5 - 1, 2 - 1));
            grid.walls.Add(new Location(6 - 1, 2 - 1));
            grid.walls.Add(new Location(7 - 1, 2 - 1));
            grid.walls.Add(new Location(8 - 1, 2 - 1));
            grid.walls.Add(new Location(10 - 1, 2 - 1));

            //  Row 3 walls
            grid.walls.Add(new Location(2 - 1, 3 - 1));
            grid.walls.Add(new Location(7 - 1, 3 - 1));
            grid.walls.Add(new Location(10 - 1, 3 - 1));

            //  Row 4 walls
            grid.walls.Add(new Location(4 - 1, 4 - 1));
            grid.walls.Add(new Location(5 - 1, 4 - 1));
            grid.walls.Add(new Location(7 - 1, 4 - 1));

            //  Row 5 walls
            grid.walls.Add(new Location(1 - 1, 5 - 1));
            grid.walls.Add(new Location(2 - 1, 5 - 1));
            grid.walls.Add(new Location(3 - 1, 5 - 1));
            grid.walls.Add(new Location(4 - 1, 5 - 1));
            grid.walls.Add(new Location(5 - 1, 5 - 1));
            grid.walls.Add(new Location(7 - 1, 5 - 1));
            grid.walls.Add(new Location(8 - 1, 5 - 1));
            grid.walls.Add(new Location(9 - 1, 5 - 1));

            //  Row 6 walls
            grid.walls.Add(new Location(1 - 1, 6 - 1));
            grid.walls.Add(new Location(2 - 1, 6 - 1));
            grid.walls.Add(new Location(3 - 1, 6 - 1));
            grid.walls.Add(new Location(4 - 1, 6 - 1));
            grid.walls.Add(new Location(5 - 1, 6 - 1));

            //  Start at (1, 1)
            Location startingLocation = new Location(0, 0);

            //  End at (10, 6)
            Location endingLocation = new Location(9, 5);

            //  Calculate the path
            AstarSearch aStar = new AstarSearch(grid);
            aStar.CalculatePath(startingLocation, endingLocation);

            //  Draw the grid to the screen so we can visually see it.
            DrawGride(grid, aStar);

            Console.ReadLine();
        }

        public static void DrawGride(SquareGrid grid, AstarSearch aStar)
        {
            for (int row = 0; row < grid.Rows; row++)
            {
                for (int column = 0; column < grid.Columns; column++)
                {
                    Location cell = new Location(column, row);

                    if (cell == aStar.Start)
                    {
                        Console.Write("S ");
                    }
                    else if (cell == aStar.Goal)
                    {
                        Console.Write("G ");
                    }
                    else if (grid.walls.Contains(cell))
                    {
                        Console.Write("# ");
                    }
                    else if (aStar.Path.Contains(cell))
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
