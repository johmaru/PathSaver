using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using AdonisUI.Controls;
using PathSaver.Pages;
using PathSaver.Properties;
using Application = System.Windows.Application;
using PathSaver.Window;
using Tommy;

namespace PathSaver
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var windowInt = Settings.Default.WindowInt;

            windowInt = 0;

            if (File.Exists("./Data/PathData.toml") == false)
            {
                Directory.CreateDirectory("Data");

                TomlTable toml = new TomlTable
                {
                    ["title"] = "TOML Example"
                };
                using(StreamWriter writer = File.CreateText("./Data/PathData.toml"))
                {
                    toml.WriteTo(writer);
                    writer.Flush();
                }
            }
            else if (File.Exists("./Data/PathData.toml") != false)
            {
                Console.WriteLine("Toml File is Exists");
            }

            //アイコン値指定

            NotifyIcon icon = new NotifyIcon();

            icon.Icon = new System.Drawing.Icon("./Assets/Image/FileIcon.ico");
            icon.Visible = true;
            icon.DoubleClick += (s, e) =>
            {
                var active = Application.Current.Windows.OfType<AdonisWindow>().SingleOrDefault(x => x.IsActive);

                if (!Application.Current.Windows.OfType<MainWindow>().Any())
                {
                    MainWindow mainwindow = new MainWindow();

                    mainwindow.Show();
                }
                

            };

            //インスタンス化
            var menu = new ContextMenuStrip();

            //メニュー内容
            
            ToolStripMenuItem openMenuItem = new ToolStripMenuItem();
            openMenuItem.Text = "開く";
            openMenuItem.Click += (a, e) =>
            {

                if (!Application.Current.Windows.OfType<MainWindow>().Any())
                {
                    MainWindow mainwindow = new MainWindow();

                    mainwindow.Show();
                }
            };

            ToolStripMenuItem settingMenuItem = new ToolStripMenuItem();
            settingMenuItem.Text = "&設定";
            settingMenuItem.Click += (b, e) =>
            {
                if (!Application.Current.Windows.OfType<SettingWindow>().Any())
                {
                    SettingWindow settingwindow = new SettingWindow();

                    settingwindow.Show();
                }
            };

            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = "&終了";
            menuItem.Click += (s, e) =>
            {
               Application.Current.Shutdown();
            };


            //メニュー内容追加

            menu.Items.Add(openMenuItem);
            menu.Items.Add(settingMenuItem);
            menu.Items.Add(menuItem);
            icon.ContextMenuStrip = menu;
        }
    }
}
