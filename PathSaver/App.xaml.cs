using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Windows;
using System.Windows.Forms;
using AdonisUI.Controls;
using PathSaver.Window;
using PathSaver.Properties;
using Tommy;
using Application = System.Windows.Application;

namespace PathSaver;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
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
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        Button_Language();

        ResourceManager rm = new ResourceManager(typeof(PathSaver.Properties.Resources));
        CultureInfo ci = CultureInfo.CreateSpecificCulture(Lang);
        string openText = rm.GetString("Open", ci);
        string settingText = rm.GetString("Setting", ci);
        string exitText = rm.GetString("Exit", ci);

        if (File.Exists("./Data/PathData.toml") == false)
        {
            Directory.CreateDirectory("Data");

            TomlTable toml = new TomlTable
                { ["title"] = "TOML Example"};
            using(StreamWriter writer = File.CreateText("./Data/PathData.toml")) { toml.WriteTo(writer); writer.Flush();}
        }

        else if ( File.Exists("./Data/PathData.toml") ) { Console.WriteLine("Toml File is Exists" );}

        if (File.Exists("Config.toml") == false)
        {
            TomlTable toml = new TomlTable
                { ["Language"] = "Default" };
            using(StreamWriter writer = File.CreateText("Config.toml")) {toml.WriteTo(writer); writer.Flush();}
        }

        NotifyIcon icon = new NotifyIcon();

        icon.Icon = new Icon("./Assets/Image/FileIcon.ico");
        icon.Visible = true;
        icon.DoubleClick += (s, e) => { var active = Current.Windows.OfType<AdonisWindow>().SingleOrDefault(x => x.IsActive);
            if (!Current.Windows.OfType<MainWindow>().Any())
            {
                MainWindow mainwindow = new MainWindow();
                mainwindow.Show();
            }};

        //インスタンス化
        try
        {
           
               
                    var menu = new ContextMenuStrip();
                    //メニュー内容
                    ToolStripMenuItem openMenuItem = new ToolStripMenuItem();
                    openMenuItem.Text = openText;
                    openMenuItem.Click += (a, e) => { if (!Current.Windows.OfType<MainWindow>().Any())
                    {
                        MainWindow mainwindow = new MainWindow();
                        mainwindow.Show();
                    }};

                    ToolStripMenuItem settingMenuItem = new ToolStripMenuItem();
                    settingMenuItem.Text = settingText;
                    settingMenuItem.Click += (b, e) => { if (!Current.Windows.OfType<SettingWindow>().Any())
                    {
                        SettingWindow settingwindow = new SettingWindow();
                        settingwindow.Show();
                    }};

                    ToolStripMenuItem menuItem = new ToolStripMenuItem();
                    menuItem.Text = exitText;
                    menuItem.Click += (s, e) => { Current.Shutdown(); };
                    //メニュー内容追加
                    menu.Items.Add(openMenuItem);
                    menu.Items.Add(settingMenuItem);
                    menu.Items.Add(menuItem);
                    icon.ContextMenuStrip = menu;
                   
            
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }
    }
    