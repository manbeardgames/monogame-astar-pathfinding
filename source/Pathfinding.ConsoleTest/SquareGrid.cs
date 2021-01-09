using Pathfinding;
using System.Collections.Generic;

namespace ConsoleTest
{
    /// <summary>
    ///     Represents a grid with square 1x1 cells.
    /// </summary>
    public class SquareGrid : IWeightedGraph<Location>
    {
        /// <summary>
        ///     Gets a <see cref="Location"/> array containing the 
        ///     values for cardinal North, South, East, and West directions.
        /// </summary>
        public static readonly Location[] Directions = new[]
        {
            new Location(0, 1),     //  Up
            new Location(0, -1),    //  Down
            new Location(-1, 0),    //  Left
            new Location(1, 0),     //  Right
        };

        /// <summary>
        ///     Gets or Sets the total number of rows within this grid.
        /// </summary>
        public int Rows { get; set; }

        /// <summary>
        ///     Gets or Sets the total number of columns within this grid.
        /// </summary>
        public int Columns { get; set; }

        //  A hashset containing all locations within the grid that 
        //  are walls
        public HashSet<Location> walls = new HashSet<Location>();

        /// <summary>
        ///     Creates a new <see cref="SquareGrid"/> instance.
        /// </summary>
        /// <param name="rows">
        ///     A <see cref="int"/> value that defines the total number of
        ///     rows that are in the grid.
        /// </param>
        /// <param name="columns">
        ///     A <see cref="int"/> value that defines the number of columns
        ///     that are in the grid.
        /// </param>
        public SquareGrid(int rows, int columns)
        {
            Columns = columns;
            Rows = rows;
        }

        /// <summary>
        ///     Gets a <see cref="bool"/> value indicating if the given
        ///     <see cref="Location"/> is within the bounds of this grid.
        /// </summary>
        /// <param name="id">
        ///     A <see cref="Location"/> value that defines the row and
        ///     column of the lcoation.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the lcoation is within the bounds of this
        ///     grid; otherwise, <c>false</c>.
        /// </returns>
        public bool InBounds(Location id)
        {
            return 0 <= id.X && id.X < Columns &&
                   0 <= id.Y && id.Y < Rows;
        }

        /// <summary>
        ///     Gets a <see cref="bool"/> value that indicates if the given
        ///     <see cref="Location"/> is a passable
        /// </summary>
        /// <param name="id">
        ///     A <see cref="Location"/> value that defines the row and
        ///     column of the lcoation.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the lcoation is passable; otherwise, <c>false</c>.
        /// </returns>
        public bool Passable(Location id)
        {
            return !walls.Contains(id);
        }

        /// <summary>
        ///     Gets a <see cref="double"/> value that indicates the weighted
        ///     cost of passing from one location to the next.
        /// </summary>
        /// <param name="a">
        ///     The starting <see cref="Location"/> value.
        /// </param>
        /// <param name="b">
        ///     The <see cref="Location"/> value to move to.
        /// </param>
        /// <returns>
        ///     A <see cref="double"/> value that defines the cost of 
        ///     moving.
        /// </returns>
        public double Cost(Location a, Location b)
        {
            //  In this grid, all cells have a cost of 1
            return 1;
        }

        /// <summary>
        ///     Gets an <see cref="IEnumerable{T}"/> value of all neighbors
        ///     of the given <see cref="Location"/> that are passable.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Location> PassableNeighbors(Location id)
        {
            foreach (Location direction in Directions)
            {
                Location next = new Location(id.X + direction.X, id.Y + direction.Y);

                if (InBounds(next) && Passable(next))
                {
                    yield return next;
                }
            }
        }
    }
}
