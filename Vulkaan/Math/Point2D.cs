namespace Vulkaan.Math
{
    /// <summary>
    /// Structure representing a 2 Dimensional point in space.
    /// </summary>
    public struct Point2D
    {
        /// <summary>
        /// X value.
        /// </summary>
        public int X;

        /// <summary>
        /// Y value.
        /// </summary>
        public int Y;

        public Point2D(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
