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
            int length = _pixels.Length;

            for(uint i = 0; i < length; i += 4)
            {
                _pixels[i + 0] = color.red;
                _pixels[i + 1] = color.green;
                _pixels[i + 2] = color.blue;
                _pixels[i + 3] = color.alpha;
            }
        }
    }
}
