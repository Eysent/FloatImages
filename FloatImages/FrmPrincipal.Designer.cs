using System;
using System.Drawing;
using System.Windows.Forms;

namespace FloatImages
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.lblStatus = new System.Windows.Forms.Label();
            this.ntfIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ckbShowImagesTaskbar = new System.Windows.Forms.CheckBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnCloseAllImages = new System.Windows.Forms.Button();
            this.ckbForceTitle = new System.Windows.Forms.CheckBox();
            this.cmIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(75, 18);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(154, 19);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Openned images: 0";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.TextChanged += new System.EventHandler(this.lblStatus_TextChanged);
            // 
            // ntfIcon
            // 
            this.ntfIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ntfIcon.ContextMenuStrip = this.cmIcon;
            this.ntfIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfIcon.Icon")));
            this.ntfIcon.Text = "Float Images";
            this.ntfIcon.Visible = true;
            this.ntfIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ntfIcon_MouseDoubleClick);
            // 
            // cmIcon
            // 
            this.cmIcon.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsExit});
            this.cmIcon.Name = "cmMain";
            this.cmIcon.Size = new System.Drawing.Size(105, 28);
            this.cmIcon.Text = "Menu";
            // 
            // tsExit
            // 
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(104, 24);
            this.tsExit.Text = "Exit";
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // ckbShowImagesTaskbar
            // 
            this.ckbShowImagesTaskbar.AutoSize = true;
            this.ckbShowImagesTaskbar.Checked = true;
            this.ckbShowImagesTaskbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbShowImagesTaskbar.Location = new System.Drawing.Point(16, 58);
            this.ckbShowImagesTaskbar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckbShowImagesTaskbar.Name = "ckbShowImagesTaskbar";
            this.ckbShowImagesTaskbar.Size = new System.Drawing.Size(245, 19);
            this.ckbShowImagesTaskbar.TabIndex = 1;
            this.ckbShowImagesTaskbar.Text = "Show image icons on taskbar";
            this.ckbShowImagesTaskbar.UseVisualStyleBackColor = true;
            this.ckbShowImagesTaskbar.CheckedChanged += new System.EventHandler(this.ckbShowImagesTaskbar_CheckedChanged);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(11, 2);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 15);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Visible = false;
            // 
            // btnCloseAllImages
            // 
            this.btnCloseAllImages.Location = new System.Drawing.Point(37, 110);
            this.btnCloseAllImages.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCloseAllImages.Name = "btnCloseAllImages";
            this.btnCloseAllImages.Size = new System.Drawing.Size(224, 27);
            this.btnCloseAllImages.TabIndex = 3;
            this.btnCloseAllImages.Text = "Close all images";
            this.btnCloseAllImages.UseVisualStyleBackColor = true;
            this.btnCloseAllImages.Click += new System.EventHandler(this.CloseAllImages);
            // 
            // ckbForceTitle
            // 
            this.ckbForceTitle.AutoSize = true;
            this.ckbForceTitle.Checked = true;
            this.ckbForceTitle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbForceTitle.Location = new System.Drawing.Point(16, 85);
            this.ckbForceTitle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckbForceTitle.Name = "ckbForceTitle";
            this.ckbForceTitle.Size = new System.Drawing.Size(117, 19);
            this.ckbForceTitle.TabIndex = 4;
            this.ckbForceTitle.Text = "Image title";
            this.ckbForceTitle.UseVisualStyleBackColor = true;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 160);
            this.Controls.Add(this.ckbForceTitle);
            this.Controls.Add(this.btnCloseAllImages);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.ckbShowImagesTaskbar);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Float Images";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.Resize += new System.EventHandler(this.FrmPrincipal_Resize);
            this.cmIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        public System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.NotifyIcon ntfIcon;
        private System.Windows.Forms.CheckBox ckbShowImagesTaskbar;
        public System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnCloseAllImages;
        private System.Windows.Forms.ContextMenuStrip cmIcon;
        private System.Windows.Forms.ToolStripMenuItem tsExit;
        public System.Windows.Forms.CheckBox ckbForceTitle;
    }
}

