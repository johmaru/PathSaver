using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Windows;
using System.Windows.Media;
using AdonisUI.Controls;
using PathSaver.Properties;
using Tommy;

namespace PathSaver.Window;

/// <summary>
/// SettingWindow.xaml の相互作用ロジック
/// </summary>
public partial class SettingWindow : AdonisWindow
{
    private static string Lang;
        
    private static void Button_Language()
    {
        String langText;
        using (StreamReader reader = File.OpenText("Config.toml"))
        {
            TomlTable table = TOML.Parse(reader);

            langText = table["Language"];
        }
        try
        {
            if (langText == "Default")
            {
                Lang = "en-US";
            }
            else if (langText == "en-US")
            {
                Lang = "en-US";
            }
            else if (langText == "ja-JP")
            {
                Lang = "ja-JP";
            }
            else
            {
                Console.WriteLine("Unknown Language");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public SettingWindow()
    {
        InitializeComponent();
        
        Button_Language();
        
        ResourceManager rm = new ResourceManager(typeof(Resources));
        CultureInfo ci = CultureInfo.CreateSpecificCulture(Lang);
        string Back = rm.GetString("Back", ci);
        string Dark = rm.GetString("DarkMode", ci);
        string ONOFF = rm.GetString("ONOFF", ci);
        string gen = rm.GetString("General", ci);
        string key = rm.GetString("Key", ci);
        string file = rm.GetString("File", ci);

        Exit_BTN.Content = Back;
        Dark_Label.Content = Dark;
        DarkModeBTN.Content = ONOFF;
        this.gen.Header = gen;
        this.key.Header = key;
        this.file.Header = file;
            
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