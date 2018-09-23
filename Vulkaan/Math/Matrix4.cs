using System;
using System.Text;

namespace Vulkaan.Math
{
    /// <summary>
    /// Matrix class representing a 4x4 matrix. Mostly from MonoGame.
    /// </summary>
    public struct Matrix4
    {
        /// <summary>First row and first column value.</summary>
        public float M11;
        /// <summary>First row and second column value.</summary>
        public float M12;
        /// <summary>First row and third column value.</summary>
        public float M13;
        /// <summary>First row and fouth column value.</summary>
        public float M14;
        /// <summary>Second row and first column value.</summary>
        public float M21;
        /// <summary>Second row and second column value.</summary>
        public float M22;
        /// <summary>Second row and third column value.</summary>
        public float M23;
        /// <summary>Second row and fouth column value.</summary>
        public float M24;
        /// <summary>Third row and first column value.</summary>
        public float M31;
        /// <summary>Third row and second column value.</summary>
        public float M32;
        /// <summary>Third row and third column value.</summary>
        public float M33;
        /// <summary>Third row and fouth column value.</summary>
        public float M34;
        /// <summary>Fourth row and first column value.</summary>
        public float M41;
        /// <summary>Fourth row and second column value.</summary>
        public float M42;
        /// <summary>Fourth row and third column value.</summary>
        public float M43;
        /// <summary>Fourth row and fouth column value.</summary>
        public float M44;

        /// <summary>
        /// An Identity matrix.
        /// </summary>
        public static Matrix4 Identity = new Matrix4(1.0f, 0.0f, 0.0f, 0.0f,
                                                      0.0f, 1.0f, 0.0f, 0.0f,
                                                      0.0f, 0.0f, 1.0f, 0.0f,
                                                      0.0f, 0.0f, 0.0f, 1.0f);

        /// <summary>Constructs a matrix with a diagonal with the given value.</summary>
        /// <param name="value">The value for the diagonal in the matrix.</param>
        public Matrix4(float value)
        {
            M11 = value; M12 = 0.0f; M13 = 0.0f; M14 = 0.0f;
            M21 = 0.0f; M22 = value; M23 = 0.0f; M24 = 0.0f;
            M31 = 0.0f; M32 = 0.0f; M33 = value; M34 = 0.0f;
            M41 = 0.0f; M42 = 0.0f; M43 = 0.0f; M44 = value;
        }

        /// <summary>Constructs a matrix with the given values.</summary>
        /// <param name="m11">First row and first column value.</param>
        /// <param name="m12">First row and second column value.</param>
        /// <param name="m13">First row and third column value.</param>
        /// <param name="m14">First row and fourth column value.</param>
        /// <param name="m21">Second row and first column value.</param>
        /// <param name="m22">Second row and second column value.</param>
        /// <param name="m23">Second row and third column value.</param>
        /// <param name="m24">Second row and fourth column value.</param>
        /// <param name="m31">Third row and first column value.</param>
        /// <param name="m32">Third row and second column value.</param>
        /// <param name="m33">Third row and third column value.</param>
        /// <param name="m34">Third row and fourth column value.</param>
        /// <param name="m41">Fourth row and first column value.</param>
        /// <param name="m42">Fourth row and second column value.</param>
        /// <param name="m43">Fourth row and third column value.</param>
        /// <param name="m44">Fourth row and fourth column value.</param>
        public Matrix4(float m11, float m12, float m13, float m14,
                        float m21, float m22, float m23, float m24,
                        float m31, float m32, float m33, float m34,
                        float m41, float m42, float m43, float m44)
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M14 = m14;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M24 = m24;
            M31 = m31;
            M32 = m32;
            M33 = m33;
            M34 = m34;
            M41 = m41;
            M42 = m42;
            M43 = m43;
            M44 = m44;
        }

        /// <summary>
        /// Transpose the given matrix.
        /// </summary>
        /// <param name="matrix">The matrix to transpose.</param>
        /// <returns>A matrix tranposed to the given matrix.</returns>
        public static Matrix4 Transpose(Matrix4 matrix)
        {
            Matrix4 mat = new Matrix4();

            mat.M11 = matrix.M11;
            mat.M12 = matrix.M21;
            mat.M13 = matrix.M31;
            mat.M14 = matrix.M41;

            mat.M21 = matrix.M12;
            mat.M22 = matrix.M22;
            mat.M23 = matrix.M32;
            mat.M24 = matrix.M42;

            mat.M31 = matrix.M13;
            mat.M32 = matrix.M23;
            mat.M33 = matrix.M33;
            mat.M34 = matrix.M43;

            mat.M41 = matrix.M14;
            mat.M42 = matrix.M24;
            mat.M43 = matrix.M34;
            mat.M44 = matrix.M44;

            return mat;
        }

