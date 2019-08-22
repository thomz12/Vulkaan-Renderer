using System;
using Vulkaan.Math;

namespace Vulkaan.Shaders
{
    public class DefaultShader : VShader
    {
        public Matrix4 transformation;

        public override Vector4 VertexStage(Vector4 input)
        {
            return input.Transform(transformation);
        }

        public override VColor FragmentStage()
        {
            throw new NotImplementedException();
        }
    }
}
