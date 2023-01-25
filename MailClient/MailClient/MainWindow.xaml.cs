using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MailClient {
    /// <summary>
    /// Program by Moritz Bernhofer
    /// 2BHIF
    /// 2023
    /// dc: Moritz#6043
    /// </summary>
    public partial class MainWindow : Window {
        public bool EmailLock { get; set; } = false;
        private String path = "";
        private List<string> filepaths = new List<string>();
        private String currentPicturePath = String.Empty;
        private DispatcherTimer LookForPictureTimer => new();

        public MainWindow() {
            InitializeComponent();
            LookForPictureTimer.Interval = TimeSpan.FromSeconds(1);
            LookForPictureTimer.Tick += LockForPicture;
        }

        private void LockForPicture(object? sender, EventArgs args) {
            string[] files = Directory.GetFiles(path);
            foreach(string filePath in files) {
                if(!filepaths.Contains(filePath)) {
                    currentPicturePath= filePath;
                    filepaths.Add(filePath);
                }
            }
                
        }

        private void Email_TextBox_KeyPress(object sender, KeyEventArgs e) {
            if (e.Key != Key.Enter) {
                return;
            }
            if(!EmailBox.Text.Contains("@") || EmailBox.Text == String.Empty) {
                Console.Text += "\n" + "no Email recognised";
                return;
            }
            if (EmailLock) {
                Console.Text += "\n" + "wating for Email To Send";
                return;
            }
            Console.Text += "\n" + "trying to Send...";
            SendMail(EmailBox.Text);
            EmailLock = true;
            EmailBox.Text = String.Empty;
        }

        private void SendMail(string text) {
            
        }

        //Enter has been pressed
    }
}