        /// <summary>
        /// Add to matrixes to each other.
        /// </summary>
        /// <param name="matrix1">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <returns>A matrix containing the sum of the given matrixes.</returns>
        public static Matrix4 Add(Matrix4 matrix1, Matrix4 matrix2)
        {
            matrix1.M11 += matrix2.M11;
            matrix1.M12 += matrix2.M12;
            matrix1.M13 += matrix2.M13;
            matrix1.M14 += matrix2.M14;
            matrix1.M21 += matrix2.M21;
            matrix1.M22 += matrix2.M22;
            matrix1.M23 += matrix2.M23;
            matrix1.M24 += matrix2.M24;
            matrix1.M31 += matrix2.M31;
            matrix1.M32 += matrix2.M32;
            matrix1.M33 += matrix2.M33;
            matrix1.M34 += matrix2.M34;
            matrix1.M41 += matrix2.M41;
            matrix1.M42 += matrix2.M42;
            matrix1.M43 += matrix2.M43;
            matrix1.M44 += matrix2.M44;
            return matrix1;
        }

        /// <summary>
        /// Multiply two matrices.
        /// </summary>
        /// <param name="matrix1">The first matrix, on the right side of the operation.</param>
        /// <param name="matrix2">The second matrix, on the left side of the operation.</param>
        /// <returns></returns>
        public static Matrix4 Multiply(Matrix4 matrix1, Matrix4 matrix2)
        {
            float m11 = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
            float m12 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
            float m13 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
            float m14 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
            float m21 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
            float m22 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
            float m23 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
            float m24 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
            float m31 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
            float m32 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
            float m33 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
            float m34 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
            float m41 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
            float m42 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
            float m43 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
            float m44 = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
            matrix1.M11 = m11;
            matrix1.M12 = m12;
            matrix1.M13 = m13;
            matrix1.M14 = m14;
            matrix1.M21 = m21;
            matrix1.M22 = m22;
            matrix1.M23 = m23;
            matrix1.M24 = m24;
            matrix1.M31 = m31;
            matrix1.M32 = m32;
            matrix1.M33 = m33;
            matrix1.M34 = m34;
            matrix1.M41 = m41;
            matrix1.M42 = m42;
            matrix1.M43 = m43;
            matrix1.M44 = m44;
            return matrix1;
        }

        /// <summary>Create a matrix which contains the rotation moment around a given axis.</summary>
        /// <param name="axis">The axis of rotation.</param>
        /// <param name="angle">The angle of rotation.</param>
        /// <returns>The rotaion matrix.</returns>
        public static Matrix4 CreateFromAxisAngle(Vector3 axis, float angle)
        {
            Matrix4 result;

            float x = axis.X;
            float y = axis.Y;
            float z = axis.Z;
            float num2 = VMath.Sin(angle);
            float num = VMath.Cos(angle);
            float num11 = x * x;
            float num10 = y * y;
            float num9 = z * z;
            float num8 = x * y;
            float num7 = x * z;
            float num6 = y * z;

            result.M11 = num11 + (num * (1f - num11));
            result.M12 = (num8 - (num * num8)) + (num2 * z);
            result.M13 = (num7 - (num * num7)) - (num2 * y);
            result.M14 = 0;
            result.M21 = (num8 - (num * num8)) - (num2 * z);
            result.M22 = num10 + (num * (1f - num10));
            result.M23 = (num6 - (num * num6)) + (num2 * x);
            result.M24 = 0;
            result.M31 = (num7 - (num * num7)) + (num2 * y);
            result.M32 = (num6 - (num * num6)) - (num2 * x);
            result.M33 = num9 + (num * (1f - num9));
            result.M34 = 0;
            result.M41 = 0;
            result.M42 = 0;
            result.M43 = 0;
            result.M44 = 1;

            return result;
        }

        /// <summary>Create a view-matrix.</summary>
        /// <param name="cameraPosition">Position of the camera in world space.</param>
        /// <param name="cameraTarget">Lookup vector of the camera.</param>
        /// <param name="cameraUpVector">Direction of the upper edge of the camera.</param>
        /// <returns></returns>
        public static Matrix4 CreateLookAt(Vector3 cameraPosition, Vector3 cameraTarget, Vector3 cameraUpVector)
        {
            Matrix4 matrix = new Matrix4();

            Vector3 vector = Vector3.Normalize(cameraPosition - cameraTarget);
            Vector3 vector2 = Vector3.Normalize(Vector3.Cross(cameraUpVector, vector));
            Vector3 vector3 = Vector3.Cross(vector, vector2);

            matrix.M11 = vector2.X;
            matrix.M12 = vector3.X;
            matrix.M13 = vector.X;
            matrix.M14 = 0f;
            matrix.M21 = vector2.Y;
            matrix.M22 = vector3.Y;
            matrix.M23 = vector.Y;
            matrix.M24 = 0f;
            matrix.M31 = vector2.Z;
            matrix.M32 = vector3.Z;
            matrix.M33 = vector.Z;
            matrix.M34 = 0f;
            matrix.M41 = -Vector3.Dot(vector2, cameraPosition);
            matrix.M42 = -Vector3.Dot(vector3, cameraPosition);
            matrix.M43 = -Vector3.Dot(vector, cameraPosition);
            matrix.M44 = 1f;

            return matrix;
        }

