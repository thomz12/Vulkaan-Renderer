namespace Example
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pb_screen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_screen)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_screen
            // 
            this.pb_screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_screen.Location = new System.Drawing.Point(0, 0);
            this.pb_screen.Name = "pb_screen";
            this.pb_screen.Size = new System.Drawing.Size(680, 440);
            this.pb_screen.TabIndex = 0;
            this.pb_screen.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 440);
            this.Controls.Add(this.pb_screen);
            this.Name = "Main";
            this.Text = "Vulkaan Renderer";
            ((System.ComponentModel.ISupportInitialize)(this.pb_screen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_screen;
    }
}

