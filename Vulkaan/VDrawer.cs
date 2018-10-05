using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vulkaan.Math;
using Vulkaan.Shaders;

namespace Vulkaan
{
    internal class VDrawer
    {
        private VRenderTarget _target;

        private VShader _shader;

        /// <summary>
        /// Color of the line to render.
        /// </summary>
        public VColor LineColor { get; set; }

        /// <summary>
        /// Drawer constructor.
        /// </summary>
        internal VDrawer()
        {
            LineColor = new VColor(255, 255, 255, 255);
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
        /// Set a shader for the drawer to use.
        /// </summary>
        /// <param name="shader">The shader to use.</param>
        internal void SetShader(VShader shader)
        {
            _shader = shader;
        }

        /// <summary>
        /// Draw a line to the current target.
        /// </summary>
        /// <param name="p0">Point to draw from, ranging from 0.0 to 1.0 in both axis.</param>
        /// <param name="p1">Point to draw to, ranging from 0.0 to 1.0 in both axis.</param>
        internal void DrawLine(Vector3 p0, Vector3 p1)
        {
            int x0 = (int)(p0.X * _target.Width);
            int y0 = (int)(p0.Y * _target.Height);
            int x1 = (int)(p1.X * _target.Width);
            int y1 = (int)(p1.Y * _target.Height);

            x0 = (int)VMath.Clamp(x0, 0, _target.Width);
            x1 = (int)VMath.Clamp(x1, 0, _target.Width);
            y0 = (int)VMath.Clamp(y0, 0, _target.Height);
            y1 = (int)VMath.Clamp(y1, 0, _target.Height);

            int dx = System.Math.Abs(x1 - x0);
            int dy = System.Math.Abs(y1 - y0);
            int sx = (x0 < x1) ? 1 : -1;
            int sy = (y0 < y1) ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                _target[(uint)x0, (uint)y0] = LineColor;

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

        /// <summary>
        /// Draw a triangle on the screen.
        /// </summary>
        /// <param name="p0">First triangle point (0.0f - 1.0f).</param>
        /// <param name="p1">Second triangle point (0.0f - 1.0f).</param>
        /// <param name="p2">Third triangle point (0.0f - 1.0f).</param>
        internal void DrawTriangle(Vector3 p0, Vector3 p1, Vector3 p2)
        {
            if (p0.Y > p1.Y)
            {
                Vector3 temp = p1;
                p1 = p0;
                p0 = temp;
            }

            if (p1.Y > p2.Y)
            {
                Vector3 temp = p1;
                p1 = p2;
                p2 = temp;
            }

            if (p0.Y > p1.Y)
            {
                Vector3 temp = p1;
                p1 = p0;
                p0 = temp;
            }

            // Calculate the inverse slopes.
            float dSlopeP0P1 = 0;
            float dSlopeP0P2 = 0;

            if (p1.Y - p0.Y > 0)
                dSlopeP0P1 = (p1.X - p0.X) / (p1.Y - p0.Y);
            if (p2.Y - p0.Y > 0)
                dSlopeP0P2 = (p2.X - p0.X) / (p2.Y - p0.Y);

            // Calculate the pixel positions.
            Point2D pp0 = new Point2D((int)(p0.X * _target.Width), (int)(p0.Y * _target.Height));
            Point2D pp1 = new Point2D((int)(p1.X * _target.Width), (int)(p1.Y * _target.Height));
            Point2D pp2 = new Point2D((int)(p2.X * _target.Width), (int)(p2.Y * _target.Height));

            // Clamp inside the render target.
            int yStart = (int)(VMath.Clamp(pp0.Y, 0, _target.Width) + 0.5f);
            int yEnd = (int)(VMath.Clamp(pp2.Y, 0, _target.Width) + 0.5f);

            // Triangle with P2 on the right.
            if (dSlopeP0P1 > dSlopeP0P2)
            {
                for (int y = yStart; y <= yEnd; ++y)
                {
                    if (y < pp1.Y)
                        ScanLine(y, pp0, pp2, pp0, pp1);
                    else
                        ScanLine(y, pp0, pp2, pp1, pp2);
                }
            }
            // Triangle with P2 on the left.
            else
            {
                for (int y = yStart; y <= yEnd; ++y)
                {
                    if (y < pp1.Y)
                        ScanLine(y, pp0, pp1, pp0, pp2);
                    else
                        ScanLine(y, pp1, pp2, pp0, pp2);
                }
            }
        }

        private void ScanLine(int y, Point2D pa, Point2D pb, Point2D pc, Point2D pd)
        {
            float gradient0 = pa.Y != pb.Y ? (float)(y - pa.Y) / (pb.Y - pa.Y) : 1;
            float gradient1 = pc.Y != pd.Y ? (float)(y - pc.Y) / (pd.Y - pc.Y) : 1;

            int xStart = (int)VMath.Interpolate(pa.X, pb.X, gradient0);
            int xEnd = (int)VMath.Interpolate(pc.X, pd.X, gradient1);

            xStart = (int)(VMath.Clamp(xStart, 0, _target.Width) + 0.5f);
            xEnd = (int)(VMath.Clamp(xEnd, 0, _target.Width) + 0.5f);

            for (int x = xStart; x < xEnd; ++x)
            {
                _target[(uint)x, (uint)y] = new VColor(128, 128, 128, 255);
            }
        }
    }
}