        /// <summary>
        /// Create an orthographic projection matrix.
        /// </summary>
        /// <param name="width">Width of viewing volume.</param>
        /// <param name="height">Height of viewing volume.</param>
        /// <param name="zNearPlane">Near clipping plane.</param>
        /// <param name="zFarPlane">Far clipping plane.</param>
        /// <returns>An orthographic projection matrix.</returns>
        public static Matrix4 CreateOrthographic(float width, float height, float zNearPlane, float zFarPlane)
        {
            Matrix4 matrix = new Matrix4();

            matrix.M11 = 2f / width;
            matrix.M12 = matrix.M13 = matrix.M14 = 0f;
            matrix.M22 = 2f / height;
            matrix.M21 = matrix.M23 = matrix.M24 = 0f;
            matrix.M33 = 1f / (zNearPlane - zFarPlane);
            matrix.M31 = matrix.M32 = matrix.M34 = 0f;
            matrix.M41 = matrix.M42 = 0f;
            matrix.M43 = zNearPlane / (zNearPlane - zFarPlane);
            matrix.M44 = 1f;

            return matrix;
        }

        /// <summary>Create a perspective projection matrix.</summary>
        /// <param name="fieldOfView">The field of view of the perspective projection matrix (in radians).</param>
        /// <param name="aspectRatio">The aspect ratio.</param>
        /// <param name="nearPlaneDistance">The near clipping plane.</param>
        /// <param name="farPlaneDistance">The far clipping plane.</param>
        /// <returns>A perspective projection matrix.</returns>
        public static Matrix4 CreatePerspectiveFieldOfView(float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance)
        {
            Matrix4 matrix = new Matrix4();

            float num = 1f / (VMath.Tan((fieldOfView * 0.5f)));
            float num9 = num / aspectRatio;

            matrix.M11 = num9;
            matrix.M12 = matrix.M13 = matrix.M14 = 0;
            matrix.M22 = num;
            matrix.M21 = matrix.M23 = matrix.M24 = 0;
            matrix.M31 = matrix.M32 = 0f;
            matrix.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            matrix.M34 = -1.0f;
            matrix.M41 = matrix.M42 = matrix.M44 = 0;
            matrix.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);

