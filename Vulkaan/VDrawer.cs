using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vulkaan.Math;

namespace Vulkaan
{
    internal class VDrawer
    {
        private VRenderTarget _target;

        /// <summary>
        /// Drawer constructor.
        /// </summary>
        internal VDrawer()
        {

        }

        /// <summary>
        /// Set the draw target of the drawer.
        /// </summary>
        /// <param name="target"></param>
        internal void SetDrawTarget(VRenderTarget target)
        {
            _target = target;
        }

        /// <summary>
        /// Draw a line to the current target.
        /// </summary>
        /// <param name="p0">Point to draw from, ranging from 0.0 to 1.0 in both axis.</param>
        /// <param name="p1">Point to draw to, ranging from 0.0 to 1.0 in both axis.</param>
        internal void DrawLine(Vector2 p0, Vector2 p1)
        {
            int x0 = (int)(p0.X * _target.Width);
            int y0 = (int)(p0.Y * _target.Height);
            int x1 = (int)(p1.X * _target.Width);
            int y1 = (int)(p1.Y * _target.Height);

            int dx = System.Math.Abs(x1 - x0);
            int dy = System.Math.Abs(y1 - y0);
            int sx = (x0 < x1) ? 1 : -1;
            int sy = (y0 < y1) ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                _target[(uint)x0, (uint)y0] = new VColor(0, 0, 0, 255);

                if ((x0 == x1) && (y0 == y1))
                    break;
                int e2 = 2 * err;
                if (e2 > -dy)
                {
                    err -= dy;
                    x0 += sx;
                }
                if (e2 < dx)
                {
                    err += dx;
                    y0 += sy;
                }
            }
        }

        internal void DrawTriangle()
        {

        }
    }
}
