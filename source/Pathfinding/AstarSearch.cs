//  NOTE about types: in the main article, in the Python code I just
//  use numbers for costs, heuristics, and priorites.  In the C++ code
//  I use a typedef for this, because you might want an int or double or
//  another type.  In this C# code, i use double for costs, heuristics,
//  and priorities.  You can use an int if you know your values are
//  always integers, and you can use a smaller size number if you know
//  the values are always small.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pathfinding
{
    public class AstarSearch
    {
        //  The most recent calculated path.
        private List<Location> _calculatedPath;

        /// <summary>
        ///     A <see cref="Dictionary{TKey, TValue}"/> that contains a key-value pair of all locations
        ///     and where they came from.  The key is a given location and the value is the location that
        ///     it came from.
        /// </summary>
        public Dictionary<Location, Location> CameFrom = new Dictionary<Location, Location>();

        /// <summary>
        ///     A <see cref="Dictionary{TKey, TValue}"/> that contains a key-value pair of all locations
        ///     and the cost of traversing to that location.
        /// </summary>
        public Dictionary<Location, double> CostSoFar = new Dictionary<Location, double>();

        /// <summary>
        ///     A <see cref="List{T}"/> that contains the most recently calculated path from the 
        ///     starting point to the  goal point
        /// </summary>
        public ReadOnlyCollection<Location> Path { get; }

        /// <summary>
        ///     A <see cref="Location"/> value that describes the starting location of the most
        ///     recently calculated path.
        /// </summary>
        public Location Start { get; private set; }

        /// <summary>
        ///     A <see cref="Location"/> value that describes the goal location of the path of the
        ///     most recently calculated path.
        /// </summary>
        public Location Goal { get; private set; }

        public IWeightedGraph<Location> Graph { get; private set; }

        /// <summary>
        ///     Creates a new <see cref="AstarSearch"/> instance.
        /// </summary>
        /// <param name="graph">
        ///     A <see cref="IWeightedGraph{L}"/> instance that represents the 
        ///     graph to traverse.
        /// </param>
        /// <param name="start">
        ///     A <see cref="Location"/> value that describes the starting location.
        /// </param>
        /// <param name="goal">
        ///     A <see cref="Location"/> value that describes the ending location.
        /// </param>
        public AstarSearch(IWeightedGraph<Location> graph)
        {
            _calculatedPath = new List<Location>();
            Path = _calculatedPath.AsReadOnly();
            Graph = graph;
        }

        /// <summary>
        ///     Calcualtes the shortest path from the <paramref name="start"/> 
        ///     <see cref="Location"/> value to the <paramref name="goal"/>
        ///     <see cref="Location"/> value.
        /// </summary>
        public void CalculatePath(Location start, Location goal)
        {
            //  Clear any previous calculated path.
            _calculatedPath.Clear();

            //  Set the start and goal locations.
            Start = start;
            Goal = goal;

            //  Calculate using A*
            PriorityQueue<Location> frontier = new PriorityQueue<Location>();
            frontier.Enqueue(Start, 0);

            CameFrom[Start] = Start;
            CostSoFar[Start] = 0;

            while (frontier.Count > 0)
            {
                var currentLocation = frontier.Dequeue();

                if (currentLocation.Equals(Goal))
                {
                    break;
                }

                foreach (Location nextLocation in Graph.PassableNeighbors(currentLocation))
                {
                    double newCost = CostSoFar[currentLocation] + Graph.Cost(currentLocation, nextLocation);
                    if (!CostSoFar.ContainsKey(nextLocation) || newCost < CostSoFar[nextLocation])
                    {
                        CostSoFar[nextLocation] = newCost;
                        double priority = newCost + Heuristic(nextLocation, Goal);
                        frontier.Enqueue(nextLocation, priority);
                        CameFrom[nextLocation] = currentLocation;
                    }
                }
            }

            //  Now that we've finished the A* stuff, create the list that contains
            //  each location from start to goal of the shortest path. We have to start
            //  from the goal position and traverse backwards from there.
            Location location = Goal;
            while (location != Start)
            {
                _calculatedPath.Add(location);
                location = CameFrom[location];
            }
            _calculatedPath.Add(Start);

            //  We have to reverse here since we had to traverse from goal to start
            _calculatedPath.Reverse();
        }

        //  Note: a generic version of A* would be abstract over Location and
        //  also Heuristic
        private static double Heuristic(Location a, Location b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }

    }
}
