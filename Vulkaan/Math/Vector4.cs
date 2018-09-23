using System;

namespace Vulkaan.Math
{
    public struct Vector4 : IEquatable<Vector4>
    {
        /// <summary>The X-Coordinate.</summary>
        public float X;
        /// <summary>The Y-Coordinate.</summary>
        public float Y;
        /// <summary>The Z-Coordinate.</summary>
        public float Z;
        /// <summary>The W-Coordinate.</summary>
        public float W;

        /// <summary>Constructors 4D vector.</summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        /// <param name="z">The Z coordinate.</param>
        /// <param name="w">The W coordinate.</param>
        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>Constructs a 4D vector, all values equal to the given value.</summary>
        /// <param name="value">The value for all axis.</param>
        public Vector4(float value)
        {
            X = value;
            Y = value;
            Z = value;
            W = value;
        }

        /// <summary>Returns the distance between two vectors.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The distance between two vectors.</returns>
        public static float Distance(Vector4 value1, Vector4 value2)
        {
            return VMath.Sqrt(DistanceSquared(value1, value2));
        }

        /// <summary>Returns the squared distance between two vectors.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The squared distance between two vectors.</returns>
        public static float DistanceSquared(Vector4 value1, Vector4 value2)
        {
            return (value1.W - value2.W) * (value1.W - value2.W) +
                     (value1.X - value2.X) * (value1.X - value2.X) +
                     (value1.Y - value2.Y) * (value1.Y - value2.Y) +
                     (value1.Z - value2.Z) * (value1.Z - value2.Z);
        }

        /// <summary>Returns the length of this vector.</summary>
        /// <returns>The length.</returns>
        public float Length()
        {
            return VMath.Sqrt((X * X) + (Y * Y) + (Z * Z) + (W * W));
        }

        /// <summary>Returns the squared length of this vector.</summary>
        /// <returns>The squared length.</returns>
        public float LengthSquared()
        {
            return (X * X) + (Y * Y) + (Z * Z) + (W * W);
        }

        public Vector4 Transform(Matrix4 matrix)
        {
            float x = (X * matrix.M11) + (Y * matrix.M21) + (Z * matrix.M31) + (W * matrix.M41);
            float y = (X * matrix.M12) + (Y * matrix.M22) + (Z * matrix.M32) + (W * matrix.M42);
            float z = (X * matrix.M13) + (Y * matrix.M23) + (Z * matrix.M33) + (W * matrix.M43);
            float w = (X * matrix.M14) + (Y * matrix.M24) + (Z * matrix.M34) + (W * matrix.M44);
            return new Vector4(x, y, z, w);
        }

        /// <summary>Makes this vector a normalized one.</summary>
        public void Normalize()
        {
            float factor = VMath.Sqrt((X * X) + (Y * Y) + (Z * Z) + (W * W));
            factor = 1.0f / factor;
            X *= factor;
            Y *= factor;
            Z *= factor;
            W *= factor;
        }

        /// <summary>Normalizes the given vector.</summary>
        /// <param name="vector">The vector to normalize.</param>
        /// <returns>A normalized vector.</returns>
        public static Vector4 Normalize(Vector4 vector)
        {
            vector.Normalize();
            return vector;
        }

        /// <summary>Calculates the dot product.</summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <returns>The dot product of two vectors.</returns>
        public static float Dot(Vector4 vector1, Vector4 vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z + vector1.W * vector2.W;
        }

        /// <summary>Gives a string representing the vector.</summary>
        /// <returns>String representation of this vector.</returns>
        public override string ToString()
        {
            return $"Vector4({X}, {Y}, {Z}, {W})";
        }

        /// <summary>Check if the vector is equal to an other vector.</summary>
        /// <param name="other">The vector to check against.</param>
        /// <returns>False if not equal, true if the vectors are equal.</returns>
        public bool Equals(Vector4 other)
        {
            return X == other.X
                && Y == other.Y
                && Z == other.Z
                && W == other.W;
        }

