using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using AdonisUI.Controls;
using PathSaver.Properties;

namespace PathSaver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AdonisWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            {
                if (Settings.Default.darkmode)
                { Background = Brushes.DarkGray;}
                else if (Settings.Default.darkmode == false)
                { Background = Brushes.White;}

                Uri uri = new Uri("/Pages/MainPage.xaml", UriKind.Relative);
                frame.Source = uri;
            }
        }

        private void MainWindow1_Closing(object sender, CancelEventArgs e)
        {
            
        }

        private void Exit_BTN_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MainWindow1_Unloaded(object sender, RoutedEventArgs e)
        {
        }

        private void FileViewer_OnDrop(object sender, DragEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FileViewer_OnDragOver(object sender, DragEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
