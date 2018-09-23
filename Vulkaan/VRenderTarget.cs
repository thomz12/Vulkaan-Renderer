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
            int length = Pixels.Length / 4;

            // Clear all pixels.
            for (uint i = 0; i < length; ++i)
                this[i] = color;
        }
    }
}
