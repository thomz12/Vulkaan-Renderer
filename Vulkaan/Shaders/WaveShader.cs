using System;
using Vulkaan.Math;

namespace Vulkaan.Shaders
{
    public class WaveShader : VShader
    {
        public Matrix4 transformation;
        public float time;

        public override Vector4 VertexStage(Vector4 input)
        {
            input = new Vector4(input.X, input.Y + VMath.Sin(input.X + time), input.Z, input.W);

            return input.Transform(transformation);
        }

        public override VColor FragmentStage()
        {
            throw new NotImplementedException();
        }
    }
}
