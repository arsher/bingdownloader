using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using DSerfozo.BingBackground.App.ViewModel;

namespace DSerfozo.BingBackground.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool closeRequested;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            if (!closeRequested)
            {
                e.Cancel = true;
                Visibility = Visibility.Collapsed;
            }
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            DoClose();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            DoClose();
        }

        private void DoClose()
        {
            closeRequested = true;
            Close();
        }
    }
}