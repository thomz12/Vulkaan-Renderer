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

namespace Example
{
    public partial class Main : Form
    {
        private VulkaanDevice _device;
        private Bitmap _bitmap;

        private float rotation = 0.0f;

        VVertexBuffer _buffer;

        public Main()
        {
            InitializeComponent();
            Application.Idle += Application_Idle;

            // Create Vulkaan device.
            _device = new VulkaanDevice();
            _bitmap = new Bitmap(pb_screen.Width, pb_screen.Height);

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

            _buffer = new VVertexBuffer(data, index);
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
            _device.Clear(new VColor(255, 255, 255, 255));

            Matrix4 view = Matrix4.CreateLookAt(new Vector3(-2 + rotation, 3, -2 + rotation * 0.5f), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            Matrix4 proj = Matrix4.CreatePerspectiveFieldOfView(VMath.PI / 2, 640.0f / 480.0f, 0.1f, 100.0f);
            rotation += 0.01f;

            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < 2; ++j)
                {
                    Matrix4 world = Matrix4.CreateTranslation(new Vector3(i * 2, 0, j * 2));
                    _device.Draw(_buffer, Matrix4.Multiply(Matrix4.Multiply(world, view), proj));
                }
            }

            UpdatePictureBox();
        }

        private void UpdatePictureBox()
        {
            byte[] image = _device.Present();

            BitmapData data = _bitmap.LockBits(new System.Drawing.Rectangle(0, 0, _bitmap.Width, _bitmap.Height), ImageLockMode.WriteOnly, _bitmap.PixelFormat);
            IntPtr ptr = data.Scan0;
            System.Runtime.InteropServices.Marshal.Copy(image, 0, ptr, image.Length);
            _bitmap.UnlockBits(data);

            pb_screen.Image = _bitmap;
        }
    }
}
