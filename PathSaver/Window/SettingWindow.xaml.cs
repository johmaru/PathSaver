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
using System.Windows.Shapes;
using AdonisUI.Controls;
using PathSaver.Pages;
using PathSaver.Properties;
using MessageBox = AdonisUI.Controls.MessageBox;

namespace PathSaver.Window
{
    /// <summary>
    /// SettingWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SettingWindow : AdonisWindow
    {
        public SettingWindow()
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
        }

        private void AdonisWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void Exit_BTN_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DarkModeBTN_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void DarkMOdeBTN_Click(object sender, RoutedEventArgs e)
        {
        }

        private void DarkModeBTN_Loaded(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.darkmode == true)
            {
                DarkModeBTN.IsChecked = true;
            }
            else
            {
                DarkModeBTN.IsChecked = false;
            }
        }

        private void DarkModeBTN_OnUnchecked(object sender, RoutedEventArgs e)
        {
            if (DarkModeBTN.IsChecked == false)
            {
                Settings.Default.darkmode = false;
                Settings.Default.Save();
            }
        }

        
    }
}
