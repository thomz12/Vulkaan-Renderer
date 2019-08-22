using System.Threading.Tasks;

namespace Vulkaan
{
    public class VDepthBuffer : VTexture
    {
        private float[] _depthData;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="width">Width of the depth buffer.</param>
        /// <param name="height">Height of the depth buffer.</param>
        public VDepthBuffer(uint width, uint height) 
            : base(width, height)
        {
            _depthData = new float[width * height];
        }

        /// <summary>
        /// Clear the depth buffer to a given value.
        /// </summary>
        /// <param name="value">The value to set the entire depth buffer to.</param>
        public void Clear(float value)
        {
            int lenght = _depthData.Length;

            Parallel.For(0, lenght, i =>
            {
                _depthData[i] = value;
            });
        }
    }
}
