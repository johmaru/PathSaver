﻿using System;
using System.Collections.Generic;
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
            if (Settings.Default.darkmode == true)
            {
                this.Background = Brushes.DarkGray;


            }
            else if (Settings.Default.darkmode == false)
            {
                this.Background = Brushes.White;
            }
            Uri uri = new Uri("/Pages/MainPage.xaml", UriKind.Relative);
            frame.Source = uri;
        }

        private void MainWindow1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            return;
        }

        private void Exit_BTN_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
