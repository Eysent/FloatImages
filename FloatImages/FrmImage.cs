﻿using System;
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
        public FrmImage()
        {
            InitializeComponent();
        }

        public FrmImage(string path, FrmPrincipal frmPrincipal, Point initialPlace)
        {
            int widthBias = 0, heightBias = 0;
            InitializeComponent();
            mainForm = frmPrincipal;
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

    }
}
