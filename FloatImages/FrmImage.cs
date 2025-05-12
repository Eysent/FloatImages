using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FloatImages
{
    public partial class FrmImage : Form
    {
        private const int WM_MOUSEWHEEL = 0x020A;

        /// <summary>
        /// Main form of application.
        /// </summary>
        FrmPrincipal mainForm;

        /// <summary>
        /// Path of current image.
        /// </summary>
        public string ownPath;
        bool formMove = false;//窗体是否移动
        Point formPoint;//记录窗体的位置
        private Image originalImage; // Store the original image

        public FrmImage()
        {
            InitializeComponent();
        }

        public FrmImage(string path, FrmPrincipal frmPrincipal, Point initialPlace)
        {
            InitializeComponent();
            mainForm = frmPrincipal;

            // Load the original image
            originalImage = Image.FromFile(path);

            // Set the initial image in the PictureBox
            imgContainer.Image = (Image)originalImage.Clone();

            int widthBias = 0, heightBias = 0;
            if (mainForm.ckbForceTitle.Checked)
            {
                this.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                widthBias = 10;
                heightBias = 35;
            }
            imgContainer.Load(path);
            imgContainer.Invalidate();

            Width = imgContainer.PreferredSize.Width + widthBias; //required for form border does not cover a litle image border part.
            Height = imgContainer.PreferredSize.Height + heightBias; //required for form border does not cover a litle image border part.

            Top = initialPlace.X;
            Left = initialPlace.Y;

            imgContainer.Top = 0;
            imgContainer.Left = 0;
            imgContainer.Height += 1;

            ownPath = path;
        }

        private void FrmImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.imgContainer.MouseClick -= this.imgContainer_MouseClick;
            this.FormClosing -= this.FrmImage_FormClosing;
            this.KeyDown -= this.FrmImage_KeyDown;

            if (imgContainer.Image != null)
            {
                imgContainer.Image.Dispose();
                imgContainer.Image = null;
            }

            if (originalImage != null)
            {
                originalImage.Dispose();
                originalImage = null;
            }

            mainForm.imgPath = ownPath;

            imgContainer = null;       

            //update main form label status
            mainForm.lblStatus.Text = string.Format("Openned images: {0}", --mainForm.totalOpenedImages);

            //Remove itself from closing control main form list
            mainForm.frmImagesList.Remove(this);

        }

        private void FrmImage_KeyDown(object sender, KeyEventArgs e)
        {
            //Copy the current image to clipboard
            if (e.KeyCode == Keys.C && e.Control)
                Clipboard.SetImage(imgContainer.Image);
            else
            if (e.KeyCode == Keys.Escape)
                Close();
            else
            if(e.KeyCode == Keys.S && e.Control)
            {
                var dr = svd.ShowDialog();

                if (dr == DialogResult.OK)
                    imgContainer.Image.Save(svd.FileName);
            }
        }

        private void imgContainer_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ctxImgForm.Show(this, e.X, e.Y);
        }

        public void setFormTitle(object sender, EventArgs e)
        {
            //Text = Interaction.InputBox("Type the new form name:", "Set form title", Text, Top, Left);
            Close();
        }
        private void EventMouseDown(object sender, MouseEventArgs e)//鼠标按下
        {
            formPoint = new Point();
            int xOffset;
            int yOffset;
            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X ;
                yOffset = -e.Y;
                formPoint = new Point(xOffset, yOffset);
                formMove = true;//开始移动
            }
        }

        private void EventMouseMove(object sender, MouseEventArgs e)//鼠标移动
        {
            if (formMove == true)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(formPoint.X, formPoint.Y);
                Location = mousePos;
            }
        }

        private void EventMouseUp(object sender, MouseEventArgs e)//鼠标松开
        {
            if (e.Button == MouseButtons.Left)//按下的是鼠标左键
            {
                formMove = false;//停止移动
            }
        }

        protected override void WndProc(ref Message m)
        {
            // Handle mouse wheel event
            if (m.Msg == WM_MOUSEWHEEL)
            {
                // Check if this is the active form and mouse is over this form
                if (Form.ActiveForm == this && this.Bounds.Contains(Cursor.Position))
                {
                    int delta = (short)((m.WParam.ToInt32() >> 16) & 0xFFFF); // Get scroll delta
                    HandleMouseWheel(delta);
                }
            }

            base.WndProc(ref m);
        }

        private void HandleMouseWheel(int delta)
        {
            // Determine initial zoom factor based on scroll direction
            float zoomFactor = delta > 0 ? 1.1f : 0.9f;

            // Calculate new size for the form
            int newWidth = (int)(this.Width * zoomFactor);
            int newHeight = (int)(this.Height * zoomFactor);

            // Get the aspect ratio of the original image
            float imageAspectRatio = (float)originalImage.Width / originalImage.Height;

            // Adjust the zoom factor to ensure no black/white borders
            float containerAspectRatio = (float)newWidth / newHeight;
            if (containerAspectRatio > imageAspectRatio)
            {
                // Container is wider than the image, adjust width
                newWidth = (int)(newHeight * imageAspectRatio);
            }
            else
            {
                // Container is taller than the image, adjust height
                newHeight = (int)(newWidth / imageAspectRatio);
            }

            // Ensure minimum size to avoid disappearing window
            if (newWidth < 100 || newHeight < 100)
                return;

            // Adjust location to keep mouse pointer at the same relative position
            Point mousePos = Cursor.Position;
            int offsetX = mousePos.X - this.Left;
            int offsetY = mousePos.Y - this.Top;

            this.Width = newWidth;
            this.Height = newHeight;

            this.Left = mousePos.X - (int)(offsetX * zoomFactor);
            this.Top = mousePos.Y - (int)(offsetY * zoomFactor);

            // Adjust the image in the PictureBox
            AdjustImageToFit();
        }

        private void AdjustImageToFit()
        {
            if (originalImage == null)
                return;

            // Get the aspect ratio of the original image
            float imageAspectRatio = (float)originalImage.Width / originalImage.Height;
            float containerAspectRatio = (float)this.ClientSize.Width / this.ClientSize.Height;

            // Create a new bitmap to hold the resized image
            Bitmap resizedImage = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);

            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.Clear(Color.Black); // Fill background to avoid white borders

                if (imageAspectRatio > containerAspectRatio)
                {
                    // Image is wider than the container, adjust height
                    int targetHeight = (int)(this.ClientSize.Width / imageAspectRatio);
                    int offsetY = (this.ClientSize.Height - targetHeight) / 2;

                    g.DrawImage(originalImage, 0, offsetY, this.ClientSize.Width, targetHeight);
                }
                else
                {
                    // Image is taller than the container, adjust width
                    int targetWidth = (int)(this.ClientSize.Height * imageAspectRatio);
                    int offsetX = (this.ClientSize.Width - targetWidth) / 2;

                    g.DrawImage(originalImage, offsetX, 0, targetWidth, this.ClientSize.Height);
                }
            }

            // Dispose of the old image in the PictureBox to free memory
            if (imgContainer.Image != null)
            {
                imgContainer.Image.Dispose();
                imgContainer.Image = null;
            }

            // Update the PictureBox with the resized image
            imgContainer.Image = resizedImage;
        }
    }
}
