using Vulkaan.Math;

namespace Vulkaan.Shaders
{
    /// <summary>
    /// Abstract class containging Shader logic.
    /// </summary>
    public abstract class VShader
    {
        /// <summary>
        /// Calculate the vertex position in screen space.
        /// </summary>
        /// <param name="input">Input vector in object space.</param>
        /// <returns>The final screen space position vector.</returns>
        internal Vector3 CalculateVertex(Vector4 input)
        {
            Vector4 pos = VertexStage(input);
            pos /= -pos.W;

            return new Vector3(
                (pos.X + 1.0f) / 2.0f,
                (pos.Y + 1.0f) / 2.0f,
                (pos.Z + 1.0f) / 2.0f
            );
        }

        /// <summary>
        /// Calculate the color of a give pixel.
        /// </summary>
        /// <returns></returns>
        internal VColor CalculateColor()
        {
            return FragmentStage();
        }

        /// <summary>
        /// The vertex stage of the shader.
        /// </summary>
        /// <param name="input">Untransformed vertex.</param>
        /// <returns>Final transformed vertex in clip space.</returns>
        public abstract Vector4 VertexStage(Vector4 input);

        /// <summary>
        /// The fragment stage of the shader.
        /// </summary>
        /// <returns>The final pixel color.</returns>
        public abstract VColor FragmentStage();
    }
}
