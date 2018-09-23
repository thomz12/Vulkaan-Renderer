using System;

namespace Vulkaan.Math
{
    public struct Vector2 : IEquatable<Vector2>
    {
        /// <summary>The X-Coordinate.</summary>
        public float X;
        /// <summary>The Y-Coordinate.</summary>
        public float Y;

        /// <summary>Constructors 2D vector.</summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        /// <param name="z">The Z coordinate.</param>
        /// <param name="w">The W coordinate.</param>
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>Constructs a 2D vector, all values equal to the given value.</summary>
        /// <param name="value">The value for all axis.</param>
        public Vector2(float value)
        {
            X = value;
            Y = value;
        }

        /// <summary>Constructs a 2D vector, taking the X and Y component of a 3 component vector.</summary>
        /// <param name="value">The <see cref="Vector3"/> to use.</param>
        public Vector2(Vector3 value)
        {
            X = value.X;
            Y = value.Y;
        }

        /// <summary>Two dimensional up vector. (0, 1)</summary>
        public static readonly Vector2 Up = new Vector2(0.0f, 1.0f);
        /// <summary>Two dimensional down vector. (0, -1)</summary>
        public static readonly Vector2 Down = new Vector2(0.0f, 1.0f);
        /// <summary>Two dimensional right vector. (1, 0)</summary>
        public static readonly Vector2 Right = new Vector2(1.0f, 0.0f);
        /// <summary>Two dimensional left vector. (-1, 0)</summary>
        public static readonly Vector2 Left = new Vector2(-1.0f, 0.0f);

        /// <summary>Returns the distance between two vectors.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The distance between two vectors.</returns>
        public static float Distance(Vector2 value1, Vector2 value2)
        {
            return VMath.Sqrt(DistanceSquared(value1, value2));
        }

        /// <summary>Returns the squared distance between two vectors.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The squared distance between two vectors.</returns>
        public static float DistanceSquared(Vector2 value1, Vector2 value2)
        {
            return  (value1.X - value2.X) * (value1.X - value2.X) +
                    (value1.Y - value2.Y) * (value1.Y - value2.Y);
        }

        /// <summary>Returns the length of this vector.</summary>
        /// <returns>The length.</returns>
        public float Length()
        {
            return VMath.Sqrt((X * X) + (Y * Y));
        }

        /// <summary>Returns the squared length of this vector.</summary>
        /// <returns>The squared length.</returns>
        public float LengthSquared()
        {
            return (X * X) + (Y * Y);
        }

        /// <summary>Makes this vector a normalized one.</summary>
        public void Normalize()
        {
            float factor = VMath.Sqrt((X * X) + (Y * Y));
            factor = 1.0f / factor;
            X *= factor;
            Y *= factor;
        }

        /// <summary>Normalizes the given vector.</summary>
        /// <param name="vector">The vector to normalize.</param>
        /// <returns>A normalized vector.</returns>
        public static Vector2 Normalize(Vector2 vector)
        {
            vector.Normalize();
            return vector;
        }

        /// <summary>Calculates the dot product.</summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <returns>The dot product of two vectors.</returns>
        public static float Dot(Vector2 vector1, Vector2 vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y;
        }

        /// <summary>Gives a string representing the vector.</summary>
        /// <returns>String representation of this vector.</returns>
        public override string ToString()
        {
            return $"Vector2({X}, {Y})";
        }

        /// <summary>Check if the vector is equal to an other vector.</summary>
        /// <param name="other">The vector to check against.</param>
        /// <returns>False if not equal, true if the vectors are equal.</returns>
        public bool Equals(Vector2 other)
        {
            return X == other.X
                && Y == other.Y;
        }

        /// <summary>Check if the vector is equal to the other object.</summary>
        /// <param name="o">The object to check against.</param>
        /// <returns>False if not equal, true if the vectors are equal.</returns>
        public override bool Equals(object o)
        {
            if (o is Vector2)
                return Equals((Vector2)o);
            return false;
        }

        /// <summary>Gets the hash code of this vector.</summary>
        /// <returns>Hash code of this vector.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>Inverts the vector values.</summary>
        /// <param name="value">The vector to invert.</param>
        /// <returns>Inverted vector.</returns>
        public static Vector2 operator -(Vector2 value)
        {
            return new Vector2(-value.X, -value.Y);
        }

        /// <summary>Checks if two vectors are equal.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>If the two vectors are equal true, otherwise false.</returns>
        public static bool operator ==(Vector2 value1, Vector2 value2)
        {
            return value1.X == value2.X
                && value1.Y == value2.Y;
        }

        /// <summary>Checks if the two vectors are not equal</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>If the two vectors are not equal true, otherwise false.</returns>
        public static bool operator !=(Vector2 value1, Vector2 value2)
        {
            return value1.X != value2.X
                && value1.Y != value2.Y;
        }

        /// <summary>Adds two vectors.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The sum of the two vectors.</returns>
        public static Vector2 operator +(Vector2 value1, Vector2 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            return value1;
        }

        /// <summary>Subtracts two vectors.</summary>
        /// <param name="value1">The first vector, on the left side.</param>
        /// <param name="value2">The second vector, on the right side.</param>
        /// <returns>The result of the substraction between the two vectors.</returns>
        public static Vector2 operator -(Vector2 value1, Vector2 value2)
        {
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            return value1;
        }

        /// <summary>Multiplies two vectors.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The multiplication between the given vectors.</returns>
        public static Vector2 operator *(Vector2 value1, Vector2 value2)
        {
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            return value1;
        }

        /// <summary>Multiplies a vector by a scalar.</summary>
        /// <param name="value1">The vector.</param>
        /// <param name="scalar">The scaler value.</param>
        /// <returns>The multiplication between the vector and scalar.</returns>
        public static Vector2 operator *(Vector2 value1, float scalar)
        {
            value1.X *= scalar;
            value1.Y *= scalar;
            return value1;
        }

        /// <summary>Multiplies a vector by a scalar.</summary>
        /// <param name="scalar">The scaler value.</param>
        /// <param name="value1">The vector.</param>
        /// <returns>The multiplication between the vector and scalar.</returns>
        public static Vector2 operator *(float scalar, Vector2 value1)
        {
            value1.X *= scalar;
            value1.Y *= scalar;
            return value1;
        }

        /// <summary>Divide two vectors.</summary>
        /// <param name="value1">The first vector, on the left side.</param>
        /// <param name="value2">The first vector, on the right side.</param>
        /// <returns>The devision between two vectors.</returns>
        public static Vector2 operator /(Vector2 value1, Vector2 value2)
        {
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            return value1;
        }

        /// <summary>Divide a vector by a scalar.</summary>
        /// <param name="value1">The vector, on the left side.</param>
        /// <param name="divider">The value to divide by.</param>
        /// <returns>The devision the vector and the scalar.</returns>
        public static Vector2 operator /(Vector2 value1, float divider)
        {
            value1.X /= divider;
            value1.Y /= divider;
            return value1;
        }
    }
}
