
namespace CameraInterfacing
{
    partial class Form1
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
            this.Pb_Picture = new System.Windows.Forms.PictureBox();
            this.Bt_StartCamera = new System.Windows.Forms.Button();
            this.Bt_Capture = new System.Windows.Forms.Button();
            this.Cb_VideoInput = new System.Windows.Forms.ComboBox();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            ((System.ComponentModel.ISupportInitialize)(this.Pb_Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // Pb_Picture
            // 
            this.Pb_Picture.Location = new System.Drawing.Point(533, 34);
            this.Pb_Picture.Name = "Pb_Picture";
            this.Pb_Picture.Size = new System.Drawing.Size(517, 453);
            this.Pb_Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pb_Picture.TabIndex = 1;
            this.Pb_Picture.TabStop = false;
            // 
            // Bt_StartCamera
            // 
            this.Bt_StartCamera.Location = new System.Drawing.Point(151, 520);
            this.Bt_StartCamera.Name = "Bt_StartCamera";
            this.Bt_StartCamera.Size = new System.Drawing.Size(216, 62);
            this.Bt_StartCamera.TabIndex = 2;
            this.Bt_StartCamera.Text = "Start Camera";
            this.Bt_StartCamera.UseVisualStyleBackColor = true;
            this.Bt_StartCamera.Click += new System.EventHandler(this.Bt_StartCamera_Click);
            // 
            // Bt_Capture
            // 
            this.Bt_Capture.Location = new System.Drawing.Point(687, 520);
            this.Bt_Capture.Name = "Bt_Capture";
            this.Bt_Capture.Size = new System.Drawing.Size(216, 62);
            this.Bt_Capture.TabIndex = 3;
            this.Bt_Capture.Text = "Capture";
            this.Bt_Capture.UseVisualStyleBackColor = true;
            this.Bt_Capture.Click += new System.EventHandler(this.Bt_Capture_Click);
            // 
            // Cb_VideoInput
            // 
            this.Cb_VideoInput.FormattingEnabled = true;
            this.Cb_VideoInput.Location = new System.Drawing.Point(1077, 34);
            this.Cb_VideoInput.Name = "Cb_VideoInput";
            this.Cb_VideoInput.Size = new System.Drawing.Size(253, 24);
            this.Cb_VideoInput.TabIndex = 4;
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Location = new System.Drawing.Point(22, 34);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(450, 453);
            this.videoSourcePlayer1.TabIndex = 5;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            this.videoSourcePlayer1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.VideoSourcePlayer1_NewFrame_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 652);
            this.Controls.Add(this.videoSourcePlayer1);
            this.Controls.Add(this.Cb_VideoInput);
            this.Controls.Add(this.Bt_Capture);
            this.Controls.Add(this.Bt_StartCamera);
            this.Controls.Add(this.Pb_Picture);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Pb_Picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox Pb_Picture;
        private System.Windows.Forms.Button Bt_StartCamera;
        private System.Windows.Forms.Button Bt_Capture;
        private System.Windows.Forms.ComboBox Cb_VideoInput;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
    }
}

