using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
