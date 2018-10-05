using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vulkaan
{
    public class VRenderTarget : VTexture
    {
        public VRenderTarget(uint width, uint height) 
            : base(width, height)
        {

        }

        /// <summary>
        /// Clear the render target to a specified color.
        /// </summary>
        /// <param name="color">The color to clear to.</param>
        internal void Clear(VColor color)
        {
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
