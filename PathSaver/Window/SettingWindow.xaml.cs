using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using AdonisUI.Controls;
using PathSaver.Properties;

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
            
            WindowTheme();
        }

        private void WindowTheme()
        {
            if ( Settings.Default.darkmode == false ) { Background = Brushes.White; DarkModeBTN.IsChecked = false; SettingsTab.Background = Brushes.White; }
            else { Background = Brushes.DimGray; DarkModeBTN.IsChecked = true; SettingsTab.Background = Brushes.DimGray; }
        }

        private void AdonisWindow_Closing(object sender, CancelEventArgs e)
        {

        }

        private void Exit_BTN_OnClick(object sender, RoutedEventArgs e)
        { 
            Close();
        }

        private void DarkModeBTN_Checked(object sender, RoutedEventArgs e)
        {
            if (DarkModeBTN.IsChecked == true) { Settings.Default.darkmode = true; Settings.Default.Save(); WindowTheme(); }
        }

        private void DarkMOdeBTN_Click(object sender, RoutedEventArgs e)
        {
        }

        private void DarkModeBTN_OnUnchecked(object sender, RoutedEventArgs e)
        {
            if (DarkModeBTN.IsChecked == false) { Settings.Default.darkmode = false; Settings.Default.Save(); WindowTheme(); }
        }
    }
}
