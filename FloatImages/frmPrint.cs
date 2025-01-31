﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace FloatImages
{
    public partial class FrmPrint : Form
    {
        Rectangle mRect;
        Point init;
        FrmPrincipal ownPrincipal;

        public bool EscPressed = false;

        public FrmPrint(FrmPrincipal frmPrincipal)
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            ownPrincipal = frmPrincipal;
        }


        private void frmPrint_Load(object sender, EventArgs e)
        {
            
            Width = Screen.AllScreens.Sum(screen => screen.WorkingArea.Width) + 200;
            Height = Screen.AllScreens.Sum(screen => screen.WorkingArea.Height) + 200;
            Top = Screen.AllScreens.Min(screen => screen.WorkingArea.Top);
            Left = Screen.AllScreens.Min(screen => screen.WorkingArea.Left);
            BackColor = Color.White;
            TransparencyKey = Color.Blue;
            FormBorderStyle = FormBorderStyle.None;
            Opacity = .30;

            WindowState = FormWindowState.Maximized;
            Bounds = Screen.PrimaryScreen.Bounds;
        }

        private void frmPrint_Paint(object sender, PaintEventArgs e)
        {
            //Draw a rectangle with 2pixel wide line
            using (Pen pen = new Pen(Color.Red, 2))
            {
                e.Graphics.DrawRectangle(pen, mRect);
            }   
        }

        private void frmPrint_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                
                Point mousePos = Control.MousePosition;
                var width = mousePos.X - init.X;
                var height = mousePos.Y - init.Y;
                mRect = new Rectangle(width >= 0 ? init.X : mousePos.X, height >= 0 ? init.Y : mousePos.Y, Math.Abs(width), Math.Abs(height));

                Invalidate();
            }
        }

        private void frmPrint_MouseDown(object sender, MouseEventArgs e)
        {
            mRect = new Rectangle(e.X, e.Y, 0, 0);

            init.X = Cursor.Position.X;
            init.Y = Cursor.Position.Y;

            this.Invalidate();            
        }

        private void frmPrint_MouseUp(object sender, MouseEventArgs e)
        {
            ownPrincipal.pointTarget = new Point(e.X, e.Y);
            Close();
        }

        private void frmPrint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                EscPressed = true;
                ownPrincipal.imgPath = string.Empty;
                Close();
            }   
        }

        private void frmPrint_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mRect.Width != 0 && mRect.Height != 0)
            {
                ownPrincipal.rectImage = mRect;
                ownPrincipal.pointSource = init;                
            }
            else
            {
                ownPrincipal.rectImage = null;
                ownPrincipal.pointSource = null;
                ownPrincipal.pointTarget     = null;
            }
           
        }


    }    
}
