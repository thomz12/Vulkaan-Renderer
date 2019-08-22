using System;

namespace Vulkaan
{
    public class VTexture
    {        
        private uint _width;
        private uint _height;
        
        protected byte[] _pixels;

        /// <summary>
        /// Pixel data of this texture.
        /// </summary>
        public byte[] Pixels
        {
            get { return _pixels; }
            private set { _pixels = value; }
        }

        /// <summary>
        /// Width of the texture in pixels.
        /// </summary>
        public uint Width { get => _width; private set => _width = value; }

        /// <summary>
        /// Height of the texture in pixels.
        /// </summary>
        public uint Height { get => _height; private set => _height = value; }

        /// <summary>
        /// Texture constructor.
        /// </summary>
        /// <param name="width">Width of the texture in pixels.</param>
        /// <param name="height">Height of the texture in pixels.</param>
        public VTexture(uint width, uint height)
        {
            // Create an array with all pixels.
            Pixels = new byte[width * height * 4];

            // Set texture width and height.
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Texture constructor.
        /// </summary>
        /// <param name="width">Width of the texture in pixels.</param>
        /// <param name="height">Height of the texture in pixels.</param>
        /// <param name="data">Texture data.</param>
        public VTexture(uint width, uint height, byte[] data)
            : this(width, height)
        {
            // Make sure the data fits in the texture.
            if (data.Length != width * height)
            {
                Console.WriteLine("pixel data doesn't match texture width and height.");
                return;
            }

            // Copy data to this texture.
            Array.Copy(data, Pixels, Pixels.Length);
        }

        /// <summary>
        /// Get or set pixel color.
        /// </summary>
        /// <param name="x">What pixel to get or set.</param>
        /// <returns>The color of the pixel.</returns>
        public VColor this[uint x]
        {
            get
            {
                uint index = x * 4;
                return new VColor
                (
                    _pixels[index + 0],
                    _pixels[index + 1],
                    _pixels[index + 2],
                    _pixels[index + 3]
                );
            }
            internal set
            {
                uint index = x * 4;
                _pixels[index + 0] = value.red;
                _pixels[index + 1] = value.green;
                _pixels[index + 2] = value.blue;
                _pixels[index + 3] = value.alpha;
            }
        }

        /// <summary>
        /// Get or set a pixel color.
        /// </summary>
        /// <param name="x">X position of the pixel.</param>
        /// <param name="y">Y position of the pixel.</param>
        /// <returns>The pixel color, or a all 0 color when out of bounds.</returns>
        public VColor this[uint x, uint y]
        {
            get
            {
                if (x < 0 || x >= _width || y < 0 || y >= _height)
                    return new VColor(0, 0, 0, 0);

                uint index = (x + y * _width) * 4;

                return new VColor
                (
                    _pixels[index + 0],
                    _pixels[index + 1],
                    _pixels[index + 2],
                    _pixels[index + 3]
                );
            }
            internal set
            {
                if (x < 0 || x >= _width || y < 0 || y >= _height)
                    return;

                uint index = (x + y * _width) * 4;

                _pixels[index + 0] = value.red;
                _pixels[index + 1] = value.green;
                _pixels[index + 2] = value.blue;
                _pixels[index + 3] = value.alpha;
            }
        }
    }
}
