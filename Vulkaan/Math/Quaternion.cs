using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vulkaan.Math
{
    public struct Quaternion
    {
        /// <summary>
        /// The x coordinate.
        /// </summary>
        public float X;

        /// <summary>
        /// The y coordinate.
        /// </summary>
        public float Y;

        /// <summary>
        /// The z coordinate.
        /// </summary>
        public float Z;

        /// <summary>
        /// The rotation component.
        /// </summary>
        public float W;

        /// <summary>
        /// Constructs a quaternion with X, Y, Z and W from four values.
        /// </summary>
        /// <param name="x">The x coordinate in 3d-space.</param>
        /// <param name="y">The y coordinate in 3d-space.</param>
        /// <param name="z">The z coordinate in 3d-space.</param>
        /// <param name="w">The rotation component.</param>
        public Quaternion(float x, float y, float z, float w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        /// <summary>
        /// Constructs a quaternion with X, Y, Z from <see cref="Vector3"/> and rotation component from a scalar.
        /// </summary>
        /// <param name="value">The x, y, z coordinates in 3d-space.</param>
        /// <param name="w">The rotation component.</param>
        public Quaternion(Vector3 value, float w)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = value.Z;
            this.W = w;
        }

        /// <summary>
        /// Constructs a quaternion from <see cref="Vector4"/>.
        /// </summary>
        /// <param name="value">The x, y, z coordinates in 3d-space and the rotation component.</param>
        public Quaternion(Vector4 value)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = value.Z;
            this.W = value.W;
        }

        /// <summary>
        /// Creates a new Quaternion from the specified yaw, pitch and roll angles.
        /// </summary>
        /// <param name="yaw">Yaw around the y axis in radians.</param>
        /// <param name="pitch">Pitch around the x axis in radians.</param>
        /// <param name="roll">Roll around the z axis in radians.</param>
        /// <returns>A new quaternion from the concatenated yaw, pitch, and roll angles.</returns>
        public static Quaternion CreateFromYawPitchRoll(float yaw, float pitch, float roll)
        {
            float halfRoll = roll * 0.5f;
            float halfPitch = pitch * 0.5f;
            float halfYaw = yaw * 0.5f;

            float sinRoll = VMath.Sin(halfRoll);
            float cosRoll = VMath.Cos(halfRoll);
            float sinPitch = VMath.Sin(halfPitch);
            float cosPitch = VMath.Cos(halfPitch);
            float sinYaw = VMath.Sin(halfYaw);
            float cosYaw = VMath.Cos(halfYaw);

            return new Quaternion((cosYaw * sinPitch * cosRoll) + (sinYaw * cosPitch * sinRoll),
                                  (sinYaw * cosPitch * cosRoll) - (cosYaw * sinPitch * sinRoll),
                                  (cosYaw * cosPitch * sinRoll) - (sinYaw * sinPitch * cosRoll),
                                  (cosYaw * cosPitch * cosRoll) + (sinYaw * sinPitch * sinRoll));
        }
    }
}
