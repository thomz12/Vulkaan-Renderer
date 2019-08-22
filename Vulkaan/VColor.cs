namespace Vulkaan
{
    /// <summary>
    /// Representing a 32 bit color.
    /// </summary>
    public struct VColor
    {
        /// <summary>
        /// Red value of the color.
        /// </summary>
        public byte red;

        /// <summary>
        /// Green value of the color.
        /// </summary>
        public byte green;

        /// <summary>
        /// Blue value of the color.
        /// </summary>
        public byte blue;

        /// <summary>
        /// Alpha value of the color.
        /// </summary>
        public byte alpha;

        /// <summary>
        /// Color constructor.
        /// </summary>
        /// <param name="r">Red value (0-255).</param>
        /// <param name="g">Green value (0-255).</param>
        /// <param name="b">Blue value (0-255).</param>
        /// <param name="a">Alpha value (0-255).</param>
        public VColor(byte r, byte g, byte b, byte a)
        {
            red = r;
            green = g;
            blue = b;
            alpha = a;
        }
    }
}
