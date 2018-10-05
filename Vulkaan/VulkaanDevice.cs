using System.Threading.Tasks;
using Vulkaan.Math;
using Vulkaan.Shaders;

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

        /// <summary>
        /// The class responsible for drawing.
        /// </summary>
        private VDrawer _drawer;

        /// <summary>
        /// The current shader to use.
        /// </summary>
        private VShader _curShader;

        /// <summary>
        /// The rendering modes.
        /// </summary>
        public RenderModes RenderModes { get; set; }

        /// <summary>
        /// Vulkaan constructor.
        /// </summary>
        public VulkaanDevice(uint width, uint height)
        {
            // Create a default sized backbuffer.
            _backBuffer = new VRenderTarget(width, height);
            _frontBuffer = new VRenderTarget(width, height);

            // Set default drawer.
            _drawer = new VDrawer();

            // Set backbuffer as default render target.
            SetRenderTarget(null);

            // Set default shader.
            _curShader = new DefaultShader();

            RenderModes = RenderModes.SOLID;
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
                SetRenderTarget(_backBuffer);

            // Return the pixels of the front buffer.
            return _frontBuffer.Pixels;
        }

        /// <summary>
        /// Draw a given buffer.
        /// </summary>
        /// <param name="buffer">The buffer to draw.</param>
        public void Draw(VVertexBuffer buffer)
        {
            // Draw non-indexed.
            if (buffer.Index == null)
            {
                // TODO: non-indexed rendering.
            }
            // Draw indexed.
            else
            {
                Parallel.For(0, buffer.Index.Length / 3, i =>
                {
                    Vector4 pos0 = new Vector4(
                        buffer.Data[buffer.Index[i * 3 + 0] * 3 + 0],
                        buffer.Data[buffer.Index[i * 3 + 0] * 3 + 1],
                        buffer.Data[buffer.Index[i * 3 + 0] * 3 + 2],
                        1.0f);

                    Vector4 pos1 = new Vector4(
                        buffer.Data[buffer.Index[i * 3 + 1] * 3 + 0],
                        buffer.Data[buffer.Index[i * 3 + 1] * 3 + 1],
                        buffer.Data[buffer.Index[i * 3 + 1] * 3 + 2],
                        1.0f);

                    Vector4 pos2 = new Vector4(
                        buffer.Data[buffer.Index[i * 3 + 2] * 3 + 0],
                        buffer.Data[buffer.Index[i * 3 + 2] * 3 + 1],
                        buffer.Data[buffer.Index[i * 3 + 2] * 3 + 2],
                        1.0f);

                    // Calculate triangle positions.
                    Vector3 triangle0 = _curShader.CalculateVertex(pos0);
                    Vector3 triangle1 = _curShader.CalculateVertex(pos1);
                    Vector3 triangle2 = _curShader.CalculateVertex(pos2);

                    // Draw the triangle.
                    if (RenderModes.HasFlag(RenderModes.SOLID))
                    {
                        _drawer.DrawTriangle(triangle0, triangle1, triangle2);
                    }
                    // Draw the wireframe.
                    if (RenderModes.HasFlag(RenderModes.WIREFRAME))
                    {
                        _drawer.DrawLine(triangle0, triangle1);
                        _drawer.DrawLine(triangle1, triangle2);
                        _drawer.DrawLine(triangle2, triangle0);
                    }
                });
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
        /// Resize the front and back buffers.
        /// </summary>
        /// <param name="width">Width to resize to.</param>
        /// <param name="height">Height to resize to.</param>
        public void Resize(uint width, uint height)
        {
            _backBuffer = new VRenderTarget(width, height);
            _frontBuffer = new VRenderTarget(width, height);

            _renderTarget = _backBuffer;
        }

        /// <summary>
        /// Set the shader to use for next draw.
        /// </summary>
        /// <param name="shader">The shader to use.</param>
        public void SetShader(VShader shader)
        {
            _curShader = shader;
            _drawer.SetShader(shader);
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
