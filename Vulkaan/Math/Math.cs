﻿namespace Vulkaan.Math
{
    public static class VMath
    {
        public const float PI = 3.14159265358979f;

        /// <summary>Calculates the square root of a number.</summary>
        /// <param name="value">The value to get the square root from.</param>
        /// <returns>The square root of a given number.</returns>
        public static float Sqrt(float value)
        {
            return (float)System.Math.Sqrt(value);
        }

        /// <summary>
        /// Calculates b to the power p. (b^p)
        /// </summary>
        /// <param name="b">The base.</param>
        /// <param name="p">The power.</param>
        /// <returns></returns>
        public static float Pow(float b, float p)
        {
            return (float)System.Math.Pow(b, p);
        }

        /// <summary>Sin function.</summary>
        /// <param name="value">Value for the sin function.</param>
        /// <returns>A value from the sin function.</returns>
        public static float Sin(float value)
        {
            return (float)System.Math.Sin(value);
        }

        /// <summary>Cos function.</summary>
        /// <param name="value">Value for the cos function.</param>
        /// <returns>A value from the cos function.</returns>
        public static float Cos(float value)
        {
            return (float)System.Math.Cos(value);
        }

        /// <summary>Tan function.</summary>
        /// <param name="value">Value for the tan function.</param>
        /// <returns>A value from the tan function.</returns>
        public static float Tan(float value)
        {
            return (float)System.Math.Tan(value);
        }

        /// <summary>
        /// Round the given value to the nearest integer.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <returns>The rounded value closest to the given value.</returns>
        public static float Round(float value)
        {
            return (float)System.Math.Round(value);
        }

        /// <summary>
        /// Ping pong a value between 0 and length
        /// </summary>
        /// <param name="t"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static float PingPong(float t, float length)
        {
            float l = 2 * length;
            float T = t % l;

            if (0 <= T && T < length)
                return T;
            else
                return l - T;
        }

        /// <summary>
        /// Clamp a value between two values.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimal return value.</param>
        /// <param name="max">The maximum return value.</param>
        /// <returns></returns>
        public static float Clamp(float value, float min, float max)
        {
            return System.Math.Max(min, System.Math.Min(value, max));
        }

        /// <summary>
        /// Interpolate a value.
        /// </summary>
        /// <param name="min">Minimal value.</param>
        /// <param name="max">Maximum value.</param>
        /// <param name="gradient">The gradient, is a percentage between min and max.
        /// 0.0f is equal to min,
        /// 1.0f is equal to max,
        /// 0.5f is in the center of min and max.
        /// </param>
        /// <returns></returns>
        public static float Interpolate(float min, float max, float gradient)
        {
            return min + (max - min) * Clamp(gradient, 0.0f, 1.0f);
        }

        /// <summary>
        /// Wraps a value around some significant range.
        /// Similar to modulo, but works in a unary direction over any range (including negative values).
        /// </summary>
        /// <param name="value">value to wrap</param>
        /// <param name="max">max in range</param>
        /// <param name="min">min in range</param>
        /// <returns>A value wrapped around min to max</returns>
        public static float Wrap(float value, float max, float min = 0)
        {
            value -= min;
            max -= min;
            if (max == 0)
                return min;

            value = value % max;
            value += min;
            while (value < min)
            {
                value += max;
            }

            return value;

        }
    }
}
