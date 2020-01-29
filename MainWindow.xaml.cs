using Emgu.CV;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace FrameExtractor
{
    /// <summary>
    /// This application converts a video file to its video frames
    /// </summary>
    public partial class MainWindow : Window
    {
        // Global Variables
        VideoCapture capturedVideo;                 // Capture Video
        Mat originalFrame;
        double TotalFrames = 0, FrameCounter = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Browse1Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog loadVideoDialog = new OpenFileDialog();
            loadVideoDialog.Filter = "Video files (*.avi, *.mkv, *.mp4) | *.avi; *.mkv; *.mp4";
            loadVideoDialog.ShowDialog();
            if (loadVideoDialog.FileName != "")
            {
                Step1TextBox.Text = loadVideoDialog.FileName;
            }
        }

        private void Browse2Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog chooseDestinationDialog = new OpenFileDialog();
            chooseDestinationDialog.ShowDialog();
            try
            {
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show("Something went wrong!\n" + err.ToString(), "Error!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }

        private void GitHubLinkLabel_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/alitourani");
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Step1TextBox.Text != "" && Step2TextBox.Text != "")
                {
                    capturedVideo = new VideoCapture(Step1TextBox.Text);
                    TotalFrames = Convert.ToDouble(capturedVideo.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount));
                    originalFrame = new Mat();
                    capturedVideo.ImageGrabbed += ProcessVideo;
                }
                else
                {
                    System.Windows.MessageBox.Show("Please choose source and destination directories correctly!", "Error!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }                
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show("Something went wrong!\n" + err.ToString(), "Error!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }

        private void ProcessVideo(object sender, EventArgs e)
        {
            FrameCounter++;
            while (FrameCounter < TotalFrames)
            {
                // Save frames in a directory
            }
        }
     }
}
