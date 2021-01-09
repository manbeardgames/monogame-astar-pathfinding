namespace Pathfinding
{
    /// <summary>
    ///     Represents an (x, y) location.
    /// </summary>
    public struct Location
    {
        /// <summary>
        ///     A <see cref="int"/> value that defines the x-coordiante 
        ///     point of this <see cref="Location"/>.
        /// </summary>
        public readonly int X;

        /// <summary>
        ///     A <see cref="int"/> value that defines the y-coordinate
        ///     point of this <see cref="Location"/>
        /// </summary>
        public readonly int Y;

        /// <summary>
        ///     Creates a new <see cref="Location"/> value.
        /// </summary>
        /// <param name="x">
        ///     A <see cref="int"/> value that defines the x-coordiante point
        ///     of this <see cref="Location"/>
        /// </param>
        /// <param name="y">
        ///     A <see cref="int"/> value that defines the y-coordinate point
        ///     of this <see cref="Location"/>
        /// </param>
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     Returns a <see cref="string"/> value that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="string"/> value containing the values of this instance.
        /// </returns>
        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        /// <summary>
        ///     Checks for equality between two <see cref="Location"/> values.
        /// </summary>
        /// <param name="locationA">
        ///     The <see cref="Location"/> value on the left side of the equality
        ///     operator.
        /// </param>
        /// <param name="locationB">
        ///     The <see cref="Location"/> value on the right side of the equality
        ///     operator.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the two <see cref="Location"/> values are equal;
        ///     otherwise, <c>false</c>
        /// </returns>
        public static bool operator ==(Location locationA, Location locationB) => locationA.Equals(locationB);

        /// <summary>
        ///     Checks for inequality between two <see cref="Location"/> values.
        /// </summary>
        /// <param name="locationA">
        ///     The <see cref="Location"/> value on the left side of the inequality
        ///     operator.
        /// </param>
        /// <param name="locationB">
        ///     The <see cref="Location"/> value on the right side of the inequality
        ///     operator.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the two <see cref="Location"/> values are not equal;
        ///     otherwise, <c>false</c>
        /// </returns>
        public static bool operator !=(Location locationA, Location locationB) => !locationA.Equals(locationB);

        /// <summary>
        ///     Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="int"/> value that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///     Indicates whether this instance and a specified instance are equal.
        /// </summary>
        /// <param name="obj">
        ///     A <see cref="object"/> to compare with this instance.
        /// </param>
        /// <returns>
        ///     <c>true</c> if both instances are equal; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => base.Equals(obj);

    }
}
