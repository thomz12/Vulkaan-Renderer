using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vulkaan.Math;

namespace Vulkaan
{
    public sealed class VulkaanDevice
    {
        /// <summary>
        /// Front buffer containing the most recent drawn image.
        /// </summary>
        private VRenderTarget _frontBuffer;

        /// <summary>
        /// Back buffer to draw to.
        /// </summary>
        private VRenderTarget _backBuffer;

        /// <summary>
        /// The current render target.
        /// </summary>
        private VRenderTarget _renderTarget;

        private VDrawer _drawer;

        /// <summary>
        /// Vulkaan constructor.
        /// </summary>
        public VulkaanDevice()
        {
            // Create a default sized backbuffer.
            _backBuffer = new VRenderTarget(640, 480);
            _frontBuffer = new VRenderTarget(640, 480);

            // Set backbuffer as default render target.
            _renderTarget = _backBuffer;

            _drawer = new VDrawer();

            // Set the default render target.
            SetRenderTarget(null);
        }

        /// <summary>
        /// Once rendering is ready, show it to the front buffer.
        /// Swaps the front and back buffer.
        /// </summary>
        public byte[] Present()
        {
            // Swap the front and back buffer.
            VRenderTarget temp = _backBuffer;
            _backBuffer = _frontBuffer;
            _frontBuffer = temp;

            // If the backbuffer was the render target, switch it too.
            if (_renderTarget == _frontBuffer)
                SetRenderTarget(null);

            // Return the pixels of the front buffer.
            return _frontBuffer.Pixels;
        }

        /// <summary>
        /// Draw a given buffer.
        /// </summary>
        /// <param name="buffer">The buffer to draw.</param>
        public void Draw(VVertexBuffer buffer, Matrix4 transformation)
        {
            if (buffer.Index == null)
            {
                // Draw non-indexed.
            }
            else
            {
                for (int i = 0; i < buffer.Index.Length; i += 3)
                {
                    // Draw indexed.
                    Vector4 pos0 = new Vector4(
                        buffer.Data[buffer.Index[i + 0] * 3 + 0],
                        buffer.Data[buffer.Index[i + 0] * 3 + 1],
                        buffer.Data[buffer.Index[i + 0] * 3 + 2],
                        1.0f);

                    Vector4 pos1 = new Vector4(
                        buffer.Data[buffer.Index[i + 1] * 3 + 0],
                        buffer.Data[buffer.Index[i + 1] * 3 + 1],
                        buffer.Data[buffer.Index[i + 1] * 3 + 2],
                        1.0f);

                    Vector4 pos2 = new Vector4(
                        buffer.Data[buffer.Index[i + 2] * 3 + 0],
                        buffer.Data[buffer.Index[i + 2] * 3 + 1],
                        buffer.Data[buffer.Index[i + 2] * 3 + 2],
                        1.0f);

                    pos0 = pos0.Transform(transformation);
                    pos1 = pos1.Transform(transformation);
                    pos2 = pos2.Transform(transformation);

                    // Perspective division.
                    pos0 /= -pos0.W;
                    pos1 /= -pos1.W;
                    pos2 /= -pos2.W;

                    Vector3 triangle0 = new Vector3((pos0.X + 1.0f) / 2.0f, (pos0.Y + 1.0f) / 2.0f, pos0.Z);
                    Vector3 triangle1 = new Vector3((pos1.X + 1.0f) / 2.0f, (pos1.Y + 1.0f) / 2.0f, pos1.Z);
                    Vector3 triangle2 = new Vector3((pos2.X + 1.0f) / 2.0f, (pos2.Y + 1.0f) / 2.0f, pos2.Z);

                    _drawer.DrawLine(
                        new Vector2(triangle0.X, triangle0.Y),
                        new Vector2(triangle1.X, triangle1.Y));

                    _drawer.DrawLine(
                        new Vector2(triangle1.X, triangle1.Y),
                        new Vector2(triangle2.X, triangle2.Y));

                    _drawer.DrawLine(
                        new Vector2(triangle2.X, triangle2.Y),
                        new Vector2(triangle0.X, triangle0.Y));
                }
            }
        }

        /// <summary>
        /// Clear the current target.
        /// </summary>
        /// <param name="color">The color to clear to.</param>
        public void Clear(VColor color)
        {
            _renderTarget.Clear(color);
        }

        /// <summary>
        /// Set a render target.
        /// </summary>
        /// <param name="target">The target to render to, null to draw to the back buffer.</param>
        public void SetRenderTarget(VRenderTarget target)
        {
            if (target == null)
                _renderTarget = _backBuffer;
            else
                _renderTarget = target;

            _drawer.SetDrawTarget(_renderTarget);
        }
    }
}
