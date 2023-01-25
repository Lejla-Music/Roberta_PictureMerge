using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
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

namespace MailClient {
    /// <summary>
    /// Program by Moritz Bernhofer
    /// 2BHIF
    /// 2023
    /// dc: Moritz#6043
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Email_TextBox_KeyPress(object sender, KeyEventArgs e) {
            if (EmailBox.Text == "") {
                EmailBox.Text = "Enter Email Here...";
            }
            if (e.Key.ToString() != null) {
                EmailBox.Text = $"{e.Key.ToString().ToLowerInvariant()}";
            }

            if (e.Key != Key.Enter) {
                return;
            }
        }

        //Enter has been pressed
    }
}

