using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Application = System.Windows.Application;

namespace PathSaver
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //アイコン値指定

            NotifyIcon icon = new NotifyIcon();

            icon.Icon = new System.Drawing.Icon("./Assets/Image/FileIcon.ico");
            icon.Visible = true;

            //インスタンス化
            var menu = new ContextMenuStrip();

            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = "&終了";
            menuItem.Click += (s, e) =>
            {
               Application.Current.Shutdown();
            };
            menu.Items.Add(menuItem);
            icon.ContextMenuStrip = menu;
        }
    }
}
