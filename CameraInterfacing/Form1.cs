using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace CameraInterfacing
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoDevice;
        private VideoCapabilities[] snapshotCapabilities;
        private ArrayList listCamera = new ArrayList();
        public string pathFolder = Application.StartupPath + @"\ImageCapture\";
        private Stopwatch stopWatch = null;
        private static bool needSnapshot = false;

        private static string _usbcamera;
        public string usbcamera
        {
            get { return _usbcamera; }
            set { _usbcamera = value; }
        }

        public Form1()
        {
            InitializeComponent();
            GetListCameraUSB();
        }

        private void GetListCameraUSB()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count != 0)
            {
                foreach(FilterInfo device in videoDevices)
                {
                    Cb_VideoInput.Items.Add(device.Name);
                }
            }
            else
            {
                Cb_VideoInput.Items.Add("No Direct Show devices found");
            }

            Cb_VideoInput.SelectedIndex = 0;
        }

        private void Bt_StartCamera_Click(object sender, EventArgs e)
        {
            StartCamera();
        }

        private void StartCamera()
        {
            try
            {
                usbcamera = Cb_VideoInput.SelectedIndex.ToString();
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count != 0)
                {
                    // add all devices to combo
                    foreach (FilterInfo device in videoDevices)
                    {
                        listCamera.Add(device.Name);
                    }
                }
                else
                {
                    MessageBox.Show("Camera devices found");
                }

                videoDevice = new VideoCaptureDevice(videoDevices[Convert.ToInt32(usbcamera)].MonikerString);
                snapshotCapabilities = videoDevice.SnapshotCapabilities;
                if (snapshotCapabilities.Length == 0)
                {
                    MessageBox.Show("Camera Capture Not supported");
                }
                OpenVideoSource(videoDevice);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        //Delegate Untuk Capture, insert database, update ke grid 
        public delegate void CaptureSnapshotManifast(Bitmap image);
        public void UpdateCaptureSnapshotManifast(Bitmap image)
        {
            try
            {
                needSnapshot = false;
                Pb_Picture.Image = image;
                Pb_Picture.Update();

                string namaImage = "sampleImage";
                string nameCapture = namaImage + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bmp";
                if (Directory.Exists(pathFolder))
                {
                    Pb_Picture.Image.Save(pathFolder + nameCapture, ImageFormat.Bmp);
                }
                else
                {
                    Directory.CreateDirectory(pathFolder);
                    Pb_Picture.Image.Save(pathFolder + nameCapture, ImageFormat.Bmp);
                }
            }
            catch { }
        }
        public void OpenVideoSource(IVideoSource source)
        {
            try
            {
                // set busy cursor
                this.Cursor = Cursors.WaitCursor;
                // stop current video source
                CloseCurrentVideoSource();
                // start new video source
                videoSourcePlayer1.VideoSource = source;
                videoSourcePlayer1.Start();
                // reset stop watch
                stopWatch = null;
                this.Cursor = Cursors.Default;
            }
            catch { }
        }

        private void Bt_Capture_Click(object sender, EventArgs e)
        {
            needSnapshot = true;
        }
        private void VideoSourcePlayer1_NewFrame_1(object sender, ref Bitmap image)
        {
            try
            {
                DateTime now = DateTime.Now;
                Graphics g = Graphics.FromImage(image);
                // paint current time
                SolidBrush brush = new SolidBrush(Color.Red);
                g.DrawString(now.ToString(), this.Font, brush, new PointF(5, 5));
                brush.Dispose();
                if (needSnapshot)
                {
                    this.Invoke(new CaptureSnapshotManifast(UpdateCaptureSnapshotManifast), image);
                }
                g.Dispose();
            }
            catch
            { }
        }
        public void CloseCurrentVideoSource()
        {
            try
            {
                if (videoSourcePlayer1.VideoSource != null)
                {
                    videoSourcePlayer1.SignalToStop();
                    // wait ~ 3 seconds
                    for (int i = 0; i < 30; i++)
                    {
                        if (!videoSourcePlayer1.IsRunning)
                            break;
                        System.Threading.Thread.Sleep(100);
                    }
                    if (videoSourcePlayer1.IsRunning)
                    {
                        videoSourcePlayer1.Stop();
                    }
                    videoSourcePlayer1.VideoSource = null;
                }
            }
            catch { }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitCamera();
            Thread.Sleep(1000);
        }

        private void ExitCamera()
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1 = null;
        }
    }
}