        /// <summary>Check if the vector is equal to the other object.</summary>
        /// <param name="o">The object to check against.</param>
        /// <returns>False if not equal, true if the vectors are equal.</returns>
        public override bool Equals(object o)
        {
            if (o is Vector4)
                return Equals((Vector4)o);
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
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                hashCode = (hashCode * 397) ^ W.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>Inverts the vector values.</summary>
        /// <param name="value">The vector to invert.</param>
        /// <returns>Inverted vector.</returns>
        public static Vector4 operator -(Vector4 value)
        {
            return new Vector4(-value.X, -value.Y, -value.Z, -value.W);
        }

        /// <summary>Checks if two vectors are equal.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>If the two vectors are equal true, otherwise false.</returns>
        public static bool operator ==(Vector4 value1, Vector4 value2)
        {
            return value1.X == value2.X
                && value1.Y == value2.Y
                && value1.Z == value2.Z
                && value1.W == value2.W;
        }

        /// <summary>Checks if the two vectors are not equal</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>If the two vectors are not equal true, otherwise false.</returns>
        public static bool operator !=(Vector4 value1, Vector4 value2)
        {
            return value1.X != value2.X
                && value1.Y != value2.Y
                && value1.Z != value2.Z
                && value1.W != value2.W;
        }

        /// <summary>Adds two vectors.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The sum of the two vectors.</returns>
        public static Vector4 operator +(Vector4 value1, Vector4 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            value1.Z += value2.Z;
            value1.W += value2.W;
            return value1;
        }

        /// <summary>Subtracts two vectors.</summary>
        /// <param name="value1">The first vector, on the left side.</param>
        /// <param name="value2">The second vector, on the right side.</param>
        /// <returns>The result of the substraction between the two vectors.</returns>
        public static Vector4 operator -(Vector4 value1, Vector4 value2)
        {
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            value1.Z -= value2.Z;
            value1.W -= value2.W;
            return value1;
        }

        /// <summary>Multiplies two vectors.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The multiplication between the given vectors.</returns>
        public static Vector4 operator *(Vector4 value1, Vector4 value2)
        {
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            value1.Z *= value2.Z;
            value1.W *= value2.W;
            return value1;
        }

        /// <summary>Multiplies a vector by a scalar.</summary>
        /// <param name="value1">The vector.</param>
        /// <param name="scalar">The scaler value.</param>
        /// <returns>The multiplication between the vector and scalar.</returns>
        public static Vector4 operator *(Vector4 value1, float scalar)
        {
            value1.X *= scalar;
            value1.Y *= scalar;
            value1.Z *= scalar;
            value1.W *= scalar;
            return value1;
        }

        /// <summary>Multiplies a vector by a scalar.</summary>
        /// <param name="scalar">The scaler value.</param>
        /// <param name="value1">The vector.</param>
        /// <returns>The multiplication between the vector and scalar.</returns>
        public static Vector4 operator *(float scalar, Vector4 value1)
        {
            value1.X *= scalar;
            value1.Y *= scalar;
            value1.Z *= scalar;
            value1.W *= scalar;
            return value1;
        }

        /// <summary>Divide two vectors.</summary>
        /// <param name="value1">The first vector, on the left side.</param>
        /// <param name="value2">The first vector, on the right side.</param>
        /// <returns>The devision between two vectors.</returns>
        public static Vector4 operator /(Vector4 value1, Vector4 value2)
        {
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            value1.Z /= value2.Z;
            value1.W /= value2.W;
            return value1;  
        }

        /// <summary>Divide a vector by a scalar.</summary>
        /// <param name="value1">The vector, on the left side.</param>
        /// <param name="divider">The value to divide by.</param>
        /// <returns>The devision the vector and the scalar.</returns>
        public static Vector4 operator /(Vector4 value1, float divider)
        {
            value1.X /= divider;
            value1.Y /= divider;
            value1.Z /= divider;
            value1.W /= divider;
            return value1;
        }
    }
}
