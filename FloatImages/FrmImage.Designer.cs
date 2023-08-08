﻿namespace FloatImages
{
    partial class FrmImage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImage));
            this.imgContainer = new System.Windows.Forms.PictureBox();
            this.ctxImgForm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setFormTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.svd = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.imgContainer)).BeginInit();
            this.ctxImgForm.SuspendLayout();
            this.SuspendLayout();
            this.TopMost = true;
            // 
            // imgContainer
            // 
            this.imgContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgContainer.Location = new System.Drawing.Point(0, 0);
            this.imgContainer.Name = "imgContainer";
            this.imgContainer.Size = new System.Drawing.Size(333, 320);
            this.imgContainer.TabIndex = 0;
            this.imgContainer.TabStop = false;
            this.imgContainer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imgContainer_MouseClick);
            // 
            // ctxImgForm
            // 
            this.ctxImgForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setFormTitleToolStripMenuItem});
            this.ctxImgForm.Name = "ctxImgForm";
            this.ctxImgForm.Size = new System.Drawing.Size(152, 26);
            // 
            // setFormTitleToolStripMenuItem
            // 
            this.setFormTitleToolStripMenuItem.Name = "setFormTitleToolStripMenuItem";
            this.setFormTitleToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.setFormTitleToolStripMenuItem.Text = "Close";
            this.setFormTitleToolStripMenuItem.Click += new System.EventHandler(this.setFormTitle);
            // 
            // svd
            // 
            this.svd.DefaultExt = "bmp";
            this.svd.Filter = "bmp images|*.bmp";
            this.svd.Title = "Save current image.";
            // 
            // FrmImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 321);
            this.Controls.Add(this.imgContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmImage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmImage_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmImage_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.imgContainer)).EndInit();
            this.ctxImgForm.ResumeLayout(false);
            this.ResumeLayout(false);

            this.imgContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EventMouseDown);
            this.imgContainer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EventMouseMove);
            this.imgContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EventMouseUp);


        }

        #endregion

        private System.Windows.Forms.PictureBox imgContainer;
        private System.Windows.Forms.ContextMenuStrip ctxImgForm;
        private System.Windows.Forms.ToolStripMenuItem setFormTitleToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog svd;
    }
}