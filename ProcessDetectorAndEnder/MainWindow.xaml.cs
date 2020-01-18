using System;
using System.Collections.Generic;
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
using System.Threading;
using VPNDetector;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string content = "NO!";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            this.Dispatcher.Invoke(async () =>
            {
                await VPNasyncTask();
            });
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickevent;
            timer.Start();
        }

        private async Task VPNasyncTask()
        {
            Task.Run(() => CheckForVPN());
            if (content == "Found the VPN!")
            {
                runningLbl.Foreground = Brushes.Red;
            }
            else if (content == "Didn't find VPN. Fap on...")
            {
                runningLbl.Foreground = Brushes.Green;
            }
            //await VPNasyncTask();
        }

        public async Task CheckForVPN()
        {
            ProcessFinder pFndr = new ProcessFinder(processCBox.Text);
            if (pFndr.found) // if we find the vpn.
            {
                content = "Found the VPN!";
                runningLbl.Content = "FOUND";
                runningLbl.Foreground = Brushes.Red;
            }
            else if (!pFndr.found)
            {
                content = "Didn't find VPN. Fap on...";
                runningLbl.Content = "NOT FND";
                runningLbl.Foreground = Brushes.Green;
            }
            //det = new VPNDetection();
        }

        private async void tickevent(object sender, EventArgs e)
        {
            await CheckForVPN();
        }

        private void optionsClick(object sender, RoutedEventArgs e)
        {
            // q is down or expand, p is oppositve.

            if (optionsBtn.Content.ToString() == "q")
            {
                optionsBtn.Content = "p";

            }
            else if (optionsBtn.Content.ToString() == "p")
            {
                optionsBtn.Content = "q";

            }
        }

        private void processSelectBox_Changed(object sender, SelectionChangedEventArgs e)
        {
            ProcessFinder pFndr = new ProcessFinder(processCBox.Text);
        }

        private void processComboBoxClick(object sender, MouseButtonEventArgs e)
        {
            processCBox.Items.Add("test");
        }

        private void processCBox_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void processCBox_DropDownOpened(object sender, EventArgs e)
        {
            ProcessFinder procList = new ProcessFinder(processCBox.Text);
            string[] procNames = procList.GetProcList();
            foreach (string procName in procNames)
            {
                processCBox.Items.Add(procName);
            }
        }
    }
}
