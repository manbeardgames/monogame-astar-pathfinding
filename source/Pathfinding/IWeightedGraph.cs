using System.Collections.Generic;

namespace Pathfinding
{
    /// <summary>
    ///     Represents a traversable graph of <typeparamref name="L"/> elements
    ///     where each element can have different heuristic weight values.
    /// </summary>
    /// <typeparam name="L"></typeparam>
    public interface IWeightedGraph<L>
    {
        double Cost(Location a, Location b);
        IEnumerable<Location> PassableNeighbors(Location id);
    }
}
