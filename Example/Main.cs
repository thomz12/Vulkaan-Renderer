using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vulkaan;
using Vulkaan.Math;
using Vulkaan.Shaders;

namespace Example
{
    public partial class Main : Form
    {
        private VulkaanDevice _device;
        private VShader _shader;
        private Bitmap _bitmap;

        private int _x;
        private int _y;

        private float rotation = 0.0f;

        private Vector3 _cameraRot;

        VVertexBuffer _buffer;

        public Main()
        {
            InitializeComponent();
            Application.Idle += Application_Idle;

            // Create Vulkaan device.
            _device = new VulkaanDevice((uint)pb_screen.Width, (uint)pb_screen.Height);
            _bitmap = new Bitmap(pb_screen.Width, pb_screen.Height);

            //float[] data = {
            //    -1.0f, 1.0f, 1.0f, // left upper front
            //    -1.0f, 1.0f, -1.0f, // left upper back
            //    1.0f, 1.0f, 1.0f, // right upper front
            //    1.0f, 1.0f, -1.0f, // right upper back
            //    -1.0f, -1.0f, 1.0f, // left lower front
            //    -1.0f, -1.0f, -1.0f, // left lower back
            //    1.0f, -1.0f, 1.0f, // right lower front
            //    1.0f, -1.0f, -1.0f // right lower back
            //};

            //uint[] index = {
            //    0, 2, 4,
            //    2, 4, 6,
            //    1, 3, 5,
            //    3, 5, 7,
            //    0, 1, 4,
            //    1, 4, 5,
            //    2, 3, 6,
            //    3, 6, 7,
            //    0, 1, 2,
            //    1, 2, 3,
            //    4, 5, 6,
            //    5, 6, 7,
            //};

            uint xSize = 32;
            uint ySize = 32;

             // _device.RenderModes = RenderModes.SOLID;
            _device.RenderModes = RenderModes.WIREFRAME;

            float[] data = new float[(xSize + 1) * (ySize + 1) * 3];
            for (int i = 0, y = 0; y <= ySize; y++)
            {
                for (int x = 0; x <= xSize; x++, i+=3)
                {
                    data[i + 0] = x;
                    data[i + 1] = 0.0f;
                    data[i + 2] = y;
                }
            }

            uint[] index = new uint[xSize * ySize * 6];
            for (uint ti = 0, vi = 0, y = 0; y < ySize; y++, vi++)
            {
                for (uint x = 0; x < xSize; x++, ti += 6, vi++)
                {
                    index[ti] = vi;
                    index[ti + 3] = index[ti + 2] = vi + 1;
                    index[ti + 4] = index[ti + 1] = vi + xSize + 1;
                    index[ti + 5] = vi + xSize + 2;
                }
            }

            VDepthBuffer depthBuffer = new VDepthBuffer(640, 480);

            _buffer = new VVertexBuffer(data, index);
            _shader = new WaveShader();

            pb_screen.Image = _bitmap;
            pb_screen.Resize += Pb_screen_Resize;
            pb_screen.MouseMove += Pb_screen_MouseMove;
        }

        private void Pb_screen_MouseMove(object sender, MouseEventArgs e)
        {
            int deltaX = e.X - _x;
            int deltaY = _y - e.Y;
            _x = e.X;
            _y = e.Y;

            _cameraRot = new Vector3(_cameraRot.X + deltaY * 0.1f, _cameraRot.Y + deltaX * 0.1f, _cameraRot.Z);
        }

        private void Pb_screen_Resize(object sender, EventArgs e)
        {
            _device.Resize((uint)pb_screen.Width, (uint)pb_screen.Height);
            _bitmap = new Bitmap(pb_screen.Width, pb_screen.Height);
            pb_screen.Image = _bitmap;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            Render();
        }

        /// <summary>
        /// Render graphics.
        /// </summary>
        public void Render()
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            _device.Clear(new VColor(0, 0, 0, 255));

            // Create view and projection matrices.
            Matrix4 view = Matrix4.CreateLookAt(new Vector3(-2f, 3f, -2f), new Vector3(5, 0, 5), new Vector3(0, 1, 0));
            Matrix4 proj = Matrix4.CreatePerspectiveFieldOfView(VMath.PI / 2, pb_screen.Width / (float)pb_screen.Height, 0.1f, 100.0f);

            rotation += 0.01f;

            _device.SetShader(_shader);

            for (int i = 0; i < 1; ++i)
            {
                for (int j = 0; j < 1; ++j)
                {
                    // Calculate world matrix.
                    Matrix4 world = Matrix4.CreateTranslation(new Vector3(i * 2, 0, j * 2));

                    // Set shader values.
                    (_shader as WaveShader).transformation = Matrix4.Multiply(Matrix4.Multiply(world, view), proj);
                    (_shader as WaveShader).time = rotation * 2.0f;

                    // Draw.
                    _device.Draw(_buffer);
                }
            }

            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks + " (" + watch.ElapsedMilliseconds + "ms)");

            UpdatePictureBox();
        }

        private void UpdatePictureBox()
        {
            byte[] image = _device.Present();

            BitmapData data = _bitmap.LockBits(new System.Drawing.Rectangle(0, 0, _bitmap.Width, _bitmap.Height), ImageLockMode.WriteOnly, _bitmap.PixelFormat);
            IntPtr ptr = data.Scan0;
            System.Runtime.InteropServices.Marshal.Copy(image, 0, ptr, image.Length);
            _bitmap.UnlockBits(data);

            pb_screen.Invalidate();
        }
    }
}
