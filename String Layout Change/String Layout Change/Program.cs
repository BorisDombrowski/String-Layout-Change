﻿using String_Layout_Change.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace String_Layout_Change
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Context());            
        }
    }

    public class Context : ApplicationContext
    {
        private NotifyIcon trayIcon;

        public Context()
        {
            trayIcon = new NotifyIcon()
            {
                Icon = Resources.AppIcon,
                ContextMenu = new ContextMenu(new MenuItem[] 
                {
                    new MenuItem("Settings", OpenSettings),
                    new MenuItem("Exit", Exit)                    
                }),
                Visible = true
            };

            if (File.Exists(Resources.settingsPath))
            {
                var file = File.ReadAllText(Resources.settingsPath);
                LayoutChanger.SetCurrentLayout(file);
            }
            else
            {
                MessageBox.Show("Unable to find settings file!");
            }
        }

        void OpenSettings(object sender, EventArgs e)
        {
            SettingsForm.Instance.ShowDialog();
        }

        void Exit(object sender, EventArgs e)
        {            
            trayIcon.Visible = false;
            Application.Exit();
        }
    }
}
