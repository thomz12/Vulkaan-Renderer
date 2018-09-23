using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vulkaan
{
    public class VVertexBuffer
    {
        public float[] Data { get; private set; }

        public uint[] Index { get; private set; }

        /// <summary>
        /// VertexBuffer Constructor.
        /// </summary>
        /// <param name="data">Vertex data.</param>
        public VVertexBuffer(float[] data)
        {
            Data = data;
        }

        public VVertexBuffer(float[] data, uint[] index)
            : this(data)
        {
            Index = index;
        }
    }
}
