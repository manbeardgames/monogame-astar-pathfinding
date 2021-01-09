using System;
using System.Collections.Generic;

namespace Pathfinding
{
    /// <summary>
    ///     A data structure that holds information that has a priority value associated with it.
    ///     When an item is removed, it is always the item with the highest proprity.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This priority queue uses an unsorted array, but ideally this would be a binary
    ///         heap.  There is an open issue for adding binary heap to the standard C# library
    ///         at <a href="https://github.com/dotnet/corefx/issues/574" />
    ///     </para>
    ///     <para>
    ///         It needs to be noted that when adding elements to this queue, for the value given
    ///         for the priority, the lower the value, the higher the priority the item has in 
    ///         the queue for retriving it. 
    ///     </para>
    /// </remarks>
    /// <typeparam name="T">
    ///     The type of information being queued.
    /// </typeparam>
    /// <!--
    ///     If you would like a better implementation of a priority queue, see the following
    ///     pages
    ///     * https://github.com/BlueRaja/High-Speed-Priority-Queue-for-C-Sharp
    ///     * http://visualstudiomagazine.com/articles/2012/11/01/priority-queues-with-c.aspx
    ///     * http://xfleury.github.io/graphsearch.html
    ///     * http://stackoverflow.com/questions/102398/priority-queue-in-net
    /// -->
    public class PriorityQueue<T>
    {
        //  The list of elements contained within this queue.
        private List<Tuple<T, double>> _elements = new List<Tuple<T, double>>();

        /// <summary>
        ///     Gets a <see cref="int"/> value that defines the total number
        ///     of elements currently within this <see cref="PriorityQueue{T}"/>
        /// </summary>
        public int Count => _elements.Count;

        /// <summary>
        ///     Queues a new element.
        /// </summary>
        /// <param name="item">
        ///     The <see cref="T"/> element to queue.
        /// </param>
        /// <param name="priority">
        ///     A <see cref="double"/> value that defines the priority of 
        ///     this element compared to other elements.  The lower the value
        ///     the higher the priority.
        /// </param>
        public void Enqueue(T item, double priority) => _elements.Add(Tuple.Create(item, priority));

        /// <summary>
        ///     Retrieves and removes the next element from this queue. The element that is
        ///     retrieved will be the element with the highest priority.
        /// </summary>
        /// <returns>
        ///     A value of type <see cref="T"/>. This will be the element that has the highest
        ///     priority within the queue currently
        /// </returns>
        public T Dequeue()
        {
            int bestIndex = 0;

            for (int i = 0; i < _elements.Count; i++)
            {
                if (_elements[i].Item2 < _elements[bestIndex].Item2)
                {
                    bestIndex = i;
                }
            }

            T bestItem = _elements[bestIndex].Item1;
            _elements.RemoveAt(bestIndex);
            return bestItem;
        }
    }
}
