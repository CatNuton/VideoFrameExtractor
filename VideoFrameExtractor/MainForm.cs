using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
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
            openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mov;*.wmv;";
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
                var fc = video.FrameCount;
                for (int i = 0; i < fc; i++)
                {
                    var frame = video.ReadVideoFrame(i);
                    if (frame != null)
                    {
                        var frameFileName = Path.Combine(framesCategoryPath, $"frame_{i}.jpg");
                        frame.Save(frameFileName, ImageFormat.Jpeg);
                        frame.Dispose();
                    }
                    pbProgress.Value = ((i + 1) * 100) / (int)fc;
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

        private void tb_TextChanged(object sender, EventArgs e)
        {
            var isEmpty = !string.IsNullOrWhiteSpace(tbCategoryFilePath.Text) && !string.IsNullOrWhiteSpace(tbVideoPath.Text);
            bool isVideo;
            if (tbVideoPath.Text.Length >= 3)
            {
                isVideo = tbVideoPath.Text.Substring(tbVideoPath.Text.Length - 3) == "mp4" ||
                        tbVideoPath.Text.Substring(tbVideoPath.Text.Length - 3) == "avi" ||
                        tbVideoPath.Text.Substring(tbVideoPath.Text.Length - 3) == "mov" ||
                        tbVideoPath.Text.Substring(tbVideoPath.Text.Length - 3) == "wmv";
            }
            else
            {
                isVideo = false;
            }
            btnExport.Enabled = isVideo && isEmpty && File.Exists(tbVideoPath.Text);
        }
    }
}