            return matrix;
        }

        /// <summary>Create rotation on the X-Axis.</summary>
        /// <param name="radians">Angle in radians.</param>
        /// <returns>The rotation matrix.</returns>
        public static Matrix4 CreateRotationX(float radians)
        {
            Matrix4 result = new Matrix4(1.0f);

            float val1 = VMath.Cos(radians);
            float val2 = VMath.Sin(radians);

            result.M22 = val1;
            result.M23 = val2;
            result.M32 = -val2;
            result.M33 = val1;

            return result;
        }

        /// <summary>Create rotation on the Y-Axis.</summary>
        /// <param name="radians">Angle in radians.</param>
        /// <returns>The rotation matrix.</returns>
        public static Matrix4 CreateRotationY(float radians)
        {
            Matrix4 result = new Matrix4(1.0f);

            float val1 = VMath.Cos(radians);
            float val2 = VMath.Sin(radians);

            result.M11 = val1;
            result.M13 = -val2;
            result.M31 = val2;
            result.M33 = val1;

            return result;
        }

        /// <summary>Create rotation on the Z-Axis.</summary>
        /// <param name="radians">Angle in radians.</param>
        /// <returns>The rotation matrix.</returns>
        public static Matrix4 CreateRotationZ(float radians)
        {
            Matrix4 result = new Matrix4(1.0f);

            float val1 = VMath.Cos(radians);
            float val2 = VMath.Sin(radians);

            result.M11 = val1;
            result.M12 = val2;
            result.M21 = -val2;
            result.M22 = val1;

            return result;
        }

        /// <summary>Creates a new rotation Matrix from the specified yaw, pitch and roll values.</summary>
        /// <param name="yaw">The yaw rotation value in radians.</param>
        /// <param name="pitch">The pitch rotation value in radians.</param>
        /// <param name="roll">The roll rotation value in radians.</param>
		public static Matrix4 CreateFromYawPitchRoll(float yaw, float pitch, float roll)
        {
            Quaternion quaternion = Quaternion.CreateFromYawPitchRoll(yaw, pitch, roll);
            return CreateFromQuaternion(quaternion);
        }

        /// <summary>Creates a new rotation matrix from a Quaternion.</summary>
        /// <param name="quaternion">Quaternion of rotation moment.</param>
        public static Matrix4 CreateFromQuaternion(Quaternion quaternion)
        {
            Matrix4 result;
            float num9 = quaternion.X * quaternion.X;
            float num8 = quaternion.Y * quaternion.Y;
            float num7 = quaternion.Z * quaternion.Z;
            float num6 = quaternion.X * quaternion.Y;
            float num5 = quaternion.Z * quaternion.W;
            float num4 = quaternion.Z * quaternion.X;
            float num3 = quaternion.Y * quaternion.W;
            float num2 = quaternion.Y * quaternion.Z;
            float num = quaternion.X * quaternion.W;
            result.M11 = 1f - (2f * (num8 + num7));
            result.M12 = 2f * (num6 + num5);
            result.M13 = 2f * (num4 - num3);
            result.M14 = 0f;
            result.M21 = 2f * (num6 - num5);
            result.M22 = 1f - (2f * (num7 + num9));
            result.M23 = 2f * (num2 + num);
            result.M24 = 0f;
            result.M31 = 2f * (num4 + num3);
            result.M32 = 2f * (num2 - num);
            result.M33 = 1f - (2f * (num8 + num9));
            result.M34 = 0f;
            result.M41 = 0f;
            result.M42 = 0f;
            result.M43 = 0f;
            result.M44 = 1f;
            return result;
        }

        /// <summary>Create a scaling matrix.</summary>
        /// <param name="scale">The scale on the x, y and z axis.</param>
        /// <returns>A scaling matrix.</returns>
        public static Matrix4 CreateScale(Vector3 scale)
        {
            Matrix4 result = new Matrix4();
            result.M11 = scale.X;
            result.M12 = 0;
            result.M13 = 0;
            result.M14 = 0;
            result.M21 = 0;
            result.M22 = scale.Y;
            result.M23 = 0;
            result.M24 = 0;
            result.M31 = 0;
            result.M32 = 0;
            result.M33 = scale.Z;
            result.M34 = 0;
            result.M41 = 0;
            result.M42 = 0;
            result.M43 = 0;
            result.M44 = 1;
            return result;
        }

        /// <summary>Create a translation matrix.</summary>
        /// <param name="translation">Translation.</param>
        /// <returns></returns>
        public static Matrix4 CreateTranslation(Vector3 translation)
        {
            Matrix4 result = new Matrix4(1.0f);
            result.M41 = translation.X;
            result.M42 = translation.Y;
            result.M43 = translation.Z;
            return result;
        }

        /// <summary>Read and write the data inside the matrix. Stored row-major.</summary>
        /// <param name="index">A value ranging [0, 15] (inclusive).</param>
        /// <returns>The value stored in the matrix.</returns>
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return M11;
                    case 1: return M12;
                    case 2: return M13;
                    case 3: return M14;
                    case 4: return M21;
                    case 5: return M22;
                    case 6: return M23;
                    case 7: return M24;
                    case 8: return M31;
                    case 9: return M32;
                    case 10: return M33;
                    case 11: return M34;
                    case 12: return M41;
                    case 13: return M42;
                    case 14: return M43;
                    case 15: return M44;
                }
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                switch (index)
                {
                    case 0: M11 = value; break;
                    case 1: M12 = value; break;
                    case 2: M13 = value; break;
                    case 3: M14 = value; break;
                    case 4: M21 = value; break;
                    case 5: M22 = value; break;
                    case 6: M23 = value; break;
                    case 7: M24 = value; break;
                    case 8: M31 = value; break;
                    case 9: M32 = value; break;
                    case 10: M33 = value; break;
                    case 11: M34 = value; break;
                    case 12: M41 = value; break;
                    case 13: M42 = value; break;
                    case 14: M43 = value; break;
                    case 15: M44 = value; break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>Read and write the data inside the matrix. Stored row-major.</summary>
        /// <param name="row">The row to get ranging [0, 4] (inclusive)</param>
        /// <param name="column">The column to get ranging [0, 4] (inclusive)</param>
        /// <returns></returns>
        public float this[int row, int column]
        {
            get
            {
                return this[(row * 4) + column];
            }

            set
            {
                this[(row * 4) + column] = value;
            }
        }

        /// <summary>Creates a string representing the matrix.</summary>
        /// <returns>A string representing the matrix.</returns>
        public override string ToString()
        {
            StringBuilder retval = new StringBuilder();
            retval.Append("{ ");
            for (int i = 0; i < 15; ++i)
            {
                retval.Append(this[i].ToString() + ", ");
            }
            retval.Append(this[15] + " }");
            return retval.ToString();
        }
    }
}
