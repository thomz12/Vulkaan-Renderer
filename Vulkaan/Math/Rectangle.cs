using System;

namespace Vulkaan.Math
{
    public struct Rectangle : IEquatable<Rectangle>
    {
        /// <summary>
        /// X position of the rectangle.
        /// </summary>
        public int X;

        /// <summary>
        /// Y position of the rectangle.
        /// </summary>
        public int Y;

        /// <summary>
        /// Width of the rectangle.
        /// </summary>
        public int Width;

        /// <summary>
        /// Height of the rectangle.
        /// </summary>
        public int Height;

        /// <summary>
        /// Rectangle Constructor.
        /// </summary>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Check if a object is equal to rectangle.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <returns>True if equal, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            return obj is Rectangle && Equals((Rectangle)obj);
        }

        /// <summary>
        /// Check if a rectangle is equal this rectangle.
        /// </summary>
        /// <param name="obj">The rectangle to check.</param>
        /// <returns>True if equal, false otherwise.</returns>
        public bool Equals(Rectangle other)
        {
            return X == other.X &&
                   Y == other.Y &&
                   Width == other.Width &&
                   Height == other.Height;
        }

        /// <summary>
        /// Check if two rectangles are the same.
        /// </summary>
        /// <param name="rectangle1">First rectangle.</param>
        /// <param name="rectangle2">Second rectangle.</param>
        /// <returns>True if equal, false otherwise.</returns>
        public static bool operator ==(Rectangle rectangle1, Rectangle rectangle2) => rectangle1.Equals(rectangle2);

        /// <summary>
        /// Check if two rectangles are not the same.
        /// </summary>
        /// <param name="rectangle1">First rectangle.</param>
        /// <param name="rectangle2">Second rectangle.</param>
        /// <returns>True if not equal, false otherwise.</returns>
        public static bool operator !=(Rectangle rectangle1, Rectangle rectangle2) => !rectangle1.Equals(rectangle2);
    }
}
