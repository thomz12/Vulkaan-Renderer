using System;
using Vulkaan;
using Vulkaan.Math;
using Vulkaan.Shaders;

namespace ConsoleExample
{
    class Program
    {
        private static VulkaanDevice _device;

        private static VVertexBuffer _buffer;
        private static float _rotation;

        static void Main(string[] args)
        {
            float[] data = {
                -1.0f, 1.0f, 1.0f, // left upper front
                -1.0f, 1.0f, -1.0f, // left upper back
                1.0f, 1.0f, 1.0f, // right upper front
                1.0f, 1.0f, -1.0f, // right upper back
                -1.0f, -1.0f, 1.0f, // left lower front
                -1.0f, -1.0f, -1.0f, // left lower back
                1.0f, -1.0f, 1.0f, // right lower front
                1.0f, -1.0f, -1.0f // right lower back
            };

            uint[] index = {
                0, 2, 4,
                2, 4, 6,
                1, 3, 5,
                3, 5, 7,
                0, 1, 4,
                1, 4, 5,
                2, 3, 6,
                3, 6, 7,
                0, 1, 2,
                1, 2, 3,
                4, 5, 6,
                5, 6, 7,
            };

            //uint xSize = 10;
            //uint ySize = 10;

            //float[] data = new float[(xSize + 1) * (ySize + 1) * 3];
            //for (int i = 0, y = 0; y <= ySize; y++)
            //{
            //    for (int x = 0; x <= xSize; x++, i += 3)
            //    {
            //        data[i + 0] = x;
            //        data[i + 1] = 0.0f;
            //        data[i + 2] = y;
            //    }
            //}

            //uint[] index = new uint[xSize * ySize * 6];
            //for (uint ti = 0, vi = 0, y = 0; y < ySize; y++, vi++)
            //{
            //    for (uint x = 0; x < xSize; x++, ti += 6, vi++)
            //    {
            //        index[ti] = vi;
            //        index[ti + 3] = index[ti + 2] = vi + 1;
            //        index[ti + 4] = index[ti + 1] = vi + xSize + 1;
            //        index[ti + 5] = vi + xSize + 2;
            //    }
            //}

            _buffer = new VVertexBuffer(data, index);
            _device = new VulkaanDevice((uint)Console.WindowWidth, (uint)Console.WindowHeight);

            int width = Console.WindowWidth;
            char[] buffer = new char[Console.WindowHeight * Console.WindowWidth];

            DefaultShader _shader = new DefaultShader();
            _device.SetShader(_shader);

            _device.RenderModes = RenderModes.WIREFRAME;

            while (true)
            {
                _device.Clear(new VColor(0, 0, 0, 0));

                Matrix4 view = Matrix4.CreateLookAt(new Vector3(3, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
                Matrix4 proj = Matrix4.CreatePerspectiveFieldOfView(VMath.PI / 2, 640.0f / 480.0f, 0.1f, 100.0f);
                _rotation += 0.05f;

                Matrix4 world = Matrix4.CreateRotationY(_rotation);

                _shader.transformation = Matrix4.Multiply(Matrix4.Multiply(world, view), proj);
                //_shader.time = _rotation * 10.0f;
                _device.Draw(_buffer);

                byte[] imageData = _device.Present();

                int stride = Console.WindowWidth * 4;
                int bpp = 4;

                for(int y = 0; y < Console.WindowHeight; ++y)
                {
                    for(int x = 0; x < Console.WindowWidth; ++x)
                    {
                        int imgIndex = x * bpp + y * stride;
                        //VColor col = new VColor(
                        //    imageData[imgIndex + 0],
                        //    imageData[imgIndex + 1],
                        //    imageData[imgIndex + 2],
                        //    imageData[imgIndex + 3]
                        //    );

                        buffer[x + y * Console.WindowWidth] = imageData[imgIndex] > 0 ? '#' : ' ';
                    }
                }

                Console.Clear();

                for (int i = 0; i < Console.WindowHeight; ++i)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write(buffer, i * Console.WindowWidth, Console.WindowWidth);
                }
            }
        }
    }
}
