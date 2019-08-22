using System.Threading.Tasks;

namespace Vulkaan
{
    public class VRenderTarget : VTexture
    {
        private bool _useDepth;

        /// <summary>
        /// When true, a depth buffer is created for this render target.
        /// </summary>
        public bool HasDepthBuffer
        {
            get { return _useDepth; }
            set
            {
                // Only call UpdateDepthBuffer when the bool value changes.
                if (_useDepth != value)
                {
                    _useDepth = value;
                    UpdateDepthBuffer();
                }
            }
        }

        /// <summary>
        /// Depth buffer this Render Target uses when <see cref="HasDepthBuffer"/> is true.
        /// </summary>
        public VDepthBuffer DepthBuffer { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="width">Width of the render target.</param>
        /// <param name="height">Height of the render target.</param>
        public VRenderTarget(uint width, uint height, bool useDepth = true) 
            : base(width, height)
        {
            HasDepthBuffer = useDepth;
        }

        /// <summary>
        /// Update the depth buffer.
        /// </summary>
        public void UpdateDepthBuffer()
        {
            if (_useDepth)
                DepthBuffer = new VDepthBuffer(Width, Height);
            else
                DepthBuffer = null;
        }

        /// <summary>
        /// Clear the render target to a specified color.
        /// </summary>
        /// <param name="color">The color to clear to.</param>
        internal void Clear(VColor color)
        {
            DepthBuffer.Clear(float.PositiveInfinity);

            int lenght = _pixels.Length / 4;

            Parallel.For(0, lenght, i =>
            {
                _pixels[(i * 4) + 0] = color.red;
                _pixels[(i * 4) + 1] = color.green;
                _pixels[(i * 4) + 2] = color.blue;
                _pixels[(i * 4) + 3] = color.alpha;
            });
        }
    }
}
