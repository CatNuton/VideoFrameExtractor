using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using AForge.Video;
using Accord.Video.FFMPEG;
using System.Diagnostics;

namespace VideoFrameExtractor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mov;*.wmv|All Files|*.*";
            openFileDialog.Title = "Select a Video File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbVideoPath.Text = openFileDialog.FileName;
            }
        }

        private void btnExtractFrames_Click(object sender, EventArgs e)
        {
            var videoFilePath = tbVideoPath.Text;
            var framesCategoryPath = tbCategoryFilePath.Text;

            if (string.IsNullOrEmpty(videoFilePath) || !File.Exists(videoFilePath))
            {
                MessageBox.Show("Please select a valid video file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(framesCategoryPath))
            {
                Directory.CreateDirectory(framesCategoryPath);
            }

            using (var video = new VideoFileReader())
            {
                video.Open(videoFilePath);

                for (int i = 0; i < video.FrameCount; i++)
                {
                    var frame = video.ReadVideoFrame(i);
                    if (frame != null)
                    {
                        var frameFileName = Path.Combine(framesCategoryPath, $"frame_{i}.jpg");
                        if (cbDelete.Checked)
                        {
                            if (i > 0 && File.Exists(Path.Combine(framesCategoryPath, $"frame_{i - 1}.jpg")))
                            {
                                var previousFrame = new Bitmap(Path.Combine(framesCategoryPath, $"frame_{i - 1}.jpg"));
                                if (IsDuplicateFrame(frame, previousFrame))
                                {
                                    frame.Dispose();
                                    previousFrame.Dispose();
                                    continue;
                                }
                                previousFrame.Dispose();
                            }
                        }
                        frame.Save(frameFileName, ImageFormat.Jpeg);
                        frame.Dispose();
                    }
                }
            }
            Process.Start("explorer.exe", framesCategoryPath);
            MessageBox.Show("Frames extracted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnSearchCategory_Click(object sender, EventArgs e)
        {
            if (fbdFramesCtegory.ShowDialog() == DialogResult.OK)
            {
                tbCategoryFilePath.Text = fbdFramesCtegory.SelectedPath;
            }
        }

        bool IsDuplicateFrame(Bitmap frame1, Bitmap frame2)
        {
            if (frame2 == null)
                return false;

            if (frame1.Width != frame2.Width || frame1.Height != frame2.Height)
                return false;

            for (int x = 0; x < frame1.Width; x++)
            {
                for (int y = 0; y < frame1.Height; y++)
                {
                    if (frame1.GetPixel(x, y) != frame2.GetPixel(x, y))
                        return false;
                }
            }

            return true;
        }
    }
}