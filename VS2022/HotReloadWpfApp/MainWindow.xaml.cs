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
using System.Windows.Threading;

namespace HotReloadWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStartCounter_Click(object sender, RoutedEventArgs e)
        {
            SetTimerConfig();
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            lblValue.Content = DateTime.Now.ToLongTimeString();
        }

        private void btnStopCounter_Click(object sender, RoutedEventArgs e)
        {
            lblValue.Content = "Timer Stopped";

            timer.Stop();
        }

        private void SetTimerConfig()
        {
            lblValue.Content = "Timer Stopped";

            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += timer_Tick;
            timer.Start();
        }
    }
}
